import { PetCreature } from './base/pet-creature';
import { DamageType } from './enums/damage-type';

export class RegularPerson extends PetCreature {
    constructor(name: string, damage: number, damageType: DamageType, healthPoints: number, immunities: DamageType[]) {
        super(name, damage, damageType, healthPoints, immunities);
    }
}