import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { CreateCardComponent } from './card/create-card/create-card.component';
import { MatMenuTrigger } from '@angular/material/menu';
import { Filter } from '../app/common/filter';
import { CardService } from './card/services/card.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(private dialog: MatDialog, private cardService: CardService) { }

  name: string = '';
  email: string = '';
  filters: Filter[] = [];

  pageSize: number = 10;
  pageNumber: number = 0;

  onPaginationChange(event: { pageSize: number; pageNumber: number }) {
    this.pageSize = event.pageSize;
    this.pageNumber = event.pageNumber;
  }

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

  downloadCsv(): void {
    const params = {
      draw: 1,
      start: this.pageNumber * this.pageSize,
      length: this.pageSize,
      filters: this.filters
    };

    this.cardService.exportToCsv(params).subscribe((data: Blob) => {
      const downloadUrl = window.URL.createObjectURL(data);
      const link = document.createElement('a');
      link.href = downloadUrl;
      link.download = 'data.csv';
      link.click();
    });
  }

  downloadXml(): void {
    const params = {
      draw: 1,
      start: this.pageNumber * this.pageSize,
      length: this.pageSize,
      filters: this.filters
    };

    this.cardService.exportToXml(params).subscribe((data: Blob) => {
      const downloadUrl = window.URL.createObjectURL(data);
      const link = document.createElement('a');
      link.href = downloadUrl;
      link.download = 'data.xml';
      link.click();
    });
  }

  uploadCsv(event: any): void {
    const file = event.target.files[0];
    if (file) {
      this.cardService.importFromCsv(file).subscribe(response => {
        console.log('CSV data imported:', response);
      });
    }
  }

  uploadXml(event: any): void {
    const file = event.target.files[0];
    if (file) {
      this.cardService.importFromXml(file).subscribe(response => {
        console.log('XML data imported:', response);
      });
    }
  }
}
