import { AlignmentType } from './enums/alignment-type';
import { Creature } from './base/creature';

export class Power {
    name: string;
    AlignmentType: AlignmentType;

    constructor(name: string, alignmentType: AlignmentType) {
        this.name = name;
        this.AlignmentType = alignmentType;
    }

    applyEffect(target: Creature): void {

    }
}