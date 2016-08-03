$(function () {
    solve()();

    var data = [],
        count = 5,
        id = 'students-table';

    document.body.innerHTML =
        '<table><thead><tr><th>#</th><th>Name</th><th>Mark</th></tr></thead>' +
        '<tbody id="' + id + '" data-template="students-row-template"></tbody></table>' +
        '<script id="students-row-template" type="text/handlebars-template"><tr class="student-row"><td>{{number}}</td><td>{{name}}</td><td>{{mark}}</td></tr></script>';


    for (var i = 0; i < count; i += 1) {
        var number = i + 1;
        var name = `Student ${i + 1}`;
        var mark = i % 5 + 2;
        data.push({ number, name, mark });
    }
    $('#' + id).listview(data);
});

