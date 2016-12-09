import { AlignmentType } from '../enums/alignment-type';
import { DamageType } from '../enums/damage-type';
import { DealDamage } from './deal-damage';

export interface TakeDamage {
    healthPoints: number;
    immunities: DamageType[];
    alignmentType: AlignmentType;
    takeDamage(attacker: DealDamage): void
}