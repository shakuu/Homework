function solve() {
    $.fn.datepicker = function () {
        var input,
            wrapper,

            picker,

            controls,
            currentMonth,
            btnPrevious,
            btnNext,

            calendar,
            calendarCells,

            currentDate,
            currentDateLink,

            allDaysNames = ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa'],
            allMonthsNames = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'],

            date,
            controlDate = {
                'year': null,
                'month': null,
                'date': null
            },
            dateToDisplay = {
                'year': null,
                'month': null,
                'date': null
            };

        // init date
        date = new Date();
        dateToDisplay.year = date.getFullYear();
        dateToDisplay.month = date.getMonth();
        dateToDisplay.date = date.getDate();

        controlDate.year = dateToDisplay.year;
        controlDate.month = dateToDisplay.month;
        controlDate.date = 1;

        input = $(this);
        input.addClass('datepicker');

        wrapper = $('<div />')
            .addClass('datepicker-wrapper')
            .appendTo(input.parents().first())
            .append(input);

        // Picker
        picker = $('<div />')
            .addClass('picker')
            .appendTo(wrapper);

        // Build Controls
        btnPrevious = $('<a />')
            .addClass('btn')
            .addClass('previous')
            .html('<');

        currentMonth = $('<div />')
            .addClass('current-month');
        updateControlString();

        btnNext = $('<a />')
            .addClass('btn')
            .addClass('next')
            .html('>');

        controls = $('<div />')
            .addClass('controls')
            .append(btnPrevious)
            .append(currentMonth)
            .append(btnNext)
            .appendTo(picker);

        // Build Calendar
        calendar = $('<table />')
            .addClass('calendar')
            .appendTo(picker);
        initCalendar();

        // Build Current date
        currentDateLink = $('<a />')
            .addClass('current-date-link');
        setCurrentDateString();

        currentDate = $('<div />')
            .addClass('current-date')
            .append(currentDateLink)
            .appendTo(picker);

        function initCalendar() {
            var day, week,
                currentRow,
                currentCell;

            calendarCells = [];

            currentRow = $('<tr />');
            for (day = 0; day < 7; day += 1) {
                currentCell = $('<th />')
                    .html(allDaysNames[day])
                    .appendTo(currentRow);
            }
            currentRow.appendTo(calendar);

            for (week = 0; week < 6; week += 1) {
                calendarCells[week] = [];

                currentRow = $('<tr />');
                for (day = 0; day < 7; day += 1) {
                    currentCell = $('<td />').appendTo(currentRow);
                    calendarCells[week][day] = currentCell;
                }
                currentRow.appendTo(calendar);
            }
        }

        function updateControlString() {
            var month, year, string;

            month = allMonthsNames[controlDate.month];
            year = controlDate.year;
            string = month + ' ' + year;

            currentMonth.html(string);
        }

        function setCurrentDateString() {
            var day, month, year, string;

            day = dateToDisplay.date;
            month = allMonthsNames[dateToDisplay.month];
            year = dateToDisplay.year;

            string = day + ' ' + month + ' ' + year;
            currentDateLink.html(string);
        }

        function populateCalendar() {
            var dayOfWeek, day, week,
                isCurrentMonth = false,
                start = new Date(controlDate.year, controlDate.month, controlDate.date);

            dayOfWeek = start.getDay();
            start.setDate(start.getDate() - dayOfWeek);

            for (week = 0; week < 6; week += 1) {
                for (day = 0; day < 7; day += 1) {
                    if (start.getDate() === 1) {
                        isCurrentMonth = !isCurrentMonth;
                    }

                    calendarCells[week][day].html(start.getDate());
                    start.setDate(start.getDate() + 1);

                    if (isCurrentMonth) {
                        calendarCells[week][day].removeClass();
                        calendarCells[week][day].addClass('current-month');
                    } else {
                        calendarCells[week][day].removeClass();
                        calendarCells[week][day].addClass('another-month');
                    }
                }
            }
        }

        // Events
        input.on('click', function () {
            picker.addClass('picker-visible');
            populateCalendar();
        });

        btnPrevious.on('click', function () {
            controlDate.month -= 1;
            if (controlDate.month < 0) {
                controlDate.month = 11;
                controlDate.year -= 1;
            }
            updateControlString();
            populateCalendar();
        });

        btnNext.on('click', function () {
            controlDate.month += 1;
            if (controlDate.month > 11) {
                controlDate.month = 0;
                controlDate.year += 1;
            }
            updateControlString();
            populateCalendar();
        });

        calendar.on('click', function (event) {
            var clicked = $(event.target),
                dat, month, year, string;

            if (!clicked.hasClass('current-month')) {
                return;
            }

            day = clicked.html();
            month = controlDate.month + 1;
            year = controlDate.year;
            string = day + '/' + month + '/' + year;

            input.attr('value', string);
            picker.removeClass('picker-visible');
        });

        currentDateLink.on('click', function () {
            var day, month, year, string;

            day = dateToDisplay.date;
            month = dateToDisplay.month + 1;
            year = dateToDisplay.year;
            string = day + '/' + month + '/' + year;

            input.attr('value', string);
            picker.removeClass('picker-visible');
        });

        $('html').on('click', function (event) {
            var clicked = $(event.target);

            if (clicked.hasClass('picker')) {

            } else if (clicked.parents('.picker').length > 0) {

            } else if (clicked.hasClass('datepicker')){

            }
            else {
                picker.removeClass('picker-visible');
            }
        });

        return $(this);
    };
}

if (typeof module !== 'undefined') {
    module.exports = solve;
}