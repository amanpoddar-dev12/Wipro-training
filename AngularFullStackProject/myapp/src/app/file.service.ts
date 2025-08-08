import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class FileService {
  private baseUrl = 'http://localhost:5000';

  constructor(private http: HttpClient) {}

  write(content: string) {
    return this.http.post<{ message: string }>(`${this.baseUrl}/write`, { content });
  }

  read() {
    return this.http.get<{ content: string }>(`${this.baseUrl}/read`);
  }

  delete() {
    return this.http.delete<{ message: string }>(`${this.baseUrl}/delete`);
  }

  rename(newName: string) {
    return this.http.post<{ message: string }>(`${this.baseUrl}/rename`, { newName });
  }
}
