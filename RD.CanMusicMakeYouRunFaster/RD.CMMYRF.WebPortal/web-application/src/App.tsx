import React from 'react';
import './App.css';
import Axios, { AxiosError, AxiosResponse } from "axios";
import { StravaButton } from './Components/StravaButton'
import { SpotifyButton } from './Components/SpotifyButton'
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
        <SpotifyButton/>
        <h2> Click the button below to find out what music made you run faster. </h2>
      </div>
    )
  }
}

export default App;