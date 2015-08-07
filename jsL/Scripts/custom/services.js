'use strict';

var services = angular.module('services', []);

services.service('sharedService', function () {
    var markers = [];
    var edit;
    var add;
    var word = "louiegor";

    var templates = [
        { name: 'getCharacter', url: 'character/get/' }
    ];

    var template = { url: templates[1].url };
    var globalFilter = {};
    var map;

    return {
        getAttrs: function () {
            return global.attrs;
        },
        getMarkers: function () {
            return markers;
        },
        getColors: function () {
            return ['Red', 'Blue', 'Green'];
        },
        getAddMarker: function () {
            return add;
        },
        getWord : function() {
            return word;
        }
    };
});