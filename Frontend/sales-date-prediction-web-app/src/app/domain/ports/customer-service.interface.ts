import { Observable } from "rxjs";
import { Customer } from "../models/customer";

export interface ICustomerService {
    getSaleDatePrediction(): Observable<Customer[]>
}