import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FilterlistComponent } from './filterlist.component';

describe('FilterlistComponent', () => {
  let component: FilterlistComponent;
  let fixture: ComponentFixture<FilterlistComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FilterlistComponent]
    });
    fixture = TestBed.createComponent(FilterlistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
