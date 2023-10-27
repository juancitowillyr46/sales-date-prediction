import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { IOrderService } from "../domain/ports/order-service.interface";
import { Order } from "../domain/models/order";
import { CreateOrder } from "../domain/models/create-order";

@Injectable()
export class OrderService implements IOrderService {
    constructor(private http: HttpClient) {}

    newOrder(createOrder: CreateOrder): Observable<Order> {
        return this.http.post<Order>(`http://localhost:45406/api/Order`, createOrder);
    }

    getClientOrders(customerId: number): Observable<Order[]>  {
        return this.http.get<Order[]>(`http://localhost:45406/api/Order/${customerId}`);
    }
}