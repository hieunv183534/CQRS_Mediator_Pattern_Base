/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { LienKhuVucComponent } from './lienkhuvuc.component';

describe('LienKhuVucComponent', () => {
  let component: LienKhuVucComponent;
  let fixture: ComponentFixture<LienKhuVucComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LienKhuVucComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LienKhuVucComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
