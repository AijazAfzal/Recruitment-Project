import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class QuizService {

  constructor(private http: HttpClient) { }

  get(url: string) {
    return this.http.get<any>(url);
  }
 
  post(url: string,data:any) {
    return this.http.post(url,data);
  }
}
