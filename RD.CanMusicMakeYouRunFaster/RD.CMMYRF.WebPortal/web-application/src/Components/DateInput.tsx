import React from 'react';
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";

interface DateConstructor  {
    startDate: Date;
} 

export class StartDateInput extends React.Component<{},DateConstructor>
{
    constructor(props: any){
        super(props);
        this.state = {
            startDate : new Date(new Date().setDate(new Date().getDate()-14))
        }
        this.dateModifier = this.dateModifier.bind(this);
    }

    private dateModifier(date : Date){
        this.setState({
            startDate : date
        });
    }

    public render()
    {
        const { startDate } = this.state;
        return (
            <div>
                <p>Start Date</p>
                <DatePicker
                dateFormat="dd/MM/yyyy"
                selected={startDate} 
                onChange={this.dateModifier}
            />
            </div>
        );
    }
}

export class EndDateInput extends React.Component<{},DateConstructor>
{
    constructor(props: any){
        super(props);
        this.state = {
            startDate : new Date()
        }
        this.dateModifier = this.dateModifier.bind(this);
    }

    private dateModifier(date : Date){
    }

    public render()
    {
        const { startDate } = this.state;
        return (
            <div>
                <p>End Date</p>
                <DatePicker
                dateFormat="dd/MM/yyyy"
                selected={startDate} 
                onChange={this.dateModifier}
            />
            </div>
        );
    }
}