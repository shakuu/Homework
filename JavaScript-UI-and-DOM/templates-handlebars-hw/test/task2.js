describe('Task 2: Build a list of Animals', function () {
    var data = {
        animals: [
            {
                name: 'Lion',
                url: 'https://susanmcmovies.files.wordpress.com/2014/12/the-lion-king-wallpaper-the-lion-king-2-simbas-pride-4685023-1024-768.jpg'
            }, {
                name: 'Turtle',
                url: 'http://www.enkivillage.com/s/upload/images/a231e4349b9e3f28c740d802d4565eaf.jpg'
            }, {
                name: 'Dog'
            }, {
                name: 'Cat',
                url: 'http://i.imgur.com/Ruuef.jpg'
            }, {
                name: 'Dog Again'
            }]
    };

    it('should build a list of anchor tags', function () {
        buildAnimals(data);
    });
});