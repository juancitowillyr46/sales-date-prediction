export interface CreateOrder {
    employeeID: number;
    shipperID: number;
    shipName: string;
    shipAddress: string;
    shipCity: string;
    freight: number;
    shipCountry: string;
    productID: number;
    unitPrice: number;
    qty: number;
    discount: number;
    dateAudit: string;
}