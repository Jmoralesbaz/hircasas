import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InventrylistComponent } from './inventrylist.component';

describe('InventrylistComponent', () => {
  let component: InventrylistComponent;
  let fixture: ComponentFixture<InventrylistComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [InventrylistComponent]
    });
    fixture = TestBed.createComponent(InventrylistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
