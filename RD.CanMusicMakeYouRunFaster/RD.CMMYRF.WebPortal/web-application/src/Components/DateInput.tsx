import React from 'react';
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";

interface IDateProps {
    dateCallback: ((updatedDate: Date) => void)
}


interface IStartDateState  {
    startDate: Date;
}

export class StartDateInput extends React.Component<IDateProps,IStartDateState>
{
    constructor(props: IDateProps){
        super(props);
        this.state = {
            startDate : new Date(new Date().setDate(new Date().getDate()-31))
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

interface IEndDateState {
    endDate: Date;
}

export class EndDateInput extends React.Component<IDateProps,IEndDateState>
{
    constructor(props: any){
        super(props);
        this.state = {
            endDate : new Date()
        }
        this.dateModifier = this.dateModifier.bind(this);
    }

    private dateModifier(date : Date){
        this.setState({
            endDate : date
        });
        this.props.dateCallback(this.state.endDate);
    }

    public render()
    {
        const { endDate } = this.state;
        return (
            <div>
                <p>End Date</p>
                <DatePicker
                dateFormat="dd/MM/yyyy"
                selected={endDate} 
                onChange={this.dateModifier}
            />
            </div>
        );
    }
}