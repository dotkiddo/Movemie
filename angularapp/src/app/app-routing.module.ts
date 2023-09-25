import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router'
import { AppComponent } from './app.component';
import { MovieAddEditComponent } from './features/movie-add-edit/movie-add-edit.component';
import { MoviesListComponent } from './features/movies-list/movies-list.component';
import { RatingsCountsComponent } from './features/ratings-counts/ratings-counts.component';

const routes: Routes = [
  { path: "", component: MoviesListComponent },
  { path: "movies/new", component: MovieAddEditComponent },
  { path: "movies/edit/:id", component: MovieAddEditComponent },
  { path: "ratings", component: RatingsCountsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
