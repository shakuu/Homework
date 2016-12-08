import { DamageType } from '../enums/damage-type';
import { DealDamage } from './deal-damage';

export interface TakeDamage {
    healthPoints: number;
    immunities: DamageType[];
    takeDamage(attacker: DealDamage): void
}