import { HttpModule } from '@angular/http';
import { Injectable } from '@angular/core';
import { Movie } from './../models/movie.model';
import { Http } from '@angular/http';

@Injectable()
export class MoviesService {
    url: string = '/data/movies.json';
    movies: Movie[];

    constructor(private http: Http) {
        this.getJson();
    }

    findAll(): Movie[] {
        return this.movies;
    }

    getJson(): void {
        this.http.get(this.url)
            .subscribe(res => {
                this.movies = res.json();
                console.log(this.movies.length);
                console.log(this.movies[0]);
            });
    }
}
