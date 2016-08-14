$(function () {
    $('#test').on('click', function (event) {
        var insertTag;

        insertTag = document.createElement('strong');
        insertNewTag(insertTag);

    });
});

function insertNewTag(tag) {
    window
        .getSelection()
        .getRangeAt(0)
        .surroundContents(tag);
}