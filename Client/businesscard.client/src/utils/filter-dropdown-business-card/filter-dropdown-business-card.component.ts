import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, HostBinding, Input, OnInit, Output, ViewChild } from '@angular/core';
import { SelectItem } from '../common/select-item';
import { Filter } from '../common/data-table-parameter';
import { Gender } from '../enums/gender';


@Component({
  selector: 'filter-dropdown-business-card',
  templateUrl: './filter-dropdown-business-card.component.html',
  styleUrls: ['./filter-dropdown-business-card.component.scss'],
})


export class FilterDropdownBusinessCardComponent implements OnInit {
  @HostBinding('class') class = 'menu menu-sub menu-sub-dropdown w-250px w-md-300px';
  @HostBinding('attr.data-kt-menu') dataKtMenu = 'true';

  name: string | null= '';
  email: string | null = '';
  gender: Gender = Gender.Other;
  searchTerm: string | null = '';

  filters: Filter[] = [];

  @Output() filter = new EventEmitter<any>();

  constructor() {
  }

  ngOnInit(): void { }

  onApply() {
    this.filter.emit({
      searchTerm: this.searchTerm,
      name: this.name,
      email: this.email,
      gender: this.gender
    });
  }

  onReset() {
    this.searchTerm = null;
    this.name = null;
    this.email = null;
    this.gender = Gender.Other;
  }
}
