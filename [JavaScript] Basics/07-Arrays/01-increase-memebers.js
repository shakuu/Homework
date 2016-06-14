function CreateArray() {

  var arr = new Array(20);

  for (var index = 0; index < arr.length; index++) {

    arr[index] = parseInt(index * 5);
    console.log(arr[index]);
  }
}