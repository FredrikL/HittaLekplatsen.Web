var Lekplatser = Lekplatser || {};

Lekplatser.addMarker = function(id, lat, lng, title) {
    var marker = new google.maps.Marker({
        position: new google.maps.LatLng(lat, lng),
        map: Lekplatser.map,
        title: title
    });
};

Lekplatser.dragTimer = null;
Lekplatser.onMapDrag = function () {
    clearTimeout(Lekplatser.dragTimer);
    Lekplatser.dragTimer = setTimeout(Lekplatser.loadPlaygrounds, 500);
};

Lekplatser.loadPlaygrounds = function() {
    console.log(Lekplatser.map.getCenter());
    // todo: call backend to get markers
};


$(function () {
    function initialize() {
        var mapOptions = {
            center: new google.maps.LatLng(55.39, 13.06),
            zoom: 8,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        Lekplatser.map = new google.maps.Map(document.getElementById("map-canvas"),
            mapOptions);

        google.maps.event.addListener(Lekplatser.map, 'dragend', Lekplatser.onMapDrag);

        google.maps.event.addListener(Lekplatser.map, "zoom_changed", function() {
            var eventListener = google.maps.event.addListener(Lekplatser.map, "bounds_changed", function() {
                google.maps.event.removeListener(eventListener);
                Lekplatser.onMapDrag();
            });
        });
    }

    initialize();

    Lekplatser.loadPlaygrounds();
});