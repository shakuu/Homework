function solve(params) {

  String.prototype.ToMixCase = function () {
    var input = this;
    var result = '';

    // var len = input.length;
    // for (var index = 0; index < len; index += 1) {
    //   if (mixCaseTracker % 2 === 0) {
    //     result += input[index].toUpperCase();
    //   } else {
    //     result += input[index].toLowerCase();
    //   }

    //   mixCaseTracker += 1;
    // }

    return result;
  };

  var mixCaseTracker = 0;
  var openUp = 'upcase';
  var closeUp = '/upcase';
  var openLow = 'lowcase';
  var closeLow = '/lowcase';
  var openMix = 'orgcase';
  var closeMix = '/orgcase';

  // states
  var isTag = false;
  var curTag = '';
  var isUp = false;
  var isLow = false;
  var isMix = false;
  var toTransform = false;
  var curTransform = '';
  var transform = '';
  var tagStack = [];
  var result = '';

  function ParseTags(text) {
    var parse = String(text);

    var len = parse.length;
    for (var index = 0; index < len; index += 1) {
      var chr = parse[index];

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
    var text = String(arg);

    if (curTransform === openUp) {
      text = text.toUpperCase();
    }

    else if (curTransform === openLow) {
      text = text.toLowerCase();
    }

    else if (curTransform === openMix) {
      // text = text.ToMixCase();
    }

    result += text;
    transform = '';
    curTransform = '';
  }

  function CheckTag(tag) {
    var curTag = String(tag);

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
    var curTag = String(arg);
    tagStack.push(curTag);
  }

  function RemovaFromStack(arg) {
    var curTag = String(arg);
    curTransform = tagStack.pop();
  }

  ParseTags(params[0] + '');

}

var test1 = ['We are <orgcase>liViNg</orgcase> in a <upcase>yellow submarine</upcase>. We <orgcase>doN\'t</orgcase> have <lowcase>anything</lowcase> else.'];

solve(test1);