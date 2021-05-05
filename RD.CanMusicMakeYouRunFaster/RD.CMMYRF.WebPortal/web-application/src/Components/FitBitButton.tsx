import React from 'react';
import Axios, { AxiosError, AxiosResponse } from "axios";

interface IFitBitButtonProps {
    handleActivitiesCallback: ((stravaHistory: JSON) => void)
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

    getFitBitHistory = async function(access_token : string)
    {
        try 
        {
            var getFitBitHistoryPromise = await Axios.get("http://localhost:8080/CMMYRF/getFitBitActivities?access_token=" + access_token)
            .then((response: AxiosResponse) => Promise.resolve(response.data))
                  .catch((error: AxiosError) => Promise.reject(error));
            return getFitBitHistoryPromise;
        }
        catch (exception)
        {
            console.log(exception);
        }
    }

    handleClick = () => {
        try 
        {
            this.getFitBitAuthToken()
            .then(response => 
                {
                    var accessToken = JSON.parse(response);
                    var fitBitHistoryPromise = this.getFitBitHistory(accessToken.access_token)
                        .then(response => 
                        {
                            this.props.handleActivitiesCallback(response);
                            Promise.resolve(response);
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
        return (
            <button onClick={this.handleClick}>Click here to connect your FitBit History</button>
        );
    }
}