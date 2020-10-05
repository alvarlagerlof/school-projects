// Needed to redefine because of ts-node shit
const fetchStuff = require("node-fetch");

interface Todo {
  userId: number;
  id: number;
  title: string;
  completed: boolean;
}

fetchStuff("https://jsonplaceholder.typicode.coma/todos")
  .then((response) => {
    if (!response.ok) {
      throw Error(response.statusText);
    }
    return response;
  })
  .then((res) => res.json())
  .then((todos: Array<Todo>) => {
    todos.forEach((item) => console.log(item));
  })
  .catch((e) => {
    console.log(e.message);
  });
