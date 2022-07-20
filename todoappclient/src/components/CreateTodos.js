import React, { useState } from "react";
import todosApi from "../api/todosApi";

export default function CreateTodos(props) {
  const initialFormData = Object.freeze({
    todoTitle: "",
  });
  const [formData, setFormData] = useState(initialFormData);

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value,
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    // Validating the form (the new todo item)

    // Check if the field is Empty
    if (formData.todoTitle.trim() === "" || null) {
      alert("The field can't be Empty !!!!");
      return;
    }
    // Check if the field has more than 10 Characters (and numbers)
    if (!formData.todoTitle.match(/^([a-zA-Z0-9\s*]{11,})$/)) {
      alert("Please enter more than 10 characters in the field !!!!");
      return;
    }
    // if everything is OK then...
    const todoToCreate = {
      todoID: 0, // The backend will handle this and change it to the right number
      todoTitle: formData.todoTitle,
      todoIsFinished: true,
    };

    console.log("todoToCreate from CreateTodos.js", todoToCreate);

    const apiUrl = todosApi.API_URL_CREATE_TODO;

    fetch(apiUrl, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(todoToCreate),
    })
      .then((response) => response.json())
      .then((responseFromServer) => {
        console.log(responseFromServer);
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });

    props.onTodoCreated(todoToCreate);
  };

  return (
    <form className="w-100 px-5">
      <div className="input-group">
        <input
          type="text"
          name="todoTitle"
          placeholder="Create a Todo Item"
          className="form-control"
          onChange={handleChange}
        />
        <div className="input-group-append">
          <button
            onClick={handleSubmit}
            className="btn btn-outline btn-primary"
          >
            Create
          </button>
        </div>
      </div>
    </form>
  );
}
