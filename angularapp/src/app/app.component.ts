//import { HttpClient } from '@angular/common/http';
import { Component, ViewChild } from '@angular/core';
import { AgGridAngular } from 'ag-grid-angular';

import { CellClickedEvent, ColDef, GridReadyEvent } from 'ag-grid-community';
import { Observable } from 'rxjs';
import { GridcarService } from './core/services/gridcar.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  constructor(
    private readonly gridcarService: GridcarService
    //http: HttpClient
  )
  {
  //  http.get<WeatherForecast[]>('/weatherforecast').subscribe(result => {
  //    this.forecasts = result;
  //  }, error => console.error(error));
  }


  //public forecasts?: WeatherForecast[];


  //title = 'angularapp';

  columnDefs: ColDef[] = [
    { field: 'make' },
    { field: 'model' },
    { field: 'price' }
  ];

  // DefaultColDef sets props common to all Columns
  public defaultColDef: ColDef = {
    sortable: true,
    filter: true,
  };

  // Data that gets displayed in the grid
  public rowData$!: Observable<any[]>;

  // For accessing the Grid's API
  @ViewChild(AgGridAngular) agGrid!: AgGridAngular;


  // Example load data from server
  onGridReady(params: GridReadyEvent) {
    this.rowData$ = this.gridcarService.getAll(); // looks like this thing subscribes automatically/itself



    //  of(
    //  [
    //    { make: 'Toyota', model: 'Celica', price: 35000 },
    //    { make: 'Ford', model: 'Mondeo', price: 32000 },
    //    { make: 'Porsche', model: 'Boxster', price: 72000 }
    //  ]
    //);

    // here you would use the injected service
  //    this.http
  //    .get<any[]>('https://www.ag-grid.com/example-assets/row-data.json');
  }

  // Example of consuming Grid Event
  onCellClicked(e: CellClickedEvent): void {
    console.log('cellClicked', e);
  }

  // Example using Grid's API
  clearSelection(): void {
    this.agGrid.api.deselectAll();
  }

}

//interface WeatherForecast {
//  date: string;
//  temperatureC: number;
//  temperatureF: number;
//  summary: string;
//}
