import { Http } from '@angular/http';
import { Injectable } from '@angular/core';

@Injectable()
export class OmdbApiService {

  constructor(private ngHttpService: Http) { }

  private getSearchUrl(title: string, page: number): string {
    return `http://www.omdbapi.com/?s=${title}&y=&plot=full&r=json&page=${page}`;
  }

  private getDetailsUrl(title: string): string {
    return `http://www.omdbapi.com/?t=${title}&y=&plot=full&r=json`;
  }
}
