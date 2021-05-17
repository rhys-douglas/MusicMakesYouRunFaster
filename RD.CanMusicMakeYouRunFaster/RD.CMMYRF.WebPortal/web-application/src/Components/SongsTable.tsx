import React from 'react';

interface ISongsTableProps 
{
    data : any
}

export default class SongsTable extends React.Component<ISongsTableProps>
{
    constructor(props : ISongsTableProps)
    {
        super(props);
        var songsJson: any[] = Array.of(props.data);
        console.log(songsJson)
    }

    Table = () =>
    {

    }

    render ()
    {
        return(
            <div>
                <table>
                    <tr>
                        <th>Song name</th>
                        <th>Artists </th>
                    </tr>
                    <tbody id="SpotifySongsTable">

                    </tbody>
                </table>
            </div>
        );
    }
}