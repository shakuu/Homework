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

        let contentDivs = $('.content').html(baconContent.slice(2, 6).join(''));
    });

