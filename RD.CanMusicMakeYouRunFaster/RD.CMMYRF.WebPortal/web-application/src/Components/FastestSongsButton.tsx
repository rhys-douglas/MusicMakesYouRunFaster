import React from 'react';

export class FastestSongsButton extends React.Component{

    handleClick = () =>
    {
        try 
        {
            
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