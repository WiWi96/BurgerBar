import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BurgerModalComponent } from './burger-modal.component';

describe('BurgerModalComponent', () => {
  let component: BurgerModalComponent;
  let fixture: ComponentFixture<BurgerModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BurgerModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BurgerModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
