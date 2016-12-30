import { Http, Response } from '@angular/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable()
export class OmdbApiService {

  constructor(private ngHttpService: Http) { }

  public searchByTitle(title: string, page: number): Observable<Response> {
    const url = this.getSearchUrl(title, page);
    return this.ngHttpService.get(url);
  }

  private getSearchUrl(title: string, page: number): string {
    return `http://www.omdbapi.com/?s=${title}&y=&plot=full&r=json&page=${page}`;
  }

  private getDetailsUrl(title: string): string {
    return `http://www.omdbapi.com/?t=${title}&y=&plot=full&r=json`;
  }
}
