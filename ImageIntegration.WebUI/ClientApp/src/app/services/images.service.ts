import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { GetImagesRequest } from '../common/models/getImagesRequest';
import { GetImagesResponse } from '../common/models/getImagesResponse';

@Injectable({
  providedIn: 'root'
})
export class ImagesService {
  API_ROOT = "https://localhost:44304/mars-images";
  constructor(private http: HttpClient) { }

  getImages(request: GetImagesRequest) {
    return this.http.get<GetImagesResponse[]>(this.buildRequestString(request));
  }

  private buildRequestString(request: GetImagesRequest) {
    return `${this.API_ROOT}?date=${request.date.getFullYear()}-${request.date.getMonth() + 1}-${request.date.getDate()}`
  }
}
