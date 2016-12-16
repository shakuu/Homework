import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'sort'
})
export class SortMoviesPipe implements PipeTransform {
    transform(movies: any[], options: string[]): any[] {
        const propertyName: string = options[0] || 'Title';
        const order: string = options[1] || 'ascending';

        if (!movies || movies.length === 0) {
            return undefined;
        }

        const sortedMovies = movies.sort((first: any, second: any): number => {
            const comparison = first[propertyName].localeCompare(second[propertyName]);
            if (order === 'descending') {
                return -comparison;
            }

            return comparison;
        });

        return sortedMovies;
    }
}
