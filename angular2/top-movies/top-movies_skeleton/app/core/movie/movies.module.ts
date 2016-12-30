import { BrowserModule } from '@angular/platform-browser';
import { FilterMoviesListComponent } from './filter-movies-list.component';
import { FilterMoviesPipe } from './../pipes/filter-movies.pipe';
import { FormsModule } from '@angular/forms';
import { MovieShortComponent } from './movie-short.component';
import { MoviesListComponent } from './movies-list.component';
import { MoviesService } from './../services/movies.service';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SortMoviesPipe } from './../pipes/sort-movies.pipe';
import { SortOrderMoviesComponent } from './sort-order-movies.component';

@NgModule({
    imports: [
        FormsModule,
        BrowserModule,
        RouterModule.forChild([
            { path: 'movies', component: MoviesListComponent }
        ])
    ],
    declarations: [
        FilterMoviesListComponent,
        FilterMoviesPipe,
        MovieShortComponent,
        MoviesListComponent,
        SortMoviesPipe,
        SortOrderMoviesComponent
    ],
    providers: [
        MoviesService
    ],
    exports: [
        MovieShortComponent
    ]
})
export class MoviesModule {

}
