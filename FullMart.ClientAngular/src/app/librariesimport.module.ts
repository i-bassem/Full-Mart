import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {PasswordModule} from 'primeng/password';
import {ChipsModule} from 'primeng/chips';
import {CalendarModule} from 'primeng/calendar';
import {ChartModule} from 'primeng/chart';
import {ToastModule} from 'primeng/toast';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule} from '@angular/material/icon';
import { MatProgressBarModule} from '@angular/material/progress-bar';



import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  exports:[
    BrowserAnimationsModule,PasswordModule,ChipsModule,CalendarModule,ChartModule,ToastModule,MatSlideToggleModule,
    MatButtonModule, MatIconModule, MatProgressBarModule, HttpClientModule
  ]
})
export class LibrariesimportModule { }
