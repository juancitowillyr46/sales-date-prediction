import { Component, Inject } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import * as moment from 'moment';
import { EmployeeService } from 'src/app/adapters/employee-service.impl';
import { OrderService } from 'src/app/adapters/order-service.impl';
import { ProductService } from 'src/app/adapters/product-service.impl';
import { ShipperService } from 'src/app/adapters/shipper-service.impl';
import { Customer } from 'src/app/domain/models/customer';
import { Employee } from 'src/app/domain/models/employee';
import { Product } from 'src/app/domain/models/product';
import { Shipper } from 'src/app/domain/models/shipper';

@Component({
  selector: 'app-order-form',
  templateUrl: './order-form.component.html',
  styleUrls: ['./order-form.component.scss']
})
export class OrderFormComponent {
  public nameCustomer: string;
  public form: FormGroup;
  public employees: Employee[] = [];
  public shippers: Shipper[] = [];
  public products: Product[] = [];
  constructor(
    public dialog: MatDialog, 
    private formBuilder: FormBuilder, 
    private _snackBar: MatSnackBar,
    private readonly orderService: OrderService,
    private readonly employeeService: EmployeeService,
    private readonly shipperService: ShipperService,
    private readonly productService: ProductService,
    @Inject(MAT_DIALOG_DATA) public customer: Customer,
  ) {
    this.nameCustomer = this.customer.customerName;

    this.form = this.formBuilder.group({
      employeeID: ['', [Validators.required]],
      shipperID: ['', [Validators.required]],
      shipName: ['', [Validators.required]],
      shipAddress: ['', [Validators.required]],
      shipCity: ['', [Validators.required]],
      shipCountry: ['', [Validators.required]],
      freight: ['', [Validators.required]],
      productID: ['', [Validators.required]],
      unitPrice: ['', [Validators.required]],
      qty: ['', [Validators.required]],
      discount: ['', [Validators.required]],
    });

    this.employeeService.getEmployees().subscribe(res => {
      this.employees = res;
    });

    this.shipperService.getShippers().subscribe(res => {
      this.shippers = res;
    });

    this.productService.getProducts().subscribe(res => {
      this.products = res;
    });
  }
  closeModal(): void {
    this.dialog.closeAll();
  }
  save() {
    if (this.form.valid) {
      this.form.value['dateAudit'] = moment(new Date(), "YYYY-MM-DDT00:00:00");
      this.orderService.newOrder(this.form.value).subscribe( res => {
        console.log(res);
        this.openSnackBar("Successfully registered order");
      });
    }
  }

  get f(): { [key: string]: AbstractControl } {
    return this.form.controls;
  }

  openSnackBar(message: string) {
    this._snackBar.open(message);
  }
}
