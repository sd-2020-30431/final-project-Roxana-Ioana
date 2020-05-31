import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserComponent } from './user/user.component';
import { RegistrationComponent } from './registration/registration.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './auth/auth.guard';
import { ProductComponent } from './product/product.component';
import { CommandComponent } from './command/command.component';


const routes: Routes = [
  {path:'',redirectTo:'/user/login',pathMatch:'full'},
{
  path: 'user', component: UserComponent,
  children: [
    { path: 'registration', component: RegistrationComponent },
    { path: 'login', component: LoginComponent }
  ]
},
{path:'home',component:HomeComponent, canActivate:[AuthGuard]},
{path:'products', component:ProductComponent},
{path:'command/:idUser', component:CommandComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
