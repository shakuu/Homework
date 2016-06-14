// jshint esversion: 6

Array.prototype.Remove = function (arg) {
  let len = this.length;
  for (let index = 0; index < len; index += 1) {
    let el = String(this[index]);
    let rem = new RegExp(arg, 'g');
    el = el.replace(rem, '');
  }
};
