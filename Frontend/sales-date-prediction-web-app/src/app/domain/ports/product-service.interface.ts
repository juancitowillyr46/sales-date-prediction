import { Observable } from "rxjs";
import { Product } from "../models/product";

export interface IProductService {
    getProducts(): Observable<Product[]>
}