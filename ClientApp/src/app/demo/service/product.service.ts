import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CustomProduct, Product } from '../api/product';
import { HttpService } from 'src/app/services/api/http.service';
import { Observable } from 'rxjs';

@Injectable()
export class ProductService {
    url: string = '/api/WeatherForecast';

    constructor(
        private http: HttpClient,
        private httpService: HttpService
        ) { }

    getProductsSmall() {
        return this.http.get<any>('assets/demo/data/products-small.json')
            .toPromise()
            .then(res => res.data as Product[])
            .then(data => data);
    }

    // 測試API用
    getProductsFromAPI(): Observable<CustomProduct[]> {
        return this.httpService.get<CustomProduct[]>(`${this.url}/GetProducts`);
    }

    getProducts() {
        return this.http.get<any>('assets/demo/data/products.json')
            .toPromise()
            .then(res => res.data as Product[])
            .then(data => data);
    }

    getProductsMixed() {
        return this.http.get<any>('assets/demo/data/products-mixed.json')
            .toPromise()
            .then(res => res.data as Product[])
            .then(data => data);
    }

    getProductsWithOrdersSmall() {
        return this.http.get<any>('assets/demo/data/products-orders-small.json')
            .toPromise()
            .then(res => res.data as Product[])
            .then(data => data);
    }
}
