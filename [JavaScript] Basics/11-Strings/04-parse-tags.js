'use strict()';

String.prototype.ToMixCase = function () {
  let input = this;
  let result = '';

  let len = input.length;
  for (let index = 0; index < len; index += 1) {
    if (mixCaseTracker % 2 === 0) {
      result += input[index].toUpperCase();
    } else {
      result += input[index].toLowerCase();
    }

    mixCaseTracker += 1;
  }

  return result;
};

let input = process.argv[2];

let mixCaseTracker = 0;
let openUp = 'upcase';
let closeUp = '/upcase';
let openLow = 'lowcase';
let closeLow = '/lowcase';
let openMix = 'mixcase';
let closeMix = '/mixcase';

// states
let isTag = false;
let curTag = '';
let isUp = false;
let isLow = false;
let isMix = false;
let toTransform = false;
let curTransform = '';
let transform = '';
let tagStack = [];
let result = '';


ParseTags(input);

function ParseTags(text) {
  let parse = String(text);

  let len = parse.length;
  for (let index = 0; index < len; index += 1) {
    let chr = parse[index];

    if (chr === '<') {
      isTag = true;
    }
    else if (chr === '>') {
      isTag = false;
      // check tag
      CheckTag(curTag);
      curTag = '';

      if (!toTransform) {
        Print(transform);
      }
    }
    else if (isTag) {
      curTag += chr;
    }
    else if (toTransform) {
      transform += chr;
    }
    else {
      // Print
      result += chr;
    }
  }

  console.log(result);
}

function Print(arg) {
  let text = String(arg);

  if (curTransform === openUp) {
    text = text.toUpperCase();
  }

  else if (curTransform === openLow) {
    text = text.toLowerCase();
  }

  else if (curTransform === openMix) {
    text = text.ToMixCase();
  }

  result += text;
  transform = '';
  curTransform = '';
}

function CheckTag(tag) {
  let curTag = String(tag);

  if (curTag === openUp ||
    curTag === openLow ||
    curTag === openMix) {

    toTransform = true;
    AddToStack(curTag);
  }
  else if (curTag === closeUp ||
    curTag === closeLow ||
    curTag === closeMix) {

    toTransform = false;
    RemovaFromStack();
  }
}

function AddToStack(arg) {
  let curTag = String(arg);
  tagStack.push(curTag);
}

function RemovaFromStack(arg) {
  let curTag = String(arg);
  curTransform = tagStack.pop();
}

