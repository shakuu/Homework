window.onload = function () {

    var kineticStage = new Kinetic.Stage({
        container: 'kinetic-div',
        width: 640,
        height: 360
    });

    var layer = new Kinetic.Layer();

    var rect = new Kinetic.Rect({
        x: 0,
        y: 0,
        width: 100,
        height: 100,
        fill: 'black',
        stroke: 'black',
        lineWidth: 5
    });

    layer.add(rect);
    kineticStage.add(layer);

    var rect2 = new Kinetic.Rect({
        x: 150,
        y: 0,
        width: 100,
        height: 100,
        fill: 'green',
        stroke: 'black',
        lineWidth: 5
    });

    layer.add(rect2);
    kineticStage.add(layer);

    
};