import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class DataserviceService {
  
  constructor(private http:HttpClient) { }
  getUser(id: number) { 
    return this.http.get('http://localhost:3000/users/'+id);
  }
  getUsers() {
    return this.http.get('http://localhost:3000/users');
  }
  addUser(user: any) {
    return this.http.post('http://localhost:3000/users', user);
  }
  updateUser(id: number, user: any) {
    return this.http.put('http://localhost:3000/users/'+id, user);
  }
  deleteUser(id: number) {
    return this.http.delete('http://localhost:3000/users/'+id);
  }
  patchUser(id: number, user: any) {
    return this.http.patch('http://localhost:3000/users/'+id, user);
}
}