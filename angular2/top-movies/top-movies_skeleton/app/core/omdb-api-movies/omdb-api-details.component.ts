import { OmdbApiService } from './../services/omdb-api.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import 'rxjs/add/operator/map';

@Component({
  selector: 'app-omdb-api-details',
  templateUrl: './omdb-api-details.component.html',
  styles: []
})
export class OmdbApiDetailsComponent implements OnInit {
  private movie: any;

  constructor(
    private omdbService: OmdbApiService,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.route.params
      .switchMap((params: Params) => {
        const imdbId = params['id'];
        return this.omdbService.searchByImdbId(imdbId);
      })
      .map(r => r.json())
      .subscribe((response) => {
        this.movie = response;
      });
  }
}
