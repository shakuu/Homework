import { Component, Output, EventEmitter } from '@angular/core';

@Component({
    selector: 'sort-order-movies-component',
    templateUrl: './sort-order-movies.component.html'
})
export class SortOrderMoviesComponent {
    @Output() onUpdateSortBy: EventEmitter<string>;
    @Output() onUpdateOrder: EventEmitter<string>;

    sortBy: string;
    order: string;

    constructor() {
        this.onUpdateSortBy = new EventEmitter<string>();
        this.onUpdateOrder = new EventEmitter<string>();

        this.sortBy = 'IMDB Rating';
        this.order = 'Descending';
    }

    updateSortBy(updatedValue: string) {
        if (!updatedValue || typeof updatedValue !== 'string') {
            updatedValue = 'IMDB Rating';
        }

        this.sortBy = updatedValue;
        this.onUpdateSortBy.emit(this.sortBy);
    }

    updateOrder(updatedValue: string) {
        if (!updatedValue || typeof updatedValue !== 'string') {
            updatedValue = 'Descending';
        }

        this.order = updatedValue;
        this.onUpdateOrder.emit(this.order);
    }
}
