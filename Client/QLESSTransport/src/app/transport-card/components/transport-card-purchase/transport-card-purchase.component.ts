import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TransportCardService } from '../../services/transport-card.service';

@Component({
  selector: 'app-transport-card-purchase',
  templateUrl: './transport-card-purchase.component.html',
  styleUrls: ['./transport-card-purchase.component.scss']
})
export class TransportCardPurchaseComponent implements OnInit {
  purchaseForm: FormGroup;
  processBtnLabel = "Proceed";
  processing = false;

  constructor(private formBuilder: FormBuilder, private service: TransportCardService) { }

  ngOnInit(): void {
    this.purchaseForm = this.formBuilder.group({
      load: ['', [Validators.required, Validators.min(100), Validators.max(10000)]]
    });
  }

  onSubmit(formValue: any) {
    this.processBtnLabel = "Processing...";
    this.processing = true;
    this.service.purchaseTransportCard(formValue.load).subscribe(id => {
      alert(`Successfully purchased! Your Q-LESS Transport ID is: ${id}`);
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
