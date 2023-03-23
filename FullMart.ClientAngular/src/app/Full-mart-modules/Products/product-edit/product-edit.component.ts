import { ProductsService } from 'src/app/_services/Products/products.service';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IProductAdded } from 'src/app/_models/iproduct-added';
import { environment } from 'src/environments/environment.development';
import { MessageService } from 'primeng/api';
import { IProduct } from 'src/app/_models/IProduct';
import { ICategory } from 'src/app/_models/ICategory';
import { IBrandDTO } from 'src/app/_models/Ibranddto';
import { CategoriesService } from 'src/app/_services/Categories/categories.service';
import { BrandService } from 'src/app/_services/Brand/Brands.service';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.css']
})
export class ProductEditComponent {
}
 