import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule} from '@angular/platform-browser';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { ModalModule } from 'ngx-bootstrap/modal';
import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from 'ngx-spinner';
import { AppRoutingModule } from './app-routing.module';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { AppComponent } from './app.component';
import { EventoComponent } from './evento/evento.component';
import { NavbarComponent } from './navbar/navbar.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ContatosComponent } from './contatos/contatos.component';
import { PalestrantesComponent } from './palestrantes/palestrantes.component';
import { PerfilComponent } from './perfil/perfil.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { EventoService } from './services/Evento.service';
import { provideHttpClient,withFetch} from '@angular/common/http';
import { DateTimeFormatPipe } from './helpers/DateTimeFormat.pipe';
import { EventoNovoComponent } from './evento/evento-novo/evento-novo.component';
import { UserComponent } from './user/user.component';
import { LoginComponent } from './user/login/login.component';
import { CriarusuarioComponent } from './user/criarusuario/criarusuario.component';

import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { defineLocale } from 'ngx-bootstrap/chronos';
import { ptBrLocale } from 'ngx-bootstrap/locale';
import { EventoListaComponent } from './evento/evento-lista/evento-lista.component';

defineLocale('pt-br', ptBrLocale);



@NgModule({
  declarations: [	
    AppComponent,    
    EventoComponent,
    NavbarComponent,
    ContatosComponent,
    PalestrantesComponent,
    PerfilComponent,
    DashboardComponent,
    DateTimeFormatPipe,
    DashboardComponent,
    EventoNovoComponent,
    UserComponent,
    LoginComponent,
    CriarusuarioComponent,
    EventoListaComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    CollapseModule.forRoot(),
    ModalModule.forRoot(),
    BsDatepickerModule.forRoot(),
    
    
    ToastrModule.forRoot({
      timeOut: 2000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,      
      
    }),    
    NgxSpinnerModule,
    
  ],
  providers: [
    provideHttpClient(withFetch()),   
    EventoService
    
    
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  bootstrap: [AppComponent]
})
export class AppModule { }
