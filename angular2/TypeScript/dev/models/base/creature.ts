import { AlignmentType } from "../enums/alignment-type";
import { DealDamage } from "../contracts/deal-damage";
import { TakeDamage } from "../contracts/take-damage";
import { DamageType } from "../enums/damage-type";

export abstract class Creature implements DealDamage, TakeDamage {
    damage: number;
    damageType: DamageType;
    healthPoints: number;
    immunities: DamageType[];
    name: string;
    alignmentType: AlignmentType;

    constructor(name: string, damage: number, damageType: DamageType, healthPoints: number, immunities: DamageType[]) {
        this.name = name;
        this.damage = damage;
        this.damageType = damageType;
        this.healthPoints = healthPoints;
        this.immunities = immunities;
    }

    dealDamage(target: TakeDamage): void {
        const a = 5;
    }

    takeDamage(attacker: DealDamage): void {
        const a = 5;
    }

    acquireTarget(availableCreatures: TakeDamage[]): TakeDamage {
        let foundCreature: TakeDamage = this.findTargetOfType(availableCreatures, (c) => c.alignmentType !== this.alignmentType);
        if (foundCreature !== null) {
            return foundCreature;
        }

        foundCreature = this.findTargetOfType(availableCreatures, (c) => c.alignmentType === AlignmentType.Neutral);
        if (foundCreature !== null) {
            return foundCreature;
        }

        foundCreature = this.findTargetOfType(availableCreatures, (c) => c.alignmentType === this.alignmentType);
        if (foundCreature !== null) {
            return foundCreature;
        }

        return undefined;
    }

    findTargetOfType(availableCreatures: TakeDamage[], predicate: (c: TakeDamage) => {}): TakeDamage {
        let foundCreature: TakeDamage = null;
        for (const creature of availableCreatures) {
            if (predicate(creature)) {
                foundCreature = creature;
                break;
            }
        }

        return foundCreature;
    }
}