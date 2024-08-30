import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  urlBaseApi: string = "https://localhost:5001/";

  public eventos: any=[];
  public eventosFiltrados: any=[]; 
  private _filtroLista: string='';
  

  public get filtroLista():string {
    return this._filtroLista;
  }

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
  constructor(private http:HttpClient) { }  
     
  ngOnInit(): void {
    this.getEventos();
  }

  public getEventos():void {
    this.http.get(this.urlBaseApi + "evento").subscribe(      
      response => {
        this.eventos=response,
        this.eventosFiltrados=this.eventos
      },
      error =>console.log(error)
    )
  

  }

}
