import { Component } from '@angular/core';
@Component({
    selector: 'navigation',
    templateUrl: 'navigation.component.html'
})
export class NavigationComponent {
    selectedItemName: String;

    markSelectedItem(itemName: string) {
        itemName = itemName || '';
        this.selectedItemName = itemName;
    }
}
