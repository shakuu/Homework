// jshint esversion:6

let Person = function (first, last, age) {
  this.firstname = first;
  this.lastname = last;
  this.age = age;
};
Person.prototype.constructor = Person;

let p1 = new Person('first', 'last', 15);
let p2 = new Person('pesho', 'peshev', 12);
let p3 = new Person('gosho', 'peshev', 12);

let arr = [p1, p2, p3];
Group(arr, 'age');

function Group(arr, arg) {
  let i, per, groups = {};

  for (i in arr) {
    per = arr[i];
// per.age === per['age']
    if (!groups[per[arg]]) {
      groups[per[arg]] = [per];
    } else {
      groups[per[arg]].push(per);
    }
  }

  console.log(groups);
}