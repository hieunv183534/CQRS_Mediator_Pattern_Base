/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { VungComponent } from './vung.component';

describe('VungComponent', () => {
  let component: VungComponent;
  let fixture: ComponentFixture<VungComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VungComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VungComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
