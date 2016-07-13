var kineticStage = new Kinetic.Stage({
    container: 'kinetic-div',
    width: 640,
    height: 360
});

var layer = new Kinetic.Layer();

kineticStage.add(layer);

var rect2 = new Kinetic.Rect({
    x: 150,
    y: 50,
    width: 100,
    height: 100,
    fill: 'green',
    stroke: 'black',
    lineWidth: 5,
    offset: { x: 50, y: 50 }
});

var ship = new Kinetic.Line({
    points: [0, 100, 25, 0, 50, 100],
    stroke: 'white',
    x: 350,
    y: 250,
    offset: { x: 25, y: 50 },
    closed: true
});

layer.add(rect2);
layer.add(ship);
layer.draw();

var pacman = new Kinetic.Shape({
    x: 250,
    y: 250,
    fill: 'yellow',
    drawFunc: function (context) {
        context.beginPath();
        context.arc(0, 0, 30, (30 - mouthOpenDegrees) * Math.PI / 180, 180 * Math.PI / 180);
        context.arc(0, 0, 30, 180 * Math.PI / 180, (330 + mouthOpenDegrees) * Math.PI / 180);
        context.lineTo(0, 0);
        context.fillStrokeShape(this);
    },
    offset: { x: 0, y: 0 },
});

layer.add(pacman);

var currentRotationAngle = 0.5;
var mouthOpenDegrees = 1;
var mouthCloseSpeed = 2;

function rotate() {
    rect2.rotate(currentRotationAngle);
    ship.rotate(currentRotationAngle);
    pacman.rotate(currentRotationAngle);
    pacman.drawFunc();
    // pacman.drawFunc(layer, currentRotationAngle);
    // Adjsut Pacman Mouth
    if (mouthOpenDegrees <= 0 || mouthOpenDegrees >= 30) {
        mouthCloseSpeed = -mouthCloseSpeed;
    }
    mouthOpenDegrees += mouthCloseSpeed;
    window.requestAnimationFrame(rotate);
    layer.draw();
}

rotate();