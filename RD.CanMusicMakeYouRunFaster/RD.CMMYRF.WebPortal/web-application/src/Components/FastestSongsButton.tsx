import React from 'react';
import Axios, { AxiosError, AxiosResponse } from "axios";
import LastFMSongsTable from './LastFMSongsTable';

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
    lastFMSongs: any
}

export class FastestSongsButton extends React.Component<IFastestSongsButtonProps,IFastestSongsButtonState>
{
    constructor(props : any) 
    {
        super(props)
        this.state =
        {
            spotifySongs: [],
            lastFMSongs: []
        }
    }

    spotifyTableCallback = () =>
    {

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

    getLastFMTracks = async function(lastFMUserName: string, after: string, duration: number)
    {
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

    printState = () =>
    {
        console.log(this.props.fastestFitBitActivity)
        console.log(this.props.fastestStravaActivity)
        console.log(this.props.lastFMUserName)
        console.log(this.props.spotifyAccessToken)
        console.log(this.state.spotifySongs)
        console.log(this.state.lastFMSongs)
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
                // Get music
                if (this.props.spotifyAccessToken !== null )
                {
                    this.getSpotifyTracks(this.props.spotifyAccessToken.AccessToken,fastestDateResponse,activityDuration)
                    .then(spotifyTracks => {
                        var songsJson: any[] = Array.of(spotifyTracks.items);
                        this.setState({spotifySongs:songsJson[0]});
                        console.log(this.state.spotifySongs);
                        Promise.resolve(spotifyTracks);
                    });
                }

                if (this.props.lastFMUserName !== null )
                {
                    this.getLastFMTracks(this.props.lastFMUserName,fastestDateResponse,activityDuration)
                    .then(lastFMTracks => {
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
                        console.log(this.state.lastFMSongs);
                        Promise.resolve(lastFMTracks);
                    });
                }

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
                <button onClick={this.handleClick}> Click here to find out what songs made you run faster!</button>
                <button onClick = {this.printState}> Log state.</button>
                <LastFMSongsTable lastFMSongData={this.state.lastFMSongs}/>
            </div>)
    }
}                