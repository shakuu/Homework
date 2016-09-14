function initMaps() {
    showMap();
}

const showMap = (() => {
    const createMap = (() => {
        return {
            parseData(data) {
                const coords = {
                    lat: data.coords.latitude,
                    lon: data.coords.longitude
                };

                return coords;
            },
            createMap(coords) {
                map = new google.maps.Map(document.getElementById('map'), {
                    center: { lat: coords.lat, lng: coords.lon },
                    zoom: 18
                });
            }
        };
    })();

    const mapPromise = new Promise(function (resolve, reject) {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(resolve);
        } else {
            reject();
        }
    });

    mapPromise
        .then(createMap.parseData)
        .then(createMap.createMap);

    return mapPromise;
});