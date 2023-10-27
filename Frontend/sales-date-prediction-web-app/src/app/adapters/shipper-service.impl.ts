import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { IShipperService } from "../domain/ports/shipper-service.interface";
import { Shipper } from "../domain/models/shipper";

@Injectable()
export class ShipperService implements IShipperService {
    constructor(private http: HttpClient) {}

    getShippers(): Observable<Shipper[]> {
        return this.http.get<Shipper[]>('http://localhost:45406/api/shipper');
    }
}