import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Evento } from '../../models/Evento';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { NgxSpinnerService } from 'ngx-spinner';
import { EventoService } from '../../services/Evento.service';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-evento-novo',
  templateUrl: './evento-novo.component.html',
  styleUrl: './evento-novo.component.scss'
})
export class EventoNovoComponent {
  
  form!: FormGroup;
  evento = {} as Evento;
  estadoSalvar = 'post';
  public userId: any;
  date!: Date;
  
  get f(): any {
    return this.form.controls;
    
  }
  
  constructor(private fb:FormBuilder,  
    private localeService: BsLocaleService,
    private eventoService: EventoService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,
    private router: ActivatedRoute,
  )
  
  {             
    this.localeService.use('pt-br');
    // this.router.params.subscribe(params => this.userId = params['id']);
    // alert(this.userId);
  }  
  
  
  ngOnInit(): void {
    this.carregarEvento();
    this.validation();            
  } 
  
  
  public validation(): void {
    this.form = this.fb.group({
      tema: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      local: ['', Validators.required],
      dataEvento: ['', Validators.required],
      qtdPessoas: ['', [Validators.required, Validators.max(4000)]],
      telefone: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      imagemURL: ['', Validators.nullValidator],
      
    });
    
  }
  
  get bsConfig(): any {
    return {
      adaptivePosition: true,
      dateInputFormat: 'DD/MM/YYYY',
      containerClass: 'theme-default',
      showWeekNumbers: false
    };
  }
  
  
  public resetForm(): void {
    this.form.reset();
  }
  
  
  public validarCampo(campoForm: FormControl): any {
    return {'is-invalid': campoForm.errors && campoForm.touched};
  }
  
  public salvarEvento():void {
    this.spinner.show();
    
    if (this.form.valid) {
      
     this.evento = (this.estadoSalvar === 'post') ? {...this.form.value}: {id: this.evento.id, ...this.form.value};     
      
      this.eventoService.salvarEvento(this.evento,this.estadoSalvar).subscribe(
        () => this.toastr.success('Evento salvo com Sucesso!', 'Sucesso'),
        (error: any) => {
          console.error(error);
          this.spinner.hide();
          this.toastr.error('Error ao salvar evento', 'Erro');
        },
        () => this.spinner.hide()
      );
    }
  }     
  
  public carregarEvento(): void {
    const eventoIdParam = this.router.snapshot.paramMap.get('id');
        
    if (eventoIdParam != null) {
      this.spinner.show();  
      this.estadoSalvar = 'put';
      
      this.eventoService.getEventoById(+eventoIdParam).subscribe(
        (evento: Evento) => {
          this.evento = {...evento};
          this.form.patchValue(this.evento);            
          
        },
        (error: any) => {
          this.spinner.hide();
          this.toastr.error('Erro ao tentar carregar Evento.', 'Erro!');
          console.error(error);
        },
        () => this.spinner.hide(),
      );
    }
  }
  
}



