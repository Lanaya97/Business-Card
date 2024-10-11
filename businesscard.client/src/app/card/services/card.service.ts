import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BusinessCard, BusinessCardReadModel } from '../models/business-card-model';
import { Result } from '../../common/result';

@Injectable({
  providedIn: 'root'
})
export class CardService {
  private apiUrl = 'http://localhost:5098/api/card';

  constructor(private http: HttpClient) {}

  getCards(params: any): Observable<Result<BusinessCardReadModel[]>> {
    return this.http.post<Result<BusinessCardReadModel[]>>(`${this.apiUrl}/search`, params);
  }

  createCard(card: BusinessCard): Observable<BusinessCard> {
    return this.http.post<BusinessCard>(this.apiUrl, card);
  }

  deleteCard(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
