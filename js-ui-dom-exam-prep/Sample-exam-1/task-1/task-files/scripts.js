function createCalendar(selector, events) {
    var TITLE = 'June 2014',
        DAYS = 30,
        WEEKS = 5,
        WEEK_DAYS = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'];


    var root = document.querySelector(selector),

        month, week, day, fragment, allDays,
        dayTemplate, dayTitle, weekTemplate,
        eventTemplate, eventTime, eventName,

        changedColorElement;

    fragment = document.createDocumentFragment();

    month = document.createElement('div');
    weekTemplate = document.createElement('div');
    dayTemplate = document.createElement('div');
    dayTitle = document.createElement('h3');

    eventTemplate = document.createElement('div');
    eventTime = document.createElement('span');
    eventName = document.createElement('strong');
    eventTemplate.appendChild(eventTime);
    eventTemplate.appendChild(eventName);

    dayTemplate.className += ' calendar-day';

    applyEventStyle(eventTemplate);
    applyDayStyles(dayTemplate);
    applyDayTitleStyles(dayTitle);
    applyRowStyles(weekTemplate);

    month.appendChild(createMonth());
    root.appendChild(month);

    function createMonth() {
        for (var i = 0; i < WEEKS; i += 1) {
            var startDay = i * 7;
            var endDay = startDay + 7;
            var currentWeek = createWeek(startDay, endDay);
            fragment.appendChild(currentWeek);
        }
        return fragment;
    }

    function createWeek(start, end) {
        var week = weekTemplate.cloneNode(true);
        for (var i = start; i < end && i < DAYS; i += 1) {
            var day = i % 7;

            var currentDay = createDay();
            var title = createDayTitle(day, i + 1);

            currentDay.appendChild(title);
            week.appendChild(currentDay);
        }
        return week;
    }

    function createDayTitle(day, date) {
        var string = WEEK_DAYS[day] + ' ' + date + ' ' + TITLE;
        var title = dayTitle.cloneNode(true);

        title.appendChild(document.createTextNode(string));
        return title;
    }

    function createDay() {
        var day = dayTemplate.cloneNode(true);
        return day;
    }

    // Fill Events
    allDays = root.getElementsByClassName('calendar-day');
    for (var i = 0, len = events.length; i < len; i += 1) {
        var hour, name, date;
        hour = events[i].hour;
        name = events[i].title;
        date = events[i].date;

        var event = createEvent(hour, name);

        allDays[date - 1].appendChild(event);
    }

    // EVENTS
    month.addEventListener('mouseleave', function (event) {
        var clicked = event.target;
        while (clicked.className.indexOf('calendar-day') < 0) {
            return;
        }
        clicked.querySelector('h3').style.backgroundColor = '#333333';
    }, true);

    month.addEventListener('mouseenter', function (event) {
        var clicked = event.target;
        while (clicked.parentNode && clicked.className.indexOf('calendar-day') < 0) {
            clicked = clicked.parentNode;
        }
        if (!(clicked instanceof HTMLElement)) {
            return;
        }
        clicked.querySelector('h3').style.backgroundColor = 'pink';
    }, true);

    month.addEventListener('click', function (event) {
        var clicked = event.target;
        while (clicked.parentNode && clicked.className.indexOf('calendar-day') < 0) {
            clicked = clicked.parentNode;
        }
        if (!(clicked instanceof HTMLElement)) {
            return;
        }

        if (changedColorElement === clicked) {
            if (changedColorElement.style.backgroundColor === 'pink') {
                changedColorElement.style.backgroundColor = '';
            } else {
                changedColorElement.style.backgroundColor = 'pink';
            }
            return;
        }
        if (changedColorElement) {
            changedColorElement.style.backgroundColor = '';
        }
        changedColorElement = clicked;
        changedColorElement.style.backgroundColor = 'pink';

    }, true);

    // HELPERS
    function createEvent(hour, name) {
        eventTime.innerHTML = hour;
        eventName.innerHTML = name;
        var event = eventTemplate.cloneNode(true);
        return event;
    }

    function applyDayStyles(day) {
        day.style.display = 'inline-block';
        day.style.width = '100px';
        day.style.height = '100px';
        day.style.border = '1px solid black';
    }

    function applyDayTitleStyles(title) {
        title.style.margin = '0';
        title.style.textAlign = 'center';
        title.style.borderBottom = '1px solid black';
        title.style.fontSize = '12px';
        title.style.backgroundColor = '#333333';
        title.style.color = '#E6E6E6';
    }

    function applyRowStyles(row) {
        row.style.marginBottom = '-2px';
    }

    function applyEventStyle(event) {
        event.style.float = 'left';
        event.style.margin = '0';
        event.style.fontSize = '10px';
        event.style.padding = '5px';
        event.querySelector('strong').style.marginLeft = '5px';
    }
}