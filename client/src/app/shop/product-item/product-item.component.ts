import { Component, Input } from '@angular/core';
import { Products } from 'src/app/shared/Models/Products';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.scss']
})
export class ProductItemComponent {
  @Input() product?: Products;
}
