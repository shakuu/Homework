'use strict';

class listNode {
    constructor(value) {
        this.value = value;
        this.next = null;
    }
}

class LinkedList {
    constructor() {

        return this;
    }

    get first() {
        return this._first.value;
    }

    set first(node) {
        this._first = node;
    }

    get last() {
        return this._last.value;
    }

    set last(node) {
        this._last = node;
    }

    get length() {
        // TODO:
        return 0;
    }

    append(...values) {
        const newNodes = this._buildNodesList(values);

        if (!this._first) {
            this._handleEmptyList(newNodes);
        } else {
            this._last.next = newNodes.first;
            this._last = newNodes.last;
        }

        return this;
    }

    prepend(...values) {
        const newNodes = this._buildNodesList(values);

        if (!this._first) {
            this._handleEmptyList(newNodes);
        } else {
            newNodes.last.next = this._first;
            this._first = newNodes.first;
        }

        return this;
    }

    insert(index, ...values) {
        if (index === 0) {
            this.prepend(...values);
        } else if (index === this.length) {
            this.append(...values);
        } else {
            const newNodes = this._buildNodesList(values);
            let previousNode = this._getNodeAtIndex(index);
            if (!previousNode) {
                previousNode = this._last;
            }

            let nextNode = this._getNodeAtIndex(index + 1);
            if (!nextNode) {
                nextNode = null;
            }

            previousNode.next = newNodes.first;
            newNodes.last.next = nextNode;
        }

        return this;
    }

    at(index, value) {
        const node = this._getNodeAtIndex(index + 1);
        if (value) {
            node.value = value;
        } else {
            return node.value;
        }
    }

    removeAt(index) {
        const previousNode = this._getNodeAtIndex(index);
        const nextNode = this._getNodeAtIndex(index + 2);

        let removed;
        if (!previousNode) {
            removed = this._first;
            this._first = this._first.next;
            removed.next = null;
        } else {
            removed = previousNode.next;
            previousNode.next = nextNode;
        }

        return removed.value;
    }

    toArray() {
        let result = [];
        for (const value of this) {
            result.push(value);
        }

        return result;
    }

    toString() {
        let asArray = this.toArray(),
            result = asArray.join(' -> ');

        return result;
    }

    *[Symbol.iterator]() {
        let currentNode = this._first;
        while (currentNode) {
            yield currentNode.value;
            currentNode = currentNode.next;
        }
    }

    _getNodeAtIndex(index) {
        let currentNode = this._first,
            count = 0,
            node;

        if (index - 1 < 0) {
            return null;
        }

        while (currentNode) {
            if (count === index - 1) {
                node = currentNode;
                break;
            }

            currentNode = currentNode.next;
            count += 1;
        }

        if (!node) {
            node = null;
        }

        return node;
    }

    _handleEmptyList(nodes) {
        this._first = nodes.first;
        this._last = nodes.last;
    }

    _buildNodesList(values) {
        let localFirst,
            localLast,
            previousNode;

        for (let i = 0; i < values.length; i += 1) {
            const newNode = new listNode(values[i]);

            if (!localFirst) {
                localFirst = newNode;
                previousNode = newNode;
                localLast = newNode;
            } else {
                previousNode.next = newNode;
                previousNode = newNode;
                localLast = newNode;
            }
        }

        return {
            first: localFirst,
            last: localLast
        };
    }
}

module.exports = LinkedList;