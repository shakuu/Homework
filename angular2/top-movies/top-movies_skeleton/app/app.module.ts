import { MoviesListComponent } from './core/movie/movies-list.component';
import { HttpModule } from '@angular/http';
import { BrowserModule } from '@angular/platform-browser';
import { MoviesService } from './core/services/movies.service';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';

@NgModule({
    imports: [BrowserModule, HttpModule],
    declarations: [AppComponent, MoviesListComponent],
    bootstrap: [AppComponent],
    providers: [MoviesService]
})
export class AppModule { }
