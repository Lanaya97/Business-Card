import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';

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

  // Pagination properties
  length = 0;

  private _pageSize: number = 10;
  private _pageNumber: number = 0;

  @Output() paginationChange: EventEmitter<{ pageSize: number; pageNumber: number }> = new EventEmitter();

  get pageSize(): number {
    return this._pageSize;
  }

  set pageSize(value: number) {
    this._pageSize = value;
    this.emitPaginationChange();
  }

  get pageNumber(): number {
    return this._pageNumber;
  }

  set pageNumber(value: number) {
    this._pageNumber = value;
    this.emitPaginationChange();
  }

  private emitPaginationChange() {
    // Emit both pageSize and pageNumber together in a single event
    this.paginationChange.emit({ pageSize: this._pageSize, pageNumber: this._pageNumber });
  }

  constructor(private cardService: CardService)
  {
    this.filters = []
  }

  ngOnInit(): void {
    this.loadCards();
  }

  ngOnChanges(changes: SimpleChanges): void {
    // Reload data when filters change
    if (changes['filters']) {
      this.loadCards(this.filters);
    }
  }
  loadCards(filters: Filter[] = []): void {
    const params = {
      draw: 1,
      start: this.pageNumber * this.pageSize,
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
    this.pageNumber = 0; // Reset to the first page
    this.loadCards();
  }

  onPaginateChange(event: PageEvent) {
    this.pageNumber = event.pageIndex;
    this.pageSize = event.pageSize;
    this.loadCards();
  }

  deleteCard(id: number): void {
    this.cardService.deleteCard(id).subscribe(() => {
      this.dataSource.data = this.dataSource.data.filter(card => card.id !== id);
    });
  }
}



