"use strict";
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var creature_1 = require("./base/creature");
// There's nothing differentiating a super hero from a super villain,
// therefore there's no need for a separate type.
var Superperson = (function (_super) {
    __extends(Superperson, _super);
    function Superperson(name, damage, damageType, healthPoints, immunities, helpfulPowers, destructivePowers) {
        var _this = _super.call(this, name, damage, damageType, healthPoints, immunities) || this;
        _this.helpfulPowers = helpfulPowers;
        _this.destructivePowers = destructivePowers;
        return _this;
    }
    Superperson.prototype.addPet = function (pet, petName) {
        this.petName = petName;
        this.petCreature = pet;
        pet.ownerCreature = this;
    };
    return Superperson;
}(creature_1.Creature));
exports.Superperson = Superperson;
//# sourceMappingURL=superperson.js.map