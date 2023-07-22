import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class HttpService {
  private readonly regExp = new RegExp('(https?|ftp)://');
  private httpOptions = {
    headers: { 'X-XSS-Protection': '1' },
  };

  constructor(
    private http: HttpClient,
  ) {}

  get<T>(url: string, params: object = {}): Observable<T> {
    const paramsStr = this.paramsToString(params);
    return this.http.get<T>(
      this.buildUrl(`${url}?${paramsStr}`),
      this.httpOptions,
    );
  }

  post<T, D>(url: string, data: D): Observable<T> {
    return this.http.post<T>(this.buildUrl(url), data, this.httpOptions);
  }

  put<T, D>(url: string, data: D): Observable<T> {
    return this.http.put<T>(this.buildUrl(url), data, this.httpOptions);
  }

  patch<T, D>(url: string, data: D): Observable<T> {
    return this.http.patch<T>(this.buildUrl(url), data, this.httpOptions);
  }

  delete<T>(url: string): Observable<T> {
    return this.http.delete<T>(this.buildUrl(url), this.httpOptions);
  }

  getString(url: string, params: object = {}): Observable<string> {
    const paramsStr = this.paramsToString(params);
    return this.http.get(this.buildUrl(`${url}?${paramsStr}`), {
      ...this.httpOptions,
      responseType: 'text',
    });
  }

  download(url: string, params: object = {}): Observable<Blob> {
    const paramsStr = this.paramsToString(params);
    return this.http.get(this.buildUrl(`${url}?${paramsStr}`), {
      ...this.httpOptions,
      responseType: 'blob',
    });
  }

  buildUrl(path: string): string {
    if (this.regExp.test(path)) {
      return path;
    }
    return environment.apiUrl + path;
  }

  paramsToString(obj: object): string {
    return Object.entries(obj)
      .filter(
        ([key, value]) => value !== undefined && value !== null && value !== '',
      )
      .map(([key, value]) => {
        if (value instanceof Date) {
          value = value.toISOString();
        }
        return `${key}=${value}`;
      })
      .join('&');
  }

}
