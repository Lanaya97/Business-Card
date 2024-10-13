import { AfterViewInit, Component, EventEmitter, NgZone, OnDestroy, Output, ViewChild } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { MatStepper } from '@angular/material/stepper';
import { CardService } from '../services/card.service';
import { SwalHelpers } from '../../../utils/swal-helpers';
import { Subscription } from 'rxjs';
import { BusinessCard } from '../models/business-card-model';


@Component({
  selector: 'app-create-card',
  templateUrl: './create-card.component.html',
  styleUrls: ['./create-card.component.css']
})
export class CreateCardComponent implements OnDestroy {


  @ViewChild('stepper') stepper!: MatStepper;
  step = 1;

  cardData : BusinessCard = {
    name: '',
    email: '',
    gender: '',
    dateOfBirth: '',
    countryCode: '',
    number: '',
    street: '',
    city: '',
    zipcode: '',
    photo: ''
  };

  translate: any;
  isLoading: boolean = false;

  private readonly Subscriptions: Subscription[] = [];

  constructor(private ngZone: NgZone, private cardService: CardService, public dialogRef: MatDialogRef<CreateCardComponent>) {

  }

  ngOnDestroy(): void {
    this.Subscriptions.forEach((sb) => sb.unsubscribe());
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
    const sub = this.cardService.createCard(this.cardData).subscribe({
      next: (response) => {
        if (response.succeeded) {
          SwalHelpers.SwalSuccess('Card added successfully', 'Ok', () => {
            this.closeDialog(true);
          });
        }
      },
      error: (err) => {
        this.isLoading = false
        this.closeDialog(false);
      },
      complete: () => {
        this.isLoading = false
        this.closeDialog();
      }
    });
    this.Subscriptions.push(sub);
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

  closeDialog(result?: boolean): void {
    this.dialogRef.close(result);
  }

}
