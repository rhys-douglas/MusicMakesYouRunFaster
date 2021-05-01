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

interface SpotifyAccessTokenResponse{
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
      const authToken = await axios.get<SpotifyAccessTokenResponse>("http://localhost:8080/CMMYRF/getSpotifyAuthToken")
      .then(response => {
      console.log(response.data)});
      console.log("authToken: " + authToken);
    }catch (exception)
    {
      console.log(exception);
    }
  }


  handleClick = () => 
  {
    try
    {
      this.GetSpotifyAuthToken();
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