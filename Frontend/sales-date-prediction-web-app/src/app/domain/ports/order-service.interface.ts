import { Observable } from "rxjs";
import { Order } from "../models/order";
import { CreateOrder } from "../models/create-order";

export interface IOrderService {
    getClientOrders(customerId: number): Observable<Order[]>
    newOrder(createOrder: CreateOrder): Observable<Order>
}