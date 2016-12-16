import { Injectable } from '@angular/core';
import { Movie } from './../models/movie.model';
import { Http } from '@angular/http';

@Injectable()

export class MoviesService {
    url: string = '/data/movies.json';
    movies: Movie[];
    http: Http;

    constructor(http: Http) {
        this.http = http;
    }

    findAll(): Promise<Movie[]> {
        const that = this;
        if (this.movies && this.movies.length > 0) {
            return new Promise(resolve => resolve(that.movies));
        }

        return new Promise((resolve, reject) => {
            that.http.get(that.url)
                .subscribe(res => {
                    that.movies = res.json();
                    resolve(that.movies);
                });
        });
    }
}
