import { Component, OnChanges, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TransportCardService } from '../../services/transport-card.service';

@Component({
  selector: 'app-transport-card-register',
  templateUrl: './transport-card-register.component.html',
  styleUrls: ['./transport-card-register.component.scss']
})
export class TransportCardRegisterComponent implements OnInit {
  registerForm: FormGroup;
  processBtnLabel = "Proceed";
  processing = false;
  formatPlaceholder = '00-0000-0000';
  idLabel = 'PWD ID';

  constructor(private formBuilder: FormBuilder, private service: TransportCardService) { }

  ngOnInit(): void {
    this.registerForm = this.formBuilder.group({
      transportCardId: ['', [Validators.required]],
      discountRegistrationType: ['0', [Validators.required]],
      discountId: ['', [Validators.required]],
    });

    this.registerForm.get('discountRegistrationType').valueChanges.subscribe(val => {
      this.registerForm.patchValue({ discountId: '' });

      if (val === '0') {
        this.idLabel = 'PWD ID';
        this.formatPlaceholder = '00-0000-0000';
      } else {
        this.idLabel = 'Senior Citizen ID';
        this.formatPlaceholder = '0000-0000-0000';
      }
    });
  }

  onSubmit(formValue: any) {
    this.processBtnLabel = "Processing...";
    this.processing = true;

    this.service.registerTransportCard(formValue.transportCardId, formValue.discountRegistrationType, formValue.discountId).subscribe(id => {
      alert(`Successfully Registered! You may now enjoy your 20% discount on your trips.`);
      location.href='/home';
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
