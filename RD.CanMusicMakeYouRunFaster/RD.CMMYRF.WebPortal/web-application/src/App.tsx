import React from 'react';
import './App.css';
import { StravaButton } from './Components/StravaButton'
import { FitBitButton } from './Components/FitBitButton'
import { SpotifyButton } from './Components/SpotifyButton'
import { StartDateInput, EndDateInput } from './Components/DateInput'

interface AppProps{

}

interface AppState{
  stravaHistory: JSON,
  fitbitHistory: JSON
}

class App extends React.Component<AppProps,AppState>{

  handleStravaHistoryCallback = (stravaHistoryUpdate: JSON) => {
    this.setState({
      stravaHistory: stravaHistoryUpdate
    });
    console.log(this.state.stravaHistory);
  }

  handleFitBitHistoryCallback = (fitBitHistoryUpdate : JSON) => {
    this.setState({
      fitbitHistory: fitBitHistoryUpdate
    });
    console.log(this.state.fitbitHistory);
  }

  render(){
    return(
      <div className = "App">
        <h1>Can Music Make You Run Faster?</h1>
        <StartDateInput/><EndDateInput/>
        <h2> Add your running history using the buttons below.</h2>
        <StravaButton handleActivitiesCallback={this.handleStravaHistoryCallback}/> <FitBitButton handleActivitiesCallback={this.handleFitBitHistoryCallback}/>
        <h2> Add your listening history using the buttons below.</h2>
        <SpotifyButton/>
        <h2> Click the button below to find out what music made you run faster. </h2>
      </div>
    )
  }
}
export default App;