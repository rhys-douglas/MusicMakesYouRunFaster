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
  lastFMUsername: string,
  statusMessage: string
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
      spotifyAuthToken : {} as any,
      statusMessage: "Status:"
    }
  }

  handleFastestStravaActivityCallback = (fastestStravaActivityUpdate: JSON) => 
  {
    if (fastestStravaActivityUpdate === null){
      this.setState({
        fastestStravaActivity: fastestStravaActivityUpdate,
        statusMessage: "Status: Strava connected successfully, no activities found!"
      });
    }
    else{
      this.setState({
        fastestStravaActivity: fastestStravaActivityUpdate,
        statusMessage: "Status: Strava connected successfully!"
      });
    }
  }

  handleFastestFitBitActivityCallback = (fastestFitBitActivityUpdate : JSON) => 
  {
    if (fastestFitBitActivityUpdate === null){
      this.setState({
        fastestFitBitActivity: fastestFitBitActivityUpdate,
        statusMessage: "Status: Fitbit connected successfully, no activities found!"
      });
    }
    else {
      this.setState({
        fastestFitBitActivity: fastestFitBitActivityUpdate,
        statusMessage: "Status: Fitbit connected successfully!"
      });
    }
  }

  handleSpotifyTokenCallback = (spotifyTokenUpdate: JSON) => 
  {
    if (spotifyTokenUpdate === null){
      this.setState({
        spotifyAuthToken: spotifyTokenUpdate,
        statusMessage: "Status: Failed to get Spotify OAuth2 Token."
      })
    }
    else {
      this.setState({
        spotifyAuthToken: spotifyTokenUpdate,
        statusMessage: "Status: Spotify connected successfully!"
      })
    }
  }

  handleLastFMUsernameCallback = (lastFMUsernameUpdate: string ) => 
  {
    this.setState({
      lastFMUsername: lastFMUsernameUpdate,
      statusMessage: "Status: Last.FM username entered!"
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
        <h1 className = "Title"><b>Can Music Make You Run Faster?</b> </h1>
        <p className="Infotext">A running-music comparison app by Rhys Douglas.</p>
        <div className="MainBody">
          <div className="SecondaryBody">
            <h2>Pick a date range to search between</h2>
            <div className = "Dates">
              <StartDateInput dateCallback={this.handleStartDateCallBack}/>
              <EndDateInput dateCallback={this.handleEndDateCallback}/>
            </div>
            <h2>Connect your running history</h2>
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
            <h2>Connect your listening history</h2>
              <div className="MusicButtons">
                <SpotifyButton handleAuthTokenCallback={this.handleSpotifyTokenCallback}/> 
                <LastFMButton handleUsernameCallback = {this.handleLastFMUsernameCallback}/>
              </div>
          </div>
          <p>{this.state.statusMessage}</p>
          <FastestSongsButton 
            fastestStravaActivity = {this.state.fastestStravaActivity}
            fastestFitBitActivity = {this.state.fastestFitBitActivity}
            spotifyAccessToken = {this.state.spotifyAuthToken}
            lastFMUserName = {this.state.lastFMUsername}/>
        </div>
      </div>
    )
  }
}
export default App;