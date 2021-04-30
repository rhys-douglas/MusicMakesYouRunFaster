import React from 'react';
import './App.css';

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

  handleClick = () => 
  {
    console.log("Clicked!");
  }

  render()
  {
    return <div>
      <button onClick={this.handleClick}>Log in to spotify</button>
    </div>
  }
}

export default App;