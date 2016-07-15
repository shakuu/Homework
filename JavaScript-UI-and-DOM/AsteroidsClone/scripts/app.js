
// Constants
const maximumAllowedRotationSpeed = 5,
    canvasWidth = 960,
    canvasHeight = 540;

var asteroidsKineticStage,
    bgLayer,
    playLayer,
    asteroidsLayer,
    shotsLayer;

// Prep Kinetic.Stage and layers
function initStage() {
    asteroidsKineticStage = new Kinetic.Stage({
        container: 'kinetic-canvas',
        width: canvasWidth,
        height: canvasHeight
    });

    bgLayer = new Kinetic.Layer();
    playLayer = new Kinetic.Layer();
    asteroidsLayer = new Kinetic.Layer();
    shotsLayer = new Kinetic.Layer();

    asteroidsKineticStage.add(bgLayer);
    asteroidsKineticStage.add(playLayer);
    asteroidsKineticStage.add(shotsLayer);
    asteroidsKineticStage.add(asteroidsLayer);
}



// Asteroids
var asteroids = [];

// Prep Player Ship
var shipSize = {
    width: 10,
    height: 20
};

function getPlayerToken() {

    var playerShip = new Kinetic.Line({
        points: [0, shipSize.height, shipSize.width / 2, 0, shipSize.width, shipSize.height],
        x: (asteroidsKineticStage.getWidth() - shipSize.width) / 2,
        y: (asteroidsKineticStage.getHeight() - shipSize.height) / 2,
        stroke: 'white',
        offset: { x: 5, y: 10 },
        closed: true
    });

    let playerToken = {
        token: playerShip,
        shots: [],
        movement: {
            forwardAcceleration: 0.9,
            forwardDeceleration: 0.006,
            forwardVelocity: 0,
            maxForwardVelocity: 2,
            yawAcceleration: 1.8,
            yawDeceleration: 0.01,
            yawVelocity: 0,
            maxYawVelocity: 3,
            angleOfRotation: 0,
            forwardDirections: []
        },
        lives: 5,
        score: 0
    };

    playLayer.add(playerShip);
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


function keepObjectOnCanvas(object, sizeOfObject) {
    const sizeMod = 0.8;
    // Left - Right
    if (object.token.getX() + sizeOfObject.width * sizeMod < 0) {
        object.token.setX(asteroidsKineticStage.getWidth() + sizeOfObject.width * sizeMod);
    } else if (object.token.getX() - sizeOfObject.width * sizeMod > asteroidsKineticStage.getWidth()) {
        object.token.setX(-sizeOfObject.width * sizeMod);
    }
    // Up - Down
    if (object.token.getY() + sizeOfObject.height * sizeMod < 0) {
        object.token.setY(asteroidsKineticStage.getHeight() + sizeOfObject.height * sizeMod);
    } else if (object.token.getY() - sizeOfObject.height * sizeMod > asteroidsKineticStage.height()) {
        object.token.setY(-sizeOfObject.height * sizeMod);
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
            // delete playerToken.movement.forwardDirections[index];
        }


        keepObjectOnCanvas(playerToken, shipSize);
    }

    playerToken.movement.forwardDirections.filter(x => x.velocity !== 0);

    // Ship Rotation
    playerToken.token.rotate(playerToken.movement.yawVelocity);
    playerToken.movement.angleOfRotation += playerToken.movement.yawVelocity;

    // Adjust current Angle
    playerToken.movement.angleOfRotation = adjustPlayerTokenAngle(playerToken.movement.angleOfRotation);
}

// Move shots -> Constant velocity
// Destroy shot when out of canvas
// Check for collision - > when asteroids are implemented
function nextShotsFrame() {
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

function nextAsteroidsFrame() {
    for (let asteroid in asteroids) {
        asteroids[asteroid].token.setX(asteroids[asteroid].token.getX() + asteroids[asteroid].direction.deltaX * asteroids[asteroid].direction.velocity);
        asteroids[asteroid].token.setY(asteroids[asteroid].token.getY() + asteroids[asteroid].direction.deltaY * asteroids[asteroid].direction.velocity);
        keepObjectOnCanvas(asteroids[asteroid], asteroids[asteroid].size);
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

    // console.log(currentDirection); // DELETE THIS LINE
    // console.log(playerToken.movement.angleOfRotation);

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
    shotsLayer.add(shotToken);
    shotsLayer.draw();
}

function getRandomInt(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}

function createSmallerAsteroids(size, amount) {
    let output = [];

    for (let i = 0; i < amount; i += 1) {
        let newAsteroid = new Kinetic.Rect({
            x: 0,
            y: 0,
            width: size,
            height: size,
            offset: { x: size / 2, y: size / 2 },
            stroke: 'white',
        });

        output[i] = newAsteroid;
    }

    return output;
}

// Top left, Bot left, Bot right, Top right ( counter clockwise )
function getSmallerAsteroidsPositions(position, size) {
    let newPositions = [
        { x: position.x - size, y: position.y - size },
        { x: position.x - size, y: position.y },
        { x: position.x, y: position.y },
        { x: position.x, y: position.y - size }
    ];
    return newPositions;
}

// Top left, Bot left, Bot right, Top right ( counter clockwise )
function getSmallerAsteroidsDirectionOfTravel(oldAngleOfRotation, oldVelocity, amount) {
    // 360 - 45; 360-45-90, 360 - 45 - 90 - 90
    let output = [];
    for (let i = 0; i < amount; i += 1) {
        let directionOfMovement = {
            deltaX: ((((shipSize.height / 2) * Math.sin((+oldAngleOfRotation - 45 - i * 90) * Math.PI / 180))) / 10),
            deltaY: -((((shipSize.height / 2) * Math.cos((+oldAngleOfRotation - 45 - i * 90) * Math.PI / 180))) / 10),
            velocity: 1
        };

        output[i] = directionOfMovement;
        output[i].velocity = oldVelocity + 1;
    }

    return output;
}

function splitAsteroid(indexInAsteroids) {
    // Split into 4 equal parts
    const amount = 4;
    let newSize = asteroids[indexInAsteroids].token.getWidth() / 2;

    if (asteroids[indexInAsteroids].token.getWidth() === 25) {

        asteroids[indexInAsteroids].token.remove();
        delete asteroids[indexInAsteroids];
        return;
    }

    let newAsteroids = createSmallerAsteroids(newSize, amount);

    let newAsteroidsPosition = getSmallerAsteroidsPositions(
        asteroids[indexInAsteroids].token.position(),
        newSize);

    let newAsteroidsDirectionOfTravel = getSmallerAsteroidsDirectionOfTravel(
        asteroids[indexInAsteroids].token.getRotation(),
        asteroids[indexInAsteroids].direction.velocity,
        amount);

    // Delete old asteroid
    asteroids[indexInAsteroids].token.remove();
    delete asteroids[indexInAsteroids];

    // Set new Asteroids Direction/ Velocity
    for (let i = 0; i < amount; i += 1) {

        newAsteroids[i].setX(newAsteroidsPosition[i].x);
        newAsteroids[i].setY(newAsteroidsPosition[i].y);

        let newAsteroid = {
            token: newAsteroids[i],
            size: {
                width: newAsteroids[i].getWidth(),
                height: newAsteroids[i].getHeight()
            },
            direction: newAsteroidsDirectionOfTravel[i]
        };

        asteroids.push(newAsteroid);
        asteroidsLayer.add(newAsteroid.token);
    }
}

function checkForShotsCollision(arrayOfShots) {
    for (let index in arrayOfShots) {

        if (asteroidsLayer.getIntersection(arrayOfShots[index].token.position())) {

            // Find the asteroid
            for (let asteroidIndex in asteroids) {

                // Find the asteroid to break up
                if (asteroids[asteroidIndex].token.intersects(arrayOfShots[index].token.position())) {
                    splitAsteroid(asteroidIndex);
                }
            }
            // Destroy the shot
            arrayOfShots[index].token.remove();
            delete arrayOfShots[index];
        }
    }
}

// TODO: Game over
function checkForPlayerCollision(player) {
    if (asteroidsLayer.getIntersection(player.token.position())) {
        gameOver = true;
    }
}

function createNewAsteroid() {
    // kinetic token
    // constant speed
    let angle = getRandomInt(0, 360); // TODO: Generate random angle

    let directionOfMovement = {
        deltaX: ((((shipSize.height / 2) * Math.sin(angle * Math.PI / 180))) / 10),
        deltaY: -((((shipSize.height / 2) * Math.cos(angle * Math.PI / 180))) / 10),
        velocity: 1
    };

    let largeAsteroid = new Kinetic.Rect({
        x: 0,
        y: 0,
        width: 200,
        height: 200,
        offset: { x: 100, y: 100 },
        stroke: 'white',
    }).rotate(angle);

    let newAsteroid = {
        token: largeAsteroid,
        size: {
            width: 200,
            height: 200
        },
        direction: directionOfMovement
    };

    // Adjust position and direction of travel
    // origin ( off canvas ) - affected by stay on canvas ?
    // direction of travel
    newAsteroid.token.setX(150);
    newAsteroid.token.setY(150);

    asteroidsLayer.add(newAsteroid.token);
    asteroids.push(newAsteroid);
}

function handleGameOver() {
    initStage();
    asteroids = [];
}

// Get Next Frame
var gameOver = false;
function nextFrame() {

    // Collisions
    // Shots with asteroids
    checkForShotsCollision(playerToken.shots);

    // Ship with asteroids
    checkForPlayerCollision(playerToken);

    // Player Ship
    nextPlayerFrame();

    // Asteroids
    nextAsteroidsFrame();

    // Update shots
    nextShotsFrame();

    // Decelerate Ship
    decelerateYawVelocity();

    // ReDraw
    playLayer.draw();
    shotsLayer.draw();
    asteroidsLayer.draw();

    // End condition
    if (gameOver) {
        handleGameOver();
        return;
    }

    requestAnimationFrame(nextFrame);
}

function startGame() {
    gameOver = false;
    // prep ui etc.
    initStage();
    // create player ship
    playerToken = getPlayerToken();

    // create asteroids
    createNewAsteroid();

    nextFrame();
}

// Read input when available
document.getElementById('controls')
    .addEventListener('keydown', function (input) {
        // GameOver = true;
        if (input.key === 'Escape') {
            getGameOver();
        } else if (input.key === 'ArrowLeft') {
            getRotateLeft();
        } else if (input.key === 'ArrowRight') {
            getRotateRight();
        } else if (input.key === ' ') {
            createNewShot();
        } else if (input.key === 'ArrowUp') {
            createNewForwardMotion();
        } else if (input.key === 's') {
            startGame();
        }
    });