//jshint esversion: 6
'use strict()';

function ExtractURL() {
  let parse = curTag;
  let output = '';

  let left = parse.indexOf('"');
  let right = parse.indexOf('"', left + 1);
  let URL = parse.substr(left + 1, right - (left + 1));

  left = parse.indexOf('>', right + 1);
  right = parse.indexOf('<', left + 1);
  let label = parse.substr(left + 1, right - (left + 1));

  output = '[' + label + '](' + URL + ')';
  return output;
}

function ContainsCloseAnchor() {
  let tag = curTag;
  let index = tag.indexOf(closeTag);

  if (index < 0) {
    return false;
  } else {
    return true;
  }
}

function IsAnchor() {
  let tag = curTag;
  if (tag.length < len) {
    return false;
  }

  for (let index = 0; index < len; index += 1) {
    if (tag[index] != openTag[index]) {
      return false;
    }
  }

  return true;
}

function ReplaceTags() {
  let parse = String(input);

  let len = parse.length;
  for (let index = 0; index < len; index += 1) {
    let chr = parse[index];

    if (chr === '<') {
      isTag = true;
      curTag += chr;
    }
    else if (chr === '>') {
      curTag += chr;

      // evaluate tag
      if (IsAnchor()) {
        if (ContainsCloseAnchor()) {
          // Extract
          output += ExtractURL();
          isTag = false;
          curTag = '';

        } else {
          // nothing
        }
      }
      else {
        output += curTag;
        isTag = false;
        curTag = '';
      }
    }
    else if (isTag) {
      curTag += chr;
    }
    else {
      output += chr;
    }
  }

  console.log(output);
}

let input = process.argv[2];
let output = '';

let openTag = String('<a href');
let closeTag = String('</a>');
let len = openTag.length;

// States
let isTag = false;

let curTag = '';

ReplaceTags();