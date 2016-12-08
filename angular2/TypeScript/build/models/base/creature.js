"use strict";
var Creature = (function () {
    function Creature(name, damage, damageType, healthPoints, immunities) {
        this.name = name;
        this.damage = damage;
        this.damageType = damageType;
        this.healthPoints = healthPoints;
        this.immunities = immunities;
    }
    Creature.prototype.dealDamage = function (target) {
    };
    Creature.prototype.takeDamage = function (attacker) {
    };
    return Creature;
}());
exports.Creature = Creature;
//# sourceMappingURL=creature.js.map