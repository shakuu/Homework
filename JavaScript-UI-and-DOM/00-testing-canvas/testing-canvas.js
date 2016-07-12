// Variables
var canvas,
    context;

// Get the element and get the context;
canvas = document.getElementById('testing-canvas');
context = canvas.getContext('2d');

let rectPosition = {
    x: 0,
    y: 0
};

let x = 0;

context.fillStyle = 'blue';

var i = 0;

function moveRect() {
    context.clearRect(0, 0, canvas.width, canvas.height);
    context.fillRect(i * 20, 0, 20, 20);

    i += 0.01;
    window.requestAnimationFrame(moveRect);
}

window.requestAnimationFrame(moveRect);

