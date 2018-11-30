import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfiguratorEditorComponent } from './configurator-editor.component';

describe('ConfiguratorEditorComponent', () => {
  let component: ConfiguratorEditorComponent;
  let fixture: ComponentFixture<ConfiguratorEditorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConfiguratorEditorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConfiguratorEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
