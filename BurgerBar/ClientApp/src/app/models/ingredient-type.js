"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var IngredientType;
(function (IngredientType) {
    IngredientType[IngredientType["Meat"] = 0] = "Meat";
    IngredientType[IngredientType["Cheese"] = 1] = "Cheese";
    IngredientType[IngredientType["Sauce"] = 2] = "Sauce";
    IngredientType[IngredientType["Vegetable"] = 3] = "Vegetable";
    IngredientType[IngredientType["Spice"] = 4] = "Spice";
})(IngredientType = exports.IngredientType || (exports.IngredientType = {}));
(function (IngredientType) {
    function values() {
        return Object.keys(IngredientType).filter(function (type) { return isNaN(type) && type !== 'values'; });
    }
    IngredientType.values = values;
})(IngredientType = exports.IngredientType || (exports.IngredientType = {}));
//# sourceMappingURL=ingredient-type.js.map