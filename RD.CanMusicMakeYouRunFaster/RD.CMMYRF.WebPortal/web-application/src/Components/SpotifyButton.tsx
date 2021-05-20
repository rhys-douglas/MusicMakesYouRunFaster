import React from 'react';
import Axios, { AxiosError, AxiosResponse } from "axios";
import '../Resources/SpotifyStyles.css'

interface ISpotifyButtonProps
{
    handleAuthTokenCallback : ((authToken:JSON) => void);
};

export class SpotifyButton extends React.Component<ISpotifyButtonProps>
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

    handleClick = () => 
    {
        try
        {
            this.GetSpotifyAuthToken()
            .then(response => 
            {
                var accessToken = JSON.parse(response);
                this.props.handleAuthTokenCallback(accessToken)
                Promise.resolve(accessToken);
            });
    }
    catch (exception)
    {
      console.log(exception)
    }
  }

  render()
  {
    return (<button onClick={this.handleClick} className="SpotifyButton">Sign in to Spotify</button>)
  }
}