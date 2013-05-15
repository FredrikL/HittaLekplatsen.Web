﻿var Lekplatser = Lekplatser || {};


$(function () {
    function initialize() {
        var mapOptions = {
            center: new google.maps.LatLng(55.39, 13.06),
            zoom: 8,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        Lekplatser.map = new google.maps.Map(document.getElementById("map-canvas"),
            mapOptions);
    }

    initialize();
});

function addMarker(id, lat, lng, title) {
    var marker = new google.maps.Marker({
        position: new google.maps.LatLng(lat, lng),
        title: title
    });

    marker.setMap(Lekplatser.map);
}