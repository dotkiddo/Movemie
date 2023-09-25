import { Component, ViewChild } from '@angular/core';
import { AgGridAngular } from 'ag-grid-angular';
import { ColDef, GridReadyEvent, SortDirection } from 'ag-grid-community';
import { Observable, of } from 'rxjs';
import { RatingCount } from 'src/app/core/models/rating-count.model';
import { MovieService } from 'src/app/core/services/movie.service';

@Component({
  selector: 'app-ratings-counts',
  templateUrl: './ratings-counts.component.html',
  styleUrls: ['./ratings-counts.component.scss']
})
export class RatingsCountsComponent {

  constructor(private readonly movieService: MovieService) { }

  columnDefs: ColDef[] = [
    { field: 'rating', },
    { field: 'count' }
  ];

  // props common to all Columns
  public defaultColDef: ColDef = {
    sortable: false,
    filter: false,
    resizable: true
  };

  public rowData$!: Observable<any[]>;

  @ViewChild(AgGridAngular) agGrid!: AgGridAngular;

  onGridReady(params: GridReadyEvent) {
    const allRatings = [1,2,3,4,5];
    
    this.movieService.ratingCounts()
    .subscribe({
      next: (data: RatingCount[]) => {

        const ratingsInData = data.map(d => d.rating);
        const ratingsToAdd = allRatings.filter(rating => !ratingsInData.includes(rating));

        for (let rating of ratingsToAdd){
          data.push({ rating: rating, count: 0});
        }

        this.rowData$ = of(data.sort((a, b) => a.rating - b.rating));
      },
      error: (e: any) => {
        console.error("On loading rating counts",e);
        alert("An error has occurred while attempting to load your data, please try again.");
      }
    });
    
  }

}
