import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MrtFareService } from '../../services/mrt-fare.service';
import { TransportCardService } from '../../services/transport-card.service';

@Component({
  selector: 'app-transport-card-pay',
  templateUrl: './transport-card-pay.component.html',
  styleUrls: ['./transport-card-pay.component.scss']
})
export class TransportCardPayComponent implements OnInit {
  payForm: FormGroup;
  processBtnLabel = "Proceed";
  processing = false;
  mrtLocations = [];
  cardBalance = '--';
  currentFare = '--';

  constructor(
    private formBuilder: FormBuilder, private transportCardService: TransportCardService,
    private mrtFareService: MrtFareService, private cdRef: ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    this.payForm = this.formBuilder.group({
      transportCardId: ['', [Validators.required]],
      fromLocation: ['', [Validators.required]],
      toLocation: ['', [Validators.required]],
      mrtLine: ['1', [Validators.required]],
    });

    this.getMrtLineLocations(this.payForm.get('mrtLine').value);

    this.payForm.get('mrtLine').valueChanges.subscribe(val => {
      this.getMrtLineLocations(val);
    });

    this.payForm.get('transportCardId').valueChanges.subscribe(val => {
      this.getCardBalance(val);
    });

    this.payForm.get('fromLocation').valueChanges.subscribe(val => {
      const toLocation = this.payForm.get('toLocation').value;

      if (toLocation) {
        this.getMrtFareByLocation(val, toLocation);
      }
    });

    this.payForm.get('toLocation').valueChanges.subscribe(val => {
      const fromLocation = this.payForm.get('fromLocation').value;

      if (fromLocation) {
        this.getMrtFareByLocation(fromLocation, val);
      }
    });
  }

  getMrtLineLocations(mrtLine: number) {
    this.mrtLocations = [];

    this.mrtFareService.getMrtLocations(mrtLine).subscribe((s: any) => {
      this.mrtLocations = s;

      this.payForm.patchValue({ fromLocation: '' });
      this.payForm.patchValue({ toLocation: '' });
    });
  }

  getCardBalance(id: number) {
    this.transportCardService.getCardBalance(id).subscribe((s: string) => {
      this.cardBalance = s;
    });
  }

  getMrtFareByLocation(fromLocation: string, toLocation: string) {
    this.mrtFareService.getMrtFareByLocation(fromLocation, toLocation).subscribe((s: any) => {
      if (s !== null) {
        this.currentFare = s.fare;
      }
    });
  }

  onSubmit(formValue: any) {
    console.log(formValue);
    this.processBtnLabel = "Processing...";
    this.processing = true;
    this.transportCardService.payFare(formValue.transportCardId, formValue.fromLocation, formValue.toLocation).subscribe((balance) => {
      alert(`Successfully paid your fare! Your current balance is ${balance}. Have a safe ride!`);
      location.href = '/home';
      this.processBtnLabel = "Proceed";
      this.processing = false;
    }, error => {
      const errorMsg = error.error;
      const matchPattern = /System.Exception: (.*)/.exec(errorMsg);
      alert(`ERROR: ${matchPattern[1]}`);
      this.processBtnLabel = "Proceed";
      this.processing = false;
    });
  }
}
