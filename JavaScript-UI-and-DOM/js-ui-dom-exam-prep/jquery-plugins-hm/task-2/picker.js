$.fn.colorpicker = function () {
    var element,

        colorpickerContainer,

        icon,

        container,
        closeButton,
        canvasPicker,
        imageContainer,
        rgbInput,
        hexInput,
        colorPreview,

        canvasCtx;

    element = $(this);

    colorpickerContainer = $('<div />')
        .addClass('colorpicker')
        .appendTo(element);

    // Icon
    icon = $('<a />')
        .addClass('colorpicker-button')
        .appendTo(colorpickerContainer);

    // Build colorpicker
    container = $('<div />')
        .addClass('colorpicker-window');

    closeButton = $('<a />')
        .addClass('close-button');

    imageContainer = $('<img />')
        .addClass('colorpicker-image')
        .attr('src', './imgs/color-picker.png')
        .attr('width', '256px')
        .attr('height', '256px');

    canvas = $('<canvas />')
        .addClass('colorpicker-canvas')
        .attr('width', '256px')
        .attr('height', '256px');

    rgbInput = $('<input />')
        .addClass('rgb-input')
        .attr('placeholder', 'RGB');

    hexInput = $('<input />')
        .addClass('hex-input')
        .attr('placeholder', 'HEX');

    colorPreview = $('<div />')
        .addClass('color-preview');

    container
        .append(closeButton)
        .append(imageContainer)
        .append(canvas)
        .append(hexInput)
        .append(rgbInput)
        .append(colorPreview)
        .appendTo(colorpickerContainer);

    canvasCtx = document
        .querySelector('.colorpicker-canvas')
        .getContext('2d');

    $(function () {
        canvasCtx.drawImage(document.querySelector('.colorpicker-image'), 0, 0);
    });

    icon.on('click', function () {
        icon.addClass('hidden');
        container.addClass('visible');
    });

    closeButton.on('click', function () {
        icon.removeClass('hidden');
        container.removeClass('visible');
    });

    canvas.on('click', function (event) {
        var rgbColor = canvasCtx.getImageData(event.offsetX, event.offsetY, 1, 1),
            rgbString,
            hexString;

        rgbString = getRgbString(rgbColor);
        hexString = getHexString(rgbColor);

        rgbInput.attr('value', rgbString);
        hexInput.attr('value', hexString);
        colorPreview.css('background-color', hexString);

        document.querySelector('.hex-input').select();
        document.execCommand('copy');
        document.getSelection().empty();
    });

    function getRgbString(rgbColor) {
        var rgbString =
            rgbColor.data[0] + ',' +
            rgbColor.data[1] + ',' +
            rgbColor.data[2] + ',' +
            rgbColor.data[3];
        return rgbString;
    }

    function getHexString(rgbColor) {
        var hexString = '#',
            rgb = [];

        for (var i = 0; i < 3; i += 1) {
            var current = rgbColor.data[i].toString(16) + '';
            if (current.length === 1) {
                current = '0' + current;
            }
            hexString += current.toUpperCase();
        }
        return hexString;
    }
};
