import React from 'react';
import Axios, { AxiosError, AxiosResponse } from "axios";

interface IStravaButtonProps {
    handleActivitiesCallback: ((stravaHistory: JSON) => void)
};

export class StravaButton extends React.Component<IStravaButtonProps>
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
            this.getStravaAuthToken()
            .then(response => 
                {
                    var accessToken = JSON.parse(response);
                    var stravaHistoryPromise = this.getStravaHistory(accessToken.access_token)
                        .then(response => 
                        {
                            this.props.handleActivitiesCallback(response);
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
        return (<button onClick={this.handleClick}>Click here to connect your Strava History</button>)
    }
}