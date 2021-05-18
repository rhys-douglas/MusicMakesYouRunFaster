import React from 'react';
import './App.css';
import { StartDateInput, EndDateInput } from './Components/DateInput'
import { StravaButton } from './Components/StravaButton'
import { FitBitButton } from './Components/FitBitButton'
import { SpotifyButton } from './Components/SpotifyButton'
import { LastFMButton } from './Components/LastFMButton'
import { FastestSongsButton } from './Components/FastestSongsButton'

interface AppProps{
}

interface AppState{
  startDate: Date,
  fastestStravaActivity: JSON,
  fastestFitBitActivity: JSON,
  spotifyAuthToken: JSON,
  lastFMUsername: string
}

class App extends React.Component<AppProps, AppState>
{
  constructor(AppProps: AppProps)
  {
    super(AppProps);
    this.state = 
    {
      startDate : new Date(),
      lastFMUsername : "",
      fastestStravaActivity : {} as any,
      fastestFitBitActivity : {} as any,
      spotifyAuthToken : {} as any
    }
  }

  handleFastestStravaActivityCallback = (fastestStravaActivityUpdate: JSON) => 
  {
    console.log(fastestStravaActivityUpdate);
    this.setState({
      fastestStravaActivity: fastestStravaActivityUpdate
    });
  }

  handleFastestFitBitActivityCallback = (fastestFitBitActivityUpdate : JSON) => 
  {
    console.log(fastestFitBitActivityUpdate);
    this.setState({
      fastestFitBitActivity: fastestFitBitActivityUpdate
    });
  }

  handleSpotifyTokenCallback = (spotifyTokenUpdate: JSON) => 
  {
    console.log(spotifyTokenUpdate);
    this.setState({
      spotifyAuthToken: spotifyTokenUpdate
    });
  }

  handleLastFMUsernameCallback = (lastFMUsernameUpdate: string ) => 
  {
    console.log(lastFMUsernameUpdate);
    this.setState({
      lastFMUsername: lastFMUsernameUpdate
    });
  }

  handleStartDateCallBack = (startDateUpdate: Date) =>
  {
    this.setState({
      startDate: startDateUpdate
    })
    console.log(this.state.startDate);
  }

  render()
  {
    return(
      <div className = "App">
        <h1>Can Music Make You Run Faster?</h1>
        <StartDateInput dateCallback={this.handleStartDateCallBack}/><EndDateInput/>
        <h2> Add your running history using the buttons below.</h2>
        <StravaButton handleFastestStravaActivityCallback={this.handleFastestStravaActivityCallback}/> <FitBitButton handleFastestFitBitActivityCallback={this.handleFastestFitBitActivityCallback}/>
        <h2> Add your listening history using the buttons below.</h2>
        <SpotifyButton handleAuthTokenCallback={this.handleSpotifyTokenCallback}/> <LastFMButton handleUsernameCallback = {this.handleLastFMUsernameCallback}/>
        <h2> Click the button below to find out what music made you run faster. </h2>
        <FastestSongsButton 
          fastestStravaActivity = {this.state.fastestStravaActivity}
          fastestFitBitActivity = {this.state.fastestFitBitActivity}
          spotifyAccessToken = {this.state.spotifyAuthToken}
          lastFMUserName = {this.state.lastFMUsername}
        />
      </div>
    )
  }
}
export default App;