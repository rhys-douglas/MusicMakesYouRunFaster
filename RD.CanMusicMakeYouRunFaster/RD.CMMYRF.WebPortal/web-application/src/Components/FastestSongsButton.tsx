import React from 'react';
import Axios, { AxiosError, AxiosResponse } from "axios";

interface IFastestSongsButtonProps
{
    fastestStravaActivity: any,
    fastestFitBitActivity: any,
    spotifyAccessToken: any,
    lastFMUserName: string
}

interface IFastestSongsButtonState
{
    spotifySongs: JSON,
    lastFMSongs: JSON
}

export class FastestSongsButton extends React.Component<IFastestSongsButtonProps,IFastestSongsButtonState>
{

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

    getSpotifyTracks = async function(spotifyAccessToken: string, after: string, duration: number){
        try 
        {
            var getFastestActivityPromise = await Axios.get("http://localhost:8080/CMMYRF/getSpotifyRecentlyPlayed?access_token=" 
            + spotifyAccessToken + "&after=" + after + "&duration=")
            .then((response: AxiosResponse) => Promise.resolve(response.data))
                  .catch((error: AxiosError) => Promise.reject(error));
            return getFastestActivityPromise;
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
            console.log(this.props.fastestStravaActivity);
            console.log(this.props.fastestFitBitActivity);
            this.findFastestDate(this.props.fastestStravaActivity, this.props.fastestFitBitActivity)
            .then(fastestDateResponse => {
                var fastestDateAsDate = new Date(fastestDateResponse);
                var stravaDate = new Date(this.props.fastestStravaActivity.start_date);
                var fitbitDate = new Date(this.props.fastestFitBitActivity.startTime);
                console.log(fastestDateAsDate);
                console.log(stravaDate);
                console.log(fitbitDate);
                if (fastestDateAsDate.toString() === stravaDate.toString())
                {
                    console.log("Strava activity");
                    // Strava activity = duration in seconds.
                    this.getSpotifyTracks(this.props.spotifyAccessToken.AccessToken, fastestDateResponse, this.props.fastestStravaActivity.elapsed_time)
                    .then(spotifyTracks => {
                        console.log(spotifyTracks);
                    });
                    
                }
                else if (fastestDateAsDate.toString() === fitbitDate.toString())
                {
                    console.log("FitBit Activity");
                    console.log(this.props.spotifyAccessToken);
                    // Fitbit activity = duration in MS.
                    var end = this.props.fastestFitBitActivity.duration / 100;
                    this.getSpotifyTracks(this.props.spotifyAccessToken.AccessToken,fastestDateResponse,end)
                    .then(spotifyTracks => {
                        this.setState({spotifySongs:spotifyTracks.items})
                        console.log(spotifyTracks);
                    });
                }
                else {
                    console.log("Dates not matching.")
                }
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
            </div>)
    }
}