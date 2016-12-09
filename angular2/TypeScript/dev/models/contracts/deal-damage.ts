import { DamageType } from '../enums/damage-type';
import { TakeDamage } from './take-damage';

export interface DealDamage {
    damage: number,
    damageType: DamageType
    dealDamage(target: TakeDamage): void
    acquireTarget(availableCreatures: TakeDamage[]): TakeDamage
}