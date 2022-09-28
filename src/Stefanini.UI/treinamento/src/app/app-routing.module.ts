import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CidadeFormComponent } from './cidade/cidade-form/cidade-form.component';
import { CidadeListComponent } from './cidade/cidade-list/cidade-list.component';
import { PessoaFormComponent } from './pessoa/pessoa-form/pessoa-form.component';
import { PessoaListComponent } from './pessoa/pessoa-list/pessoa-list.component';
import { HomeComponent } from './shared/home/home.component';

const routes: Routes = [
  {
    path:'', component: HomeComponent
  },
  {
    path:'pessoa', component: PessoaListComponent
  },
  {
    path:'pessoa-nova', component: PessoaFormComponent
  },
  {
    path:'pessoa/editar/:id', component: PessoaFormComponent
  },
  {
    path:'cidade', component: CidadeListComponent
  },
  {
    path:'cidade-nova', component: CidadeFormComponent
  },
  {
    path:'cidade/editar/:id', component: CidadeFormComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
