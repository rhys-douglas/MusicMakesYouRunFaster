import React from 'react';

interface IFastestSongsButtonProps{
    fastestStravaActivity: JSON,
    fastestFitBitActivity: JSON,
    spotifyAccessToken: JSON,
    lastFMUserName: string
}

export class FastestSongsButton extends React.Component<IFastestSongsButtonProps>
{
    handleClick = () =>
    {
        try 
        {
            console.log(this.props.fastestStravaActivity);
            console.log(this.props.fastestFitBitActivity);
            console.log(this.props.spotifyAccessToken);
            console.log(this.props.lastFMUserName);
        }
        catch (exception)
        {
            console.log(exception);
        }
    }

    render()
    {
        return(
            <div>
                <button onClick={this.handleClick}> Click here to find out what songs made you run faster!</button>
            </div>)
    }
}