import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RatingsRendererComponent } from './ratings-renderer.component';

describe('RatingsRendererComponent', () => {
  let component: RatingsRendererComponent;
  let fixture: ComponentFixture<RatingsRendererComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [RatingsRendererComponent]
    });
    fixture = TestBed.createComponent(RatingsRendererComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
