import { Observable } from "rxjs";
import { Shipper } from "../models/shipper";

export interface IShipperService {
    getShippers(): Observable<Shipper[]>
}