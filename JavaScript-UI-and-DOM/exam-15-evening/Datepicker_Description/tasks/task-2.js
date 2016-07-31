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

        //  var inputDatePicker,
        //     datePickerWrapper,

        //     picker;

        // inputDatePicker = $(this)
        //     .addClass('datepicker');
        // datePickerWrapper = $('<div />')
        //     .addClass('datepicker-wrapper')
        //     .appendTo(inputDatepicker.parents().first())
        //     .append(inputDatePicker);

        // picker = $('<div />')
        //     .addClass('picker')
        //     .addClass('picker-visible');

        // // you are welcome :)
        var date = new Date();
        // console.log(date.getDayName());
        // console.log(date.getMonthName());

        var datepickerWraper,

            inputDatepicker,

            picker,

            controls,
            btnPrev,
            currentMonth,
            btnNext,

            calendar,
            calendarCells = [],

            currentDate,
            currentDateLink,

            currentDates = [],
            week, day,
            currentDisplayDate,
            currentDisplayMonth,
            currentDisplayYear = 2016;

        inputDatepicker = $(this)
            .addClass('datepicker');

        var parent = inputDatepicker.parents().first();

        datepickerWraper = $('<div />')
            .addClass('datepicker-wrapper')
            .appendTo( inputDatepicker.parents().first())
            .append(inputDatepicker);

        picker = $('<div />')
            .addClass('picker')
            // .addClass('picker-visible')
            .appendTo(datepickerWraper);

        controls = $('<div />')
            .addClass('controls')
            .appendTo(picker);

        btnPrev = $('<a />')
            .addClass('btn')
            .addClass('previous')
            .html('<')
            .appendTo(controls);

        currentMonth = $('<div />')
            .addClass('current-month')
            .appendTo(controls);
        // .html();

        btnNext = $('<a />')
            .addClass('btn')
            .addClass('next')
            .html('>')
            .appendTo(controls);

        calendar = $('<table />')
            .addClass('calendar')
            .appendTo(picker);

        currentDate = $('<div />')
            .addClass('current-date')
            .appendTo(picker);

        currentDateLink = $('<a />')
            .addClass('current-date-link')
            .appendTo(currentDate);

        function populateCalendarTableCells(currentDates) {
            var isCurrent = false;

            for (week = 0; week < 6; week += 1) {

                for (day = 0; day < 7; day += 1) {
                    calendarCells[week][day].html(currentDates[week][day]);

                    if (currentDates[week][day] === 1) {
                        isCurrent = !isCurrent;
                    }

                    if (isCurrent) {
                        calendarCells[week][day]
                            .removeClass()
                            .addClass('current-month');
                    } else {
                        calendarCells[week][day]
                            .removeClass()
                            .addClass('another-month');
                    }
                }
            }
        }

        function createCalendarTable() {
            var currentWeek,
                newCell,
                week,
                day;

            // HeaderRow
            currentWeek = $('<tr />')
                .addClass('header-row');
            for (day = 0; day < 7; day += 1) {
                newCell = $('<th />')
                    .html(WEEK_DAY_NAMES[day])
                    .appendTo(currentWeek);
            }
            currentWeek.appendTo(calendar);

            for (week = 0; week < 6; week += 1) {
                calendarCells[week] = [];
                currentWeek = $('<tr />')
                    .addClass('week' + week);

                for (day = 0; day < 7; day += 1) {
                    newCell = $('<td />').appendTo(currentWeek);
                    calendarCells[week][day] = newCell;
                }
                currentWeek.appendTo(calendar);
            }
        }

        function getStartDate(current) {
            current.setDate(1);
            current.setDate(current.getDate() - current.getDay());
            return current;
        }

        function getDates(Date) {
            var currentDates = [],
                startDate = Date;

            for (week = 0; week < 6; week += 1) {
                currentDates[week] = [];

                for (day = 0; day < 7; day += 1) {
                    currentDates[week][day] = startDate.getDate();
                    startDate.setDate(startDate.getDate() + 1);
                }
            }
            return currentDates;
        }

        createCalendarTable();

        // Events
        inputDatepicker.on('click', function () {
            picker.toggleClass('picker-visible');

            currentDisplayDate = getStartDate(new Date());
            currentDates = getDates(currentDisplayDate);
            populateCalendarTableCells(currentDates);

            var month = new Date();
            currentDisplayMonth = month.getMonth();
            currentMonth.html(MONTH_NAMES[Math.abs(currentDisplayMonth % 12)] + ' ' + (currentDisplayYear + Math.floor(currentDisplayMonth / 12)));

            currentDateLink.html(month.getDate() + ' ' + month.getMonthName() + ' ' + month.getFullYear());

            $('.current-month').on('click', function () {
                picker.removeClass('picker-visible');
                var date = $(this).html();
                inputDatepicker.attr('value', date + '/' + (Math.abs(currentDisplayMonth % 12) + 1) + '/' + (currentDisplayYear + Math.floor(currentDisplayMonth / 12)));
            });


        });

        btnPrev.on('click', function () {
            var start,
                month;

            currentDisplayDate.setMonth(currentDisplayDate.getMonth() - 2);
            start = getStartDate(currentDisplayDate);
            currentDates = getDates(start);
            populateCalendarTableCells(currentDates);

            currentDisplayMonth -= 1;
            currentMonth.html(MONTH_NAMES[Math.abs(currentDisplayMonth % 12)] + ' ' + (currentDisplayYear + Math.floor(currentDisplayMonth / 12)));
        });

        btnNext.on('click', function () {
            var start,
                month;

            currentDisplayDate.setMonth(currentDisplayDate.getMonth() + 0.5);
            start = getStartDate(currentDisplayDate);
            currentDates = getDates(start);
            populateCalendarTableCells(currentDates);

            currentDisplayMonth += 1;
            currentMonth.html(MONTH_NAMES[Math.abs(currentDisplayMonth % 12)] + ' ' + (currentDisplayYear + Math.floor(currentDisplayMonth / 12)));
        });

        currentDateLink.on('click', function(){
            var date = new Date();
            inputDatepicker.attr('value', date.getDate() + '/' + (date.getMonth() + 1 )+ '/' + date.getFullYear());
        });

        return datepickerWraper;
    };
}

module.exports = solve;