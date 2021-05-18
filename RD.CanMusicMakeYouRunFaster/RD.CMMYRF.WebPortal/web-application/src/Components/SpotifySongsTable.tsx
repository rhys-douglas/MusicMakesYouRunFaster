import React from 'react';

interface ISongsTableProps 
{
    spotifySongsData : any
}

export default class SpotifySongsTable extends React.Component<ISongsTableProps>
{
    openPage = (url: any) =>
    {
        window.open(url);
    }

    render () 
    {
        const datarecords = this.props.spotifySongsData;
        const listItems = datarecords.map((song: any) => 
        <span>
            <img src={song.image} onClick={() => this.openPage(song.url)} width="174" height="174"/>
            <p key="song.name"><b>{song.name}</b></p>
            <p key="song.artist" onClick = {() => this.openPage(song.artistURL)}> {song.artist}</p>
        </span>)

        return(
            <div>
                <div className="songs">
                    {listItems}
                </div>
            </div>
        );
    }
}