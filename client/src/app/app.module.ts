import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomePageComponent } from './components/home-page/home-page.component';
import { PrivateComponent } from './components/private/private.component';
import { PageTripsComponent } from './components/page-trips/page-trips.component';
import { LoginComponent } from './components/login/login.component';
import { ConnectComponent } from './components/connect/connect.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { MoreDetailsComponent } from './components/more-details/more-details.component';
import { UsersComponent } from './components/users/users.component';
import { WeTripsComponent } from './components/we-trips/we-trips.component';
import { GaleryComponent } from './components/galery/galery.component';
import { SignOutComponent } from './components/sign-out/sign-out.component';
import { EditTripComponent } from './components/edit-trip/edit-trip.component';
import { DatePipe } from '@angular/common';


@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    PrivateComponent,
    PageTripsComponent,
    LoginComponent,
    ConnectComponent,
    MoreDetailsComponent,
    UsersComponent,
    WeTripsComponent,
    GaleryComponent,
    SignOutComponent,
    EditTripComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule, 
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
