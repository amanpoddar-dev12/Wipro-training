import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class Dataservice {
  

  constructor(private http: HttpClient) { }

  getUser(id: number) {
    return this.http.get('http://localhost:3000/users/' + id); // for all users
   // return this.http.get('http://localhost:3000/users/'+id); // for single user
  }

  getUsers() {
    return this.http.get('http://localhost:3000/users/'); // for all users
  }

  addUser(user : any) {
    return this.http.post('http://localhost:3000/users/', user); // for all users
  }

  updateUser(user : any, id: number) {
    return this.http.put('http://localhost:3000/users/' + id, user); // for all users
  }

  deleteUser(id: number) {
    return this.http.delete('http://localhost:3000/users/' + id); // for  all users
  }

  patchUser(user : any, id: number) {
    return this.http.patch('http://localhost:3000/users/' + id, user); // for all users
  }

}
