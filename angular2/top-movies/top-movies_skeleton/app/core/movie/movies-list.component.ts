import { Component } from '@angular/core';
import { Movie } from './../models/movie.model';
import { MoviesService } from './../services/movies.service';

@Component({
    selector: 'movies-list',
    templateUrl: './movies-list.component.html'
})
export class MoviesListComponent {
    pageTitle: string;
    movies: Movie[];

    constructor(private moviesService: MoviesService) {
        const that = this;
        this.moviesService.findAll()
            .then((movies) => {
                that.movies = movies;
            });
    }
}
