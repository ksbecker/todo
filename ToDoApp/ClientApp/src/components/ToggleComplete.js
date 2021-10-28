import React, { Component } from 'react';
import { Input } from 'reactstrap';

export class ToggleComplete extends Component {

    constructor(props) {
        super(props);

        this.handleToggleComplete = this.handleToggleComplete.bind(this);
    }

    handleToggleComplete() {
        var p = this.props;
        var id = p.id;
        var completed = p.completed;

        var formData = new FormData();
        formData.append("id", id);
        formData.append("completed", !completed);

        fetch(`/api/ToDo/${id}`,
            {
                method: "PUT",
                body: formData
            })
            .then(response => {
                if (response.status === 200) {
                    p.onToggleComplete();
                } else {
                    alert("There was a problem");
                }
            });
    }

    render() {
        return (
            <Input type="checkbox" checked={this.props.completed} onClick={this.handleToggleComplete} />
        );
    }
}