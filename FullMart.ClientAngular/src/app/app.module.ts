import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CoreModule } from './core/core.module';
import { SharedModule } from './shared/shared.module';
import { LibrariesComponent } from './Libraries/libraries.component';
import { HomeComponent } from './home/home.component';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { AboutUsComponent } from './about-us/about-us.component';
import { NotFoundComponent } from './Not-found/not-found.component';
import { AppRoutingModule } from './app-routing.module';
import { LibrariesimportModule } from './Libraries/librariesimport.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FullMartModulesModule } from './Full-mart-modules/full-mart-modules.module';
import { SpinnerComponent } from './Spinner/spinner.component';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { LoadingInterceptor } from './Interceptor/loading.interceptor';


@NgModule({
  declarations: [
    AppComponent,LibrariesComponent, HomeComponent, ContactUsComponent, 
    AboutUsComponent, NotFoundComponent, SpinnerComponent 
  ],
  imports: [
    BrowserModule, FormsModule, CoreModule, SharedModule,AppRoutingModule, 
    BrowserAnimationsModule, ReactiveFormsModule, LibrariesimportModule, FullMartModulesModule
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }