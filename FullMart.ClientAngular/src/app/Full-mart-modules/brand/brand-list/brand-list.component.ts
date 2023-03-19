import { Component } from '@angular/core';
import { IBrandDTO } from 'src/app/_models/Ibranddto';
import { BrandService } from 'src/app/_services/Brand/Brands.service';


@Component({
  selector: 'app-brand-list',
  templateUrl: './brand-list.component.html',
  styleUrls: ['./brand-list.component.css']
})
export class BrandListComponent {
  brands: IBrandDTO[] = [];

  constructor(private b: BrandService) { }

  ngOnInit(): void {
    this.b.getBrands().subscribe(
      (brands: IBrandDTO[]) => {
        this.brands = brands;
      },
      (error: any) => {
        console.error(error);
      }
    );
}}
