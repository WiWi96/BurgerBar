import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BunsComponent } from './buns.component';

describe('BunsComponent', () => {
  let component: BunsComponent;
  let fixture: ComponentFixture<BunsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BunsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BunsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
