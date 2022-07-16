/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { HuyenComponent } from './huyen.component';

describe('HuyenComponent', () => {
  let component: HuyenComponent;
  let fixture: ComponentFixture<HuyenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HuyenComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HuyenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
