function solve() {
    return function () {
        $.fn.listview = function (data) {
            var element,
                templateSourceID,
                source,
                template,
                length = data.length,
                item;

            element = $(this);
            templateSourceID = element.attr('data-template');
            source = $('#' + templateSourceID).html();
            template = handlebars.compile(source); // LOWER H ON HANDLEBARS !!!!!!!!!!!!!!!!!!!!!

            for (item = 0; item < length; item += 1) {
                element.append(template(data[item]));
            }

            return this;
        };
    };
}

module.exports = solve;
