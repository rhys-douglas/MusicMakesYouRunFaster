import React from 'react';
import Axios, { AxiosError, AxiosResponse } from "axios";

export class StravaButton extends React.Component
{
    getStravaAuthToken = async function()
    {
        try
        {
            var getStravaAuthTokenPromise = await Axios.get("http://localhost:8080/CMMYRF/getStravaAuthToken")
            .then((response: AxiosResponse) => Promise.resolve(response.data))
                  .catch((error: AxiosError) => Promise.reject(error));
            return getStravaAuthTokenPromise;
          }
          catch (exception)
          {
            console.log(exception);
          }
    }

    getStravaHistory = async function()
    {
        try 
        {
            var getStravaHistoryPromise = await Axios.get("http://localhost:8080/CMMYRF/getStravaActivities")
            .then((response: AxiosResponse) => Promise.resolve(response.data))
                  .catch((error: AxiosError) => Promise.reject(error));
            return getStravaHistoryPromise;
        }
        catch (exception)
        {
            console.log(exception);
        }
    }

    handleClick = () => {
        try {
            var stravaAccessTokenPromise = this.getStravaAuthToken()
            .then(response => 
                {
                    Promise.resolve(JSON.parse(response));
                })
                .then(accessTokenJson =>
                    {
                        console.log("SECOND THEN. ACCESS TOKEN: " + accessTokenJson);
                        var stravaHistoryPromise = this.getStravaHistory()
                        .then(response => 
                        {
                            Promise.resolve(JSON.parse(response))
                            console.log("RESPONSE " + JSON.parse(response))
                        });
                        Promise.resolve(stravaHistoryPromise);
                        console.log(stravaHistoryPromise);
                    })
        }
        catch (exception){
            console.log(exception)
        }
    }
    public render()
    {
        return (
            <button onClick={this.handleClick}>Click here to get your Strava History</button>
        );
    }
}