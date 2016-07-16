function validateCount(count) {

    if (+count || count === 0) {
        if (+count < 1) {
            throw Error('Count must be more than or equal to one.');
        }
    } else {
        throw Error('Count must be a number.');
    }
}

function taskPopulateList(selector, count) {
    validateCount(count);

    let newUl = $('<ul>')
        .addClass('items-list')
        .appendTo($(selector));

    console.log(newUl);

    for (let i = 0; i < count; i += 1) {
        $('<li>')
            .addClass('list-item')
            .text(`List item #${i}`)
            .appendTo(newUl);
    }

    return selector;
}