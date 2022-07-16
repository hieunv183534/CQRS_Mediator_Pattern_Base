/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { StepTinhComponent } from './steptinh.component';

describe('SteptinhComponent', () => {
  let component: StepTinhComponent;
  let fixture: ComponentFixture<StepTinhComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StepTinhComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StepTinhComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
