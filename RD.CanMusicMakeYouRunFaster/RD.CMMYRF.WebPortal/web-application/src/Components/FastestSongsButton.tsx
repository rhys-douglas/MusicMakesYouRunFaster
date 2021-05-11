import React from 'react';
import Axios, { AxiosError, AxiosResponse } from "axios";

interface IFastestSongsButtonProps
{
    fastestStravaActivity: any,
    fastestFitBitActivity: any,
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

    handleClick = () =>
    {
        try 
        {
            console.log(this.props.fastestStravaActivity);
            console.log(this.props.fastestFitBitActivity);
            this.findFastestDate(this.props.fastestStravaActivity, this.props.fastestFitBitActivity)
            .then(fastestDate => {
                console.log("Fastest Date: " + fastestDate);
                if (fastestDate === this.props.fastestStravaActivity.start_date)
                {
                    
                }
                else if (fastestDate === this.props.fastestFitBitActivity.start_date)
                {
                    
                }
                else {
                    console.log("error.")
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