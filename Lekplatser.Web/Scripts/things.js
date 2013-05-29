var Lekplatser = Lekplatser || {};
Lekplatser.mapCache = Lekplatser.mapCache || {};

Lekplatser.addMarker = function (id, lat, lng, title) {
    if (!Lekplatser.mapCache[id]) {
        var marker = new google.maps.Marker({
            position: new google.maps.LatLng(lat, lng),
            map: Lekplatser.map,
            title: title,
            icon: '/images/playground.png'
        });
        Lekplatser.mapCache[id] = marker;
    }
};

Lekplatser.dragTimer = null;
Lekplatser.onMapDrag = function () {
    clearTimeout(Lekplatser.dragTimer);
    Lekplatser.dragTimer = setTimeout(Lekplatser.loadPlaygrounds, 500);
};

Lekplatser.loadPlaygrounds = function() {
    var location = Lekplatser.map.getCenter();
    $.ajax("/api/playgrounds/GetByLocation?lat=" + location.lat() + "&lng=" + location.lng(),
        {   
            success: function (data) {
                data.forEach(function (d) {
                    Lekplatser.addMarker(d.Id, d.Location.Lat, d.Location.Long, d.Name);
                });
            }
        });
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