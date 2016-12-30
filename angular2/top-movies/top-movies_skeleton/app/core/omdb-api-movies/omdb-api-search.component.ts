import 'rxjs/add/operator/map';
import { Component } from '@angular/core';
import { OmdbApiService } from './../services/omdb-api.service';
import { OmdbSearch } from './../models/omdb-search.model';

@Component({
  selector: 'app-omdb-api-search',
  templateUrl: './omdb-api-search.component.html',
  styles: []
})
export class OmdbApiSearchComponent {
  private searchResult: OmdbSearch;
  private searchTitle: string;
  private previousSearchTitle: string;
  private pageNumber: number;
  private hasPagination: boolean;

  constructor(private omdbService: OmdbApiService) {

    // api pages start at 1
    this.pageNumber = 1;
  }

  onSubmit(): void {
    this.previousSearchTitle = this.searchTitle;
    this.request();
  }

  onPreviousPage(): void {
    if (this.pageNumber > 1) {
      this.pageNumber -= 1;
    }
    this.request();
  }

  onNextPage(): void {
    const maxPage = Math.ceil(+this.searchResult.totalResults / 10);
    if (this.pageNumber < maxPage) {
      this.pageNumber += 1;
    }
    this.request();
  }

  private request(): void {
    this.omdbService.searchByTitle(this.previousSearchTitle, this.pageNumber)
      .map(response => response.json())
      .subscribe((response) => {
        this.searchResult = response;
        this.hasPagination = +this.searchResult.totalResults > 10;
        console.log(this.searchResult);
      }, (err) => {
        console.log(err);
      }, () => {

      });
  }
}
