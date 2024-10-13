import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { CardService } from '../../services/card.service';

@Component({
  selector: 'app-import-dialog',
  templateUrl: './import-dialog.component.html',
  styleUrls: ['./import-dialog.component.css'],
})
export class ImportDialogComponent {



  selectedFile: File | null = null; // Property to hold the uploaded file

  constructor(private dialogRef: MatDialogRef<ImportDialogComponent>, private cardService: CardService) { }

  onDragOver(event: DragEvent): void {
    event.preventDefault();
    event.stopPropagation();
    const dropZone = event.currentTarget as HTMLElement;
    dropZone.classList.add('hover'); 
  }

  onDragLeave(event: DragEvent): void {
    event.preventDefault();
    event.stopPropagation();
    const dropZone = event.currentTarget as HTMLElement;
    dropZone.classList.remove('hover'); 
  }

  onDrop(event: DragEvent): void {
    event.preventDefault();
    event.stopPropagation();
    const dropZone = event.currentTarget as HTMLElement;
    dropZone.classList.remove('hover'); 

    const files = event.dataTransfer?.files;
    if (files && files.length > 0) {
      this.upload(files[0]); 
    }
  }

  uploadCsv(file: File): void {
    if (file) {
      this.cardService.importFromCsv(file).subscribe(response => {
        console.log('CSV data imported:', response);
      });
    }
  }

  uploadXml(file: File): void {
    if (file) {
      this.cardService.importFromXml(file).subscribe(response => {
        console.log('XML data imported:', response);
      });
    }
  }

  uploadQR(file: File): void {
    if (file) {
      this.cardService.importFromQR(file).subscribe(response => {
        console.log('XML data imported:', response);
      });
    }
  }
  upload(event: Event | File): void {

    let file: File | null = null;

    const qrFileExtensions = ['.jpg', '.jpeg', '.png', '.pdf', '.bmp', '.gif'];

    if (event instanceof File) {
      file = event; // Directly passed file
    } else {
      const input = event.target as HTMLInputElement;
      const files = input.files;
      if (files && files.length > 0) {
        file = files[0]; // Get the first file from the input
      }
    }

    if (file && (file.name.endsWith('.csv'))) {
      this.selectedFile = file; 
      this.uploadCsv(file);
      this.closeDialog();
    }
    else if (file &&  file.name.endsWith('.xml')) {
      this.selectedFile = file; 
      this.uploadXml(file);
      this.closeDialog();
    }
    else if (file && qrFileExtensions.some(ext => file.name.toLowerCase().endsWith(ext))) {
      this.selectedFile = file;
      this.uploadQR(file);
      this.closeDialog();
    }
    else {
      console.error('Invalid file type. Please upload a CSV or XML file.');
      this.selectedFile = null; // Reset selected file on invalid type
    }
  }

  closeDialog(): void {
    this.dialogRef.close();
  }
}
