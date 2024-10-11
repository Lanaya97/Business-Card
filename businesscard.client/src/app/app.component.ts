import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { CreateCardComponent } from './card/create-card/create-card.component';
import { MatMenuTrigger } from '@angular/material/menu';
import { Filter } from '../app/common/filter';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(private dialog: MatDialog) { }

  name: string = '';
  email: string = '';
  filters: Filter[] = [];

  openCreateCardDialog(): void {
    this.dialog.open(CreateCardComponent, {
      width: '80%', // Set the width as needed
      height: '80%',
      maxHeight: '90vh', // Optional: Set maxHeight directly when opening
      disableClose: true,
    });

  }

  onApplyFiltersClick(menuTrigger: MatMenuTrigger) {
    menuTrigger.closeMenu();

    const filterParams: Filter[] = [];
    if (this.name)
      filterParams.push({ name: 'name', value: this.name })
    if (this.email)
      filterParams.push({ name: 'email', value: this.email })

    this.filters = filterParams;
  }

  onReset(menuTrigger: MatMenuTrigger) {
    menuTrigger.closeMenu();

    this.name = '';
    this.email = '';
    this.filters = [];
  }
}
