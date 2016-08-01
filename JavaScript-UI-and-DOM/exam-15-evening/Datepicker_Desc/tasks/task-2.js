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
            calendarHead,
            calendarBody,
            calendarCells,

            currentDate,
            currentDateLink,

            initialDateAsObject = {
                'year': date.getFullYear(),
                'month': date.getMonth(),
                'date': date.getDate()
            },
            currentDateAsObject = {
                'year': date.getFullYear(),
                'month': date.getMonth(),
                'date': 1
            },
            allDatesInCalenar;

        // Build all required elements
        function initializeAllElements() {
            inputDatePicker.addClass('datepicker');

            datePickerWrapper = $('<div />')
                .addClass('datepicker-wrapper')
                .appendTo(inputDatePicker.parents().first())
                .append(inputDatePicker);

            picker = $('<div />')
                .addClass('picker');
            // .addClass('picker-visible');

            prevButton = $('<a />')
                .css('padding', '5px 10px')
                .addClass('btn')
                .html('<');

            currentMonth = $('<div />')
                .addClass('current-month')
                .html(MONTH_NAMES[initialDateAsObject.month] + ' ' + initialDateAsObject.year);

            nextButton = $('<a />')
                .css('padding', '5px 10px')
                .addClass('btn')
                .html('>');

            controls = $('<div />')
                .addClass('controls')
                .append(prevButton)
                .append(currentMonth)
                .append(nextButton)
                .appendTo(picker);

            calendarHead = $('<thead />')
                .addClass('calendar-header');

            calendarBody = $('<tbody />')
                .addClass('calendar-body');

            calendar = $('<tabel />')
                .addClass('calendar')
                .append(calendarHead)
                .append(calendarBody)
                .appendTo(picker);

            currentDateLink = $('<a />')
                .addClass('current-date-link')
                .html(initialDateAsObject.date + ' ' + MONTH_NAMES[initialDateAsObject.month] + ' ' + initialDateAsObject.year);

            currentDate = $('<div />')
                .addClass('current-date')
                .append(currentDateLink)
                .appendTo(picker);

            picker.appendTo(datePickerWrapper);
        }

        function initializeCalendarTable() {
            var week,
                day,
                currentRow,
                newCell;

            // header row
            currentRow = $('<tr />').addClass('header-row');
            for (day = 0; day < 7; day += 1) {
                newCell = $('<th />')
                    .html(WEEK_DAY_NAMES[day])
                    .appendTo(currentRow);
            }
            currentRow.appendTo(calendar.children('.calendar-header'));

            // 6 rows of dates
            calendarCells = [];
            for (week = 0; week < 6; week += 1) {
                currentRow = $('<tr />');
                calendarCells[week] = [];
                for (day = 0; day < 7; day += 1) {
                    newCell = $('<td />').appendTo(currentRow);
                    calendarCells[week][day] = newCell;
                }
                currentRow.appendTo(calendar.children('.calendar-body'));
            }
        }

        function populateCalendarWithDates(dateAsObject) {
            var startDate,
                dayOfTheWeek,

                week,
                day,

                isCurrentMonth = false;

            startDate = new Date(dateAsObject.year, dateAsObject.month, dateAsObject.date);
            startDate.setDate(1);
            dayOfTheWeek = startDate.getDay();
            startDate.setDate(startDate.getDate() - dayOfTheWeek);

            allDatesInCalenar = [];
            for (week = 0; week < 6; week += 1) {
                allDatesInCalenar[week] = [];
                for (day = 0; day < 7; day += 1) {
                    if (startDate.getDate() === 1) {
                        isCurrentMonth = !isCurrentMonth;
                    }

                    allDatesInCalenar[week][day] = startDate;
                    calendarCells[week][day].html(startDate.getDate());
                    startDate.setDate(startDate.getDate() + 1);

                    calendarCells[week][day].removeClass();
                    if (isCurrentMonth) {
                        calendarCells[week][day].addClass('current-month');
                    } else {
                        calendarCells[week][day].addClass('another-month');
                    }
                }
            }
        }

        function getInputDateString(date) {
            var string = date.getDate() + '/' + (date.getMonth() + 1) + '/' + date.getFullYear();
            return string;
        }

        // // Tests
        // console.log(currentDateAsObject);

        // Logic
        initializeAllElements();
        initializeCalendarTable();

        // events
        inputDatePicker.on('click', function () {
            populateCalendarWithDates(initialDateAsObject);
            currentMonth.html(MONTH_NAMES[initialDateAsObject.month] + ' ' + initialDateAsObject.year);
            picker.toggleClass('picker-visible');

            currentDateAsObject.year = initialDateAsObject.year;
            currentDateAsObject.month = initialDateAsObject.month;
            currentDateAsObject.date = 1;
        });

        prevButton.on('click', function () {
            currentDateAsObject.month -= 1;
            if (currentDateAsObject.month < 0) {
                currentDateAsObject.month = 11;
                currentDateAsObject.year -= 1;
            }
            populateCalendarWithDates(currentDateAsObject);
            currentMonth.html(MONTH_NAMES[currentDateAsObject.month] + ' ' + currentDateAsObject.year);
        });

        nextButton.on('click', function () {
            currentDateAsObject.month += 1;
            if (currentDateAsObject.month > 11) {
                currentDateAsObject.month = 0;
                currentDateAsObject.year += 1;
            }
            populateCalendarWithDates(currentDateAsObject);
            currentMonth.html(MONTH_NAMES[currentDateAsObject.month] + ' ' + currentDateAsObject.year);
        });

        currentDateLink.on('click', function () {
            var inputValue,
                date;

            date = new Date(initialDateAsObject.year, initialDateAsObject.month, initialDateAsObject.date);
            inputValue = getInputDateString(date);
            inputDatePicker.attr('value', inputValue);
            picker.removeClass('picker-visible');
        });

        calendar.on('click', function (event) {
            var clicked = $(event.target),
                inputValue,
                date;

            if (!clicked.hasClass('current-month')) {
                return;
            }

            date = new Date(currentDateAsObject.year, currentDateAsObject.month, clicked.html());
            inputValue = getInputDateString(date);
            inputDatePicker.attr('value', inputValue);
            picker.removeClass('picker-visible');
        });

        // Chaining 
        return inputDatePicker;
    };
}

module.exports = solve;