// jshint esversion:6

let Person = function (first, last, age, isfemale) {
  this.firstname = String(first);
  this.lastname = String(last);
  this.age = Number(age);
  this.isFemale = !!isfemale;
};
Person.prototype.constructor = Person;
let people = [];

// testing 
let p1 = new Person('gesho', 'peshev', '20', 'true');
let p2 = new Person('goshe', 'peshev', '13', 'true');
let p3 = new Person('pesho', 'geshev', '20', 'true');
people = [p1, p2, p3]

PeopleOfAge();
GetUnderAged();
AverageAgeOfFemales();
YoungestPerson();
Groups();

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

function YoungestPerson() {
  let min = people[0];
  let len = people.length - 1;
  let result = people.find(function (per, index) {
    if (per.age < min.age) {
      min = per;
    }
    return false;
  });
  console.log('Youngest person is: ' + min.firstname + ' age: ' + min.age);
}

function Groups() {
  let groups = {};
  var output = people.reduce(function (groups, per) {
    if (!groups[per.firstname[0]]){
      groups[per.firstname[0]] = [per];
    }else{
      groups[per.firstname[0]].push(per);
    }
    return groups;
  }, {});
  console.log(output);
}