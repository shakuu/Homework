import { Movie } from './../models/movie.model';
import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'filter'
})
export class FilterMoviesPipe {
    transform(movies: Movie[], filterText: string): Movie[] {
        filterText = filterText || '';
        if (filterText === '') {
            return movies;
        }

        const filteredMovies = movies.filter(movie => movie.Title.toLowerCase().includes(filterText.toLowerCase()));
        return filteredMovies;
    }
}
