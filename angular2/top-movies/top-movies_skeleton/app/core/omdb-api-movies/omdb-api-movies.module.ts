import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { MoviesModule } from './../movie/movies.module';
import { NgModule } from '@angular/core';
import { OmdbApiDetailsComponent } from './omdb-api-details.component';
import { OmdbApiSearchComponent } from './omdb-api-search.component';
import { OmdbApiService } from './../services/omdb-api.service';
import { RouterModule } from '@angular/router';

@NgModule({
  imports: [
    FormsModule,
    BrowserModule,
    MoviesModule,
    RouterModule.forChild([
      { path: 'omdb', component: OmdbApiSearchComponent },
      { path: 'omdb/:id', component: OmdbApiDetailsComponent }
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
