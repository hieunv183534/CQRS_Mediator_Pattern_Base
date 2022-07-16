this.L = this.L || {},
this.L.Control = this.L.Control || {},
this.L.Control.Geocoder = function(e) {
    "use strict";
    e = e && e.hasOwnProperty("default") ? e.default : e;
    var t = 0
      , o = /[&<>"'`]/g
      , s = /[&<>"'`]/
      , n = {
        "&": "&amp;",
        "<": "&lt;",
        ">": "&gt;",
        '"': "&quot;",
        "'": "&#x27;",
        "`": "&#x60;"
    };
    function i(e) {
        return n[e]
    }
    function r(o, s, n, i, r) {
        var a = "_l_geocoder_" + t++;
        s[r || "callback"] = a,
        window[a] = e.Util.bind(n, i);
        var l = document.createElement("script");
        l.type = "text/javascript",
        l.src = o + e.Util.getParamString(s),
        l.id = a,
        document.getElementsByTagName("head")[0].appendChild(l)
    }
    function a(t, o, s) {
        var n = new XMLHttpRequest;
        n.onreadystatechange = function() {
            4 === n.readyState && (200 === n.status || 304 === n.status ? s(JSON.parse(n.response)) : s(""))
        }
        ,
        n.open("GET", t + e.Util.getParamString(o), !0),
        n.setRequestHeader("Accept", "application/json"),
        n.send(null)
    }
    function l(e, t) {
        return e.replace(/\{ *([\w_]+) *\}/g, function(e, n) {
            var r, a = t[n];
            return void 0 === a ? a = "" : "function" == typeof a && (a = a(t)),
            null == (r = a) ? "" : r ? (r = "" + r,
            s.test(r) ? r.replace(o, i) : r) : r + ""
        })
    }
    var c = {
        class: e.Class.extend({
            options: {
                serviceUrl: "/",
                geocodingQueryParams: {
                    countrycodes: "VN",
                    addressdetails: 1,
                    namedetails: 1
                },
                reverseQueryParams: {
                    countrycodes: "VN",
                    addressdetails: 1,
                    namedetails: 1
                },
                map: null,
                htmlTemplate: function(e) {
                    var t = e.address
                      , o = []
                      , s = e.display_name.split(",");
                    return o.push('<span class="leaflet-control-geocoder-address-detail" title="' + s.join(",") + '">' + s[0] + "</span>"),
                    s.shift(),
                    o.push('<span class="leaflet-control-geocoder-address-context" title="' + s.join(",") + '">' + s.join(",") + "</span>"),
                    l(o.join(""), t)
                }
            },
            initialize: function(t) {
                e.Util.setOptions(this, t)
            },
            geocode: function(t, o, s) {
                this.options.map && (this.options.geocodingQueryParams.viewbox = this.options.map.getBounds().toBBoxString()),
                a(this.options.serviceUrl + "search", e.extend({
                    q: t,
                    limit: 5,
                    format: "json",
                    addressdetails: 1,
                    namedetails: 1
                }, this.options.geocodingQueryParams), e.bind(function(t) {
                    for (var n = [], i = t.length - 1; i >= 0; i--) {
                        for (var r = t[i].boundingbox, a = 0; a < 4; a++)
                            r[a] = parseFloat(r[a]);
                        n[i] = {
                            address: t[i].address,
                            namedetails: t[i].namedetails,
                            icon: t[i].icon,
                            name: t[i].display_name,
                            html: this.options.htmlTemplate ? this.options.htmlTemplate(t[i]) : void 0,
                            bbox: e.latLngBounds([r[0], r[2]], [r[1], r[3]]),
                            center: e.latLng(t[i].lat, t[i].lon),
                            properties: t[i]
                        }
                    }
                    o.call(s, n)
                }, this))
            },
            reverse: function(t, o, s, n) {
                a(this.options.serviceUrl + "reverse", e.extend({
                    lat: t.lat,
                    lon: t.lng,
                    zoom: Math.round(Math.log(o / 256) / Math.log(2)),
                    addressdetails: 1,
                    format: "json"
                }, this.options.reverseQueryParams), e.bind(function(t) {
                    var o, i = [];
                    t && t.lat && t.lon && (o = e.latLng(t.lat, t.lon),
                    i.push({
                        address: t.address,
                        namedetails: t.namedetails,
                        name: t.display_name,
                        html: this.options.htmlTemplate ? this.options.htmlTemplate(t) : void 0,
                        center: o,
                        bounds: e.latLngBounds(o, o),
                        properties: t
                    })),
                    s.call(n, i)
                }, this))
            }
        }),
        factory: function(t) {
            return new e.Control.Geocoder.Nominatim(t)
        }
    }
      , d = {
        class: e.Control.extend({
            options: {
                showResultIcons: !1,
                collapsed: !1,
                expand: "click",
                position: "topleft",
                placeholder: "Tìm kiếm...",
                errorMessage: "Không tìm thấy địa điểm",
                suggestMinLength: 3,
                suggestTimeout: 250,
                defaultMarkGeocode: !0
            },
            includes: e.Evented.prototype || e.Mixin.Events,
            initialize: function(t) {
                e.Util.setOptions(this, t),
                this.options.geocoder || (this.options.geocoder = new f.class),
                this._routingGeocodersOpened = !1,
                this._requestCount = 0
            },
            onAdd: function(t) {
                var o, s = "leaflet-control-geocoder", n = e.DomUtil.create("div", "mdl-color--white mdl-shadow--2dp"), i = e.DomUtil.create("button", "mdl-button mdl-js-button mdl-button--icon mdl-button--colored leaflet-control-geocoder-search-icon", n), r = (e.DomUtil.create("div", "dim", n),
                this._form = e.DomUtil.create("div", s + "-form", n)), a = e.DomUtil.create("button", "mdl-button mdl-js-button mdl-button--icon mdl-button--colored leaflet-control-geocoder-route-icon", n), l = e.DomUtil.create("div", "mdl-tooltip mdl-tooltip--right", n);
                this.options.geocoder = new f.class({
                    map: t
                }),
                this._map = t,
                this._container = n,
                this._routing = a,
                this._routing_tooltip = l,
                i.innerHTML = '<i class="material-icons">menu</i>',
                l.setAttribute("data-mdl-for", "icon_routing"),
                l.innerHTML = "Chỉ đường",
                a.id = "icon_routing",
                this._changeRouteIcon(!0);
                var c = e.DomUtil.create("button", "mdl-button mdl-js-button mdl-button--icon  mdl-button--colored leaflet-control-geocoder-search-icon", n);
                return c.innerHTML = '<i class="material-icons">search</i>',
                (o = this._input = e.DomUtil.create("input", "", r)).type = "text",
                o.placeholder = this.options.placeholder,
                this._errorElement = e.DomUtil.create("div", s + "-form-no-error", n),
                this._errorElement.innerHTML = this.options.errorMessage,
                this._alts = e.DomUtil.create("ul", s + "-alternatives leaflet-control-geocoder-alternatives-minimized", n),
                e.DomEvent.disableClickPropagation(this._alts),
                e.DomEvent.addListener(o, "keydown", this._keydown, this),
                e.DomEvent.addListener(o, "input", this._change, this),
                e.DomEvent.addListener(o, "click", this._showResults, this),
                e.DomEvent.addListener(i, "click", toggleLeftmenu),
                e.DomEvent.addListener(o, "blur", function() {
                    this.options.collapsed && !this._preventBlurCollapse && this._collapse(),
                    this._preventBlurCollapse = !1
                }, this),
                this.options.collapsed ? "click" === this.options.expand ? e.DomEvent.addListener(c, "click", function(e) {
                    0 === e.button && 2 !== e.detail && this._toggle()
                }, this) : e.Browser.touch && "touch" === this.options.expand ? e.DomEvent.addListener(n, "touchstart mousedown", function(e) {
                    this._toggle(),
                    e.preventDefault(),
                    e.stopPropagation()
                }, this) : (e.DomEvent.addListener(n, "mouseover", this._expand, this),
                e.DomEvent.addListener(n, "mouseout", this._collapse, this),
                this._map.on("movestart", this._collapse, this)) : (this._expand(),
                e.Browser.touch ? e.DomEvent.addListener(c, "touchstart", function() {
                    this._geocode()
                }, this) : e.DomEvent.addListener(c, "click", function() {
                    this._geocode()
                }, this)),
                this.options.defaultMarkGeocode && this.on("markgeocode", this.markGeocode, this),
                this.on("startgeocode", function() {
                    e.DomUtil.addClass(this._container, "leaflet-control-geocoder-throbber")
                }, this),
                this.on("finishgeocode", function() {
                    e.DomUtil.removeClass(this._container, "leaflet-control-geocoder-throbber")
                }, this),
                e.DomEvent.disableClickPropagation(n),
                n
            },
            _geocodeResult: function(t, o, s) {
                if (!0 === s && t.length > 0)
                    this._geocodeResultSelected(t[0]);
                else if (t.length > 0) {
                    this._alts.innerHTML = "",
                    this._results = t,
                    e.DomUtil.removeClass(this._alts, "leaflet-control-geocoder-alternatives-minimized");
                    for (var n = 0; n < t.length; n++)
                        this._alts.appendChild(this._createAlt(t[n], n))
                } else
                    e.DomUtil.addClass(this._errorElement, "leaflet-control-geocoder-error")
            },
            markGeocode: function(t) {
                return t = t.geocode || t,
                this._map.fitBounds(t.bbox),
                this._geocodeMarker && this._map.removeLayer(this._geocodeMarker),
                newPlace(t.name),
                this._geocodeMarker = new e.Marker(t.center).bindPopup(t.html || t.name).addTo(this._map),
                this
            },
            _geocode: function(e, t) {
                var o = ++this._requestCount
                  , s = e ? "suggest" : "geocode"
                  , n = {
                    input: this._input.value
                };
                this._lastGeocode = this._input.value,
                e || this._clearResults(),
                this.fire("start" + s, n),
                this._input.value ? this.options.geocoder[s](this._input.value, function(i) {
                    o === this._requestCount && (n.results = i,
                    this.fire("finish" + s, n),
                    this._geocodeResult(i, e, t))
                }, this) : this._input.select()
            },
            _geocodeResultSelected: function(e) {
                this._input.value = e.name,
                toggleDetailmenu(!0),
                e.fingerprint = fingerprint,
                e.lat = e.center.lat,
                e.lon = e.center.lng,
                detailAddress(e);
                var t = new XMLHttpRequest;
                t.open("POST", "https://apis.wemap.asia/userlog/lookup?key=vpstPRxkBBTLaZkOaCfAHlqXtCR", !0),
                t.send(JSON.stringify(e)),
                removeCurrentMarker();
                var o = e.display_name.split(", ")
                  , s = (o = o.filter(function(e) {
                    return !parseInt(e) && "Việt Nam" != e
                })).join(", ");
                e.html = s,
                e.name = e.display_name,
                this.fire("markgeocode", {
                    geocode: e
                })
            },
            _toggle: function() {
                e.DomUtil.hasClass(this._container, "leaflet-control-geocoder-expanded") ? this._collapse() : this._expand()
            },
            _expand: function() {
                e.DomUtil.addClass(this._container, "leaflet-control-geocoder-expanded"),
                this._input.select(),
                this.fire("expand")
            },
            _collapse: function() {
                e.DomUtil.removeClass(this._container, "leaflet-control-geocoder-expanded"),
                e.DomUtil.addClass(this._alts, "leaflet-control-geocoder-alternatives-minimized"),
                e.DomUtil.removeClass(this._errorElement, "leaflet-control-geocoder-error"),
                this._input.blur(),
                this.fire("collapse")
            },
            _clearResults: function() {
                e.DomUtil.addClass(this._alts, "leaflet-control-geocoder-alternatives-minimized"),
                this._selection = null,
                e.DomUtil.removeClass(this._errorElement, "leaflet-control-geocoder-error")
            },
            _showResults: function() {
                this._results ? this._results.length > 0 ? e.DomUtil.removeClass(this._alts, "leaflet-control-geocoder-alternatives-minimized") : e.DomUtil.addClass(this._errorElement, "leaflet-control-geocoder-error") : this._input.value.length > 3 && this._geocode()
            },
            _createAlt: function(t, o) {
                var s = e.DomUtil.create("li", "")
                  , n = e.DomUtil.create("a", "", s)
                  , i = this.options.showResultIcons && t.icon ? e.DomUtil.create("img", "leaflet-control-geocoder-icon", n) : e.DomUtil.create("i", "mdi mdi-map-marker leaflet-control-geocoder-address-detail", n)
                  , r = t.html ? void 0 : document.createTextNode(t.name);
                return i && (i.src = t.icon),
                s.setAttribute("data-result-index", o),
                t.html ? n.innerHTML = n.innerHTML + t.html : n.appendChild(r),
                e.DomEvent.addListener(s, "mousedown touchstart", function(o) {
                    this._preventBlurCollapse = !0,
                    e.DomEvent.stop(o),
                    this._geocodeResultSelected(t),
                    e.DomEvent.on(s, "click", function() {
                        this.options.collapsed ? this._collapse() : this._clearResults()
                    }, this)
                }, this),
                s
            },
            _keydown: function(t) {
                var o = this
                  , s = function(t) {
                    o._selection && (e.DomUtil.removeClass(o._selection, "leaflet-control-geocoder-selected"),
                    o._selection = o._selection[t > 0 ? "nextSibling" : "previousSibling"]),
                    o._selection || (o._selection = o._alts[t > 0 ? "firstChild" : "lastChild"]),
                    o._selection && e.DomUtil.addClass(o._selection, "leaflet-control-geocoder-selected")
                };
                switch (t.keyCode) {
                case 27:
                    this.options.collapsed && this._collapse();
                    break;
                case 38:
                    s(-1);
                    break;
                case 40:
                    s(1);
                    break;
                case 13:
                    if (this._selection) {
                        var n = parseInt(this._selection.getAttribute("data-result-index"), 10);
                        this._geocodeResultSelected(this._results[n]),
                        this._clearResults()
                    } else {
                        this._geocode(!1, !0)
                    }
                }
            },
            _change: function() {
                var t = this._input.value;
                "" != t ? (this._changeRouteIcon(!1),
                t !== this._lastGeocode && (clearTimeout(this._suggestTimeout),
                t.length >= this.options.suggestMinLength ? this._suggestTimeout = setTimeout(e.bind(function() {
                    this._geocode()
                }, this), this.options.suggestTimeout) : this._clearResults())) : this._changeRouteIcon(!0)
            },
            _clearInput: function() {
                this._input.value = "",
                this._changeRouteIcon(!0),
                this._clearResults(),
                this._clearMarker(),
                toggleDetailmenu(!1),
                clearPlace()
            },
            _direction: function(t=!1) {
                var o = e.DomUtil.get("routingGeocoders")
                  , s = e.DomUtil.get("routingAlternativesContainer")
                  , n = e.DomUtil.get("icon_routing");
                this._routingGeocodersOpened ? (e.DomUtil.addClass(o, "d-none"),
                e.DomUtil.addClass(s, "d-none"),
                e.DomUtil.removeClass(n, "opened"),
                document.getElementsByClassName("leaflet-routing-remove-waypoint")[0].click(),
                document.getElementsByClassName("leaflet-routing-remove-waypoint")[1].click(),
                $(".leaflet-control-geocoder-expanded").show(),
                initContextMenu(!1)) : (e.DomUtil.removeClass(o, "d-none"),
                e.DomUtil.removeClass(s, "d-none"),
                e.DomUtil.addClass(n, "opened"),
                $(".leaflet-control-geocoder-expanded").hide(),
                $("#detail").removeClass("detail-left"),
                addMyLocationWayPoint("start", t)),
                this._routingGeocodersOpened = !this._routingGeocodersOpened,
                this._clearMarker && this._clearMarker()
            },
            _changeRouteIcon(t) {
                t ? (this._routing.innerHTML = '<i class="material-icons">directions</i>',
                this._routing_tooltip.innerHTML = "Chỉ đường",
                e.DomEvent.removeListener(this._routing, "click", this._clearInput, this),
                e.DomEvent.removeListener(this._routing, "click", this._direction, this),
                e.DomEvent.addListener(this._routing, "click", this._direction, this)) : (this._routing.innerHTML = '<i class="material-icons">close</i>',
                this._routing_tooltip.innerHTML = "Xóa tìm kiếm",
                e.DomEvent.removeListener(this._routing, "click", this._clearInput, this),
                e.DomEvent.removeListener(this._routing, "click", this._direction, this),
                e.DomEvent.addListener(this._routing, "click", this._clearInput, this))
            },
            _clearMarker() {
                this._geocodeMarker && this._map.removeLayer(this._geocodeMarker)
            }
        }),
        factory: function(t) {
            return new e.Control.Geocoder(t)
        }
    }
      , u = {
        class: e.Class.extend({
            initialize: function(e) {
                this.key = e
            },
            geocode: function(t, o, s) {
                r("https://dev.virtualearth.net/REST/v1/Locations", {
                    query: t,
                    key: this.key
                }, function(t) {
                    var n = [];
                    if (t.resourceSets.length > 0)
                        for (var i = t.resourceSets[0].resources.length - 1; i >= 0; i--) {
                            var r = t.resourceSets[0].resources[i]
                              , a = r.bbox;
                            n[i] = {
                                name: r.name,
                                bbox: e.latLngBounds([a[0], a[1]], [a[2], a[3]]),
                                center: e.latLng(r.point.coordinates)
                            }
                        }
                    o.call(s, n)
                }, this, "jsonp")
            },
            reverse: function(t, o, s, n) {
                r("//dev.virtualearth.net/REST/v1/Locations/" + t.lat + "," + t.lng, {
                    key: this.key
                }, function(t) {
                    for (var o = [], i = t.resourceSets[0].resources.length - 1; i >= 0; i--) {
                        var r = t.resourceSets[0].resources[i]
                          , a = r.bbox;
                        o[i] = {
                            name: r.name,
                            bbox: e.latLngBounds([a[0], a[1]], [a[2], a[3]]),
                            center: e.latLng(r.point.coordinates)
                        }
                    }
                    s.call(n, o)
                }, this, "jsonp")
            }
        }),
        factory: function(t) {
            return new e.Control.Geocoder.Bing(t)
        }
    }
      , h = {
        class: e.Class.extend({
            options: {
                serviceUrl: "https://www.mapquestapi.com/geocoding/v1"
            },
            initialize: function(t, o) {
                this._key = decodeURIComponent(t),
                e.Util.setOptions(this, o)
            },
            _formatName: function() {
                var e, t = [];
                for (e = 0; e < arguments.length; e++)
                    arguments[e] && t.push(arguments[e]);
                return t.join(", ")
            },
            geocode: function(t, o, s) {
                a(this.options.serviceUrl + "/address", {
                    key: this._key,
                    location: t,
                    limit: 5,
                    outFormat: "json"
                }, e.bind(function(t) {
                    var n, i, r = [];
                    if (t.results && t.results[0].locations)
                        for (var a = t.results[0].locations.length - 1; a >= 0; a--)
                            n = t.results[0].locations[a],
                            i = e.latLng(n.latLng),
                            r[a] = {
                                name: this._formatName(n.street, n.adminArea4, n.adminArea3, n.adminArea1),
                                bbox: e.latLngBounds(i, i),
                                center: i
                            };
                    o.call(s, r)
                }, this))
            },
            reverse: function(t, o, s, n) {
                a(this.options.serviceUrl + "/reverse", {
                    key: this._key,
                    location: t.lat + "," + t.lng,
                    outputFormat: "json"
                }, e.bind(function(t) {
                    var o, i, r = [];
                    if (t.results && t.results[0].locations)
                        for (var a = t.results[0].locations.length - 1; a >= 0; a--)
                            o = t.results[0].locations[a],
                            i = e.latLng(o.latLng),
                            r[a] = {
                                name: this._formatName(o.street, o.adminArea4, o.adminArea3, o.adminArea1),
                                bbox: e.latLngBounds(i, i),
                                center: i
                            };
                    s.call(n, r)
                }, this))
            }
        }),
        factory: function(t, o) {
            return new e.Control.Geocoder.MapQuest(t,o)
        }
    }
      , p = {
        class: e.Class.extend({
            options: {
                serviceUrl: "https://api.tiles.mapbox.com/v4/geocode/mapbox.places-v1/",
                geocodingQueryParams: {},
                reverseQueryParams: {}
            },
            initialize: function(t, o) {
                e.setOptions(this, o),
                this.options.geocodingQueryParams.access_token = t,
                this.options.reverseQueryParams.access_token = t
            },
            geocode: function(t, o, s) {
                var n = this.options.geocodingQueryParams;
                void 0 !== n.proximity && n.proximity.hasOwnProperty("lat") && n.proximity.hasOwnProperty("lng") && (n.proximity = n.proximity.lng + "," + n.proximity.lat),
                a(this.options.serviceUrl + encodeURIComponent(t) + ".json", n, function(t) {
                    var n, i, r, a = [];
                    if (t.features && t.features.length)
                        for (var l = 0; l <= t.features.length - 1; l++)
                            n = t.features[l],
                            i = e.latLng(n.center.reverse()),
                            r = n.hasOwnProperty("bbox") ? e.latLngBounds(e.latLng(n.bbox.slice(0, 2).reverse()), e.latLng(n.bbox.slice(2, 4).reverse())) : e.latLngBounds(i, i),
                            a[l] = {
                                name: n.place_name,
                                bbox: r,
                                center: i
                            };
                    o.call(s, a)
                })
            },
            suggest: function(e, t, o) {
                return this.geocode(e, t, o)
            },
            reverse: function(t, o, s, n) {
                a(this.options.serviceUrl + encodeURIComponent(t.lng) + "," + encodeURIComponent(t.lat) + ".json", this.options.reverseQueryParams, function(t) {
                    var o, i, r, a = [];
                    if (t.features && t.features.length)
                        for (var l = 0; l <= t.features.length - 1; l++)
                            o = t.features[l],
                            i = e.latLng(o.center.reverse()),
                            r = o.hasOwnProperty("bbox") ? e.latLngBounds(e.latLng(o.bbox.slice(0, 2).reverse()), e.latLng(o.bbox.slice(2, 4).reverse())) : e.latLngBounds(i, i),
                            a[l] = {
                                name: o.place_name,
                                bbox: r,
                                center: i
                            };
                    s.call(n, a)
                })
            }
        }),
        factory: function(t, o) {
            return new e.Control.Geocoder.Mapbox(t,o)
        }
    }
      , m = {
        class: e.Class.extend({
            options: {
                serviceUrl: "https://api.what3words.com/v2/"
            },
            initialize: function(e) {
                this._accessToken = e
            },
            geocode: function(t, o, s) {
                a(this.options.serviceUrl + "forward", {
                    key: this._accessToken,
                    addr: t.split(/\s+/).join(".")
                }, function(t) {
                    var n, i, r = [];
                    t.hasOwnProperty("geometry") && (n = e.latLng(t.geometry.lat, t.geometry.lng),
                    i = e.latLngBounds(n, n),
                    r[0] = {
                        name: t.words,
                        bbox: i,
                        center: n
                    }),
                    o.call(s, r)
                })
            },
            suggest: function(e, t, o) {
                return this.geocode(e, t, o)
            },
            reverse: function(t, o, s, n) {
                a(this.options.serviceUrl + "reverse", {
                    key: this._accessToken,
                    coords: [t.lat, t.lng].join(",")
                }, function(t) {
                    var o, i, r = [];
                    200 == t.status.status && (o = e.latLng(t.geometry.lat, t.geometry.lng),
                    i = e.latLngBounds(o, o),
                    r[0] = {
                        name: t.words,
                        bbox: i,
                        center: o
                    }),
                    s.call(n, r)
                })
            }
        }),
        factory: function(t) {
            return new e.Control.Geocoder.What3Words(t)
        }
    }
      , g = {
        class: e.Class.extend({
            options: {
                serviceUrl: "https://maps.googleapis.com/maps/api/geocode/json",
                geocodingQueryParams: {},
                reverseQueryParams: {}
            },
            initialize: function(t, o) {
                this._key = t,
                e.setOptions(this, o),
                this.options.serviceUrl = this.options.service_url || this.options.serviceUrl
            },
            geocode: function(t, o, s) {
                var n = {
                    address: t
                };
                this._key && this._key.length && (n.key = this._key),
                n = e.Util.extend(n, this.options.geocodingQueryParams),
                a(this.options.serviceUrl, n, function(t) {
                    var n, i, r, a = [];
                    if (t.results && t.results.length)
                        for (var l = 0; l <= t.results.length - 1; l++)
                            n = t.results[l],
                            i = e.latLng(n.geometry.location),
                            r = e.latLngBounds(e.latLng(n.geometry.viewport.northeast), e.latLng(n.geometry.viewport.southwest)),
                            a[l] = {
                                name: n.formatted_address,
                                bbox: r,
                                center: i,
                                properties: n.address_components
                            };
                    o.call(s, a)
                })
            },
            reverse: function(t, o, s, n) {
                var i = {
                    latlng: encodeURIComponent(t.lat) + "," + encodeURIComponent(t.lng)
                };
                i = e.Util.extend(i, this.options.reverseQueryParams),
                this._key && this._key.length && (i.key = this._key),
                a(this.options.serviceUrl, i, function(t) {
                    var o, i, r, a = [];
                    if (t.results && t.results.length)
                        for (var l = 0; l <= t.results.length - 1; l++)
                            o = t.results[l],
                            i = e.latLng(o.geometry.location),
                            r = e.latLngBounds(e.latLng(o.geometry.viewport.northeast), e.latLng(o.geometry.viewport.southwest)),
                            a[l] = {
                                name: o.formatted_address,
                                bbox: r,
                                center: i,
                                properties: o.address_components
                            };
                    s.call(n, a)
                })
            }
        }),
        factory: function(t, o) {
            return new e.Control.Geocoder.Google(t,o)
        }
    }
      , f = {
        class: e.Class.extend({
            options: {
                serviceUrl: "https://maps.vnpost.vn/api/search",
                reverseUrl: "https://maps.vnpost.vn/api/reverse",
                nameProperties: ["name", "street", "suburb", "hamlet", "town", "city", "state", "country"],
                htmlTemplate: function(e) {
                    let t = []
                      , o = [];
                    e.name && o.push(e.name),
                    e.housenumber && e.street ? (e.street = e.housenumber + " " + e.street,
                    o.push(e.street)) : e.street && o.push(e.street),
                    e.suburb && o.push(e.suburb),
                    e.hamlet && o.push(e.hamlet),
                    e.town && o.push(e.town),
                    e.city && o.push(e.city),
                    e.district && o.push(e.district),
                    e.state && o.push(e.state),
                    o.push("Việt Nam");
                    let s = o.join(", ");
                    return t.push('<span class="leaflet-control-geocoder-address-detail" title="' + s + '">' + o[0] + " </span>"),
                    o.shift(),
                    t.push('<span class="leaflet-control-geocoder-address-context" title="' + s + '">' + o.join(", ") + "</span>"),
                    l(t.join(""), [])
                }
            },
            initialize: function(t) {
                e.setOptions(this, t),
                e._apiKey = t
            },
            geocode: function(t, o, s) {
                let n = map.getCenter();
                var i = e.extend({
                    text: t,
                    "focus.point.lat": n.lat,
                    "focus.point.lon": n.lng,
                    apikey: e._apiKey,
                    "api-version":"1.1",
                    location_bias_scale: 2
                }, this.options.geocodingQueryParams);
                a(this.options.serviceUrl, i, e.bind(function(e) {
                    e.data && (e = e.data),
                    o.call(s, this._decodeFeatures(e))
                }, this))
            },
            suggest: function(e, t, o) {
                return this.geocode(e, t, o)
            },
            reverse: function(t, o, s, n) {
                var i = e.extend({
                    "point.lat": t.lat,
                    "point.lon": t.lng,
                    apikey: e._apiKey,
                    "api-version":"1.1",
                }, this.options.reverseQueryParams);
                a(this.options.reverseUrl, i, e.bind(function(e) {
                    
                    s.call(n, this._decodeFeatures(e))
                }, this))
            },
            _displayName: function(e) {
                let t = [];
                return e.name && t.push(e.name),
                e.housenumber && e.street ? (e.street = e.housenumber + " " + e.street,
                t.push(e.street)) : e.street && t.push(e.street),
                e.suburb && t.push(e.suburb),
                e.hamlet && t.push(e.hamlet),
                e.town && t.push(e.town),
                e.city && t.push(e.city),
                e.state && t.push(e.state),
                t.push("Việt Nam"),
                t.join(", ")
            },
            _decodeFeatures: function(t) {
                
                var o, s, n, i, r, a, l = [];
                
                if (t && t.data.features)
                
                    for (o = 0; o < t.data.features.length; o++){
                        s = t.data.features[o];
                        
                        n = s.geometry.coordinates;
                        i = e.latLng(n[1], n[0]),
                        a = (r = s.properties.extent) ? e.latLngBounds([r[1], r[0]], [r[3], r[2]]) : e.latLngBounds(i, i),
                        s.properties.lat = n[1],
                        s.properties.lon = n[0],
                        l.push({
                            geometry: s.geometry,
                            name: this._deocodeFeatureName(s),
                            html: this.options.htmlTemplate ? this.options.htmlTemplate(s.properties) : void 0,
                            center: i,
                            bbox: a,
                            properties: s.properties
                        });
                       
                    }   
                return l
            },
            _deocodeFeatureName: function(e) {
                var t, o;
                for (t = 0; !o && t < this.options.nameProperties.length; t++)
                    o = e.properties[this.options.nameProperties[t]];
                   
                return o
            }
        }),
        factory: function(t) {
            return new e.Control.Geocoder.Vmap(t)
        }
    }
      , v = {
        class: e.Class.extend({
            options: {
                serviceUrl: "https://search.mapzen.com/v1",
                geocodingQueryParams: {},
                reverseQueryParams: {}
            },
            initialize: function(t, o) {
                e.Util.setOptions(this, o),
                this._apiKey = t,
                this._lastSuggest = 0
            },
            geocode: function(t, o, s) {
                var n = this;
                a(this.options.serviceUrl + "/search", e.extend({
                    api_key: this._apiKey,
                    text: t
                }, this.options.geocodingQueryParams), function(e) {
                    o.call(s, n._parseResults(e, "bbox"))
                })
            },
            suggest: function(t, o, s) {
                var n = this;
                a(this.options.serviceUrl + "/autocomplete", e.extend({
                    api_key: this._apiKey,
                    text: t
                }, this.options.geocodingQueryParams), e.bind(function(e) {
                    e.geocoding.timestamp > this._lastSuggest && (this._lastSuggest = e.geocoding.timestamp,
                    o.call(s, n._parseResults(e, "bbox")))
                }, this))
            },
            reverse: function(t, o, s, n) {
                var i = this;
                a(this.options.serviceUrl + "/reverse", e.extend({
                    api_key: this._apiKey,
                    "point.lat": t.lat,
                    "point.lon": t.lng
                }, this.options.reverseQueryParams), function(e) {
                    s.call(n, i._parseResults(e, "bounds"))
                })
            },
            _parseResults: function(t, o) {
                var s = [];
                return e.geoJson(t, {
                    pointToLayer: function(t, o) {
                        return e.circleMarker(o)
                    },
                    onEachFeature: function(t, n) {
                        var i, r, a = {};
                        n.getBounds ? r = (i = n.getBounds()).getCenter() : (r = n.getLatLng(),
                        i = e.latLngBounds(r, r)),
                        a.name = n.feature.properties.label,
                        a.center = r,
                        a[o] = i,
                        a.properties = n.feature.properties,
                        s.push(a)
                    }
                }),
                s
            }
        }),
        factory: function(t, o) {
            return new e.Control.Geocoder.Mapzen(t,o)
        }
    }
      , _ = {
        class: e.Class.extend({
            options: {
                service_url: "http://geocode.arcgis.com/arcgis/rest/services/World/GeocodeServer"
            },
            initialize: function(t, o) {
                e.setOptions(this, o),
                this._accessToken = t
            },
            geocode: function(t, o, s) {
                var n = {
                    SingleLine: t,
                    outFields: "Addr_Type",
                    forStorage: !1,
                    maxLocations: 10,
                    f: "json"
                };
                this._key && this._key.length && (n.token = this._key),
                a(this.options.service_url + "/findAddressCandidates", n, function(t) {
                    var n, i, r, a = [];
                    if (t.candidates && t.candidates.length)
                        for (var l = 0; l <= t.candidates.length - 1; l++)
                            n = t.candidates[l],
                            i = e.latLng(n.location.y, n.location.x),
                            r = e.latLngBounds(e.latLng(n.extent.ymax, n.extent.xmax), e.latLng(n.extent.ymin, n.extent.xmin)),
                            a[l] = {
                                name: n.address,
                                bbox: r,
                                center: i
                            };
                    o.call(s, a)
                })
            },
            suggest: function(e, t, o) {
                return this.geocode(e, t, o)
            },
            reverse: function(t, o, s, n) {
                var i = {
                    location: encodeURIComponent(t.lng) + "," + encodeURIComponent(t.lat),
                    distance: 100,
                    f: "json"
                };
                a(this.options.service_url + "/reverseGeocode", i, function(t) {
                    var o, i = [];
                    t && !t.error && (o = e.latLng(t.location.y, t.location.x),
                    i.push({
                        name: t.address.Match_addr,
                        center: o,
                        bounds: e.latLngBounds(o, o)
                    })),
                    s.call(n, i)
                })
            }
        }),
        factory: function(t, o) {
            return new e.Control.Geocoder.ArcGis(t,o)
        }
    }
      , y = {
        class: e.Class.extend({
            options: {
                geocodeUrl: "http://geocoder.api.here.com/6.2/geocode.json",
                reverseGeocodeUrl: "http://reverse.geocoder.api.here.com/6.2/reversegeocode.json",
                app_id: "<insert your app_id here>",
                app_code: "<insert your app_code here>",
                geocodingQueryParams: {},
                reverseQueryParams: {}
            },
            initialize: function(t) {
                e.setOptions(this, t)
            },
            geocode: function(t, o, s) {
                var n = {
                    searchtext: t,
                    gen: 9,
                    app_id: this.options.app_id,
                    app_code: this.options.app_code,
                    jsonattributes: 1
                };
                n = e.Util.extend(n, this.options.geocodingQueryParams),
                this.getJSON(this.options.geocodeUrl, n, o, s)
            },
            reverse: function(t, o, s, n) {
                var i = {
                    prox: encodeURIComponent(t.lat) + "," + encodeURIComponent(t.lng),
                    mode: "retrieveAddresses",
                    app_id: this.options.app_id,
                    app_code: this.options.app_code,
                    gen: 9,
                    jsonattributes: 1
                };
                i = e.Util.extend(i, this.options.reverseQueryParams),
                this.getJSON(this.options.reverseGeocodeUrl, i, s, n)
            },
            getJSON: function(t, o, s, n) {
                a(t, o, function(t) {
                    var o, i, r, a = [];
                    if (t.response.view && t.response.view.length)
                        for (var l = 0; l <= t.response.view[0].result.length - 1; l++)
                            o = t.response.view[0].result[l].location,
                            i = e.latLng(o.displayPosition.latitude, o.displayPosition.longitude),
                            r = e.latLngBounds(e.latLng(o.mapView.topLeft.latitude, o.mapView.topLeft.longitude), e.latLng(o.mapView.bottomRight.latitude, o.mapView.bottomRight.longitude)),
                            a[l] = {
                                name: o.address.label,
                                bbox: r,
                                center: i
                            };
                    s.call(n, a)
                })
            }
        }),
        factory: function(t) {
            return new e.Control.Geocoder.HERE(t)
        }
    }
      , b = e.Util.extend(d.class, {
        Nominatim: c.class,
        nominatim: c.factory,
        Bing: u.class,
        bing: u.factory,
        MapQuest: h.class,
        mapQuest: h.factory,
        Mapbox: p.class,
        mapbox: p.factory,
        What3Words: m.class,
        what3words: m.factory,
        Google: g.class,
        google: g.factory,
        Vmap: f.class,
        vmap: f.factory,
        Mapzen: v.class,
        mapzen: v.factory,
        ArcGis: _.class,
        arcgis: _.factory,
        HERE: y.class,
        here: y.factory
    });
    return e.Util.extend(e.Control, {
        Geocoder: b,
        geocoder: d.factory
    }),
    b
}(L);
