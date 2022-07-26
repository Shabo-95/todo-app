import React, { useState, useEffect } from "react";
import todosApi from "./api/todosApi";
import CreateTodos from "./components/CreateTodos";

export default function App() {
  var day = new Date().getDate(); //To get the Current Date
  var month = new Date().getMonth() + 1; //To get the Current Month
  var year = new Date().getFullYear(); //To get the Current Year

  var currentDate = year + "-" + month + "-" + day; // Today's date

  const [todos, setTodos] = useState([]);

  useEffect(() => {
    getTodos();
  }, []);

  // Get all todos
  function getTodos() {
    const apiUrl = todosApi.API_URL_GET_ALL_TODOS;

    fetch(apiUrl, {
      method: "GET",
    })
      .then((response) => response.json())
      .then((todosFromServer) => {
        setTodos(todosFromServer);
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });
  }

  // Delete todo by id
  function deleteTodo(todoID) {
    const apiUrl = `${todosApi.API_URL_DELETE_TODO_BY_ID}/${todoID}`;

    fetch(apiUrl, {
      method: "DELETE",
    })
      .then((response) => response.json())
      .then((responseFromServer) => {
        console.log(responseFromServer);
        onTodoDeleted(todoID);
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });
  }

  // Update a todo item
  function updateTodo(todo) {
    const todoToUpdate = {
      todoID: todo.todoID,
      todoTitle: todo.todoTitle,
      todoDeadline: todo.todoDeadline,
      todoIsFinished: !todo.todoIsFinished, // Reverse the state
    };

    const apiUrl = todosApi.API_URL_UPDATE_TODO;

    fetch(apiUrl, {
      method: "PUT",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(todoToUpdate),
    })
      .then((response) => response.json())
      .then((responseFromServer) => {
        console.log(responseFromServer);
        onTodoUpdated();
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });
  }

  return (
    <div className="container">
      <div className="row min-vh-100">
        <div className="col d-flex flex-column justify-content-center align-items-center">
          <h1>ASP.NET & React ToDo App</h1>
        </div>
        <CreateTodos onTodoCreated={onTodoCreated} />
        {todos.length > 0 && renderTodoItems()}
      </div>
    </div>
  );

  function renderTodoItems() {
    return (
      <div className="table-responsive px-5">
        <table className="table table-hover">
          <thead>
            <tr>
              <th scope="col">Finished</th>
              <th scope="col">Todos</th>
              <th scope="col">Deadline</th>
              <th scope="col">Actions</th>
            </tr>
          </thead>
          <tbody>
            {todos.map((todo) => (
              <tr
                key={todo.todoID}
                className={
                  todo.todoIsFinished
                    ? "table-success"
                    : new Date(todo.todoDeadline) < new Date(currentDate)
                    ? "table-danger"
                    : ""
                }
              >
                <td>
                  <input
                    className="form-check-input"
                    type="checkbox"
                    role="button"
                    defaultChecked={todo.todoIsFinished}
                    onChange={() => {
                      updateTodo(todo);
                    }}
                  />
                </td>
                <td>{todo.todoTitle}</td>
                <td>{todo.todoDeadline}</td>
                <td>
                  <button
                    className="btn btn-danger"
                    onClick={() => {
                      deleteTodo(todo.todoID);
                    }}
                  >
                    Delete
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    );
  }

  function onTodoCreated(createdTodo) {
    if (createdTodo === null) {
      return;
    }

    alert("New todo item is created successfuly !!");

    getTodos(); // Rerender the todo list
  }

  function onTodoDeleted(deletedTodoID) {
    let todosArrayCopy = [...todos];

    const index = todosArrayCopy.findIndex(
      (todosArrayCopyItem, currentIndex) => {
        if (todosArrayCopyItem.todoID === deletedTodoID) {
          return true;
        }
      }
    );

    if (index !== -1) {
      todosArrayCopy.splice(index, 1);
    }

    setTodos(todosArrayCopy);

    alert("Todo item is deleted successfuly !!");
  }

  function onTodoUpdated() {
    getTodos(); // Rerender the todo list

    //alert("Todo item is updated successfuly !!");
  }
}
