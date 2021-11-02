import React, { Component } from "react";
import { Form, FormGroup, Label, Input, Spinner } from "reactstrap";
import { Redirect } from "react-router-dom";

export class Add extends Component {
  static displayName = Add.name;

  constructor(props) {
    super(props);

    this.handleSubmit = this.handleSubmit.bind(this);

    this.state = {
      submitted: false,
      submitting: false,
    };
  }

  handleSubmit(event) {
    this.setState({ submitting: true });

    var formData = new FormData(event.target);

    event.preventDefault();

    fetch("/api/ToDo", {
      method: "POST",
      body: formData,
    }).then((response) => {
      this.setState({ submitting: false });

      if (response.status === 200) {
        this.setState({ submitted: true });
      } else {
        alert("There was a problem");
      }
    });
  }

  render() {
    if (this.state.submitted) return <Redirect to={{ pathname: "/" }} />;
    else if (this.state.submitting) return <Spinner />;
    return (
      <Form onSubmit={this.handleSubmit}>
        <FormGroup>
          <Label for="title">Title</Label>
          <Input type="text" name="title" id="title" maxLength="50" required />
        </FormGroup>
        <FormGroup>
          <Label for="description">Description</Label>
          <Input type="textarea" id="description" name="description" />
        </FormGroup>
        <FormGroup>
          <Label for="due">Due Date</Label>
          <Input type="date" name="due" id="due" />
        </FormGroup>
        <Input type="submit" value="Submit" />
      </Form>
    );
  }
}
