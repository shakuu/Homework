function solve() {
    return function () {
        $.fn.listview = function (data) {
            var element,
                templateSourceID,
                source,
                template,
                item,
                result;

            element = $(this);
            templateSourceID = element.attr('data-template');
            source = $('#' + templateSourceID).html();
            template = Handlebars.compile(source);

            result = '';
            data.forEach(function(element) {
                result += template(element);
            }, this);
            element.html(result);

            return $(this);
        };
    };
}

module.exports = solve;