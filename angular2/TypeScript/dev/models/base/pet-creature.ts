import { Creature } from './creature';
import { DamageType } from '../enums/damage-type';
import { Owner } from '../contracts/owner';
import { Pet } from '../contracts/pet';

export abstract class PetCreature extends Creature implements Pet {
    ownerCreature: Owner;

    constructor(name: string, damage: number, damageType: DamageType, healthPoints: number, immunities: DamageType[]) {
        super(name, damage, damageType, healthPoints, immunities);
    }

    dealDamage(target: Creature): void {

    }
}