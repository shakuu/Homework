var eventHandlers = (function () {
    function onButtonClick(ev) {
        var browserName = window.navigator.appCodeName,
            isMozilla = browserName === 'Mozilla';

        if (isMozilla) {
            alert("Yes");
        } else {
            alert("No");
        }
    }

    return {
        onButtonClick: onButtonClick
    };
} ());