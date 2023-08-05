import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArticlelistComponent } from './articlelist.component';

describe('ArticlelistComponent', () => {
  let component: ArticlelistComponent;
  let fixture: ComponentFixture<ArticlelistComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ArticlelistComponent]
    });
    fixture = TestBed.createComponent(ArticlelistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
