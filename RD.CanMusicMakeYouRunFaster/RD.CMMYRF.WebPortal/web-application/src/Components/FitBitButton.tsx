import React from 'react';
import Axios, { AxiosError, AxiosResponse } from "axios";
import '../Resources/FitBitStyles.css';

interface IFitBitButtonProps {
    handleFastestFitBitActivityCallback: ((fitBitActivity: JSON) => void)
    startDate: Date;
    endDate : Date;
};

export class FitBitButton extends React.Component<IFitBitButtonProps>
{
    state = {stravaHistory : JSON}
    getFitBitAuthToken = async function()
    {
        try
        {
            var getFitBitAuthTokenPromise = await Axios.get("http://localhost:8080/CMMYRF/getFitBitAuthToken")
            .then((response: AxiosResponse) => Promise.resolve(response.data))
                  .catch((error: AxiosError) => Promise.reject(error));
            return getFitBitAuthTokenPromise;
          }
          catch (exception)
          {
            console.log(exception);
          }
    }

    getFitBitHistory = async function(access_token : string, startDate: Date, endDate: Date)
    {
        try 
        {
            var start_date = startDate.toISOString();
            var end_date = endDate.toISOString();
            var getFitBitHistoryPromise = await Axios.get("http://localhost:8080/CMMYRF/getFitBitActivities?access_token=" + access_token
            + "&start_date="+ start_date + "&end_date=" + end_date)
            .then((response: AxiosResponse) => Promise.resolve(response.data))
                  .catch((error: AxiosError) => Promise.reject(error));
            return getFitBitHistoryPromise;
        }
        catch (exception)
        {
            console.log(exception);
        }
    }

    getFastestActivity = async function(fitBitHistory : JSON)
    {
        try 
        {
            var getFastestActivityPromise = await Axios.post("http://localhost:8080/CMMYRFI/postFitBitActivities",fitBitHistory)
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
            this.getFitBitAuthToken()
            .then(response => 
                {
                    var accessToken = JSON.parse(response);
                    var fitBitHistoryPromise = this.getFitBitHistory(accessToken.access_token, this.props.startDate, this.props.endDate)
                        .then(activityList => 
                        {
                            var fastestActivityPromise = this.getFastestActivity(activityList)
                            .then(fastestActivity => 
                                {
                                    this.props.handleFastestFitBitActivityCallback(fastestActivity);
                                    Promise.resolve(fastestActivity);
                                });
                            Promise.resolve(fastestActivityPromise);
                        });
                    Promise.resolve(fitBitHistoryPromise);
                });
        }
        catch (exception)
        {
            console.log(exception)
        }
    }
    public render()
    {
        return (<button onClick={this.handleClick} className="FitBitButton">Connect with Fitbit</button>);
    }
}