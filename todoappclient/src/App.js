import React, { useState, useEffect } from "react";

export default function App() {
  const [todos, setTodos] = useState([]);

  useEffect(() => {
    getTodos();
  }, []);

  function getTodos() {
    const apiUrl = "https://localhost:7272/get-all-todos";

    fetch(apiUrl, {
      method: "GET",
    })
      .then((response) => response.json())
      .then((todosFromServer) => {
        console.log(todosFromServer);
        setTodos(todosFromServer);
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
        {todos.length > 0 && renderTodoItems()}
      </div>
    </div>
  );

  function renderTodoItems() {
    return (
      <div className="table-responsive">
        <table className="table table-hover">
          <thead>
            <tr>
              <th scope="col">State</th>
              <th scope="col">Todos</th>
              <th scope="col">Actions</th>
            </tr>
          </thead>
          <tbody>
            {todos.map((todo) => (
              <tr key={todo.todoID}>
                <td>
                  <input
                    className="form-check-input"
                    type="checkbox"
                    defaultChecked={todo.todoIsFinished}
                  />
                </td>
                <td scope="row">{todo.todoTitel}</td>
                <td scope="row">
                  <button type="button" className="btn btn-danger">
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
}
