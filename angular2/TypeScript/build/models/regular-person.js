"use strict";
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var pet_creature_1 = require("./base/pet-creature");
var RegularPerson = (function (_super) {
    __extends(RegularPerson, _super);
    function RegularPerson(name, damage, damageType, healthPoints, immunities) {
        return _super.call(this, name, damage, damageType, healthPoints, immunities) || this;
    }
    return RegularPerson;
}(pet_creature_1.PetCreature));
exports.RegularPerson = RegularPerson;
//# sourceMappingURL=regular-person.js.map