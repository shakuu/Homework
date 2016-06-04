function CheckPoint() {
  var pointX = Number(document.getElementById("x").value);
  var pointY = Number(document.getElementById("y").value);

  var inCricle = false;
  var inRectangle = false;

  // Circle 1, 1, radius 3
  var distanceToCircleX = pointX - 1;
  var distanceToCircleY = pointY - 1;

  var distanceToCircle = Math.sqrt(
    (distanceToCircleX
      * distanceToCircleX)
      + (distanceToCircleY
      * distanceToCircleY));

  // check inside circle                   
  if (distanceToCircle <= 3) {
    inCricle = true;
  }
  //(top=1, left=-1, width=6, height=2)
  if (pointX >= -1
    && pointX <= 5
    && pointY <= 1
    && pointY >= -1) {

    inRectangle = true;
  }

  if (inCricle && !inRectangle) {
    jsConsole.writeLine("yes");
  }
  else {
    jsConsole.writeLine("no");
  }
} 