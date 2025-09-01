import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class JobService {
  private baseUrl = 'http://localhost:5092/api/jobpostings';

  constructor(private http: HttpClient) {}

  getJobs() {
    return this.http.get<any[]>(this.baseUrl);
  }

  addJob(job: any) {
    return this.http.post(this.baseUrl, job);
  }
}
