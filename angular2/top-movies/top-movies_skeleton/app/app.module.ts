import { AppComponent } from './app.component';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { MoviesModule } from './core/movie/movies.module';
import { NavigationComponent } from './core/navigation.component';
import { NgModule } from '@angular/core';
import { OmdbApiMoivesModule } from './core/omdb-api-movies/omdb-api-movies.module';
import { RouterModule } from '@angular/router';

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        MoviesModule,
        OmdbApiMoivesModule,
        RouterModule.forRoot([
            { path: '', redirectTo: '/', pathMatch: 'full' },
            { path: '**', redirectTo: '/', pathMatch: 'full' }
        ])
    ],
    declarations: [
        AppComponent,
        NavigationComponent
    ],
    bootstrap: [
        AppComponent
    ]
})
export class AppModule { }
