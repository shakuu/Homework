import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
    selector: 'filter-movies-list-component',
    templateUrl: './filter-movies-list.component.html'
})
export class FilterMoviesListComponent {
    @Input()
    filterText: string;

    @Output()
    onFilterTextChange: EventEmitter<string> = new EventEmitter<string>();

    filterTextChange() {
        this.onFilterTextChange.emit(this.filterText);
    }
}
