import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { DiscountRegistrationTypeEnum } from '../../common/enums/discount-registration-type.enum';

@Injectable({
  providedIn: 'root'
})
export class TransportCardService {
  private url = "https://localhost:5001/api/transportcard";

  constructor(private http: HttpClient) { }

  getTransportCards() {
    return this.http.get(`${this.url}/GetTransportCards`);
  }

  getTransportCardById(id: number) {
    return this.http.get(`${this.url}/GetTransportCardById?id=${id}`);
  }

  addLoad(id: number, load: number) {
    return this.http.post(`${this.url}/AddLoad?id=${id}&load=${load}`, {});
  }

  purchaseTransportCard(load: number) {
    return this.http.post(`${this.url}/PurchaseTransportCard?load=${load}`, {});
  }

  registerTransportCard(id: number, discountRegistrationType: DiscountRegistrationTypeEnum, discountId: string) {
    return this.http.post(`${this.url}/RegisterTransportCard?id=${id}&discountType=${discountRegistrationType}&discountId=${discountId}`, {});
  }

  payFare(id: number, fromLocation: string, toLocation: string) {    
    return this.http.post(`${this.url}/PayFare?id=${id}&fromLocation=${fromLocation}&toLocation=${toLocation}`, {});
  }

  getCardBalance(id: number) {
    return this.http.get(`${this.url}/GetCardBalance?id=${id}`);
  }
}
