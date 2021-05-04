import React from 'react';
import Axios, { AxiosError, AxiosResponse } from "axios";

export class StravaButton extends React.Component
{
    state = {stravaHistory : JSON}
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

    getStravaHistory = async function(access_token : string)
    {
        try 
        {
            var getStravaHistoryPromise = await Axios.get("http://localhost:8080/CMMYRF/getStravaActivities?access_token=" + access_token)
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
        try 
        {
            var stravaAccessTokenPromise = this.getStravaAuthToken()
            .then(response => 
                {
                    console.log(response);
                    var accessToken = JSON.parse(response);
                    console.log(accessToken);
                    var stravaHistoryPromise = this.getStravaHistory(accessToken.access_token)
                        .then(response => 
                        {
                            console.log(response);
                            this.setState(response)
                            console.log(this.state);
                            Promise.resolve(response);
                        });
                    Promise.resolve(stravaHistoryPromise);
                });
        }
        catch (exception)
        {
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