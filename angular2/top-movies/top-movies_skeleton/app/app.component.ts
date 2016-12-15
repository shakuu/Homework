import { Movie } from './core/models/movie.model';
import { MoviesService } from './core/services/movies.service';
import { Component } from '@angular/core';

@Component({
    selector: 'mvdb-app',
    templateUrl: './app.component.html'
})
export class AppComponent {
    movies: Movie[];

    constructor(private moviesService: MoviesService) {
        this.movies = moviesService.findAll();
    }
}
