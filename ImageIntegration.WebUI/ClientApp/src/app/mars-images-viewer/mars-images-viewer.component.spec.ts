import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MarsImagesViewerComponent } from './mars-images-viewer.component';

describe('MarsImagesViewerComponent', () => {
  let component: MarsImagesViewerComponent;
  let fixture: ComponentFixture<MarsImagesViewerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MarsImagesViewerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MarsImagesViewerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
