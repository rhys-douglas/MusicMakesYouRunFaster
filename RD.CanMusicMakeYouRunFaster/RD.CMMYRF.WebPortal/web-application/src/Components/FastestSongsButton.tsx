import React from 'react';
import Axios, { AxiosError, AxiosResponse } from "axios";
import LastFMSongsTable from './LastFMSongsTable';
import SpotifySongsTable from './SpotifySongsTable';
import '../Resources/SongsMakeMeRunFasterStyles.css'


type Nullable<T> = T | null;

interface IFastestSongsButtonProps
{
    fastestStravaActivity: any,
    fastestFitBitActivity: any,
    spotifyAccessToken: any,
    lastFMUserName: string
}

interface IFastestSongsButtonState
{
    spotifySongs: any,
    lastFMSongs: any,
    userMessage: string
}

export class FastestSongsButton extends React.Component<IFastestSongsButtonProps,IFastestSongsButtonState>
{
    constructor(props : any) 
    {
        super(props)
        this.state =
        {
            spotifySongs: [],
            lastFMSongs: [],
            userMessage : ""
        }
    }
    
    findFastestDate = async function(fastestStravaActivity: Nullable<any>=null, fastestFitBitActivity: Nullable<any>=null)
    {
        try
        {
            var url = "";
            if (Object.keys(fastestStravaActivity).length === 0 && Object.keys(fastestFitBitActivity).length > 0)
            {
                var fitbitDate = new Date(fastestFitBitActivity.startTime).toISOString();
                url = "http://localhost:8080/CMMYRFI/findFastestActivity?stravaSpeed=0&stravaStartTime=1980-05-31T13:48:04Z" + "&fitBitSpeed=" + fastestFitBitActivity.speed + "&fitBitDateTime=" + fitbitDate
            }
            else if (Object.keys(fastestStravaActivity).length > 0 && Object.keys(fastestFitBitActivity).length === 0)
            {
                var stravaDate = new Date(fastestStravaActivity.start_date).toISOString();
                url = "http://localhost:8080/CMMYRFI/findFastestActivity?stravaSpeed=" + fastestStravaActivity.average_speed + 
                "&stravaStartTime=" + stravaDate + "&fitBitSpeed=0&fitBitDateTime=1980-05-31T13:48:04Z"
            }
            else if(Object.keys(fastestStravaActivity).length === 0 && Object.keys(fastestFitBitActivity).length === 0)
            {
                return null;
            }
            else 
            {
                var fitBitDateAsISO = new Date(fastestFitBitActivity.startTime).toISOString();
                var stravaDateAsISO = new Date(fastestStravaActivity.start_date).toISOString();
                url = "http://localhost:8080/CMMYRFI/findFastestActivity?stravaSpeed=" + fastestStravaActivity.average_speed + 
                "&stravaStartTime=" + stravaDateAsISO + "&fitBitSpeed=" + fastestFitBitActivity.speed + "&fitBitDateTime=" + fitBitDateAsISO
            }
            var getFastestActivityPromise = await Axios.get(url)
            .then((response: AxiosResponse) => Promise.resolve(response.data))
                  .catch((error: AxiosError) => Promise.reject(error));
            return getFastestActivityPromise;
        }
        catch (exception)
        {
            console.log(exception)
        }
    }

    getSpotifyTracks = async function(spotifyAccessToken: Nullable<string>=null, after: Nullable<string>=null, duration: Nullable<number>=null)
    {
        if(!spotifyAccessToken || !after || !duration) 
        {
            return null;
        }
        try 
        {
            var getSpotifyTracksPromise = await Axios.get("http://localhost:8080/CMMYRF/getSpotifyRecentlyPlayed?access_token=" 
            + spotifyAccessToken + "&after=" + after + "&duration=" + duration)
            .then((response: AxiosResponse) => Promise.resolve(response.data))
                  .catch((error: AxiosError) => Promise.reject(error));
            return getSpotifyTracksPromise;
        }
        catch (exception)
        {
            console.log(exception)
        }
    }

    getLastFMTracks = async function(lastFMUserName: Nullable<string>=null, after: Nullable<string>=null, duration: Nullable<number>=null)
    {
        if (!lastFMUserName || !after || !duration)
        {
            return null;
        }
        try 
        {
            var getLastFMTracksPromise = await Axios.get("http://localhost:8080/CMMYRF/getLastFMRecentlyPlayed?user_name="
            + lastFMUserName + "&after=" + after + "&duration=" + duration)
            .then((response: AxiosResponse) => Promise.resolve(response.data))
                  .catch((error: AxiosError) => Promise.reject(error));
            return getLastFMTracksPromise;
        }
        catch (exception)
        {
            console.log(exception)
        }
    }

    handleClick = () =>
    {
        try 
        {
            if (Object.keys(this.props.fastestFitBitActivity).length === 0 && Object.keys(this.props.fastestStravaActivity).length === 0)
            {
                this.setState({userMessage:"No activities to use!"});
                return;
            }
            if (this.props.lastFMUserName === "" && Object.keys(this.props.spotifyAccessToken).length === 0)
            {
                this.setState({userMessage:"No music providers to use!"})
                return;
            }
            this.findFastestDate(this.props.fastestStravaActivity, this.props.fastestFitBitActivity)
            .then(fastestDateResponse => {
                if (!fastestDateResponse){
                    this.setState({userMessage:"No Songs Found"})
                    return;
                }
                var fastestDateAsDate = new Date(fastestDateResponse);
                var stravaDate = new Date(this.props.fastestStravaActivity.start_date);
                var fitbitDate = new Date(this.props.fastestFitBitActivity.startTime);
                var activityDuration;
                if (fastestDateAsDate.toString() === stravaDate.toString())
                {
                    // Strava activity = duration in seconds.
                    activityDuration = this.props.fastestStravaActivity.elapsed_time
                    
                }
                else if (fastestDateAsDate.toString() === fitbitDate.toString())
                {
                    // Fitbit activity = duration in MS.
                    activityDuration = this.props.fastestFitBitActivity.duration / 100;
                }
                else 
                {
                    Promise.resolve("No Data - Dates not matching")
                }

                if (fastestDateResponse === null && activityDuration === null){
                    console.log("Missing data.")
                    Promise.resolve("Missing data.");
                }
                if (this.props.spotifyAccessToken !== null )
                {
                    // Need to add activity validation.
                    this.getSpotifyTracks(this.props.spotifyAccessToken.AccessToken,fastestDateAsDate.toISOString(),activityDuration)
                    .then(spotifyTracks => {
                        try
                        {
                            spotifyTracks.items.map((track: any) =>{
                                delete track.playedAt;
                                delete track.context;
                                track["name"] = track.track.name;
                                track["image"] = "https://developer.spotify.com/assets/branding-guidelines/icon1@2x.png"
                                track["artist"] = track.track.artists[0].name;
                                track["artistURL"] = track.track.artists[0].externalUrls.spotify;
                                track["url"] = track.track.externalUrls.spotify;
                                delete track.track;
                                return track;
                            });
                            var songsJson: any[] = Array.of(spotifyTracks.items);
                            this.setState({spotifySongs:songsJson[0]});
                            Promise.resolve(spotifyTracks);
                        }
                        catch(exception)
                        {
                            this.setState({userMessage:"No Spotify songs found."})
                            console.log(exception);
                        }
                    });
                }

                if (this.props.lastFMUserName !== null )
                {
                    // Need to add activity validation.
                    this.getLastFMTracks(this.props.lastFMUserName,fastestDateAsDate.toISOString(),activityDuration)
                    .then(lastFMTracks => {
                        try 
                        {
                            lastFMTracks.map((track: any) => 
                            {
                                delete track.id;
                                delete track.rank;
                                delete track.duration;
                                delete track.mbid;
                                delete track.artistMbid;
                                delete track.isLoved; 
                                delete track.topTags;
                                delete track.listenerCount;
                                delete track.isNowPlaying;
                                delete track.userPlayCount;
                                delete track.timePlayed;
                                delete track.playCount;
                                delete track.artistImages;
                                track.images = track.images[2];
                                return track;
                            });
                            var songsJson: any[] = Array.of(lastFMTracks);
                            this.setState({lastFMSongs: songsJson[0]});
                            Promise.resolve(lastFMTracks);
                        }
                        catch(exception)
                        {
                            this.setState({userMessage:"No Last.FM songs found."})
                            console.log(exception);
                        }
                    });
                }
                this.setState({userMessage: "Songs that make you run faster"})
                Promise.resolve(fastestDateResponse);
            });
        }
        catch (exception)
        {
            console.log(exception);
        }
    }

    render()
    {
        return(
            <div>
                <button onClick={this.handleClick} className="RunFasterButton"> What songs make me run faster? </button>
                <h2>{this.state.userMessage}</h2>
                <LastFMSongsTable lastFMSongData={this.state.lastFMSongs}/>
                <SpotifySongsTable spotifySongsData={this.state.spotifySongs}/>
            </div>)
    }
}                