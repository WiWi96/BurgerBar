import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfiguratorViewerComponent } from './configurator-viewer.component';

describe('ConfiguratorViewerComponent', () => {
  let component: ConfiguratorViewerComponent;
  let fixture: ComponentFixture<ConfiguratorViewerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConfiguratorViewerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConfiguratorViewerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
