import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SalelistComponent } from './salelist.component';

describe('SalelistComponent', () => {
  let component: SalelistComponent;
  let fixture: ComponentFixture<SalelistComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SalelistComponent]
    });
    fixture = TestBed.createComponent(SalelistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
