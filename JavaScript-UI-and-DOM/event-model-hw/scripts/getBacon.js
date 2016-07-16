// $.getJSON('http://baconipsum.com/api/?callback=?',
//     { 'type': 'meat-and-filler', 'start-with-lorem': '1', 'paras': '3' },
//     function (baconGoodness) {
//         if (baconGoodness && baconGoodness.length > 0) {
//             $("#baconIpsumOutput").html('');
//             for (var i = 0; i < baconGoodness.length; i++)
//                 $("#baconIpsumOutput").append('<p>' + baconGoodness[i] + '</p>');
//             $("#baconIpsumOutput").show();
//         }

var baconContent = '';

$.getJSON('http://baconipsum.com/api/?callback=?',
    { 'type': 'meat-and-filler', 'start-with-lorem': '1', 'paras': '2' },
    function (bacon) {
        if (bacon && bacon.length > 0) {
            for (let i = 0; i < bacon.length; i += 1) {
                baconContent += `<p>${bacon[i]}</p> `;
            }
        }

        let contentDivs = $('.content').html(baconContent);
    });

