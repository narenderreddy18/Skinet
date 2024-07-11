import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-pager',
  templateUrl: './pager.component.html',
  styleUrls: ['./pager.component.scss']
})
export class PagerComponent {
  @Input() pageSize: number = 0;
  @Input() totalCount: number = 0;

  @Output() pageChanged = new EventEmitter<number>()

  onPagerChanged(event: any){
    this.pageChanged.emit(event.page);
  }
}
