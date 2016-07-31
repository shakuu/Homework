function solve() {
    $.fn.datepicker = function () {
        var MONTH_NAMES = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
        var WEEK_DAY_NAMES = ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa'];

        Date.prototype.getMonthName = function () {
            return MONTH_NAMES[this.getMonth()];
        };

        Date.prototype.getDayName = function () {
            return WEEK_DAY_NAMES[this.getDay()];
        };

        // // you are welcome :)
        var date = new Date();
        // console.log(date.getDayName());
        // console.log(date.getMonthName());

        var inputDatePicker = $(this),
            datePickerWrapper,

            picker,

            controls,
            prevButton,
            currentMonth,
            nextButton,

            calendar,

            currentDate,
            currentDateLink;

        // Build all required elements
        function initializeAllElements() {
            inputDatePicker.addClass('datepicker');

            datePickerWrapper = $('<div />')
                .addClass('datepicker-wrapper')
                .appendTo(inputDatePicker.parents().first())
                .append(inputDatePicker);

            picker = $('<div />')
                .addClass('picker')
                .addClass('picker-visible');

            prevButton = $('<a />')
                .addClass('btn')
                .html('<');

            currentMonth = $('<div />')
                .addClass('current-month');

            nextButton = $('<a />')
                .addClass('btn')
                .html('>');

            controls = $('<div />')
                .addClass('controls')
                .append(prevButton)
                .append(currentMonth)
                .append(nextButton)
                .appendTo(picker);

            calendar = $('<tabel />')
                .addClass('calendar')
                .appendTo(picker);

            currentDateLink = $('<a />')
                .addClass('current-date-lin');

            currentDate = $('<div />')
                .addClass('current-date')
                .append(currentDateLink)
                .appendTo(picker);

            picker.appendTo(datePickerWrapper);
        }

        // Logic
        initializeAllElements();

        return inputDatePicker;
    };
}

module.exports = solve;