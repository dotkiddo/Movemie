import { Component, Input } from '@angular/core';
import { ICellRendererAngularComp } from 'ag-grid-angular';
import { ICellRendererParams } from 'ag-grid-community';

@Component({
  selector: 'app-edit-delete-buttons',
  templateUrl: './edit-delete-buttons.component.html',
  styleUrls: ['./edit-delete-buttons.component.scss']
})

export class EditDeleteButtonsComponent implements ICellRendererAngularComp {

  @Input() id!: number;

  agInit(params: ICellRendererParams): void {
    this.id = this.getId(params);
  }

  refresh(params: ICellRendererParams): boolean {
    this.id = this.getId(params);
    return true;
  }

  btnEditClickedHandler() {
    //this.params.clicked(this.params.value);

    // how would you pass the appropriate function in here?
  }

  btnDeleteClickedHandler() {
    //this.params.clicked(this.params.value);

    // how would you pass the appropriate function in here?
  }

  getId(params: ICellRendererParams) {
    return params.valueFormatted ? params.valueFormatted : params.value;
  }

}
