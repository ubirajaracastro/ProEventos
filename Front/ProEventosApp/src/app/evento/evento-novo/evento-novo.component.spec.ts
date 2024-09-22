import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EventoNovoComponent } from './evento-novo.component';

describe('EventoNovoComponent', () => {
  let component: EventoNovoComponent;
  let fixture: ComponentFixture<EventoNovoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [EventoNovoComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EventoNovoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
