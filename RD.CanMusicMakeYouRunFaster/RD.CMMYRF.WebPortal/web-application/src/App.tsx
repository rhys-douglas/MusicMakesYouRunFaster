import React from 'react';
import './App.css';
import { StravaButton } from './Components/StravaButton'
import { FitBitButton } from './Components/FitBitButton'
import { SpotifyButton } from './Components/SpotifyButton'
import { StartDateInput, EndDateInput } from './Components/DateInput'

class App extends React.Component{

  handleStravaHistory = (stravaHistory: JSON) => {
    console.log("Callback reached!!" + stravaHistory);
    console.log(stravaHistory);
  }

  handleFitBitHistory = (fitBitHistory: JSON) => {
    console.log(fitBitHistory);
  }

  render(){
    return(
      <div className = "App">
        <h1>Can Music Make You Run Faster?</h1>
        <StartDateInput/><EndDateInput/>
        <h2> Add your running history using the buttons below.</h2>
        <StravaButton handleActivities={this.handleStravaHistory}/> <FitBitButton/>
        <h2> Add your listening history using the buttons below.</h2>
        <SpotifyButton/>
        <h2> Click the button below to find out what music made you run faster. </h2>
      </div>
    )
  }
}
export default App;