import { AfterViewInit, Component, NgZone, ViewChild } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { MatStepper } from '@angular/material/stepper';
import { CardService } from '../services/card.service';


@Component({
  selector: 'app-create-card',
  templateUrl: './create-card.component.html',
  styleUrls: ['./create-card.component.css']
})
export class CreateCardComponent implements AfterViewInit{
  @ViewChild('stepper') stepper! : MatStepper;
  step = 1;

  cardData = {
    name: '',
    email: '',
    gender: '',
    dateOfBirth: '',
    countryCode: '',
    phone: '',
    street: '',
    city: '',
    zipcode: '',
    photo: ''
  };

  constructor(private ngZone: NgZone, private cardService: CardService, public dialogRef: MatDialogRef<CreateCardComponent>) { }
    ngAfterViewInit(): void {

    }

  nextStep(cardForm: any): void {
    if (cardForm.valid) {
      this.ngZone.run(() => {
        this.step++;
        this.stepper.next();
      })
    } else {
      // Mark all fields as touched to show error messages
      Object.keys(cardForm.controls).forEach(field => {
        const control = cardForm.controls[field];
        control.markAsTouched();
      });
    }
  }

  prevStep(): void {
    this.ngZone.run(() => {
      this.step--;
      this.stepper.previous();
    })
  }

  createCard(): void {
    this.cardService.createCard(this.cardData).subscribe(() => {
      this.dialogRef.close(); // Close the dialog
    });
  }

  onFileSelected(event: any): void {
    const file: File = event.target.files[0]; // Get the first file from the input
    if (file) {
      const reader = new FileReader();
      // Define what happens when the file is read
      reader.onload = (e: any) => {
        this.cardData.photo = e.target.result; // Store the Base64 string in the photo property
      };
      reader.readAsDataURL(file); // Convert the file to a Base64-encoded string
    }
  }

  closeDialog(): void {
    this.dialogRef.close();
  }
}
