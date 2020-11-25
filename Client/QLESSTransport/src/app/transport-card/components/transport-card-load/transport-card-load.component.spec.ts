import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TransportCardLoadComponent } from './transport-card-load.component';

describe('TransportCardLoadComponent', () => {
  let component: TransportCardLoadComponent;
  let fixture: ComponentFixture<TransportCardLoadComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TransportCardLoadComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TransportCardLoadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
