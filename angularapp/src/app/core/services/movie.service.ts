import { Injectable } from '@angular/core';
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { HttpClient, HttpErrorResponse } from "@angular/common/http";

import { Movie } from "../models/movie.model";


@Injectable({
  providedIn: 'root'
})
export class MovieService {

  constructor(private readonly http: HttpClient) { }

  getAll(): Observable<Movie[]> {

    return this.http.get<Movie[]>('/movies/list')
           .pipe(map((data) => data));
  }

  create(movie: Movie): void {
   this.http.post<Movie>('/movies/create', { movie: movie })
            .subscribe(
              (response: any) => {
                console.log('success: ', response);
              },
              (error: HttpErrorResponse) => {console.error('Error: ', error);}
            );
  }

  update(movie: Movie): void {
    this.http.put<Movie>('/movies/update', { movie: movie })
             .subscribe(
               (response: any) => {
                 console.log('success: ', response);
               },
               (error: HttpErrorResponse) => {console.error('Error: ', error);}
             );
  }
}
