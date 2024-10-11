import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';

import { MatTableDataSource } from '@angular/material/table';
import { PageEvent } from '@angular/material/paginator';
import { CardService } from '../services/card.service';
import { BusinessCardReadModel } from '../models/business-card-model';
import { Filter } from '../../common/filter';


@Component({
  selector: 'app-card-list',
  templateUrl: './card-list.component.html',
  styleUrls: ['./card-list.component.css']
})
export class CardListComponent implements OnInit, OnChanges {
  @Input() filters: Filter[];

  cards: BusinessCardReadModel[] = [];

  dataSource = new MatTableDataSource<BusinessCardReadModel>(this.cards);
  displayedColumns: string[] = ['name', 'email', 'phone', 'gender', 'action'];

  // Pagination properties
  length = 0;
  pageSize = 10;
  pageIndex = 0;


  constructor(private cardService: CardService)
  {
    this.filters = []
  }

  ngOnInit(): void {
    this.loadCards();
  }

  ngOnChanges(changes: SimpleChanges): void {
    // Reload data when filters change
    debugger
    if (changes['filters']) {

      this.loadCards(this.filters);
    }
  }
  loadCards(filters: Filter[] = []): void {
    const params = {
      draw: 1,
      start: this.pageIndex * this.pageSize,
      length: this.pageSize,
      filters: filters
    };

    this.cardService.getCards(params).subscribe(cards => {
      if (cards.data) {
        this.dataSource.data = cards.data;
        this.length = cards.metadata['count']; 
      }
    });
  }


  applyFilters() {
    this.pageIndex = 0; // Reset to the first page
    this.loadCards();
  }

  onPaginateChange(event: PageEvent) {
    this.pageIndex = event.pageIndex;
    this.pageSize = event.pageSize;
    this.loadCards();
  }

  deleteCard(id: number): void {
    this.cardService.deleteCard(id).subscribe(() => {
      this.dataSource.data = this.dataSource.data.filter(card => card.id !== id);
    });
  }
}



