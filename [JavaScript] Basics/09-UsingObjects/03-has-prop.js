// jshint esversion:6

function HasProperty(obj, prop){

  var props = Object.getOwnPropertyNames(obj);
  var len = props.length;

  for (let index = 0; index < len; index += 1){

    if (props[index] === prop) {
      return true;
    }
  }

  return false;
}