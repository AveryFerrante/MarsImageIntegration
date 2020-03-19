import { Component, OnInit } from '@angular/core';
import { GetImagesRequest } from '../common/models/getImagesRequest';
import { GetImagesResponse, Photo } from '../common/models/getImagesResponse';
import { ImagesService } from '../services/images.service';
import { Subject, ReplaySubject } from 'rxjs';
import { tap, map } from 'rxjs/operators';

@Component({
  selector: 'app-mars-images-viewer',
  templateUrl: './mars-images-viewer.component.html',
  styleUrls: ['./mars-images-viewer.component.css']
})
export class MarsImagesViewerComponent implements OnInit {

  selectedDate: Date;
  isLoading = false;
  images$ = new ReplaySubject<Photo[]>(1);
  constructor(private imagesService: ImagesService) { }

  ngOnInit() {
  }

  onGetImages() {
    const request: GetImagesRequest = { date: this.selectedDate };
    this.isLoading = true;
    this.imagesService.getImages(request).pipe(
      map((response: GetImagesResponse) => response.photos),
      tap((photos: Photo[]) => this.images$.next(photos)),
      tap(() => this.isLoading = false)
    ).subscribe();
  }

  onDateInput(dateString: string) {
    this.selectedDate = this.parseDateString(dateString);    
  }

  private parseDateString(dateString: string): Date {
    const [year, month, day]: number[] = dateString.split('-').map(val => Number(val));
    return new Date(year, month - 1, day);
  }

}
