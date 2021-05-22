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
    
    findFastestDate = async function(fastestStravaActivity: any, fastestFitBitActivity: any)
    {
        try
        {
            var stravaDateAsISO = new Date(fastestStravaActivity.start_date).toISOString();
            var fitBitDateAsISO = new Date(fastestFitBitActivity.startTime).toISOString();
            var getFastestActivityPromise = await Axios.get("http://localhost:8080/CMMYRFI/findFastestActivity?stravaSpeed=" + fastestStravaActivity.average_speed + 
            "&stravaStartTime=" + stravaDateAsISO + "&fitBitSpeed=" + fastestFitBitActivity.speed + "&fitBitDateTime=" + fitBitDateAsISO)
            .then((response: AxiosResponse) => Promise.resolve(response.data))
                  .catch((error: AxiosError) => Promise.reject(error));
            return getFastestActivityPromise;
        }
        catch (exception)
        {
            console.log(exception)
        }
    }

    getSpotifyTracks = async function(spotifyAccessToken: string, after: string, duration: number)
    {
        if(!spotifyAccessToken){
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
        var url = "http://localhost:8080/CMMYRF/getLastFMRecentlyPlayed?"
        if (!lastFMUserName){
            return null;
        }
        url+= "user_name=" + lastFMUserName + "&";
        if(after)
        {
            url+= "after=" + after + "&";
        }
        if (duration)
        {
            url+= "duration=" + duration
        }
        try 
        {
            var getLastFMTracksPromise = await Axios.get(url)
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
            this.findFastestDate(this.props.fastestStravaActivity, this.props.fastestFitBitActivity)
            .then(fastestDateResponse => {
                var fastestDateAsDate = new Date(fastestDateResponse);
                var stravaDate = new Date(this.props.fastestStravaActivity.start_date);
                var fitbitDate = new Date(this.props.fastestFitBitActivity.startTime);
                var activityDuration;
                if (fastestDateAsDate.toString() === stravaDate.toString())
                {
                    // Strava activity = duration in seconds.
                    console.log("Strava activity");
                    activityDuration = this.props.fastestStravaActivity.elapsed_time
                    
                }
                else if (fastestDateAsDate.toString() === fitbitDate.toString())
                {
                    // Fitbit activity = duration in MS.
                    console.log("FitBit Activity");
                    activityDuration = this.props.fastestFitBitActivity.duration / 100;
                }
                else 
                {
                    Promise.resolve("No Data - Dates not matching")
                }

                console.log(fastestDateResponse);
                console.log(activityDuration);

                if (fastestDateResponse === null && activityDuration === null){
                    console.log("Missing data.")
                    Promise.resolve("Missing data.");
                }
                if (this.props.spotifyAccessToken !== null )
                {
                    // Need to add activity validation.
                    this.getSpotifyTracks(this.props.spotifyAccessToken.AccessToken,fastestDateResponse,activityDuration)
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
                            console.log(exception);
                        }
                    });
                }

                if (this.props.lastFMUserName !== null )
                {
                    // Need to add activity validation.
                    this.getLastFMTracks(this.props.lastFMUserName,fastestDateResponse,activityDuration)
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