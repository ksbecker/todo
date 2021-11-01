import React, { Component } from "react";
import { Form, FormGroup, Label, Input, Spinner } from "reactstrap";
import { Redirect } from "react-router-dom";

export class Edit extends Component {
  static displayName = Edit.name;

  constructor(props) {
    super(props);

    this.handleSubmit = this.handleSubmit.bind(this);
    this.loadToDo = this.loadToDo.bind(this);
    this.handleInputChange = this.handleInputChange.bind(this);

    this.state = {
      submitted: false,
      submitting: false,
      loading: true,
      title: "",
      description: "",
      due: new Date(),
      id: 0,
    };

    this.loadToDo();
  }

  handleSubmit(event) {
    this.setState({ submitting: true });

    var formData = new FormData(event.target);

    event.preventDefault();

    fetch("/api/ToDo", {
      method: "PUT",
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

  handleInputChange(event) {
    const target = event.target;
    const value = target.value;
    const name = target.name;

    this.setState({
      [name]: value,
    });
  }

  loadToDo() {
    const id = this.props.match.params.id;

    fetch(`/api/ToDo/${id}`)
      .then((response) => response.json())
      .then((data) => {
        this.setState({ loading: false });
        const toDo = data;

        this.setState({
          title: toDo.title,
          description: toDo.description,
          due: toDo.due.substr(0, 10),
          id: toDo.id,
        });
      });
  }

  render() {
    if (this.state.submitted) return <Redirect to={{ pathname: "/" }} />;
    else if (this.state.submitting || this.state.loading) return <Spinner />;
    return (
      <Form onSubmit={this.handleSubmit}>
        <FormGroup>
          <Label for="title">Title</Label>
          <Input
            type="text"
            name="title"
            id="title"
            maxLength="50"
            required
            value={this.state.title}
            onChange={this.handleInputChange}
          />
        </FormGroup>
        <FormGroup>
          <Label for="description">Description</Label>
          <Input
            type="textarea"
            id="description"
            name="description"
            value={this.state.description}
            onChange={this.handleInputChange}
          />
        </FormGroup>
        <FormGroup>
          <Label for="due">Due Date</Label>
          <Input
            type="date"
            name="due"
            id="due"
            value={this.state.due}
            onChange={this.handleInputChange}
          />
        </FormGroup>
        <Input type="hidden" name="id" value={this.state.id} />
        <Input type="submit" value="Submit" />
      </Form>
    );
  }
}
