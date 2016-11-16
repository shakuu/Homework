/* globals module */
const getRandomName = (() => {
  const lowerCaseLetters = 'abcdefghijklmnopqrstuvwxyz';
  const upperCaseLetters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ';

  function generateName() {
    let name = '';
    const nameLength = getRandomInteger(5, 15);

    const alphabetLength = lowerCaseLetters.length;
    name += upperCaseLetters.substr(getRandomInteger(0, alphabetLength - 1), 1);
    for (let i = 1; i < nameLength; i += 1) {
      name += lowerCaseLetters.substr(getRandomInteger(0, alphabetLength - 1), 1);
    }

    return name;
  }

  return generateName;
})();

const getRandomEmailAddress = (() => {
  const emails = [
    'random@email.add',
    'less@random.mail',
    'email@address.co',
    'someone@progress.com'
  ];

  function generateEmail() {
    const emailsLength = emails.length;
    const randomIndex = getRandomInteger(0, emailsLength - 1);
    const email = emails[randomIndex];

    return email;
  }

  return generateEmail;
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

  return generatePhoneNumber;
})();

const getRandomInsuranceNumber = (() => {
  const allowedCharacters = '0123456789-abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ';
  const charactersCount = allowedCharacters.length;
  const insuranceNumberLength = 10;

  function generateInsuranceNumber() {
    let insuranceNumber = '';
    for (let i = 0; i < insuranceNumberLength; i += 1) {
      const nextCharacterIndex = getRandomInteger(0, charactersCount - 1);
      insuranceNumber += allowedCharacters.substr(nextCharacterIndex, 1);
    }

    return insuranceNumber;
  }

  return generateInsuranceNumber;
})();

const getRandomInteger = (() => {
  function generateInt(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
  }

  return generateInt;
})();


const randomGenerator = {
  getRandomName,
  getRandomPhoneNumber,
  getRandomEmailAddress,
  getRandomInsuranceNumber,
  getRandomInteger
};

module.exports = randomGenerator;