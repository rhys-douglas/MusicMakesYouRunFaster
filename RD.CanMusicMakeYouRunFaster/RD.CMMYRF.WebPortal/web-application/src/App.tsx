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
  endDate: Date,
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
      startDate : new Date(new Date().setDate(new Date().getDate()-31)),
      endDate : new Date(),
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

  handleEndDateCallback = (endDateUpdate: Date) =>
  {
    this.setState({
      endDate: endDateUpdate
    })
    console.log(this.state.endDate);
  }

  render()
  {
    return(
      <div className = "App">
        <h1 className = "Title"><b>Can Music Make You Run Faster?</b></h1>
        <p className="Infotext">A running-music comparison app by Rhys Douglas.</p>
        <div className="MainBody">
          <div className="SecondaryBody">
            <h2> Pick a date range to search between.</h2>
            <div className = "Dates">
              <StartDateInput dateCallback={this.handleStartDateCallBack}/>
              <EndDateInput dateCallback={this.handleEndDateCallback}/>
            </div>
            <h2> Add your running history using the buttons below.</h2>
            <div className="RunningButtons">
              <StravaButton 
              handleFastestStravaActivityCallback={this.handleFastestStravaActivityCallback}
              startDate={this.state.startDate}
              endDate={this.state.endDate}/> 
              <FitBitButton 
              handleFastestFitBitActivityCallback={this.handleFastestFitBitActivityCallback}
              startDate={this.state.startDate}
              endDate={this.state.endDate}/>
            </div>
            <h2> Add your listening history using the buttons below.</h2>
              <div className="MusicButtons">
                <SpotifyButton handleAuthTokenCallback={this.handleSpotifyTokenCallback}/> 
                <LastFMButton handleUsernameCallback = {this.handleLastFMUsernameCallback}/>
              </div>
          </div>
          <h2> Click the button below to find out what music made you run faster. </h2>
        </div>
          <FastestSongsButton 
            fastestStravaActivity = {this.state.fastestStravaActivity}
            fastestFitBitActivity = {this.state.fastestFitBitActivity}
            spotifyAccessToken = {this.state.spotifyAuthToken}
            lastFMUserName = {this.state.lastFMUsername}/>
      </div>
    )
  }
}
export default App;