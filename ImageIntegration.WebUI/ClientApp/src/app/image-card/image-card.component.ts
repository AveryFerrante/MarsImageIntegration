import { Component, OnInit, Input } from '@angular/core';
import { Photo } from '../common/models/getImagesResponse';

@Component({
  selector: 'app-image-card',
  templateUrl: './image-card.component.html',
  styleUrls: ['./image-card.component.css']
})
export class ImageCardComponent implements OnInit {
  @Input() photo: Photo;
  imgSrc: string;
  constructor() { }

  ngOnInit() {
  }

}
