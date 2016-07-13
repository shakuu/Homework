// Constants
const maximumAllowedRotationSpeed = 5,
    canvasWidth = 960,
    canvasHeight = 540;

// Prep Kinetic.Stage and layers
var asteroidsKineticStage = new Kinetic.Stage({
    container: 'kinetic-canvas',
    width: canvasWidth,
    height: canvasHeight
});

var bgLayer = new Kinetic.Layer();
var playLayer = new Kinetic.Layer();

asteroidsKineticStage.add(bgLayer);
asteroidsKineticStage.add(playLayer);

// Prep Player Ship
var shipSize = {
    width: 10,
    height: 20
};

var playerShip = new Kinetic.Line({
    points: [0, shipSize.height, shipSize.width / 2, 0, shipSize.width, shipSize.height],
    x: (asteroidsKineticStage.getWidth() - shipSize.width) / 2,
    y: (asteroidsKineticStage.getHeight() - shipSize.height) / 2,
    stroke: 'white',
    offset: { x: 5, y: 10 },
    closed: true
});

playLayer.add(playerShip);
playLayer.draw();

console.log(playerShip.getX(), playerShip.getY());

function getPlayerToken() {
    let playerToken = {
        token: playerShip,
        shots: [],
        movement: {
            forwardAcceleration: 1,
            forwardDeceleration: 0.1,
            forwardVelocity: 0,
            maxForwardVelocity: 5,
            yawAcceleration: 2,
            yawDeceleration: 0.05,
            yawVelocity: 0,
            maxYawVelocity: 10,
            angleOfRotation: 0,
            direction: {
                x: 0,
                y: 0
            }
        },
        lives: 5,
        score: 0
    };

    return playerToken;
}

function adjustPlayerTokenAngle(currentValue) {
    // angle must be between 0 - 360
    if (+currentValue > 360) {
        currentValue -= 360;
    } else if (+currentValue < 360) {
        currentValue += 360;
    }
    return currentValue;
}

var playerToken = getPlayerToken();

function nextPlayerFrame() {
    // Ship Movement
    playerToken.token.setX(playerToken.token.getX() + (playerToken.movement.direction.x * playerToken.movement.forwardVelocity));
    playerToken.token.setY(playerToken.token.getY() + (playerToken.movement.direction.y * playerToken.movement.forwardVelocity));

    // Ship Rotation
    playerToken.token.rotate(playerToken.movement.yawVelocity);
    playerToken.movement.angleOfRotation += playerToken.movement.yawVelocity;

    // Adjust current Angle
    playerToken.movement.angleOfRotation = adjustPlayerTokenAngle(playerToken.movement.angleOfRotation);
}

function nextAsteroidsFrame() {
    // TODO:
}

// Controls functions
function getGameOver() {
    gameOver = true;
}

function getRotateLeft() {
    playerToken.movement.yawVelocity = playerToken.movement.yawVelocity < -playerToken.movement.maxYawVelocity
        ? -playerToken.movement.maxYawVelocity
        : playerToken.movement.yawVelocity -= playerToken.movement.yawAcceleration;
}

function getRotateRight() {
    playerToken.movement.yawVelocity = playerToken.movement.yawVelocity > playerToken.movement.maxYawVelocity
        ? playerToken.movement.maxYawVelocity
        : playerToken.movement.yawVelocity += playerToken.movement.yawAcceleration;
}

function decelerateYawVelocity() {
    let modifier = playerToken.movement.yawDeceleration;

    if (playerToken.movement.yawVelocity < 0) {
        modifier = -modifier;
    }

    if (playerToken.movement.yawVelocity !== 0) {

        if (Math.abs(playerToken.movement.yawVelocity - modifier) < Math.abs(modifier)) {
            playerToken.movement.yawVelocity = 0;
        } else {
            playerToken.movement.yawVelocity -= modifier;
        }
    }
}

function createNewShot() {
    // Starts at current location
    // Direction is current angle
    // Destroyed on out of player area
}

// Get Next Frame
var gameOver = false;
function nextFrame() {
    // Player Ship
    nextPlayerFrame();

    // Asteroids

    // Decelerate Ship
    decelerateYawVelocity();

    // ReDraw
    playLayer.draw();

    // End condition
    if (gameOver) {
        return;
    }

    requestAnimationFrame(nextFrame);
}

// Read input when available
document.getElementById('controls')
    .addEventListener('keydown', function (input) {
        console.log(input.key);

        // GameOver = true;
        if (input.key === 'Escape') {
            getGameOver();
        } else if (input.key === 'ArrowLeft') {
            getRotateLeft();
        } else if (input.key === 'ArrowRight') {
            getRotateRight();
        } else if (input.key === ' ') {
            console.log('space');
        }
    });

nextFrame();