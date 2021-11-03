import React, { Component } from "react";
import { Button, Modal, ModalBody, ModalFooter, ModalHeader } from "reactstrap";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faTrashAlt } from "@fortawesome/free-solid-svg-icons";

export class Delete extends Component {
  constructor(props) {
    super(props);

    this.handleDelete = this.handleDelete.bind(this);

    this.state = {
      modal: false,
    };
  }

  handleDelete() {
    var p = this.props;
    var id = p.id;

    fetch(`/api/ToDo/${id}`, {
      method: "DELETE",
    }).then((response) => {
      if (response.status === 200) {
        p.onDelete();
      } else {
        alert("There was a problem");
      }
    });
  }

  toggle = () => {
    this.setState({
      modal: !this.state.modal,
    });
  };

  render() {
    return (
      <div>
        <FontAwesomeIcon onClick={this.toggle} icon={faTrashAlt} />
        <Modal isOpen={this.state.modal} toggle={this.toggle}>
          <ModalHeader>Delete</ModalHeader>
          <ModalBody>Do you want to delete this to do?</ModalBody>
          <ModalFooter>
            <Button onClick={this.toggle} color="primary" outline>
              Cancel
            </Button>
            <Button onClick={this.handleDelete} color="danger">
              Confirm
            </Button>
          </ModalFooter>
        </Modal>
      </div>
    );
  }
}
