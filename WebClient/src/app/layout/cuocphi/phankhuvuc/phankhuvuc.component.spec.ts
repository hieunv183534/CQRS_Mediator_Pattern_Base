/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { PhanKhuVucComponent } from './phankhuvuc.component';

describe('PhanKhuVucComponent', () => {
  let component: PhanKhuVucComponent;
  let fixture: ComponentFixture<PhanKhuVucComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PhanKhuVucComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PhanKhuVucComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
