import { Observable } from "rxjs";
import { Customer } from "../models/customer";
import { Employee } from "../models/employee";

export interface IEmployeeService {
    getEmployees(): Observable<Employee[]>
}