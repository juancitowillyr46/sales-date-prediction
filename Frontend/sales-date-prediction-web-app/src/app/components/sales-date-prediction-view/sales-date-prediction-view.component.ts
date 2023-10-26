import {AfterViewInit, Component, ViewChild} from '@angular/core';
import {MatTableDataSource} from '@angular/material/table';
import {MatPaginator, MatPaginatorModule} from '@angular/material/paginator';
import {MatSort, MatSortModule} from '@angular/material/sort';

export interface SalePredictionData {
  customerName: string;
  lastOrderDate: string;
  nextPredictedOrder: string;  
}

const NAMES: string[] = [
  'Maia',
  'Asher',
  'Olivia'
];


@Component({
  selector: 'app-sales-date-prediction-view',
  templateUrl: './sales-date-prediction-view.component.html',
  styleUrls: ['./sales-date-prediction-view.component.scss']
})
export class SalesDatePredictionViewComponent {
  displayedColumns: string[] = ['customerName', 'lastOrderDate', 'nextPredictedOrder'];
  dataSource: MatTableDataSource<SalePredictionData>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor() {
    const dataSource = Array.from({length: 20}, (_, k) => createDataSource(k + 1));
    this.dataSource = new MatTableDataSource(dataSource);
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
}
/** Builds and returns a new User. */
function createDataSource(id: number): SalePredictionData {
  const name =
    NAMES[Math.round(Math.random() * (NAMES.length - 1))] +
    ' ' +
    NAMES[Math.round(Math.random() * (NAMES.length - 1))].charAt(0) +
    '.';

  return {
    customerName: name,
    lastOrderDate: '2/4/2023',
    nextPredictedOrder: '2/4/2023'
  };
}