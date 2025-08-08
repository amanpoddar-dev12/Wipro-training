import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { FileOpsComponent } from './component/file-ops/file-ops.component';
import { HttpClientModule } from '@angular/common/http';
import { LoginComponent } from './component/login/login.component';
import { RegisterComponent } from './component/register/register.component'; // standalone

@NgModule({
  declarations: [
    AppComponent,
    FileOpsComponent,
    LoginComponent 
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RegisterComponent 
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
