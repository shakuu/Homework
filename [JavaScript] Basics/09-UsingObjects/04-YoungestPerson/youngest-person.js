// jshint esversion:6

let Person = function (first, last, age) {
  this.firstname = first;
  this.lastname = last;
  this.age = age;
};
Person.prototype.constructor = Person;

let p1 = new Person('first', 'last', 15);
let p2 = new Person('pesho', 'peshev', 10);

YoungestPerson();

function YoungestPerson(){
  let people = [p1, p2];

  let len = people.length;
  let min = 0;
  for (let index = 1; index < len; index += 1){
    if (people[index].age < people[min].age) {
      min = index;
    }
  }

  console.log(people[min]);
}