import React from 'react';
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";

interface IDateProps {
    dateCallback: ((updatedDate: Date) => void)
}

interface DateConstructor  {
    startDate: Date;
} 

export class StartDateInput extends React.Component<IDateProps,DateConstructor>
{
    constructor(props: IDateProps){
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
        this.props.dateCallback(this.state.startDate);
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