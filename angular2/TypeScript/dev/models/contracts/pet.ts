import { Creature } from '../base/creature';
import { Owner } from './owner';

export interface Pet {
    ownerCreature: Owner;

    dealDamage(target: Creature): void;
}