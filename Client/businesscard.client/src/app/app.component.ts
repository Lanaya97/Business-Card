import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { CreateCardComponent } from './card/create-card/create-card.component';
import { MatMenuTrigger } from '@angular/material/menu';
import { Filter } from '../app/common/filter';
import { CardService } from './card/services/card.service';
import { Gender } from '../utils/enums/gender';
import { ImportDialogComponent } from './card/dialogs/import-dialog/import-dialog.component';


interface FilterColumns {
  Name: string | null;
  Email: string | null;
  Phone: string | null;
  Gender: Gender | null;
  StartDate: Date | null;
  EndDate: Date | null;
}
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(private dialog: MatDialog, private cardService: CardService) { }

  // Supported columns for filtering
  filterColumns: FilterColumns = {
      Name: null,
      Email: null,
      Phone: null,
      Gender: null,
      StartDate: null,
      EndDate: null
  }

  genderOptions = Object.keys(Gender).filter(key => isNaN(Number(key)));

  filters: Filter[] = [];

  pageSize: number = 10;
  pageNumber: number = 0;


  openImportDialog(): void {
    this.dialog.open(ImportDialogComponent, {
      width: '400px', // Adjust the dialog width as needed
    });
  }

  //#region events

  onApplyFiltersClick(menuTrigger: MatMenuTrigger) {
    menuTrigger.closeMenu();

    const filterParams: Filter[] = [];
    if (this.filterColumns.Name)
      filterParams.push({ name: 'name', value: this.filterColumns.Name })
    if (this.filterColumns.Email)
      filterParams.push({ name: 'email', value: this.filterColumns.Email })
    if (this.filterColumns.Phone)
      filterParams.push({ name: 'phone', value: this.filterColumns.Phone })
    if (this.filterColumns.Gender)
      filterParams.push({ name: 'gender', value: this.filterColumns.Gender.toString() })
    if (this.filterColumns.StartDate)
      filterParams.push({ name: 'startDate', value: this.filterColumns.StartDate.toString() })
    if (this.filterColumns.EndDate)
      filterParams.push({ name: 'endDate', value: this.filterColumns.EndDate.toString() })

    this.filters = filterParams;
  }

  onReset(menuTrigger: MatMenuTrigger) {
    menuTrigger.closeMenu();

    // Assigning all propreties of Filtered Columns to null
    Object.keys(this.filterColumns).forEach(key => {
      // @ts-ignore: Suppress TypeScript error about assigning null
      this.filterColumns[key as keyof T] = null;
    });

    this.filters = [];
  }

  onPaginationChange(event: { pageSize: number; pageNumber: number }) {
    this.pageSize = event.pageSize;
    this.pageNumber = event.pageNumber;
  }
  //#endregion events


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

}
