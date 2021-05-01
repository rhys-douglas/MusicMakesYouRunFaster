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
      const authToken = await axios.get("http://localhost:5000/CMMYRF/getSpotifyAuthToken");
      console.log("authToken: " + authToken);
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