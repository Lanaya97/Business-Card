import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Result } from '../../common/result';
import { BusinessCard, BusinessCardReadModel } from '../models/business-card-model';

@Injectable({
  providedIn: 'root'
})
export class CardService {
  private apiUrl = 'http://localhost:5098/api/card';

  constructor(private http: HttpClient) {}

  getCards(params: any): Observable<Result<BusinessCardReadModel[]>> {
    return this.http.post<Result<BusinessCardReadModel[]>>(`${this.apiUrl}/search`, params);
  }

  createCard(card: BusinessCard): Observable<Result<BusinessCard>> {
    return this.http.post<Result<BusinessCard>>(this.apiUrl, card);
  }

  deleteCard(id: string): Observable<Result<boolean>> {
    return this.http.delete<Result<boolean>>(`${this.apiUrl}?id=${id}`);
  }

  exportToCsv(data: any): Observable<Blob> {
    return this.http.post(`${this.apiUrl}/export/csv`, data, { responseType: 'blob' });
  }

  exportToXml(data: any): Observable<Blob> {
    return this.http.post(`${this.apiUrl}/export/xml`, data, { responseType: 'blob' });
  }

  importFromCsv(file: File): Observable<any> {
    const formData = new FormData();
    formData.append('file', file);
    return this.http.post(`${this.apiUrl}/import/csv`, formData);
  }

  importFromXml(file: File): Observable<any> {
    const formData = new FormData();
    formData.append('file', file);
    return this.http.post(`${this.apiUrl}/import/xml`, formData);
  }

  importFromQR(file: File): Observable<any> {
    const formData = new FormData();
    formData.append('file', file);
    return this.http.post(`${this.apiUrl}/import/qr`, formData);
  }

}
