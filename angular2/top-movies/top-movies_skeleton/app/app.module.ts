import { SortOrderMoviesComponent } from './core/movie/sort-order-movies.component';
import { FilterMoviesPipe } from './core/pipes/filter-movies.pipe';
import { FilterMoviesListComponent } from './core/movie/filter-movies-list.component';
import { FormsModule } from '@angular/forms';
import { SortMoviesPipe } from './core/pipes/sort-movies.pipe';
import { MovieShortComponent } from './core/movie/movie-short.component';
import { MoviesListComponent } from './core/movie/movies-list.component';
import { HttpModule } from '@angular/http';
import { BrowserModule } from '@angular/platform-browser';
import { MoviesService } from './core/services/movies.service';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';

@NgModule({
    imports: [
        BrowserModule,
        HttpModule,
        FormsModule
    ],
    declarations: [
        AppComponent,
        MoviesListComponent,
        MovieShortComponent,
        FilterMoviesListComponent,
        SortOrderMoviesComponent,
        SortMoviesPipe,
        FilterMoviesPipe
    ],
    bootstrap: [
        AppComponent
    ],
    providers: [
        MoviesService
    ]
})
export class AppModule { }
