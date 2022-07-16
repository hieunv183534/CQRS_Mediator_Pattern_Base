/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { BuuCucComponent } from './buucuc.component';

describe('BuuCucComponent', () => {
  let component: BuuCucComponent;
  let fixture: ComponentFixture<BuuCucComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BuuCucComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BuuCucComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
