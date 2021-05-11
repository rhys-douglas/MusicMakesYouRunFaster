import React from 'react';
import Axios, { AxiosError, AxiosResponse } from "axios";

interface IFastestSongsButtonProps
{
    fastestStravaActivity: JSON,
    fastestFitBitActivity: JSON,
    spotifyAccessToken: JSON,
    lastFMUserName: string
}

interface IFastestSongsButtonState
{
    spotifySongs: JSON,
    lastFMSongs: JSON
}

export class FastestSongsButton extends React.Component<IFastestSongsButtonProps,IFastestSongsButtonState>
{

    findFastestActivity = async function(fastestStravaActivity: any, fastestFitBitActivity: any)
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

    getSpotifySongs = async function(fastestDate : Date, spotifyAccessToken: JSON)
    {
        var getSpotifyTokenPromise = await Axios.get("http://localhost:8080/CMMYRF/getSpotifyRecentlyPlayed?access_token="+spotifyAccessToken + "&after=" + fastestDate.toISOString())
                .then((response: AxiosResponse) => Promise.resolve(response.data))
                .catch((error: AxiosError) => Promise.reject(error));
    }

    getFastestDate = async function(fastestStravaActivity: any, fastestFitBitActivity: any, fastestDate : Date, spotifyAccessToken: JSON)
    {
        try 
        {
            var stravaDate = new Date(fastestStravaActivity.start_date);
            var fitBitDate = new Date(fastestFitBitActivity.startTime);
            console.log("STRAVA: " + stravaDate);
            console.log("FITBIT: " + fitBitDate);
            console.log("FASTEST: " + fastestDate);

            if (fastestDate.toString() === stravaDate.toString())
            {
                console.log("Its a strava date!");
                // make music api calls
            }
            else if (fastestDate.toString() === fitBitDate.toString())
            {
                await this.getSpotifySongs(fastestDate,spotifyAccessToken)
                .then(spotifySongs => {
                    console.log(spotifySongs);

                });
                // make music api calls
            }
        }

        catch (exception)
        {
            console.log(exception);
        }
    }

    handleClick = () =>
    {
        try 
        {
            console.log(this.props.fastestStravaActivity);
            console.log(this.props.fastestFitBitActivity);
            this.findFastestActivity(this.props.fastestStravaActivity, this.props.fastestFitBitActivity)
            .then(fastestDate => {
                console.log("Fastest Date: " + fastestDate);
                this.getRunningFasterSongs(
                    this.props.fastestStravaActivity, 
                    this.props.fastestFitBitActivity, 
                    new Date(fastestDate),
                    this.props.spotifyAccessToken)
                .then(songs => {
                    
                });
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