// jshint esversion:6

let Person = function (first, last, age, isfemale) {
  this.firstname = first;
  this.lastname = last;
  this.age = Number(age);
  this.isFemale = !!isfemale;
};
Person.prototype.constructor = Person;
let people = [];

// testing 
let p1 = new Person('pesho', 'peshev', '20', 'true');
let p2 = new Person('goshe', 'peshev', '14', 'true');
people.push(p1);
people.push(p2);

PeopleOfAge();
GetUnderAged();
AverageAgeOfFemales();

function PeopleOfAge() {
  let result = people
    .every(p => p.age >= 18);

  console.log('All people are 18+: ' + result);
}

function GetUnderAged() {
  console.log('All underaged people: ');
  let result = people
    .filter(p => p.age < 18)
    .forEach(p => console.log(p));
}

function AverageAgeOfFemales() {
  let counter = 0;
  let result = people
    .filter(p => p.isFemale)
    .reduce(function (sum, p) {
      counter += 1;
      return sum + p.age;
    }, 0) / counter;

  console.log('Average Age of isFemale: ' + result);
}