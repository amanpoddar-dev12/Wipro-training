import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { FileOpsComponent } from './component/file-ops/file-ops.component';
import { HttpClientModule } from '@angular/common/http';
import { LoginComponent } from './component/login/login.component';
import { RegisterComponent } from './component/register/register.component';
import { UsersComponent } from './component/users/users.component';

@NgModule({
  declarations: [
    AppComponent,
    FileOpsComponent,
    LoginComponent,
    RegisterComponent,
    UsersComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
        
    HttpClientModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }