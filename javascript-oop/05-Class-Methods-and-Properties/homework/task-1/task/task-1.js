'use strict';

class listNode {
    constructor(value) {
        this._data = value;
    }

    get data() {
        return this._data;
    }

    set data(data) {
        this._data = data;
    }

    get next() {
        return this._next;
    }

    set next(next) {
        this._next = next;
    }
}

class LinkedList {
    constructor() {
        return this;
    }

    get first() {
        return this._first.data;
    }

    get last() {
        return this._last.data;
    }

    get length() {
        this._length = this._countNodes();
        return this._length;
    }

    append(...elements) {
        this._addElementsAtIndex(elements, Number.MAX_VALUE);
        return this;
    }

    insert(...elements) {
        this._addElementsAtIndex(elements.slice(1), elements[0]);
        return this;
    }

    at(index, value) {
        const node = this._getNodeAtIndex(index);

        if (value || value === 0) {
            node.data = value;
            return this;
        } else {
            return node;
        }
    }

    prepend(...elements) {
        const self = this;

        let nextNode = this._getNodeAtIndex(0);
        for (let i = elements.length - 1; i >= 0; i -= 1) {
            const newNode = this._createNewElement(elements[i]);

            if (nextNode) {
                newNode.next = nextNode;
            } else {
                this._assignFirstAndLast(newNode);
            }

            nextNode = newNode;
            this._first = newNode;
        }

        return self;
    }

    toArray() {
        const listAsArray = [];
        let node = this._first;
        while (node) {
            listAsArray.push(node.data);
            node = node.next;
        }

        return listAsArray;
    }

    toString() {
        let result = this.toArray().join(' -> ');
        return result;
    }

    *[Symbol.iterator]() {
        let node = this._first;

        while (node) {
            yield node;
            node = node.next;
        }
    }

    _addElementsAtIndex(elements, index) {
        let previousNode = this._getNodeAtIndex(index - 1);
        for (let i = 0; i < elements.length; i += 1) {
            const newNode = this._createNewElement(elements[i]);

            if (previousNode) {
                newNode.next = previousNode.next;
                previousNode.next = newNode;
            } else {
                this._assignFirstAndLast(newNode);
            }

            previousNode = newNode;
        }

        this._updateLastNode();
    }

    _getNodeAtIndex(index) {
        index = index < 0 ? 0 : index;
        index = index > this.length ? this.length - 1 : index;

        let count = 0;
        let node = this._first;
        while (node && count < index) {
            node = node.next;
            count += 1;
        }

        return node;
    }

    _countNodes() {
        let nodesCount = 0;
        let node = this._first;

        while (node) {
            nodesCount += 1;
            node = node.next;
        }

        return nodesCount;
    }

    _updateLastNode() {
        let node = this._first;
        while (node) {
            if (!node.next) {
                this._last = node;
            }

            node = node.next;
        }
    }

    _assignFirstAndLast(node) {
        this._first = node;
        this._last = node;
    }

    _createNewElement(value) {
        const newNode = new listNode(value);
        return newNode;
    }
}


const list = new LinkedList()
    .append(1, 2)
    .append(3, 4)
    .append(5)
    .append(6);

console.log(list.toString());
console.log(list.last);
module.exports = LinkedList;