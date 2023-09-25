import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';

import { AgGridModule } from 'ag-grid-angular';
import { ActionsRendererComponent } from './shared/ag-grid-helpers/actions-renderer/actions-renderer.component';
import { MovieAddEditComponent } from './features/movie-add-edit/movie-add-edit.component';
import { RatingsRendererComponent } from './shared/ag-grid-helpers/ratings-renderer/ratings-renderer.component';
import { AppRoutingModule } from './app-routing.module';
import { MoviesListComponent } from './features/movies-list/movies-list.component';
import { RatingsCountsComponent } from './features/ratings-counts/ratings-counts.component';


@NgModule({
  declarations: [
    AppComponent,
    ActionsRendererComponent,
    MovieAddEditComponent,
    RatingsRendererComponent,
    MoviesListComponent,
    RatingsCountsComponent
  ],
  imports: [
    BrowserModule, HttpClientModule, AgGridModule, AppRoutingModule, FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
