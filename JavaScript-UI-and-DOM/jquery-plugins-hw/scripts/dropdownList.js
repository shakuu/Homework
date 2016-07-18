
jQuery.fn.dropdownList = function () {
    let select = $(this).css('display', 'none');
    let parent = select.parent();

    // Step 1: div class dropdown wrapper
    let wrapper = $('<div>')
        .addClass('dropdown-list')
        .append(select)
        .prependTo(parent);

    // Step 2: div current
    let current = $('<div>')
        .addClass('current')
        .attr('data-value', '')
        .text(select.children().first().text())
        .appendTo(wrapper)
        .on('click', function () {
            optionsContainer.toggle();
        });
        
    // Step 3: div options container
    let optionsContainer = $('<div>')
        .addClass('options-container')
        .css({
            'position': 'absolute',
            'display': 'none'
        }).appendTo(wrapper)
        .on('click', '.dropdown-item', function () {
            let clicked = $(this);

            current
                .attr('data-value', clicked.attr('data-value'))
                .text(clicked.text());

            optionsContainer.toggle();
        });

    // Step 4: divs with options
    for (let i = 0; i < select.children().length; i += 1) {
        $('<div>')
            .addClass('dropdown-item')
            .attr('data-value', `value-${i + 1}`)
            .attr('data-index', `${i}`)
            .text($(select.children()[i]).text())
            .appendTo(optionsContainer);
    }

    return wrapper;
};

$('#the-select').dropdownList();
// <div class="dropdown-list">
//   <select style="display: none;">
//     <option value="value-1">Option 1</option>
//     <option value="value-2">Option 2</option>
//     <option value="value-3">Option 3</option>
//     <option value="value-4">Option 4</option>
//     <option value="value-5">Option 5</option>
//   </select>
//   <div class="current" data-value="">Option 1</div>
//   <div class="options-container" style="position: absolute; display: none;">
//     <div class="dropdown-item" data-value="value-1" data-index="0">Option1</div>
//     <div class="dropdown-item" data-value="value-2" data-index="1">Option 2</div>
//     <div class="dropdown-item" data-value="value-3" data-index="2">Option 3</div>
//     <div class="dropdown-item" data-value="value-4" data-index="3">Option 4</div>
//     <div class="dropdown-item" data-value="value-5" data-index="4">Option 5</div>
//   </div>
// </div>