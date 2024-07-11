import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Products } from '../shared/Models/Products';
import { ShopService } from './shop.service';
import { Brand } from '../shared/Models/Brand';
import { Type } from '../shared/Models/Type';
import { ShopParams } from '../shared/Models/shopParams';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit{
  @ViewChild('searchtext') searchterm?: ElementRef;
  products: Products[] = [];
  brands: Brand[] = [];
  types: Type[] = [];
  shopParams = new ShopParams();
  totalcount = 0;
  sortOptions = [
    {name:"Name: A-Z", value: 'name'},
    {name:"Price: Low-High", value: 'priceAsc'},
    {name:"Price: High-Low", value: 'priceDesc'}
  ]

  constructor(private shopService: ShopService){}
  
  ngOnInit(): void {
      this.getProducts();
      this.getBrands();
      this.getTypes();
    }

  getProducts(){
    this.shopService.getProducts(this.shopParams).subscribe({
      next: response => {
        this.products = response.data,
        this.shopParams.pageNumber = response.pageIndex,
        this.shopParams.pageSize = response.pageSize,
        this.totalcount = response.count
      },
      error: err => console.log(err)
    });
  }

  getBrands(){
    this.shopService.getBrands().subscribe({
      next: response => this.brands = [{id:0, name: 'All'}, ...response],
      error: err => console.log(err)
    });
  }

  getTypes(){
    this.shopService.getTypes().subscribe({
      next: response => this.types = [{id:0, name: 'All'}, ...response],
      error: err => console.log(err)
    });
  }

  onBrandSelected(brandID: number){
    this.shopParams.brandId = brandID;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onTypeSelected(typeID: number){
    this.shopParams.typeId = typeID;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onSortSelected(event: any){
    this.shopParams.sort = event.target.value;
    this.getProducts();
  }

  onPageChanged(event: any){
    if(this.shopParams.pageNumber != event){
      this.shopParams.pageNumber = event;
      this.getProducts();
    }
  }

  onSearch(){
    this.shopParams.search = this.searchterm?.nativeElement.value;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onReset(){
    if(this.searchterm) this.searchterm.nativeElement.value = '';
    this.shopParams = new ShopParams();
    this.getProducts();
  }
}
