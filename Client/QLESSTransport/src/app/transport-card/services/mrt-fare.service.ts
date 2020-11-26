import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { DiscountRegistrationTypeEnum } from '../../common/enums/discount-registration-type.enum';

@Injectable({
  providedIn: 'root'
})
export class MrtFareService {
  private url = "https://localhost:5001/api/mrtfare";

  constructor(private http: HttpClient) { }

  getMrtLocations(mrtLine: number) {
    return this.http.get(`${this.url}/GetMrtLocations?mrtLine=${mrtLine}`);
  }

  getMrtFareByLocation(fromLocation: string, toLocation: string) {
    return this.http.get(`${this.url}/GetMrtFareByLocation?fromLocation=${fromLocation}&toLocation=${toLocation}`);
  }
}