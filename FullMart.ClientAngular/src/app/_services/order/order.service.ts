import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Iorder } from 'src/app/_models/Iorder';
import { OrderCreateDTO } from 'src/app/_models/ordercraete';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  private baseUrl = 'https://localhost:7191/api/Order/';

  constructor(private http: HttpClient) { }

  getOrdersByUserId(userId: string): Observable<Iorder[]> {
    return this.http.get<Iorder[]>(this.baseUrl + userId);
  }

  createOrder(userId: string, orderDTO: OrderCreateDTO): Observable<OrderCreateDTO> {
    const url = `${this.baseUrl}${userId}`;
    console.log(orderDTO)
    return this.http.post<OrderCreateDTO>(url, orderDTO);
  }
  
  addProductToOrder(orderId: number, productId: number): Observable<OrderCreateDTO> {
    const url = `${this.baseUrl}/${orderId}/products/${productId}`;
    return this.http.post<OrderCreateDTO>(url, {});
  } 
}
