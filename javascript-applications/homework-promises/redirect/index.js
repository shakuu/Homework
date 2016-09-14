const popup = (() => {
    const container = document.createElement('div');
    container.className += ' popup';
    container.innerHTML = 'Redirecting...';
    container.style.display = 'none';
    document.body.appendChild(container);

    function display() {
        container.style.display = '';
    }

    function fadeOut(time) {
        const initialOpacity = container.style.opacity || 1;
        const opacityDecreaseStep = 1 / time;
        while (container.style.opacity > 0) {
            container.style.opacity -= opacityDecreaseStep;
        }
    }

    return {
        display,
        fadeOut
    };
})();

const redirect = ((popup) => {
    const redirectPromise = new Promise((resolve, reject) => {
        popup.display();
        window.setTimeout(resolve, 5000);
    })
        .then(popup.fadeOut)
        .then(() => window.location = "https://www.google.bg/");
})(popup);