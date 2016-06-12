//jshint esversion: 6
'use strict()';

// People For Testing
let Person = function (name, age) {
  this.name = name;
  this.age = age;
};
Person.prototype.constructor = Person;
let people = [].map(Person);
people.push(new Person('Peter', 15));
people.push(new Person('George', 16));
people.push(new Person('John', 17));

function createList() {
  let temp = document
    .getElementById('list-item');

  let output = '';
  let template = temp.innerHTML;
  // tmep.innerHTML = '';
  output += '<ul>';
  let len = people.length;
  for (let index = 0; index < len; index += 1) {
    let add = stringFormat(template, people[index]);
    output += '<li>' + add + '</li>';
  }
  output += '</ul>';
  temp.innerHTML = output;
}

function stringFormat() {
  let format = String(arguments[0]);
  let len = format.length;
  let person = arguments[1];
  let output = '';

  let isToken = false;
  let token = '';

  for (let index = 0; index < len; index += 1) {
    let chr = format[index];

    if (chr === '{') {
      isToken = true;
    } else if (chr === '}') {
      // replace
      let insert = person[token];
      output += insert;
      isToken = false;
      token = '';
    } else if (isToken) {
      token += chr;
    } else {
      output += chr;
    }
  }

  return output;
}

let btngo = document
.getElementById('go')
.addEventListener('click', function () {
  
createList();
});
