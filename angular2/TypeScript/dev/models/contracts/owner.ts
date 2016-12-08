import { Pet } from './pet';

export interface Owner {
    petName: string;
    petCreature: Pet;
}