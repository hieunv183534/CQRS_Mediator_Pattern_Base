/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { CuocChinhComponent } from './cuocchinh.component';

describe('CuocChinhComponent', () => {
  let component: CuocChinhComponent;
  let fixture: ComponentFixture<CuocChinhComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CuocChinhComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CuocChinhComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
