import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BandsComponent } from './bands/bands.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'bands'
  },
  {
    path: 'bands',
    component: BandsComponent
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BandsRoutingModule { }
