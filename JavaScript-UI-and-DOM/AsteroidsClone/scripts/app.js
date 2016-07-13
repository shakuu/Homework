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
            forwardAcceleration: 1.2,
            forwardDeceleration: 0.01,
            forwardVelocity: 0,
            maxForwardVelocity: 3,
            yawAcceleration: 2.4,
            yawDeceleration: 0.01,
            yawVelocity: 0,
            maxYawVelocity: 5,
            angleOfRotation: 0,
            forwardDirections: []
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
    } else if (+currentValue < 0) {
        currentValue += 360;
    }
    return currentValue;
}

var playerToken = getPlayerToken();

function keepObjectOnCanvas(object, sizeOfObject) {
    // Left - Right
    if (object.token.getX() + sizeOfObject.width / 2 < 0) {
        object.token.setX(asteroidsKineticStage.getWidth() - sizeOfObject.width / 2);
    } else if (object.token.getX() - sizeOfObject.width / 2 > asteroidsKineticStage.getWidth()) {
        object.token.setX(sizeOfObject.width / 2);
    }
    // Up - Down
    if (object.token.getY() + sizeOfObject.height / 2 < 0) {
        object.token.setY(asteroidsKineticStage.getHeight() - sizeOfObject.height / 2);
    } else if (object.token.getY() - sizeOfObject.height / 2 > asteroidsKineticStage.height()) {
        object.token.setY(sizeOfObject.height / 2);
    }
}

function nextPlayerFrame() {
    // Apply each forward motion to the ship
    let motionsArrayLength = playerToken.movement.forwardDirections.length;
    let totalSpeed = {
        x: 0,
        y: 0
    };

    for (let index = motionsArrayLength - 1; index >= 0; index -= 1) {
        let currentMotion = playerToken.movement.forwardDirections[index];

        playerToken.token.setX(playerToken.token.getX() + (currentMotion.deltaX * currentMotion.velocity));
        playerToken.token.setY(playerToken.token.getY() + (currentMotion.deltaY * currentMotion.velocity));

        totalSpeed.x += (currentMotion.deltaX * currentMotion.velocity);
        totalSpeed.y += (currentMotion.deltaY * currentMotion.velocity);

        // Decelerate
        playerToken.movement.forwardDirections[index].velocity -= playerToken.movement.forwardDeceleration;

        // Remove the motion if it no longer applies
        if (playerToken.movement.forwardDirections[index].velocity < 0) {
            playerToken.movement.forwardDirections[index].velocity = 0;
        }

        keepObjectOnCanvas(playerToken, shipSize);
        // Bug with ship shooting too far
        // Break if total speed is too high
        // if (totalSpeed.x > 3 * playerToken.movement.maxForwardVelocity ||
        //     totalSpeed.y > 3 * playerToken.movement.maxForwardVelocity) {
        //     break;
        // }
    }

    // Ship Rotation
    playerToken.token.rotate(playerToken.movement.yawVelocity);
    playerToken.movement.angleOfRotation += playerToken.movement.yawVelocity;

    // Adjust current Angle
    playerToken.movement.angleOfRotation = adjustPlayerTokenAngle(playerToken.movement.angleOfRotation);
}

function nextAsteroidsFrame() {
    // TODO:
}

// Move shots -> Constant velocity
// Destroy shot when out of canvas
// Check for collision - > when asteroids are implemented
function nextShotsFrame() {
    console.log(playerToken.shots);

    let velocity = 8.5;
    let numberOfShots = playerToken.shots.length;

    for (let index in playerToken.shots) {
        // Move
        playerToken.shots[index].token.setX(playerToken.shots[index].token.getX() + playerToken.shots[index].direction.deltaX * velocity);
        playerToken.shots[index].token.setY(playerToken.shots[index].token.getY() + playerToken.shots[index].direction.deltaY * velocity);

        // Destroy if needed
        if (playerToken.shots[index].token.getX() < -10 || playerToken.shots[index].token.getX() > asteroidsKineticStage.getWidth() + 10) {
            // playLayer.remove(playerToken.shots[index].token);
            delete playerToken.shots[index];
        } else if (playerToken.shots[index].token.getY() < -10 || playerToken.shots[index].token.getY() > asteroidsKineticStage.getHeight() + 10) {
            delete playerToken.shots[index];
        }
    }
}

// Controls functions
function getGameOver() {
    gameOver = true;
}

// Rotation the Ship
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

function getCurrentDirection() {
    let directionOfMovement = {
        deltaX: ((((shipSize.height / 2) * Math.sin(playerToken.movement.angleOfRotation * Math.PI / 180))) / 10),
        deltaY: -((((shipSize.height / 2) * Math.cos(playerToken.movement.angleOfRotation * Math.PI / 180))) / 10),
        velocity: playerToken.movement.forwardAcceleration
    };

    return directionOfMovement;
}
// X = xcircle + (r * sin(angle))
// Y = ycircle + (r * cos(angle))
// Moving the Ship
function createNewForwardMotion() {
    // Get direction
    let currentDirection = getCurrentDirection();

    console.log(currentDirection); // DELETE THIS LINE
    console.log(playerToken.movement.angleOfRotation);

    // If old direction -> accelerate
    // if (playerToken.movement.forwardDirections.length > 0) {
    //     // Adjust existing motion
    //     let length = playerToken.movement.forwardDirections.length;

    //     if (playerToken.movement.forwardDirections[length - 1].deltaX === currentDirection.deltaX &&
    //         playerToken.movement.forwardDirections[length - 1].deltaY === currentDirection.deltaY) {

    //         playerToken.movement.forwardDirections[length - 1].velocity += playerToken.movement.forwardAcceleration;

    //         // Stay within maxForwardVelocity limit
    //         if (playerToken.movement.forwardDirections[length - 1].velocity > playerToken.movement.maxForwardVelocity) {
    //             playerToken.movement.forwardDirections[length - 1].velocity = playerToken.movement.maxForwardVelocity;
    //         }

    //         // Exit function
    //         return;
    //     }
    // }

    // If new direction push to the stack of forward motion
    playerToken.movement.forwardDirections.push(currentDirection);
}

// Direction of movement
// All shots have the same speed
// build a Visual token ( line ? dot ? square ? )
function createNewShot() {
    // Starts at current location
    // Direction is current angle
    // Destroyed on out of player area
    console.log('called');

    let shotToken = new Kinetic.Rect({
        x: 20,
        y: 20,
        width: 4,
        height: 4,
        offset: { x: 2, y: 2 },
        fill: 'limegreen'
    }).rotate(playerToken.movement.angleOfRotation);

    let shotDirection = getCurrentDirection();

    let shot = {
        token: shotToken,
        direction: shotDirection
    };

    playerToken.shots.push(shot);

    shot.token.setX(playerToken.token.getX() + shot.direction.deltaX * 10);
    shot.token.setY(playerToken.token.getY() + shot.direction.deltaY * 10);

    // Testing 
    playLayer.add(shotToken);
    playLayer.draw();

}



// Get Next Frame
var gameOver = false;
function nextFrame() {
    // Player Ship
    nextPlayerFrame();

    // Asteroids

    // Update shots
    nextShotsFrame();

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
            createNewShot();
        } else if (input.key === 'ArrowUp') {
            createNewForwardMotion();
        }
    });

nextFrame();