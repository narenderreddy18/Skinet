import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Products } from './Models/Products';
import { Pagination } from './Models/Pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  title = 'Skinet';
  products: Products[] = [];

  constructor(private http: HttpClient){ }

  ngOnInit(): void {
    this.http.get<Pagination<Products[]>>('https://localhost:7246/api/Products?pageSize=50').subscribe({
      next: response => this.products =response.data,
      error: erro => console.log(erro),
      complete: () => {
        console.log('complete')
      }
    });
  }
}