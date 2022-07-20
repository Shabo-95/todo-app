const TODO_API_URL = "https://localhost:7272";

const ENDPOINTS = {
  GET_ALL_TODOS: "get-all-todos",
  GET_TODO_BY_ID: "get-todo-by-id",
  CREATE_TODO: "create-todo",
  UPDATE_TODO: "update-todo",
  DELETE_TODO_BY_ID: "delete-todo-by-id",
};

const development = {
  API_URL_GET_ALL_TODOS: `${TODO_API_URL}/${ENDPOINTS.GET_ALL_TODOS}`,
  API_URL_GET_TODO_BY_ID: `${TODO_API_URL}/${ENDPOINTS.GET_TODO_BY_ID}`,
  API_URL_CREATE_TODO: `${TODO_API_URL}/${ENDPOINTS.CREATE_TODO}`,
  API_URL_UPDATE_TODO: `${TODO_API_URL}/${ENDPOINTS.UPDATE_TODO}`,
  API_URL_DELETE_TODO_BY_ID: `${TODO_API_URL}/${ENDPOINTS.DELETE_TODO_BY_ID}`,
};

const todosApi = development;

export default todosApi;
