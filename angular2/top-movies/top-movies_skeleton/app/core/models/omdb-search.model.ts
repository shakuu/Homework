import { OmdbMovie } from './omdb-movie.model';

export interface OmdbSearch {
  Search: OmdbMovie[];
  totalResults: number;
  Response: boolean;
}
