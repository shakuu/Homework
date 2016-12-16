import { Component } from '@angular/core';
import { Input } from '@angular/core';
import { Movie } from './../models/movie.model';

@Component({
    selector: '[mvdb-movie-short]',
    templateUrl: './movie-short.component.html'
})
export class MovieShortComponent {
    @Input()
    movie: Movie;

    constructor() {

    }
}
