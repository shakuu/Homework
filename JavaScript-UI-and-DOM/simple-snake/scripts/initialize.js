var gameStage,
    gameLayers = [];

window.onload = function () {
    initializeKineticStage();
    initializeKineticLayers(numberOfKineticLayers);
};

function initializeKineticStage() {
    gameStage = new Kinetic.Stage({
        container: 'kinetic-stage',
        width: gameStageWidth,
        height: gameStageHeight
    });
}

function initializeKineticLayers(number) {
    for (let i = 0; i < +number; i += 1) {
        gameLayers[i] = new Kinetic.Layer();
    }
}