import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ConnectComponent } from './components/connect/connect.component';
import { LoginComponent } from './components/login/login.component';
import { PageTripsComponent } from './components/page-trips/page-trips.component';
import { PrivateComponent } from './components/private/private.component';
import { MoreDetailsComponent } from './components/more-details/more-details.component';
import { UsersComponent } from './components/users/users.component';
import { WeTripsComponent } from './components/we-trips/we-trips.component';
import { HomePageComponent } from './components/home-page/home-page.component';
import { SignOutComponent } from './components/sign-out/sign-out.component';
import { GaleryComponent } from './components/galery/galery.component';
import { EditTripComponent } from './components/edit-trip/edit-trip.component';
//ניתובים עבור התפריט
const routes: Routes = [
  {path:'גלריה',component:GaleryComponent},
{path:'התנתקות',component:SignOutComponent},
{path:'דף הבית',component:HomePageComponent},
{path:'כניסה', component:ConnectComponent},
{path:'הרשמה', component:LoginComponent},
{path:'לטיולים שלנו', component:PageTripsComponent},
{path:'איזור אישי', component:PrivateComponent},
{path:'פרטי טיול', component:MoreDetailsComponent},
{path:'המשתמשים שלנו', component:UsersComponent},
{path:'כל הטיולים', component:WeTripsComponent},
{path:'עריכת פרטים אישיים', component:LoginComponent},
{path:'עריכת טיול',component:EditTripComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
