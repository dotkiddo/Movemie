import { Injectable } from '@angular/core';
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { HttpClient } from "@angular/common/http";

import { GridCar } from "../models/gridcar.model";

import { of } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class GridcarService {

  constructor(private readonly http: HttpClient) { }

  getAll(): Observable<GridCar[]> {

    //return of(
    //  [
    //    { make: 'Toyota', model: 'Celica', price: 35000 },
    //    { make: 'Ford', model: 'Mondeo', price: 32000 },
    //    { make: 'Porsche', model: 'Boxster', price: 72000 }
    //  ]
    //);

    return this.http.get<GridCar[]>('/gridcar')

      .pipe(map((data) => {

        console.log('data returned from gridcar:');
        console.log(data);

        return data;

      }));

  }
}
