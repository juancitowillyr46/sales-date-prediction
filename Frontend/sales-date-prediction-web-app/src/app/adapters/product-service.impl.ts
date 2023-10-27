import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { IProductService } from "../domain/ports/product-service.interface";
import { Product } from "../domain/models/product";

@Injectable()
export class ProductService implements IProductService {
    constructor(private http: HttpClient) {}
    getProducts(): Observable<Product[]> {
        return this.http.get<Product[]>('http://localhost:45406/api/product');
    }
}