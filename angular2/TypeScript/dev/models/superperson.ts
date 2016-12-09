import { AlignmentType } from './enums/alignment-type';
import { Creature } from './base/creature';
import { DamageType } from './enums/damage-type';
import { Owner } from './contracts/owner';
import { Pet } from './contracts/pet';
import { Power } from './power';
import { Powers } from './contracts/powers';

// There's nothing differentiating a super hero from a super villain,
// therefore there's no need for a separate type.
export class Superperson extends Creature implements Owner, Powers {
    petName: string;
    petCreature: Pet;
    helpfulPowers: Power[];
    destructivePowers: Power[];

    constructor(name: string, damage: number, damageType: DamageType, healthPoints: number, immunities: DamageType[], helpfulPowers: Power[], destructivePowers: Power[]) {
        super(name, damage, damageType, healthPoints, immunities);

        this.helpfulPowers = helpfulPowers;
        this.destructivePowers = destructivePowers;
    }

    addPet(pet: Pet, petName: string): void {
        this.petName = petName;
        this.petCreature = pet;
        pet.ownerCreature = this;
    }
}