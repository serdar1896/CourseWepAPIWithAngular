import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { StatisticComponent } from './pages/statistic/statistic.component';
import { ControlComponent } from './pages/control/control.component';
import { UserComponent } from './pages/user/user.component';

const routes: Routes = [
  { path: '', component: DashboardComponent },
  { path: 'statistic/:id', component: StatisticComponent },
  { path: 'control/:id', component: ControlComponent },
  { path: 'user/:id', component: UserComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {
    initialNavigation: 'enabled'
})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
