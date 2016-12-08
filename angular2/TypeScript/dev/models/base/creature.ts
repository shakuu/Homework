import { DealDamage } from '../contracts/deal-damage';
import { TakeDamage } from '../contracts/take-damage';

import { DamageType } from '../enums/damage-type';

export abstract class Creature implements DealDamage, TakeDamage {
    damage: number;
    damageType: DamageType;
    healthPoints: number;
    immunities: DamageType[];
    name: string;

    constructor(name: string, damage: number, damageType: DamageType, healthPoints: number, immunities: DamageType[]) {
        this.name = name;
        this.damage = damage;
        this.damageType = damageType;
        this.healthPoints = healthPoints;
        this.immunities = immunities;
    }

    dealDamage(target: TakeDamage): void {

    }

    takeDamage(attacker: DealDamage): void {

    }
}