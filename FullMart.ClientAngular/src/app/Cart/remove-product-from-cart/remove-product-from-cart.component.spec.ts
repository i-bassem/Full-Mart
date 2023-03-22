import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RemoveProductFromCartComponent } from './remove-product-from-cart.component';

describe('RemoveProductFromCartComponent', () => {
  let component: RemoveProductFromCartComponent;
  let fixture: ComponentFixture<RemoveProductFromCartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RemoveProductFromCartComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RemoveProductFromCartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
