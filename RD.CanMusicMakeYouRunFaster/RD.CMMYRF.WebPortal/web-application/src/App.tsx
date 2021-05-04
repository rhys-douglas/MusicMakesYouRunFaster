import React from 'react';
import './App.css';
import Axios, { AxiosError, AxiosResponse } from "axios";
import { StravaButton } from './Components/StravaButton'
import { StartDateInput, EndDateInput } from './Components/DateInput'

class App extends React.Component{
  render(){
    return(
      <div className = "App">
        <h1>Can Music Make You Run Faster?</h1>
        <StartDateInput/><EndDateInput/>
        <h2> Add your running history using the buttons below.</h2>
        <StravaButton/>
        <h2> Add your listening history using the buttons below.</h2>
        <SpotifyLoginButton/>
        <h2> Click the button below to find out what music made you run faster. </h2>
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
      var getSpotifyTokenPromise = await Axios.get("http://localhost:8080/CMMYRF/getSpotifyAuthToken")
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