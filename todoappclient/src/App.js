import React from "react";

export default function App() {
  return (
    <div className="container">
      <div className="row min-vh-100">
        <div className="col d-flex flex-column justify-content-center align-items-center">
          <h1>ASP.NET & React ToDo App</h1>
        </div>
        {renderTodoItems()}
      </div>
    </div>
  );

  function renderTodoItems() {
    return (
      <div className="table-responsive">
        <table className="table table-bordered table-hover">
          <thead>
            <tr>
              <th scope="col">State</th>
              <th scope="col">Todos</th>
              <th scope="col">Actions</th>
            </tr>
          </thead>
          <tbody>
            <tr>
              <td scope="row">Finished</td>
              <td scope="row">Todo Item 1</td>
              <td scope="row">
                <button type="button" class="btn btn-danger">
                  Delete
                </button>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    );
  }
}
