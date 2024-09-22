import { Component, OnInit,TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Evento } from '../models/Evento';
import { EventoService } from '../services/Evento.service';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { Router } from '@angular/router';

@Component({
  selector: 'app-evento',
  templateUrl: './evento.component.html',
  styleUrl: './evento.component.scss'
})
export class EventoComponent {
  
  modalRef = {} as BsModalRef;
  public eventos: Evento[] = [];
  public eventoId = 0;
  public eventosFiltrados: Evento[] = [];
  public larguraImagem = 150;
  public margemImagem = 2;
  public exibirImagem = true;
  private filtroListado = '';
  
  constructor(private eventoService: EventoService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private router: Router) 
    { }  
    
    
    public ngOnInit(): void {      
     
      this.spinner.show();
      this.getEventos();
      
      setTimeout(() => {
        /** spinner ends after 5 seconds */
       
      }, 2000);
      
      
      
    }
    
    public alterarImagem(): void {
      this.exibirImagem = !this.exibirImagem;
    }
    
    
    public getEventos(): void {
      this.eventoService.getEventos().subscribe({
        next: (eventos: Evento[]) => {
          this.eventos = eventos;
          this.eventosFiltrados = this.eventos;
        },
        error: (error: any) => {
          this.spinner.hide();
          this.toastr.error('Erro ao Carregar os Eventos', 'Erro!');
        },
        complete: () => this.spinner.hide()
      });
    }
    
    public get filtroLista(): string {
      return this.filtroListado;
    }
    
    public set filtroLista(value: string) {
      this.filtroListado = value;
      this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
    }
    
    public filtrarEventos(filtrarPor: string): Evento[] {
      filtrarPor = filtrarPor.toLocaleLowerCase();
      return this.eventos.filter(
        evento => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
        evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
      );
    }
    
    openModal(event: any, template: TemplateRef<void>,eventoId:number) {
      event.stopPropagation();
      this.eventoId = eventoId;
      this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
    }
    
    confirm(): void {
      this.modalRef.hide();
      this.spinner.show();

      this.eventoService.deleteEvento(this.eventoId).subscribe(
        (result: any) => {
          if (result.message === 'Deletado') {
            this.toastr.success('O Evento foi deletado com Sucesso.', 'Deletado!');           
            this.getEventos();
          }
        },
        (error: any) => {
          console.error(error);
          this.toastr.error(`Erro ao tentar deletar o evento ${this.eventoId}`, 'Erro'); 
          this.spinner.hide();        
        },
        () => this.spinner.hide(),
      );
      
    }
  
    
    decline(): void {
      this.modalRef.hide();
    }
    
    detalheEvento(id: number): void{
      this.router.navigate([`evento/novo/${id}`]);
    }
    
  }
  
  
  
  
  
  
  
  
  
  
  