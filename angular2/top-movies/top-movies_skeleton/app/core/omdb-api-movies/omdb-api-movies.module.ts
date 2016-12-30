import { MoviesModule } from './../movie/movies.module';
import { OmdbApiService } from './../services/omdb-api.service';
import { OmdbApiSearchComponent } from './omdb-api-search.component';
import { RouterModule } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';

@NgModule({
  imports: [
    FormsModule,
    BrowserModule,
    MoviesModule,
    RouterModule.forChild([
      { path: 'omdb', component: OmdbApiSearchComponent }
    ])
  ],
  declarations: [
    OmdbApiSearchComponent
  ],
  providers: [
    OmdbApiService
  ]
})
export class OmdbApiMoivesModule { }
