import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BandsRoutingModule } from './bands-routing.module';
import { BandsComponent } from './bands/bands.component';
import { MaterialModule } from '../material/material.module';
import { ChildComponent } from './child/child.component';

@NgModule({
  declarations: [BandsComponent, ChildComponent],
  imports: [CommonModule, BandsRoutingModule, MaterialModule],
})
export class BandsModule {}
