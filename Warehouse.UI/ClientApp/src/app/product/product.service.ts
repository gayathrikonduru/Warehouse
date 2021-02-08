
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { Product } from './Product';

const API_URL = "https://localhost:44393/api/products";
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};
@Injectable({
  providedIn: 'root',
})
export class ProductService {
  constructor(private http: HttpClient) { }

  getAllProducts(): Observable<Product[]> {
    var products = this.http.get<Product[]>(API_URL, { responseType: 'json' });
    console.log()
    return products;
  }

  deleteProduct(productId: number): Observable<any> {
   return this.http.delete(API_URL + "/" + productId, { responseType: 'json' });
  }

}
