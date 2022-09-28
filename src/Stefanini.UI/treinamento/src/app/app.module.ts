import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PessoaFormComponent } from './pessoa/pessoa-form/pessoa-form.component';
import { PessoaListComponent } from './pessoa/pessoa-list/pessoa-list.component';
import { CidadeListComponent } from './cidade/cidade-list/cidade-list.component';
import { CidadeFormComponent } from './cidade/cidade-form/cidade-form.component';
import { BreadcrumbComponent } from './shared/breadcrumb/breadcrumb.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { HomeComponent } from './shared/home/home.component';

@NgModule({
  declarations: [
    AppComponent,
    PessoaFormComponent,
    PessoaListComponent,
    CidadeListComponent,
    CidadeFormComponent,
    BreadcrumbComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule 
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
