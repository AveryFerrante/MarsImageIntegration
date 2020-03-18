import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { MarsImagesViewerComponent } from './mars-images-viewer/mars-images-viewer.component';

@NgModule({
  declarations: [
    AppComponent,
    MarsImagesViewerComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    RouterModule.forRoot([
      { path: 'mars-images', component: MarsImagesViewerComponent },
      { path: '', redirectTo: 'mars-images', pathMatch: 'full' }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
