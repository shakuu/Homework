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

// function solve(){
// 	return function(){
// 		$.fn.listview = function(data) {
// 			var templateSource = $('#' + (this.attr('data-template'))).html();
// 			var template = handlebars.compile(templateSource);
// 			var len = data.length,
// 			i;

// 			for (i = 0; i < len; i+=1) {
// 				this.append(template(data[i]));
// 			}

// 			return this;
// 		};
// 	};
// }

module.exports = solve;