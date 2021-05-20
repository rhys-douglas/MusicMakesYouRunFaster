import React from 'react';
import Axios, { AxiosError, AxiosResponse } from "axios";
import ConnectWithStrava from '../Resources/ConnectWithStrava.svg'
import '../Resources/StravaStyles.css'

interface IStravaButtonProps {
    handleFastestStravaActivityCallback: ((stravaHistory: JSON) => void);
    startDate: Date;
    endDate : Date;
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

    getStravaHistory = async function(access_token : string, startDate: Date, endDate: Date)
    {
        try 
        {
            var start_date = startDate.toISOString();
            var end_date = endDate.toISOString();
            var getStravaHistoryPromise = await Axios.get("http://localhost:8080/CMMYRF/getStravaActivities?access_token=" + access_token
            + "&start_date="+ start_date + "&end_date=" + end_date)
            .then((response: AxiosResponse) => Promise.resolve(response.data))
                  .catch((error: AxiosError) => Promise.reject(error));
            return getStravaHistoryPromise;
        }
        catch (exception)
        {
            console.log(exception);
        }
    }

    getFastestActivity = async function(stravaHistory: JSON)
    {
        try 
        {
            var getFastestActivityPromise = await Axios.post("http://localhost:8080/CMMYRFI/postStravaActivities",stravaHistory)
            .then((response: AxiosResponse) => Promise.resolve(response.data))
                  .catch((error: AxiosError) => Promise.reject(error));
            return getFastestActivityPromise;
        }
        catch (exception)
        {
            console.log(exception)
        }
    }

    handleClick = () => {
        try 
        {
            this.getStravaAuthToken()
            .then(response => 
                {
                    var accessToken = JSON.parse(response);
                    var stravaHistoryPromise = this.getStravaHistory(accessToken.access_token, this.props.startDate, this.props.endDate)
                        .then(response => 
                        {
                            this.getFastestActivity(response)
                            .then(fastestActivity =>{
                                this.props.handleFastestStravaActivityCallback(fastestActivity);
                                Promise.resolve(fastestActivity);
                            })
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
        return (<img src={ConnectWithStrava} onClick={this.handleClick} alt="Click here to connect your Strava history!" className="StravaImage"/>)
    }
}