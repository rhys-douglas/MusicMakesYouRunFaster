import React from 'react';

interface ISongsTableProps 
{
    lastFMSongData : any
}

export default class LastFMSongsTable extends React.Component<ISongsTableProps>
{

    openPage = (url: any) =>
    {
        window.open(url);
    }

    render ()
    {
        const datarecords = this.props.lastFMSongData;
        const listItems = datarecords.map((song: any) => 
        <span>
            <img src={song.images} onClick={() => this.openPage(song.url)} alt="Click to go to the song's page on Last.FM."/>
            <p key="song.name"><b>{song.name}</b></p>
            <p key="song.artistName" onClick = {() => this.openPage(song.artistUrl)}> {song.artistName}</p>
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