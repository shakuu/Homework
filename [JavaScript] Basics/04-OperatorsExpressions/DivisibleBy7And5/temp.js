function Check(){
  var input = document.getElementById("input");
  
  if (input.value % 5 == 0 && input.value % 7 ==0) {
    jsConsole.writeLine(true);
  }
  else{
    jsConsole.writeLine(false);
  }
}