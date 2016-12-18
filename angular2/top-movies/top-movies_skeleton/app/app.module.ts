import { MoviesModule } from './core/movie/movies.module';
import { NavigationComponent } from './core/navigation.component';
import { AppComponent } from './app.component';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        MoviesModule,
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
