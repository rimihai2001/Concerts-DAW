import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BandsRoutingModule } from './bands-routing.module';
import { BandsComponent } from './bands/bands.component';
import { MaterialModule } from '../material/material.module';

@NgModule({
  declarations: [BandsComponent],
  imports: [CommonModule, BandsRoutingModule, MaterialModule],
})
export class BandsModule {}
