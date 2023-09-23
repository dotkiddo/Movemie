import { Component, ViewChild } from '@angular/core';

import { AgGridAngular } from 'ag-grid-angular';
import { CellClickedEvent, ColDef, FirstDataRenderedEvent, GridReadyEvent } from 'ag-grid-community';
import { Observable } from 'rxjs';
import { MovieService } from '../../core/services/movie.service';


@Component({
  selector: 'app-movies-list',
  templateUrl: './movies-list.component.html',
  styleUrls: ['./movies-list.component.scss']
})
export class MoviesListComponent {

  constructor(private readonly movieService: MovieService){}


 //title = 'angularapp';

 columnDefs: ColDef[] = [
  { field: 'name' },
  { field: 'category' },
  { field: 'rating' },
  { field: 'actions' }
];

// DefaultColDef sets props common to all Columns
public defaultColDef: ColDef = {
  sortable: true,
  filter: true,
  resizable: true
};

// Data that gets displayed in the grid
public rowData$!: Observable<any[]>;

// For accessing the Grid's API
@ViewChild(AgGridAngular) agGrid!: AgGridAngular;


// Example load data from server
onGridReady(params: GridReadyEvent) {
  this.rowData$ = this.movieService.getAll();  
}

onFirstDataRendered(params: FirstDataRenderedEvent) {
  params.api.sizeColumnsToFit();
}

// Example of consuming Grid Event
onCellClicked(e: CellClickedEvent): void {
  console.log('cellClicked', e);
}

}

//#warning - horizontal scrollbars for small devices