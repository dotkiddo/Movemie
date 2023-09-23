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

  exists(movie: string) : Observable<boolean> {
    return this.http.get<boolean>(`/movies/exists?movie=${movie}`);
  }

  create(movie: Movie): void {
   this.http.post<Movie>('/movies/create', movie)
            .subscribe(
              (response: any) => {
                console.log('success: ', response);
              },
              (error: HttpErrorResponse) => {console.error('Error: ', error);}
            );
  }

  update(movie: Movie): void {
    this.http.put<Movie>('/movies/update', movie)
             .subscribe(
               (response: any) => {
                 console.log('success: ', response);
               },
               (error: HttpErrorResponse) => {console.error('Error: ', error);}
             );
  }
}
