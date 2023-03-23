import { TestBed } from '@angular/core/testing';

import { WishlistProductService } from './wishlist-product.service';

describe('WishlistProductService', () => {
  let service: WishlistProductService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(WishlistProductService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
