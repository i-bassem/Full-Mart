import { IProduct } from './../../../_models/IProduct';
import { ProductsService } from 'src/app/_services/Products/products.service';
import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IBrandDTO } from 'src/app/_models/Ibranddto';
import { ICategory } from 'src/app/_models/ICategory';
import { BrandService } from 'src/app/_services/Brand/Brands.service';
import { CategoriesService } from 'src/app/_services/Categories/categories.service';
import { environment } from 'src/environments/environment.development';

@Component({
  selector: 'app-category-details',
  templateUrl: './category-details.component.html',
  styleUrls: ['./category-details.component.css'],
})
export class CategoryDetailsComponent {
  protected catID: number = 0;
  protected category: ICategory | null = null;
  protected products: IProduct[] = [];
  protected serverURL = `${environment.ImgURL}`;
  catList: ICategory[] = [];
  categorys: ICategory | null = null;
  brands: IBrandDTO[] = [];
  selectedSortOption: string;
  sortBy: string;
  constructor(
    private catservice: CategoriesService,
    private productServices: ProductsService,
    private b: BrandService,
    private ac: ActivatedRoute
  ) {
    this.sortBy = 'name';
    this.selectedSortOption = "Random";
  }

  ngOnInit(): void {
    this.catID = this.ac.snapshot.params['id'];
    this.catservice.getCategoryByID(this.catID)
      .subscribe((cat) => (this.category = cat));

    this.productServices.getAllProducts()
      .subscribe((cat: any) => (this.products = cat));

    this.b.getBrands()
      .subscribe((cat) => (this.brands = cat));

    this.getBrands();
    this.sortProducts();
  }

  ngOnChanges(): void {
    this.productServices.getAllProducts()
      .subscribe((cat: any) => (this.products = cat));


    this.sortProducts();
  }

  getBrands() {
    this.b.getBrands().subscribe( (res: any) => {
        console.log(res);

        this.brands = res;
      },
      (error) => {
        console.log(error.message);
      }
    );
  }

  

  filterCategory(event: any) {
    let val = event.target.value; //Nike

    if (val == 'All') {
      this.productServices.getAllProducts()
        .subscribe((cat: any) => (this.products = cat));
    } else {
      this.getProductsByBrandName(val);
    }
    console.log(val);
  }

  getProductsByBrandName(brandName: string) {
    this.productServices
      .getProductByBrandName(brandName)
      .subscribe((res: any) => {
        this.products = res;
      });
  }


  sortProducts() {

    if (this.selectedSortOption === 'random') {
      this.productServices.getAllProducts()
        .subscribe((cat: any) => (this.products = cat));
    }
    else if (this.selectedSortOption === 'priceAsc') {
      this.products.sort((a, b) => a.price - b.price);
    } else if (this.selectedSortOption === 'priceDesc') {
      this.products.sort((a, b) => b.price - a.price);
    } else if (this.selectedSortOption === 'nameAsc') {
      this.products.sort((a, b) => a.productName.localeCompare(b.productName));
    } else if (this.selectedSortOption === 'nameDesc') {
      this.products.sort((a, b) => b.productName.localeCompare(a.productName));
    }
  }
}
