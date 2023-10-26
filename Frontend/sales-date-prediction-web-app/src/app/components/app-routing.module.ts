import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SalesDatePredictionViewComponent } from './sales-date-prediction-view/sales-date-prediction-view.component';

const routes: Routes = [
  { path: '', redirectTo: '/sales', pathMatch: 'full' },
  { path: 'sales', component: SalesDatePredictionViewComponent }
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}
