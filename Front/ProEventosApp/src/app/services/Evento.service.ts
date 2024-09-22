import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, take } from 'rxjs';
import { Evento } from './../models/Evento';


@Injectable({
  providedIn: 'root'
})
export class EventoService {
  baseURL = 'https://localhost:5001/api/Evento';

  constructor(private http:HttpClient) { }

  public getEventos(): Observable<Evento[]> {
    return this.http.get<Evento[]>(this.baseURL);
  }

  public getEventosByTema(tema: string): Observable<Evento[]> {
    return this.http.get<Evento[]>(`${this.baseURL}/${tema}/tema`);
  }

  public getEventoById(id: number): Observable<Evento> {
    return this.http.get<Evento>(`${this.baseURL}/${id}`);
    
  }

  public postEvento(evento: Evento): Observable<Evento> {
    return this.http
      .post<Evento>(this.baseURL, evento)
      //.pipe(take(1));
  }

  public putEvento(evento: Evento): Observable<Evento> {
    return this.http
      .put<Evento>(`${this.baseURL}/${evento.id}`, evento)
      .pipe(take(1));
  }

  public deleteEvento(id: number): Observable<any> {
    return this.http
      .delete(`${this.baseURL}/${id}`)
      .pipe(take(1));
  }

  public salvarEvento(evento:Evento, metodo: string): Observable<Evento>{
    return (metodo == 'post') ? this.http.post<Evento>(`${this.baseURL}`,evento) :this.http.put<Evento>(`${this.baseURL}/${evento.id}`, evento);
  }




}
