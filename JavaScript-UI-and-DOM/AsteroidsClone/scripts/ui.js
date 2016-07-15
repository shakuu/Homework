$('#game').hide();

$('#controls').on('keydown', function (input) {
    if (input.key === 's') {
        showGame();
    } if (input.key === 'Escape') {
        hideGame();
    }
});

function showGame() {
    $('body > h1').animate({
        padding: '10px 0 0 0'
    }, 3000);
    $('#game').slideDown(3000);
    $('#instructions').slideUp(3000);
    setTimeout(3000);
    $('#list-controls').slideUp(3000);
}

function hideGame() {
     $('body > h1').animate({
        padding: '200px 0 0 0'
    }, 3000);
    $('#game').slideUp(3000);
    $('#instructions').slideDown(3000);
    setTimeout(3000);
    $('#list-controls').slideDown(3000);
}
