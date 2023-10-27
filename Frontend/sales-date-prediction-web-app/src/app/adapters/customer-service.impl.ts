import { Observable } from "rxjs";
import { ICustomerService } from "../domain/ports/customer-service.interface";
import { Customer } from "../domain/models/customer";
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable()
export class CustomerService implements ICustomerService {
    constructor(private http: HttpClient) {}

    getSaleDatePrediction(): Observable<Customer[]>  {
        return this.http.get<Customer[]>('http://localhost:45406/api/customer');
    }
}