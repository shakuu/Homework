function solve(a){
if(a[0]*a[1]>0){
return a[0]>0?1:2;
}else{
return a[0]>0?3:0;
}
}

console.log(solve(['-1', '-1'])); 