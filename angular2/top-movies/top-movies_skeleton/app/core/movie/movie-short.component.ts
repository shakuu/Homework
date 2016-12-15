import { Movie } from './../models/movie.model';
import { Component } from '@angular/core';

@Component({
    selector: 'mvdb-movie-short',
    templateUrl: './movie-short.component.html'
})
export class MovieShortComponent {
    movie: Movie;
    
    constructor() {

    }
}
