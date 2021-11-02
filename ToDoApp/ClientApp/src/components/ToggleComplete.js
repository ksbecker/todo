import React, { Component } from "react";
import { Input } from "reactstrap";

export class ToggleComplete extends Component {
  constructor(props) {
    super(props);

    this.handleToggleComplete = this.handleToggleComplete.bind(this);
  }

  handleToggleComplete() {
    var props = this.props;

    var id = props.id;
    var completed = props.completed;

    var formData = new FormData();
    formData.append("id", id);
    formData.append("completed", !completed);

    fetch(`/api/ToDo/${id}`, {
      method: "PUT",
      body: formData,
    }).then((response) => {
      if (response.status === 200) {
        props.onToggleComplete();
      } else {
        alert("There was a problem");
      }
    });
  }

  render() {
    return (
      <Input
        type="checkbox"
        checked={this.props.completed}
        onChange={this.handleToggleComplete}
      />
    );
  }
}
