/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { StepBuuCucComponent } from './stepbuucuc.component';

describe('StepbuucucComponent', () => {
  let component: StepBuuCucComponent;
  let fixture: ComponentFixture<StepBuuCucComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StepBuuCucComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StepBuuCucComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
