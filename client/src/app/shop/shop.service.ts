import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Pagination } from '../shared/Models/Pagination';
import { Products } from '../shared/Models/Products';
import { Brand } from '../shared/Models/Brand';
import { Type } from '../shared/Models/Type';
import { ShopParams } from '../shared/Models/shopParams';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = "https://localhost:7246/api/";

  constructor(private http: HttpClient) { }

  getProducts(shopParams: ShopParams){
    let params = new HttpParams();
    if(shopParams.brandId) params = params.append('brandID', shopParams.brandId);
    if(shopParams.typeId) params = params.append('typeID', shopParams.typeId);
    params = params.append('sort', shopParams.sort);
    params = params.append('pageIndex', shopParams.pageNumber);
    params = params.append('pageSize', shopParams.pageSize);
    if(shopParams.search) params = params.append('search', shopParams.search)

    return this.http.get<Pagination<Products[]>>(this.baseUrl + 'Products', {params: params});
  }

  getBrands(){
    return this.http.get<Brand[]>(this.baseUrl + 'Products/brands');
  }

  getTypes(){
    return this.http.get<Type[]>(this.baseUrl + 'Products/types');
  }
}
