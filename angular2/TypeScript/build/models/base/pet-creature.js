"use strict";
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var creature_1 = require("./creature");
var PetCreature = (function (_super) {
    __extends(PetCreature, _super);
    function PetCreature(name, damage, damageType, healthPoints, immunities) {
        return _super.call(this, name, damage, damageType, healthPoints, immunities) || this;
    }
    PetCreature.prototype.dealDamage = function (target) {
    };
    return PetCreature;
}(creature_1.Creature));
exports.PetCreature = PetCreature;
//# sourceMappingURL=pet-creature.js.map