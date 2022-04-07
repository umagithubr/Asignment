import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { HttpHeaders } from '@angular/common/http';
import { Employee } from './employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeedetailsService {

  url = 'https://localhost:44306';
  constructor(private http: HttpClient) { }
  createEmployee(employee: Employee): Observable<Employee> {
       
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json', }), responseType: 'text' as 'json' };
    return this.http.post<Employee>(this.url + '/Employee/', employee, httpOptions);
    
  }
  
}
