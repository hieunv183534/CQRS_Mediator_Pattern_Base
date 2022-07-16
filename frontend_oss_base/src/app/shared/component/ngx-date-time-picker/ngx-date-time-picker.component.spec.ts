import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NgxDateTimePickerComponent } from './ngx-date-time-picker.component';

describe('NgxDateTimePickerComponent', () => {
  let component: NgxDateTimePickerComponent;
  let fixture: ComponentFixture<NgxDateTimePickerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NgxDateTimePickerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NgxDateTimePickerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
