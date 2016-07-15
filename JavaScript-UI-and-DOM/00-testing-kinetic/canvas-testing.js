var rotation = 0;

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

var mouthOpenDegrees = 1;

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

layer.add(rect2);
layer.add(ship);
layer.add(pacman);
layer.draw();

var currentRotationAngle = 0.5;
var mouthCloseSpeed = 2;

var toRotate = true;


function rotate() {
    rotation += currentRotationAngle;
    rect2.rotate(currentRotationAngle);
    ship.rotate(currentRotationAngle);
    pacman.rotate(currentRotationAngle);

    // Adjsut Pacman Mouth
    if (mouthOpenDegrees <= 0 || mouthOpenDegrees >= 30) {
        mouthCloseSpeed = -mouthCloseSpeed;
    }
    mouthOpenDegrees += mouthCloseSpeed;
    layer.draw();

    window.requestAnimationFrame(rotate);

}
// X = xcircle + (r * sin(angle))
// Y = ycircle + (r * cos(angle))
function getDelta() {
    console.log(rotation);
    let radius = 50;
    
    console.log((radius * Math.sin(rotation * Math.PI / 180)));
    console.log((radius * Math.cos(rotation * Math.PI / 180)));

    
    // delta.x /= 10;
    // delta.y /= 10;

}

var docbody = document.getElementById('wrapper')
    .addEventListener('keydown', function (args) {
        console.log(args.key);

        if (args.key === 'ArrowLeft') {

            currentRotationAngle -= 0.5;

        } else if (args.key === 'ArrowRight') {

            currentRotationAngle += 0.5;

        } else if (args.key === 'a') {
            start();
        } else if (args.key === 'ArrowDown') {
            currentRotationAngle = 0;
        } else if (args.key === 'ArrowUp') {
            getDelta();
        }
    });


rotate();


// rotate();