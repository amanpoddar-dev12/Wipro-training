import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Todo } from '../models/todo.model';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class TodoService {
  private readonly baseUrl = 'http://localhost:3000';

  constructor(private http: HttpClient) {}

  getTodos(): Observable<Todo[]> {
    return this.http.get<Todo[]>(`${this.baseUrl}/todos`);
  }

  addTodo(title: string): Observable<Todo> {
    return this.http.post<Todo>(`${this.baseUrl}/todos`, { title });
  }

  updateTodo(id: string, patch: Partial<Pick<Todo, 'title' | 'completed'>>): Observable<Todo> {
    return this.http.put<Todo>(`${this.baseUrl}/todos/${id}`, patch);
  }

  deleteTodo(id: string): Observable<Todo> {
    return this.http.delete<Todo>(`${this.baseUrl}/todos/${id}`);
  }
}
