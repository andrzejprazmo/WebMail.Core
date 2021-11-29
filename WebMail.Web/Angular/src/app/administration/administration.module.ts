import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdministrationComponent } from './components/administration/administration.component';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [
    AdministrationComponent
  ],
  imports: [
    CommonModule, SharedModule
  ]
})
export class AdministrationModule { }
