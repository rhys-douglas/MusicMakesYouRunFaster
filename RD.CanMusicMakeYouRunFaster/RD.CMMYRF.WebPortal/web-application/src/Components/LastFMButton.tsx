import React from 'react';

interface ILastFMButtonProps
{
    handleUsernameCallback : ((username:string) => void);
};

export class LastFMButton extends React.Component<ILastFMButtonProps> 
{
    handleClick = () => 
    {
        var username = prompt("Enter your Last.FM username. This is case sensitive.");
        if (username != null)
        {
            this.props.handleUsernameCallback(username);
        }
    }
    render()
    {
        return(<button onClick={this.handleClick}>Enter your Last.FM username</button>)
    }
}