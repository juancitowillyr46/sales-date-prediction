import { Observable } from "rxjs";
import { Customer } from "../domain/models/customer";
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { IEmployeeService } from "../domain/ports/employee-service.interface";
import { Employee } from "../domain/models/employee";

@Injectable()
export class EmployeeService implements IEmployeeService {
    constructor(private http: HttpClient) {}

    getEmployees(): Observable<Employee[]> {
        return this.http.get<Employee[]>('http://localhost:45406/api/employee');
    }
}