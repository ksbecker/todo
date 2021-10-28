import React, { Component } from 'react';
import { Link } from "react-router-dom";
import { Delete } from "./Delete";
import { ToggleComplete } from './ToggleComplete';

export class Home extends Component {
    static displayName = Home.name;

    constructor(props) {
        super(props);
        this.state = { toDos: [], loading: false };
        this.renderToDosTable = this.renderToDosTable.bind(this);
        this.handDataRefresh = this.handDataRefresh.bind(this);
    }

    componentDidMount() {
        this.populateToDoData();
    }

    handDataRefresh() {
        this.populateToDoData();
    }

    renderToDosTable(toDos) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Title</th>
                        <th>Description</th>
                        <th>Due date</th>
                        <th>Complete</th>
                        <th>Delete</th>
                    </tr>
                </thead>
                <tbody>
                    {toDos.map(toDo =>
                        <tr key={toDo.id}>
                            <td>{toDo.title}</td>
                            <td>{toDo.description}</td>
                            <td>{new Intl.DateTimeFormat("en-US").format(Date.parse(toDo.due))}</td>
                            <td><ToggleComplete id={toDo.id} completed={toDo.completed} onToggleComplete={this.handDataRefresh} /></td>
                            <td><Delete id={toDo.id} onDelete={this.handDataRefresh} /></td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderToDosTable(this.state.toDos);

        return (
            <div>
                <Link className="float-right btn btn-primary" to="/add">Add</Link>
                <h1 id="tabelLabel">To Dos</h1>
                {contents}
            </div>
        );
    }

    async populateToDoData() {
        this.setState({ loading: true });
        const response = await fetch('api/ToDo');
        const data = await response.json();
        this.setState({ toDos: data, loading: false });
    }
}
