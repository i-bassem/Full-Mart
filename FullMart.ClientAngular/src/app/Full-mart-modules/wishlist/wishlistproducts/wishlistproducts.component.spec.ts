import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WishlistproductsComponent } from './wishlistproducts.component';

describe('WishlistproductsComponent', () => {
  let component: WishlistproductsComponent;
  let fixture: ComponentFixture<WishlistproductsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WishlistproductsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WishlistproductsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
