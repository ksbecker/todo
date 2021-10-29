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
        this.handleDataRefresh = this.handleDataRefresh.bind(this);
    }

    componentDidMount() {
        this.populateToDoData();
    }

    handleDataRefresh() {
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
                            <td>{toDo.due ? new Intl.DateTimeFormat("en-US").format(Date.parse(toDo.due)) : ""}</td>
                            <td><ToggleComplete id={toDo.id} completed={toDo.completed} onToggleComplete={this.handleDataRefresh} /></td>
                            <td><Delete id={toDo.id} onDelete={this.handleDataRefresh} /></td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let incompleteToDos, completeToDos;

        if (this.state.loading)
            incompleteToDos = completeToDos = <p><em>Loading...</em></p>
        else {
            let incompleteToDosArray = this.state.toDos
                .filter(toDo => toDo.completed === false);
            incompleteToDos = this.renderToDosTable(incompleteToDosArray);

            let completeToDosArray = this.state.toDos
                .filter(toDo => toDo.completed === true);

            completeToDos = this.renderToDosTable(this.state.toDos.filter(toDo => toDo.completed === true));
        }

        return (
            <div>
                <Link className="float-right btn btn-primary" to="/add">Add</Link>
                <h1 id="tabelLabel">Incomplete To Dos</h1>
                {incompleteToDos}
                <h1 id="tabelLabel">Complete To Dos</h1>
                {completeToDos}
            </div>
        );
    }

    async populateToDoData() {
        this.setState({ loading: true });
        const response = await fetch('api/ToDo');
        const data = await response.json();
        this.setState({ toDos: data.sort((toDo1, toDo2) => toDo1.due - toDo2.due), loading: false });
    }
}
