import React from 'react';

import Axios, { AxiosError, AxiosResponse } from "axios";

export class SpotifyButton extends React.Component
{
    GetSpotifyAuthToken = async function()
    {
        try
        {
            var getSpotifyTokenPromise = await Axios.get("http://localhost:8080/CMMYRF/getSpotifyAuthToken")
                .then((response: AxiosResponse) => Promise.resolve(response.data))
                .catch((error: AxiosError) => Promise.reject(error));
            return getSpotifyTokenPromise;
        }
        catch (exception)
        {
            console.log(exception);
        }
    }

    GetSpotifyListeningHistoryForActivities = async function(access_token : string)
    {
        try 
        {
            var getSpotifyListeningHistoryPromise = await Axios.get("SOMEURL")
                .then((response: AxiosResponse) => Promise.resolve(response.data))
                .catch((error: AxiosError) => Promise.reject(error));
            return getSpotifyListeningHistoryPromise;
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
            this.GetSpotifyAuthToken()
            .then(response => 
            {
                var accessToken = JSON.parse(response);
                console.log(accessToken);
                var spotifyHistoryPromise = this.GetSpotifyListeningHistoryForActivities(accessToken.AccessToken)
                    .then(response =>
                        {
                           console.log(response); 
                        });
            });
    }
    catch (exception)
    {
      console.log(exception)
    }
  }

  render()
  {
    return <div>
      <button onClick={this.handleClick}>Log in to spotify</button>
    </div>
  }
}