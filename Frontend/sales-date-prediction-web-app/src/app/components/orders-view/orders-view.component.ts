import { Component, ViewChild, Inject } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';
import { CustomerService } from 'src/app/adapters/customer-service.impl';
import { OrderService } from 'src/app/adapters/order-service.impl';
import { Customer } from 'src/app/domain/models/customer';
import { Order } from 'src/app/domain/models/order';

@Component({
  selector: 'app-orders-view',
  templateUrl: './orders-view.component.html',
  styleUrls: ['./orders-view.component.scss']
})
export class OrdersViewComponent {
  public nameCustomer: string;
  displayedColumns: string[] = ['orderId', 'requiredDate', 'shippedDate', 'shipName', 'shipAddress', 'shipCity'];
  dataSource!: MatTableDataSource<Order>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    public dialog: MatDialog,
    private dialogRef: MatDialogRef<OrdersViewComponent>,
    @Inject(MAT_DIALOG_DATA) public customer: Customer,
    private readonly orderService: OrderService
  ) {
    this.nameCustomer = customer.customerName;
    this.orderService.getClientOrders(customer.id).subscribe( res => {
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

  public closeModal(): void {
    this.dialog.closeAll();
  }

}