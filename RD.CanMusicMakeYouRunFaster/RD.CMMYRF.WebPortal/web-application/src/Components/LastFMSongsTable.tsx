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
            console.log("ENTERED");
            this.extractColumnNames();
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

    private displayRecords(key:number) 
    {
        const dataColumns = this.state.dataColumns;
        return dataColumns.map((each_col) =>
            this.displayRecordName(each_col,key))
    }

    private displayRecordName(colname:string, key:number){
        const record = this.props.lastFMSongData[key];
        return <th>{record[colname]}</th>
    }

    render ()
    {
        console.log("RENDER CALLED");
        console.log(this.props.lastFMSongData);
        const datarecords = this.props.lastFMSongData;
        console.log(datarecords);
        const table_headers = this.state.dataColumns;
        console.log(table_headers);
        return(
            <div>
                <h1> Songs that make you run faster </h1>
                <div className = "container">
                    <div className = "row">
                        <table className = "table table-bordered">
                            <thead className= "theadLight">
                                <tr>
                                    {table_headers && table_headers.map(each_table_header => <th scope="col">{each_table_header}</th>)}
                                </tr>
                            </thead>
                            <tbody>
                                {datarecords && datarecords.map((eachDataRecord : any,recordIndex : any) => 
                                <tr key = {eachDataRecord}>{this.displayRecords(recordIndex)}</tr>
                                )}
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        );
    }
}