import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { OrdersViewComponent } from '../orders-view/orders-view.component';
import { OrderFormComponent } from '../order-form/order-form.component';
import { CustomerService } from 'src/app/adapters/customer-service.impl';
import { Customer } from 'src/app/domain/models/customer';

@Component({
  selector: 'app-sales-date-prediction-view',
  templateUrl: './sales-date-prediction-view.component.html',
  styleUrls: ['./sales-date-prediction-view.component.scss']
})
export class SalesDatePredictionViewComponent {
  displayedColumns: string[] = ['customerName', 'lastOrderDate', 'nextPredictedOrder', 'id'];
  dataSource!: MatTableDataSource<Customer>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(public dialog: MatDialog, private readonly customerService: CustomerService) {
    this.customerService.getSaleDatePrediction().subscribe(res => {
      this.dataSource = new MatTableDataSource(res);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }

  public applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  public viewOrder(customer: Customer) {
    this.openTableModal(customer);
  }

  public newOrder(customer: Customer) {
    this.openFormModal(customer);
  }

  public openTableModal(customer: Customer) {
    const dialogRef = this.dialog.open(OrdersViewComponent, {
      width: '80%',
      data: customer
    });
  }

  public openFormModal(customer: Customer) {
    const dialogRef = this.dialog.open(OrderFormComponent, {
      width: '45%',
      data: customer
    });
  }

}