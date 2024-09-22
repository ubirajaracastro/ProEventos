import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EventoComponent } from './evento/evento.component';
import { PalestrantesComponent } from './palestrantes/palestrantes.component';
import { ContatosComponent } from './contatos/contatos.component';
import { PerfilComponent } from './perfil/perfil.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { EventoNovoComponent } from './evento/evento-novo/evento-novo.component';
import { UserComponent } from './user/user.component';
import { LoginComponent } from './user/login/login.component';
import { CriarusuarioComponent } from './user/criarusuario/criarusuario.component';
import { EventoListaComponent } from './evento/evento-lista/evento-lista.component';

const routes: Routes = [
  
  { path: 'user', component: UserComponent,
    
    children: [
      { path: 'login', component: LoginComponent },
      { path: 'criarusuario', component: CriarusuarioComponent },            
    ]
  },  
  
  { path: 'evento', redirectTo: 'evento/lista' },

  {
    path: 'evento', component: EventoComponent,
    children: [
      { path: 'novo', component: EventoNovoComponent },
      { path: 'novo/:id', component: EventoNovoComponent },
      { path: 'lista', component: EventoListaComponent },

     
    ],
  },

  { path: 'dashboard', component: DashboardComponent },
  { path: 'palestrantes', component: PalestrantesComponent },
  { path: 'contatos', component: ContatosComponent },
  { path: 'perfil', component: PerfilComponent },
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  { path: '**', redirectTo: 'dashboard', pathMatch: 'full' },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
