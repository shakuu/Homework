/*jshint esversion: 6 */

function CreatePoint(x, y) {
  return {
    X: x,
    Y: y
  };
}

function CreateLine(p1, p2) {
  return {
    P1: p1,
    P2: p2
  };
}

function Distance(p1, p2) {
  let deltaX = Math.abs(p1.X - p2.X);
  let deltaY = Math.abs(p1.Y - p2.Y);

  let dist = Math.sqrt((deltaX * deltaX) + (deltaY * deltaY));

  return dist;
}

function IsTrianle(l1, l2, l3) {
  let points = [l1.P1, l1.P2, l2.P1, l2.P2, l3.P1, l3.P2];
  for (let point = 0; point < 6; point += 1) {
    let counter = 0;

    for (let comp = 0; comp < 6; comp += 1) {
      if (points[point].X === points[comp].X &&
        points[point].Y === points[comp].Y) {
        counter += 1;
      }
    }

    if (counter != 2) {
      return false;
    }
  }

  return true;
}