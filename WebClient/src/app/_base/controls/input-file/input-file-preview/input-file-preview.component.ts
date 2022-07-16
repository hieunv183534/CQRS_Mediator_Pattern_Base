import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-input-file-preview',
  templateUrl: './input-file-preview.component.html',
  styleUrls: ['./input-file-preview.component.scss']
})
export class InputFilePreviewComponent implements OnInit {

  @Input() url: string;
  @Output() onClose = new EventEmitter<any>();

  constructor() { }

  ngOnInit() {
  }

  async closeDialog(): Promise<void> {
    this.onClose.emit();
  }

}
