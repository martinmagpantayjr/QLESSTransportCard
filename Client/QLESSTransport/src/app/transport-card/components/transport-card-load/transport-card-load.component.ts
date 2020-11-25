import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TransportCardService } from '../../services/transport-card.service';

@Component({
  selector: 'app-transport-card-load',
  templateUrl: './transport-card-load.component.html',
  styleUrls: ['./transport-card-load.component.scss']
})
export class TransportCardLoadComponent implements OnInit {
  loadForm: FormGroup;
  processBtnLabel = "Proceed";
  processing = false;

  constructor(private formBuilder: FormBuilder, private service: TransportCardService) { }

  ngOnInit(): void {
    this.loadForm = this.formBuilder.group({
      transportCardId: ['', [Validators.required]],
      load: ['', [Validators.required]],
      cash: ['', [Validators.required]]
    });
  }

  onSubmit(formValue: any) {
    if (formValue.cash < formValue.load) {
      alert('Error: Insufficient Cash');
    } else {
      const change = formValue.cash - formValue.load;
      
      this.processBtnLabel = "Processing...";
      this.processing = true;
      this.service.addLoad(formValue.transportCardId, formValue.load).subscribe(load => {
        if (change > 0) {
          alert(`Funds successfully added! Your current balance is ${load}.\n\nChange: ${change}`);
        } else {
          alert(`Funds successfully added! Your current balance is ${load}`);
        }
        
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
}
