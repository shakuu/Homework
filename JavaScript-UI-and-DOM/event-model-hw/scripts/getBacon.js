var baconContent = [];

$.getJSON('http://baconipsum.com/api/?callback=?',
    { 'type': 'meat-and-filler', 'start-with-lorem': '1', 'paras': '10' },
    function (bacon) {
        if (bacon && bacon.length > 0) {
            for (let i = 0; i < bacon.length; i += 1) {
                baconContent[i] = '';
                baconContent[i] += `<p>${bacon[i]}</p> `;
            }
        }

        let contentDivs = $('#test-div').children('.content');

        for (let i = 0; i < contentDivs.length; i += 1) {
            $(contentDivs[i]).html(baconContent.slice(getRandomInt(0, 5), getRandomInt(5, 10)).join(''));
        }
    });

function getRandomInt(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}
