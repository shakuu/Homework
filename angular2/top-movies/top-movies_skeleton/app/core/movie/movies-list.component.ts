import { Component, ChangeDetectorRef } from '@angular/core';
import { Movie } from './../models/movie.model';
import { MoviesService } from './../services/movies.service';

@Component({
    selector: 'movies-list',
    templateUrl: './movies-list.component.html'
})
export class MoviesListComponent {
    pageTitle: string;
    movies: Movie[];

    filterByText: string;
    sortByPropertyName: string;
    sortOrder: string;

    constructor(private moviesService: MoviesService, private _changeDetectionRef: ChangeDetectorRef) {
        this.pageTitle = 'TOP 10 IMDB MOVIES';
        this.sortByPropertyName = 'imdbRating';
        this.sortOrder = 'ascending';

        const that = this;
        this.moviesService.findAll()
            .then((movies) => {
                that.movies = movies;
            });
    }

    onFilterTextChange(newValue: string) {
        this.filterByText = newValue;
    }
}
