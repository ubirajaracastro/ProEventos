import { Component, OnInit } from '@angular/core';
import { EventoService } from '../services/Evento.service';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {
  
  public eventos: any=[];
  public eventosFiltrados: any=[]; 
  private _filtroLista: string='';
  

  public get filtroLista():string {
    return this._filtroLista;
  }

  constructor(private eventoService: EventoService) { }  

  public set filtroLista(value:string) {
    this._filtroLista = value;
    this.eventosFiltrados=this.filtroLista ? this.filtrarEventos(this.filtroLista): this.eventos; 

  }

  filtrarEventos(filtrarPor: string): any {
    filtrarPor=filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      (   evento: any)=> evento.nome.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
          evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
      );


  }   
     
  ngOnInit(): void {
    this.getEventos();
  }

  public getEventos():void {
    this.eventoService.getEventos().subscribe(
      response => {
      this.eventos = response,
      this.eventosFiltrados = this.eventos;
     },
     error => console.log(error)
     );
  }
     
     
      
  }
