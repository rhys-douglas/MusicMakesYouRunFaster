import React from 'react';

interface ISongsTableProps 
{
    data : JSON
}

export default class SongsTable extends React.Component<ISongsTableProps>
{
    constructor(props : ISongsTableProps)
    {
        super(props);
        this.getHeader = this.getHeader.bind(this);
        this.getRowsData = this.getRowsData.bind(this);
        this.getKeys = this.getKeys.bind(this);
    }

    getKeys = () =>
    {
        return Object.keys(this.props.data[0]);
    }

    getHeader = () =>
    {
        var keys = this.getKeys();
        return keys.map((key : any, index : any)=>
        {
            return <th key={key}>{key.toUpperCase()}</th>
        });
    }

    getRowsData = () =>
    {
        var items = this.props.data;
        var keys = this.getKeys();
        return items.map((row: any, index: any)=>
        {
            return <tr key={index}><this.RenderRow key={index} data={row} keys={keys}/></tr>
        });
    }

    RenderRow = (props: any) => 
    {
        return props.keys.map((key : any, index : any)=>
        {
            return <td key={props.data[key]}>{props.data[key]}</td>
        })
    }

    render ()
    {
        return(
            <div>
                <table>
                    <thead>
                        <tr>{this.getHeader() }</tr>
                    </thead>
                    <tbody>
                        {this.getRowsData() }
                    </tbody>
                </table>
            </div>
        );
    }
}