import { AppComponent } from './app.component';
import { BrowserModule } from '@angular/platform-browser';
import { FilterMoviesListComponent } from './core/movie/filter-movies-list.component';
import { FilterMoviesPipe } from './core/pipes/filter-movies.pipe';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { MovieShortComponent } from './core/movie/movie-short.component';
import { MoviesListComponent } from './core/movie/movies-list.component';
import { MoviesService } from './core/services/movies.service';
import { NgModule } from '@angular/core';
import { SortMoviesPipe } from './core/pipes/sort-movies.pipe';
import { SortOrderMoviesComponent } from './core/movie/sort-order-movies.component';

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule
    ],
    declarations: [
        AppComponent,
        FilterMoviesListComponent,
        FilterMoviesPipe,
        MovieShortComponent,
        MoviesListComponent,
        SortMoviesPipe,
        SortOrderMoviesComponent
    ],
    bootstrap: [
        AppComponent
    ],
    providers: [
        MoviesService
    ]
})
export class AppModule { }
