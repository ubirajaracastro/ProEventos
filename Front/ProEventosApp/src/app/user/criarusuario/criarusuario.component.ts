import { Component } from '@angular/core';
import { AbstractControlOptions,FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ValidatorField } from '../../helpers/ValidatorField';

@Component({
  selector: 'app-criarusuario',
  templateUrl: './criarusuario.component.html',
  styleUrl: './criarusuario.component.scss'
})
export class CriarusuarioComponent {
  
  form!: FormGroup;  
  
  constructor(public fb: FormBuilder) {   
    
  }   
  
  get f(): any { return this.form.controls; }
  
  
  ngOnInit(): void {
    this.validation();
  }
  
  private validation(): void {
    
    const formOptions: AbstractControlOptions = {
      validators: ValidatorField.MustMatch('senha', 'confirmeSenha')
    };
    
    this.form = this.fb.group({
      primeiroNome: ['', Validators.required],
      ultimoNome: ['', Validators.required],
      email: ['',
        [Validators.required, Validators.email]
      ],
      userName: ['', Validators.required],
      senha: ['',
        [Validators.required, Validators.minLength(6)]
      ],
      confirmeSenha: ['', Validators.required],
    }, formOptions);
  }
  
}







