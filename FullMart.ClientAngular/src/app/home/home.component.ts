import { Component, OnChanges, OnInit } from '@angular/core';
import { IBrandDTO } from 'src/app/_models/Ibranddto';
import { ICategory } from 'src/app/_models/ICategory';
import { IProduct } from 'src/app/_models/IProduct';
import { BrandService } from 'src/app/_services/Brand/Brands.service';
import { CartService } from 'src/app/_services/Cart/cart.service';
import { CategoriesService } from 'src/app/_services/Categories/categories.service';
import { ProductsService } from 'src/app/_services/Products/products.service';
import { environment } from 'src/environments/environment.development';
import { CategoryListComponent } from '../Full-mart-modules/Category/category-list/category-list.component';


import { WishlistProductService } from 'src/app/_services/Wishlist/wishlist-product.service';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  constructor(
    private catservice: CategoriesService,
    public router: Router,
    private productServices: ProductsService
  ) {}

  catList: ICategory[] = [];
  category: ICategory | null = null;
  products: IProduct[] = [];
  serverURL = `${environment.ImgURL}`;

  ngOnInit(): void {
    this.catservice.getAllCategories().subscribe((cat) => (this.catList = cat));
    this.productServices.getAllProducts().subscribe((res: IProduct[]) => {
      this.products = res;
    });

  }

  ngOnChanges(): void {
    this.catservice.getAllCategories().subscribe((cat) => (this.catList = cat));
  }

  createImagepath(serverPath: string) {
    return `${environment.ImgURL + serverPath}`;
  }
  getProductsByCategory(categoryId: string): IProduct[] {
    return this.products.filter((product) => product.categoryName === categoryId);
  }

  delete(catID: number) {
    this.catservice.deleteCategory(catID).subscribe((data) => console.log(data));
    // setTimeout(()=>this.router.navigateByUrl("/category"),1500)
    window.location.reload();
  }
}

