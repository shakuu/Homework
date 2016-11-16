/* globals module */
const getRandomName = (() => {
  const lowerCaseLetters = 'abcdefghijklmnopqrstuvwxyz';
  const upperCaseLetters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ';
  const digits = '0123456789';

  function generateName() {
    let name = '';
    const nameLength = getRandomInteger(5, 15);

    const alphabetLength = lowerCaseLetters.length;
    name += upperCaseLetters[getRandomInteger(0, alphabetLength - 1)];
    for (let i = 1; i < nameLength; i += 1) {
      name += lowerCaseLetters[getRandomInteger(0, alphabetLength - 1)];
    }

    return name;
  }

  return generateName;
})();


const getRandomPhoneNumber = (() => {
  const phoneNumbers = [
    '359 888 444 555',
    '359 889 555 666',
    '002 555 310 000'
  ];

  function generatePhoneNumber() {
    const phoneNumbersLength = phoneNumbers.length;
    const randomIndex = getRandomInteger(0, phoneNumbersLength - 1);
    const phoneNumber = phoneNumbers[randomIndex];

    return phoneNumber;
  }

  return getRandomPhoneNumber;
})();

function getRandomInteger(min, max) {
  return Math.floor(Math.random() * (max - min + 1)) + min;
}

const randomGenerators = {
  getRandomName,
  getRandomPhoneNumber
};

module.exports = randomGenerators;