import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  constructor(private http:HttpClient) { }

  /*public eventos: any = [
   {
    Tema: 'Angula 12',
    Local: 'Rio de Janeiro',
    Lote: '001'    
   },
   {
    Tema: 'React',
    Local: 'São Paulo',
    Lote: '002'   
   },
   {
    Tema: 'Cloud In World',
    Local: 'Califórnia',
    Lote: '001'   
   },
   {
    Tema: 'Microsoft CoPilot',
    Local: 'Califórnia',
    Lote: '001'    
   }

  ] */

   public eventos: any;
   
  
  ngOnInit(): void {
    this.getEventos();
  }

  public getEventos():void {
    this.http.get("https://localhost:5001/evento").subscribe(
      response => this.eventos=response,
      error =>console.log(error)
    )
    
  

  }

}
