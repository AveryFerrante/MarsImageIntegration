import { Component, OnInit } from '@angular/core';
import { GetImagesRequest } from '../common/models/getImagesRequest';
import { GetImagesResponse } from '../common/models/getImagesResponse';
import { ImagesService } from '../services/images.service';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';

@Component({
  selector: 'app-mars-images-viewer',
  templateUrl: './mars-images-viewer.component.html',
  styleUrls: ['./mars-images-viewer.component.css']
})
export class MarsImagesViewerComponent implements OnInit {

  selectedDate: Date;
  isLoading = false;
  imageData: SafeUrl;
  constructor(private imagesService: ImagesService, private sanitizer: DomSanitizer) { }

  ngOnInit() {
  }

  onGetImages() {
    const request: GetImagesRequest = { date: this.selectedDate };
    this.isLoading = true;
    this.imagesService.getImages(request).subscribe(
      (value: GetImagesResponse[]) => {
        //const reader = new FileReader();
        //reader.onload = (e) => this.imageData = e.target.result as ArrayBuffer;
        //reader.readAsDataURL(new Blob([value[0].data]));
        let objectUrl = `data:image/${value[0].extention.value.toLowerCase()};base64,` + value[0].data;
        this.imageData = this.sanitizer.bypassSecurityTrustUrl(objectUrl);
        this.isLoading = false;
      }
    );
  }

  onDateInput(dateString: string) {
    this.selectedDate = this.parseDateString(dateString);    
  }

  private parseDateString(dateString: string): Date {
    const [year, month, day]: number[] = dateString.split('-').map(val => Number(val));
    return new Date(year, month - 1, day);
  }

}
