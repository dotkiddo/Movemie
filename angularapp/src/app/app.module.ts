import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';

import { AgGridModule } from 'ag-grid-angular';
import { EditDeleteButtonsComponent } from './shared/ag-grid-helpers/edit-delete-buttons/edit-delete-buttons.component';
import { MovieAddEditComponent } from './features/movie-add-edit/movie-add-edit.component';
import { RatingsRendererComponent } from './shared/ag-grid-helpers/ratings-renderer/ratings-renderer.component';
import { AppRoutingModule } from './app-routing.module';
import { MoviesListComponent } from './features/movies-list/movies-list.component';


@NgModule({
  declarations: [
    AppComponent,
    EditDeleteButtonsComponent,
    MovieAddEditComponent,
    RatingsRendererComponent,
    MoviesListComponent
  ],
  imports: [
    BrowserModule, HttpClientModule, AgGridModule, AppRoutingModule, FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
