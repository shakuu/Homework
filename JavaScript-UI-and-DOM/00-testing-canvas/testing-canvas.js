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

    // Adjust horizontal speed
    if (rectPosition.x === canvas.width - 20 || rectPosition.x === 0) {
        rectSpeed.x = -rectSpeed.x;
    }

    // Adjust vertical speed
    if (rectPosition.y === canvas.height - 20 || rectPosition.y === 0) {
        rectSpeed.y = -rectSpeed.y;
    }

    // Update current postion.
    rectPosition.x += rectSpeed.x;
    rectPosition.y += rectSpeed.y;

    // Request a new frame.
    window.requestAnimationFrame(moveRect);
}

window.requestAnimationFrame(moveRect);

