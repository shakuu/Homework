import { Creature } from '../models/base/creature';

export class SuperheroesBrawlEngine {
    start(creatures: Creature[]) {
        while (creatures.length > 0) {
            creatures.forEach(att => {
                creatures.forEach(def => {
                    att.dealDamage(def);
                })
            })
        }
    }
}