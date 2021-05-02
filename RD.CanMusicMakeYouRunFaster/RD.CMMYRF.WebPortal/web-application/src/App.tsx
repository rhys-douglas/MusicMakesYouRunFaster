import axios from 'axios';
import React from 'react';
import './App.css';
import Axios, { AxiosError, AxiosResponse } from "axios";

class App extends React.Component{
  render(){
    return(
      <div className = "App">
        <h1>Can Music Make You Run Faster?</h1>
        <SpotifyLoginButton/>
      </div>
    )
  }
}

type IProps = {
}

type IState = {
}

interface ISpotifyAccessToken{
  AccessToken : string,
  TokenType : string,
  ExpiresIn : number,
  RefreshToken : string,
  CreatedAt: string,
  IsExpired: false
}


class SpotifyLoginButton extends React.Component<IProps,IState>
{
  constructor (props:IProps)
  {
    super(props);
    this.state = {};

  }

  GetSpotifyAuthToken = async function()
  {
    try{
      var getSpotifyTokenPromise = await axios.get("http://localhost:8080/CMMYRF/getSpotifyAuthToken")
      .then((response: AxiosResponse) => Promise.resolve(response.data))
            .catch((error: AxiosError) => Promise.reject(error));
      return getSpotifyTokenPromise
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
      let actualToken : ISpotifyAccessToken
      var temp
      var token = this.GetSpotifyAuthToken()
      .then(response => 
        {console.log(typeof response + "response: " + response)
        temp = JSON.parse(response)
        console.log(temp)
        console.log(temp.AccessToken)});
    }
    catch (exception)
    {
      console.log("EXCEPTION:" + exception)
    }
  }

  render()
  {
    return <div>
      <button onClick={this.handleClick}>Log in to spotify</button>
    </div>
  }
}

export default App;