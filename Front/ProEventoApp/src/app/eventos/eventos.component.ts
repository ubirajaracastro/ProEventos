import { Component, OnInit, TemplateRef } from '@angular/core';
import { EventoService } from '../services/Evento.service';
import { Evento } from '../models/Evento';
// import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {
  
  //modalRef: BsModalRef;
  public eventos: Evento[]=[];
  public eventosFiltrados:Evento[]=[];; 
  private _filtroLista: string='';
  

  public get filtroLista():string {
    return this._filtroLista;
  }

  constructor(
    private eventoService: EventoService ) { }  

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
      (eventos: Evento[]) => {
        this.eventos = eventos,
        this.eventosFiltrados = this.eventos;
     },
     error => console.log(error)
     );
  }
     
  // openModal(template: TemplateRef<any>): void {
  //   this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  // }

  // confirm(): void {
    
  //   this.modalRef.hide();
  //   //this.toastr.success('O Evento foi deletado com Sucesso.', 'Deletado!');
  // }

  // decline(): void {
  //   this.modalRef.hide();
  // }
      
   }
