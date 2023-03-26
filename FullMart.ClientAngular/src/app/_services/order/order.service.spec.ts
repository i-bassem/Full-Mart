import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {Iorder} from 'src/app/_models/Iorder'
@Injectable({
  providedIn: 'root'
})
export class OrderService {

  private baseUrl = 'https://your-api-url-here.com/api/orders/';

  constructor(private http: HttpClient) { }

  getOrdersByUserId(userId: string): Observable<Iorder[]> {
    return this.http.get<Iorder[]>(this.baseUrl + userId);
  }
}
