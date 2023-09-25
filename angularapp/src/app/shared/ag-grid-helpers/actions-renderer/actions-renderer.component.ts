import { Component, Input } from '@angular/core';
import { ICellRendererAngularComp } from 'ag-grid-angular';
import { ICellRendererParams } from 'ag-grid-community';

@Component({
  selector: 'actions-renderer',
  templateUrl: './actions-renderer.component.html',
  styleUrls: ['./actions-renderer.component.scss']
})

export class ActionsRendererComponent implements ICellRendererAngularComp {
  params: any;

  @Input() id!: number;

  agInit(params: ICellRendererParams): void {
    this.params = params;
  }

  refresh(params: ICellRendererParams): boolean {
    this.params = params;
    return true;
  }

  editClicked(): void {
    this.params.onEdit(this.params.data);
  }

  deleteClicked(): void {
    this.params.onDelete(this.params.data);
  }

}
