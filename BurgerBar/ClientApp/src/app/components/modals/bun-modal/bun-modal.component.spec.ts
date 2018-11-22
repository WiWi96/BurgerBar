import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BunModalComponent } from './bun-modal.component';

describe('BunModalComponent', () => {
  let component: BunModalComponent;
  let fixture: ComponentFixture<BunModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BunModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BunModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
