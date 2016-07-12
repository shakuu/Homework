let myCanvas = document.getElementById('the-canvas');
console.log(myCanvas);
let context = myCanvas.getContext('2d');

context.fillStyle = 'rgb(107, 187, 201)';

let rectanglePosition = {
    'x': 0,
    'y': 0
};

function anim() {
    context.fillRect(0, 0, 100, 100);
    rectanglePosition.x += 1;
    rectanglePosition.y += 1;
}

context.
