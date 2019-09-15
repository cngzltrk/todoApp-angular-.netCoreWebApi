import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TodoService {

  constructor(
    private http:HttpClient
  ) { }
  
  getAllTodos()
  {
    return this.http.get('https://localhost:5001/api/todos')
  }
  updateTodo(obj)
  {
    return this.http.post('https://localhost:5001/api/todos',obj);
  }


}
