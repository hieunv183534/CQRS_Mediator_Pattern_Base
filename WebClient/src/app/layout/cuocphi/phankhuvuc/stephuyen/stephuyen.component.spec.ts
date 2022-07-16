/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { StepHuyenComponent } from './stephuyen.component';

describe('StephuyenComponent', () => {
  let component: StepHuyenComponent;
  let fixture: ComponentFixture<StepHuyenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StepHuyenComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StepHuyenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
