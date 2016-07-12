// Variables
var canvas,
    context;

// Get the element and get the context;
canvas = document.getElementById('testing-canvas');
context = canvas.getContext('2d');

// Get gradient
var gradient = context.createLinearGradient(0, 0, 20, 0);
gradient.addColorStop(0, 'blue');
gradient.addColorStop(1, 'orange');

context.strokeStyle = 'yellowgreen';
context.lineWidth = 3;
context.fillStyle = gradient;

// Animation
let rectPosition = {
    x: 1,
    y: 1
};

rectSpeed = {
    x: 1,
    y: 1
};

// Pacman
var mouthOpenDegrees = 1;
var mouthCloseSpeed = 1;

function moveRect() {

    // Update the gradient before each draw;
    var gradient = context.createLinearGradient(rectPosition.x, rectPosition.y, rectPosition.x + 20, rectPosition.y);
    gradient.addColorStop(0, 'blue');
    gradient.addColorStop(0.5, 'orange');
    gradient.addColorStop(1, 'blue');

    // Assing the gradient to as a current fill.
    context.fillStyle = gradient;

    // Draw with the current gradient fill.
    context.clearRect(0, 0, canvas.width, canvas.height);
    context.fillRect(rectPosition.x, rectPosition.y, 20, 20);
    context.strokeRect(rectPosition.x, rectPosition.y, 20, 20);

    // Testing Arc
    context.beginPath();
    context.arc(300, 120, 30, (30 - mouthOpenDegrees) * Math.PI / 180, 180 * Math.PI / 180);
    context.arc(300, 120, 30, 180 * Math.PI / 180, (330 + mouthOpenDegrees) * Math.PI / 180);
    context.lineTo(300, 120);
    context.fill();

    // Adjust horizontal speed
    if (rectPosition.x === canvas.width - 20 || rectPosition.x === 0) {
        rectSpeed.x = -rectSpeed.x;
    }

    // Adjust vertical speed
    if (rectPosition.y === canvas.height - 20 || rectPosition.y === 0) {
        rectSpeed.y = -rectSpeed.y;
    }

    // Adjsut Pacman Mouth
    if (mouthOpenDegrees === 0 || mouthOpenDegrees ===30){
        mouthCloseSpeed = -mouthCloseSpeed;
    }

    // Update current postion.
    rectPosition.x += rectSpeed.x;
    rectPosition.y += rectSpeed.y;

    // Update Mouth
    mouthOpenDegrees += mouthCloseSpeed;

    // Request a new frame.
    window.requestAnimationFrame(moveRect);
}

window.requestAnimationFrame(moveRect);

