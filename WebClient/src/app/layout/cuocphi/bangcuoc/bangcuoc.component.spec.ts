/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { BangCuocComponent } from './bangcuoc.component';

describe('BangcuocComponent', () => {
  let component: BangCuocComponent;
  let fixture: ComponentFixture<BangCuocComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BangCuocComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BangCuocComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
