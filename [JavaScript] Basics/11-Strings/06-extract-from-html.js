//jshint esversion: 6
'use strict()';


function RemoveTags(){
  let parse = String(input);
  let result = '';

  let len = parse.length;
  for (let index = 0; index < len; index += 1){
    let chr = parse[index];

    if (chr === '<') {
      isTag = true;
    }
    else if (chr === '>') {
      isTag = false;
    }
    else if (!isTag) {
      result += chr;
    }
  }

  console.log(result);
}

let input = process.argv[2]

let isTag= false;

RemoveTags();