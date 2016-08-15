function createCalendar(selector, events) {
    var root = document.querySelector(selector),

        calendar,

        dateTemplate,
        dateName,
        dateEvents,
        eventTemplate,

        dayNames = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'],
        date = 1,

        day, week, currentRow, currentDay,
        allCells, event, eventsLength, current, newEvent;

    calendar = document.createElement('table');

    dateTemplate = document.createElement('td');
    dateTemplate.style.height = '100px';
    dateTemplate.style.border = '1px solid black';
    dateName = document.createElement('strong');
    dateEvents = document.createElement('ul');
    eventTemplate = document.createElement('li');

    dateTemplate.appendChild(dateName);
    dateTemplate.appendChild(dateEvents);

    for (week = 0; week < 5; week += 1) {
        currentRow = document.createElement('tr');
        for (day = 0; day < 7; day += 1) {
            dateName.innerHTML = dayNames[day] + ' ' + date + ' ' + 'June 2014';
            currentDay = dateTemplate.cloneNode(true);
            currentRow.appendChild(currentDay);
            date += 1;
        }
        calendar.appendChild(currentRow);
    }
    root.appendChild(calendar);

    eventsLength = events.length;
    allCells = calendar.getElementsByTagName('td');
    for (event = 0; event < eventsLength; event += 1) {
        current = events[event];

        eventTemplate.innerHTML = current.hour + ' ' + current.title;
        newEvent = eventTemplate.cloneNode(true);
        allCells[+current.date - 1].appendChild(newEvent);
    }
}