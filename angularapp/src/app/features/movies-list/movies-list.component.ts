import { Component, ViewChild } from '@angular/core';

import { AgGridAngular } from 'ag-grid-angular';
import { ColDef, FirstDataRenderedEvent, GridReadyEvent } from 'ag-grid-community';
import { Observable } from 'rxjs';
import { MovieService } from '../../core/services/movie.service';
import { ActionsRendererComponent } from 'src/app/shared/ag-grid-helpers/actions-renderer/actions-renderer.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-movies-list',
  templateUrl: './movies-list.component.html',
  styleUrls: ['./movies-list.component.scss']
})
export class MoviesListComponent {

  constructor(
    private readonly movieService: MovieService,
    private readonly router: Router){}


 columnDefs: ColDef[] = [
  { field: 'name' },
  { field: 'category' },
  { field: 'rating' },
  { 
    headerName: 'Actions',
    cellRenderer: ActionsRendererComponent,
    cellRendererParams: {
      onEdit: this.onEdit.bind(this),
      onDelete: this.onDelete.bind(this)
    }  
  }
];

// props common to all Columns
public defaultColDef: ColDef = {
  sortable: true,
  filter: true,
  resizable: true
};

// Data displayed in the grid
public rowData$!: Observable<any[]>;

// For accessing the Grid's API
@ViewChild(AgGridAngular) agGrid!: AgGridAngular;


onGridReady(params: GridReadyEvent) {
  this.rowData$ = this.movieService.getAll();  
}

onFirstDataRendered(params: FirstDataRenderedEvent) {
  params.api.sizeColumnsToFit();
}

onEdit(params: any) {
  const movieToEdit = JSON.stringify(params);
  this.router.navigateByUrl(`/movies/edit/${params.id}`, { state: { data: params } });
}

onDelete(params: any) {

  this.movieService.delete(params.id)
  .subscribe({
    next: () => {
      this.agGrid.api.applyTransaction({ remove: [params] });
    },
    error: (e) => {
      console.error("error on movie delete", e);
      alert("An error occurred while deleting your movie, please try again.")        
    }
  });

}

}

//#warning - horizontal scrollbars for small devices