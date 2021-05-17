import React from 'react';
import { useTable } from 'react-table';


interface ISongsTableProps 
{
    data : any
}

interface ISongsTableState
{
    dataColumns : string[]
}

export default class SongsTable extends React.Component<ISongsTableProps, ISongsTableState>
{
    constructor(props : ISongsTableProps)
    {
        super(props);
        var songsJson: any[] = Array.of(props.data);
        this.state = {
            dataColumns : ["Song name"]
        }
        console.log(songsJson)
    }

    private displayRecords(key:number) 
    {
        const dataColumns = this.state.dataColumns;
        console.log(dataColumns);
        return dataColumns.map((each_col) =>
            this.displayRecordName(each_col,key))
    }

    private displayRecordName(colname:string, key:number){
        const record = this.props.data[key];
        return <th>{record[colname]}</th>
    }

    render ()
    {
        const datarecords = this.props.data;
        const table_headers = this.state.dataColumns;
        return(
            <div>
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
                                <tr key = {eachDataRecord.id}>{this.displayRecords(recordIndex)}</tr>
                                )}
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        );
    }
}