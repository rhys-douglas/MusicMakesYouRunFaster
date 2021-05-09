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
  fastestStravaHistory: JSON,
  fitbitHistory: JSON,
  spotifyAuthToken: JSON,
  lastFMUsername: string
}

class App extends React.Component<AppProps, AppState>
{

  handleFastestStravaHistoryCallback = (fastestStravaHistoryUpdate: JSON) => 
  {
    this.setState({
      fastestStravaHistory: fastestStravaHistoryUpdate
    });
  }

  handleFitBitHistoryCallback = (fitBitHistoryUpdate : JSON) => 
  {
    this.setState({
      fitbitHistory: fitBitHistoryUpdate
    });
  }

  handleSpotifyTokenCallback = (spotifyTokenUpdate: JSON) => 
  {
    this.setState({
      spotifyAuthToken: spotifyTokenUpdate
    });
  }

  handleLastFMUsernameCallback = (lastFMUsernameUpdate: string ) => 
  {
    this.setState({
      lastFMUsername: lastFMUsernameUpdate
    });
  }

  render()
  {
    return(
      <div className = "App">
        <h1>Can Music Make You Run Faster?</h1>
        <StartDateInput/><EndDateInput/>
        <h2> Add your running history using the buttons below.</h2>
        <StravaButton handleActivitiesCallback={this.handleFastestStravaHistoryCallback}/> <FitBitButton handleActivitiesCallback={this.handleFitBitHistoryCallback}/>
        <h2> Add your listening history using the buttons below.</h2>
        <SpotifyButton handleAuthTokenCallback={this.handleSpotifyTokenCallback}/> <LastFMButton handleUsernameCallback = {this.handleLastFMUsernameCallback}/>
        <h2> Click the button below to find out what music made you run faster. </h2>
        <FastestSongsButton/>
      </div>
    )
  }
}
export default App;