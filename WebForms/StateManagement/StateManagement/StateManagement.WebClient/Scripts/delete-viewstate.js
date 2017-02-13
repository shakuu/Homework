window.onload = function () {
    var vs = document.getElementById("__VIEWSTATE");
    console.log(vs);
    vs.setAttribute("value", "");
};