import React, { Component } from 'react';
import { Button } from 'reactstrap';

export class Delete extends Component {

    constructor(props) {
        super(props);

        this.handleDelete = this.handleDelete.bind(this);
    }

    handleDelete() {
        var p = this.props;
        var id = p.id;

        if (window.confirm("Are you sure you want to delete this to do?")) {
            fetch(`/api/ToDo/${id}`,
                {
                    method: "DELETE"
                })
                .then(response => {
                    if (response.status === 200) {
                        p.onDelete();
                    } else {
                        alert("There was a problem");
                    }
                });
        }
    }

    render() {
        return (
            <Button onClick={this.handleDelete}>Delete</Button>
        );
    }
}