import React from 'react';
import _ from 'lodash';

interface ISongsTableProps 
{
    lastFMSongData : any
}

interface ISongsTableState
{
    dataColumns : any[]
}

export default class LastFMSongsTable extends React.Component<ISongsTableProps, ISongsTableState>
{
    constructor(props : ISongsTableProps)
    {
        super(props);
        this.state = {
            dataColumns : []
        }
    }

    componentDidUpdate() 
    {
        console.log("UPDATER CALLED");
        if (this.state.dataColumns.length === 0 || typeof(this.state.dataColumns) === undefined)
        {
            if (this.props.lastFMSongData.length !== 0){
                this.extractColumnNames();
            }
        }  
    }

    private extractColumnNames()
    {
        console.log("EXTRACTING COLUMN NAMES");
        console.log(this.props.lastFMSongData);
        try{
            var firstRecord = _.keys(this.props.lastFMSongData[0]);
            this.setState({dataColumns: firstRecord});
            this.render();
        }
        catch(exception)
        {
            console.log(exception)
        }
    }

    private displayRecords(rowNumber:number) 
    {
        const dataColumns = this.state.dataColumns;
        return dataColumns.map((each_col) =>
            this.displayRecordName(each_col,rowNumber))
    }

    private displayRecordName(colname:string, rowNumber:number)
    {
        const song = this.props.lastFMSongData[rowNumber];
        return <th>{song[colname]}</th>
    }

    openPage = (url: any) =>
    {
        window.open(url);
    }

    render ()
    {
        console.log("RENDER CALLED");
        const datarecords = this.props.lastFMSongData;
        console.log(datarecords);
        const table_headers = this.state.dataColumns;
        console.log(table_headers);
        const listItems = datarecords.map((song: any) => 
        <span>
            <img src={song.images} onClick={() => this.openPage(song.url)}/>
            <p key="song.name">{song.name}</p>
            <p key="song.artistName" onClick = {() => this.openPage(song.artistUrl)}> {song.artistName}</p>
        </span>)
        return(
            <div>
                <h1> Songs that make you run faster </h1>
                <div className="songs">
                {listItems}
                </div>
                <div className = "container">
                    <div className = "row">
                        <table className = "table table-bordered">
                            <thead className= "theadLight">
                                <tr>
                                    {table_headers && table_headers.map(each_table_header => <th scope="col">{each_table_header}</th>)}
                                </tr>
                            </thead>
                            <tbody>
                                {datarecords && datarecords.map((song : any, rowNumber : any) => 
                                <tr key = {song}>{this.displayRecords(rowNumber)}</tr>
                                )}
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        );
    }
}