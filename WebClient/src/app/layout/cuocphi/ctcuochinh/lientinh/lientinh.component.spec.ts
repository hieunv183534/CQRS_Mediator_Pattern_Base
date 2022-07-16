/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { LienTinhComponent } from './lientinh.component';

describe('LienTinhComponent', () => {
  let component: LienTinhComponent;
  let fixture: ComponentFixture<LienTinhComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LienTinhComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LienTinhComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
