import React from 'react';
import _ from 'lodash';

interface ISongsTableProps 
{
    data : any
}

interface ISongsTableState
{
    dataColumns : any[]
}

export default class SongsTable extends React.Component<ISongsTableProps, ISongsTableState>
{
    constructor(props : ISongsTableProps)
    {
        super(props);
        this.state = {
            dataColumns : []
        }
        this.extractColumnNames();
    }

    componentDidUpdate(){
        this.extractColumnNames();
    }

    private extractColumnNames()
    {
        console.log("EXTRACTING COLUMN NAMES");
        console.log(this.props.data);
        var firstRecord = _.keys(this.props.data[0]);
        console.log(firstRecord);
        this.setState({dataColumns: firstRecord});
    }

    private displayRecords(key:number) 
    {
        const dataColumns = this.state.dataColumns;
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