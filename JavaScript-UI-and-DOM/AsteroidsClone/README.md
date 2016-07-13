#  Asteroids Clone

## [Asteroids on Wikipedia](https://en.wikipedia.org/wiki/Asteroids_(video_game))

## Canvas
  - 960 x 540 px
  - background: BLACK

## Ship
  - Triangle
    - white
  - Movement
  - Rotate
  - Shoot
    - Starts at current ship location
    - Direction is current angle
    - Destroyed on out of player area
  - Controls:
    - ArrowLeft: rotate left
    - ArrowRight: rotate right
    - ArrowUp: thrust forward
    - ArrowDown: stop rotation
    - Space: shoot 
  
## Asteroids
  - Generate Shape 
    - Pre-set
    - Random
  - Size
  - Movement
    - Constant speed at a randomly generated constant direction
    - Floating out of the canvas - reenters on the opposite end
  - Split when shot
    - Pre-set number of sizes ( 3 - 5)

## Enemy Flying Saucers
  - Large
    - shoots in a random direction
  - Small
    - shoots at player's ship