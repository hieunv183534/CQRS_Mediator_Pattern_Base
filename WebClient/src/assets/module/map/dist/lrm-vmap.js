!function() {
    return function t(e, n, i) {
        function o(s, a) {
            if (!n[s]) {
                if (!e[s]) {
                    var l = "function" == typeof require && require;
                    if (!a && l)
                        return l(s, !0);
                    if (r)
                        return r(s, !0);
                    var u = new Error("Cannot find module '" + s + "'");
                    throw u.code = "MODULE_NOT_FOUND",
                    u
                }
                var c = n[s] = {
                    exports: {}
                };
                e[s][0].call(c.exports, function(t) {
                    return o(e[s][1][t] || t)
                }, c, c.exports, t, e, n, i)
            }
            return n[s].exports
        }
        for (var r = "function" == typeof require && require, s = 0; s < i.length; s++)
            o(i[s]);
        return o
    }
}()({
    1: [function(t, e, n) {
        void 0 !== e && (e.exports = function(t, e, n) {
            var i = !1;
            if (void 0 === window.XMLHttpRequest)
                return e(Error("Browser not supported"));
            if (void 0 === n) {
                var o = t.match(/^\s*https?:\/\/[^\/]*/);
                n = o && o[0] !== location.protocol + "//" + location.domain + (location.port ? ":" + location.port : "")
            }
            var r = new window.XMLHttpRequest;
            if (n && !("withCredentials"in r)) {
                r = new window.XDomainRequest;
                var s = e;
                e = function() {
                    if (i)
                        s.apply(this, arguments);
                    else {
                        var t = this
                          , e = arguments;
                        setTimeout(function() {
                            s.apply(t, e)
                        }, 0)
                    }
                }
            }
            function a() {
                var t;
                void 0 === r.status || (t = r.status) >= 200 && t < 300 || 304 === t ? e.call(r, null, r) : e.call(r, r, null)
            }
            return "onload"in r ? r.onload = a : r.onreadystatechange = function() {
                4 === r.readyState && a()
            }
            ,
            r.onerror = function(t) {
                e.call(this, t || !0, null),
                e = function() {}
            }
            ,
            r.onprogress = function() {}
            ,
            r.ontimeout = function(t) {
                e.call(this, t, null),
                e = function() {}
            }
            ,
            r.onabort = function(t) {
                e.call(this, t, null),
                e = function() {}
            }
            ,
            r.open("GET", t, !0),
            r.send(null),
            i = !0,
            r
        }
        )
    }
    , {}],
    2: [function(t, e, n) {
        var i = {};
        function o(t, e) {
            t = Math.round(t * e),
            (t <<= 1) < 0 && (t = ~t);
            for (var n = ""; t >= 32; )
                n += String.fromCharCode(63 + (32 | 31 & t)),
                t >>= 5;
            return n += String.fromCharCode(t + 63)
        }
        i.decode = function(t, e) {
            for (var n, i = 0, o = 0, r = 0, s = [], a = 0, l = 0, u = null, c = Math.pow(10, e || 5); i < t.length; ) {
                u = null,
                a = 0,
                l = 0;
                do {
                    l |= (31 & (u = t.charCodeAt(i++) - 63)) << a,
                    a += 5
                } while (u >= 32);
                n = 1 & l ? ~(l >> 1) : l >> 1,
                a = l = 0;
                do {
                    l |= (31 & (u = t.charCodeAt(i++) - 63)) << a,
                    a += 5
                } while (u >= 32);
                o += n,
                r += 1 & l ? ~(l >> 1) : l >> 1,
                s.push([o / c, r / c])
            }
            return s
        }
        ,
        i.encode = function(t, e) {
            if (!t.length)
                return "";
            for (var n = Math.pow(10, e || 5), i = o(t[0][0], n) + o(t[0][1], n), r = 1; r < t.length; r++) {
                var s = t[r]
                  , a = t[r - 1];
                i += o(s[0] - a[0], n),
                i += o(s[1] - a[1], n)
            }
            return i
        }
        ,
        void 0 !== typeof e && (e.exports = i)
    }
    , {}],
    3: [function(t, e, n) {
        (function(n) {
            !function() {
                "use strict";
                var i = "undefined" != typeof window ? window.L : void 0 !== n ? n.L : null
                  , o = t("corslite")
                  , r = t("polyline");
                i.Routing = i.Routing || {},
                i.Routing.Vmap = i.Evented.extend({
                    options: {
                        serviceUrl: "https://maps.vnpost.vn/api/route",
                        timeout: 3e4,
                        urlParameters: {
                            points_encoded: !0,
                            "api-version": "1.1"
                        }
                    },
                    initialize: function(t, e) {
                        this._apiKey = t,
                        i.Util.setOptions(this, e),
                        this._vehicle = "car"
                    },
                    route: function(t, e, n, r) {
                        var s, a, l, u, c = !1, p = [];
                        for (r = r || {},
                        s = this.buildRouteUrl(t, r),
                        a = setTimeout(function() {
                            c = !0,
                            e.call(n || e, {
                                status: -1,
                                message: "Request timed out."
                            })
                        }, this.options.timeout),
                        u = 0; u < t.length; u++)
                            l = t[u],
                            p.push({
                                latLng: l.latLng,
                                name: l.name,
                                options: l.options
                            });
                        return o(s, i.bind(function(t, i) {
                            var o;
                            if (clearTimeout(a),
                            !c) {
                                var r = t || i;
                                if (this.fire("response", {
                                    status: r.status,
                                    // limit: Number(r.getResponseHeader("X-RateLimit-Limit")),
                                    // remaining: Number(r.getResponseHeader("X-RateLimit-Remaining")),
                                    // reset: Number(r.getResponseHeader("X-RateLimit-Reset")),
                                    // credits: Number(r.getResponseHeader("X-RateLimit-Credits"))
                                }),
                                t) {
                                    var s, l = t && t.responseText;
                                    try {
                                        s = JSON.parse(l)
                                    } catch (t) {
                                        s = l
                                    }
                                    e.call(n || e, {
                                        status: -1,
                                        message: "HTTP request failed: " + t,
                                        response: s
                                    })
                                } else
                                    o = JSON.parse(i.responseText),
                                    this._routeDone(o, p, e, n)
                            }
                        }, this)),
                        this
                    },
                    _routeDone: function(t, e, n, i) {
                        var o, r, s, a, l = [];
                        if (i = i || n,
                        t.info && t.info.errors && t.info.errors.length)
                            n.call(i, {
                                status: t.info.errors[0].details,
                                message: t.info.errors[0].message
                            });
                        else {
                            for (s = 0; s < t.paths.length; s++)
                                a = t.paths[s],
                                r = this._decodePolyline(a.points),
                                o = this._mapWaypointIndices(e, a.instructions, r),
                                l.push({
                                    name: "",
                                    coordinates: r,
                                    instructions: this._convertInstructions(a.instructions),
                                    summary: {
                                        totalDistance: a.distance,
                                        totalTime: 2 * a.time / 1e3,
                                        totalAscend: a.ascend
                                    },
                                    inputWaypoints: e,
                                    actualWaypoints: o.waypoints,
                                    waypointIndices: o.waypointIndices
                                });
                            n.call(i, null, l)
                        }
                    },
                    _decodePolyline: function(t) {
                        var e, n = r.decode(t, 5), o = new Array(n.length);
                        for (e = 0; e < n.length; e++)
                            o[e] = new i.LatLng(n[e][0],n[e][1]);
                        return o
                    },
                    _toWaypoints: function(t, e) {
                        var n, o = [];
                        for (n = 0; n < e.length; n++)
                            o.push({
                                latLng: i.latLng(e[n]),
                                name: t[n].name,
                                options: t[n].options
                            });
                        return o
                    },
                    buildRouteUrl: function(t, e) {
                        var n, o, //!(options && options.geometryOnly),
                        r = [];
                        for (n = 0; n < t.length; n++)
                            r.push("point=" + t[n].latLng.lat + "," + t[n].latLng.lng);
                        return o = this.options.serviceUrl + "?" + r.join("&"),
                        this._getVehicle(),
                        o + i.Util.getParamString(i.extend({
                            instructions: !0,
                            type: "json",
                            locale: "vi",
                            apikey: this._apiKey,
                            vehicle: this._vehicle
                        }, this.options.urlParameters), o)
                    },
                    _getVehicle: function() {
                        this._vehicle = "car";
                        // var t = i.DomUtil.get("carVehicle");
                        // if (i.DomUtil.hasClass(t, "selected"))
                        //     this._vehicle = "car";
                        // else {
                        //     var e = i.DomUtil.get("footVehicle");
                        //     if (i.DomUtil.hasClass(e, "selected"))
                        //         this._vehicle = "foot";
                        //     else {
                        //         var n = i.DomUtil.get("bikeVehicle");
                        //         i.DomUtil.hasClass(n, "selected") && (this._vehicle = "bike")
                        //     }
                        // }
                    },
                    _convertInstructions: function(t) {
                        var e, n, i, o = {
                            "-3": "SharpLeft",
                            "-2": "Left",
                            "-1": "SlightLeft",
                            0: "Straight",
                            1: "SlightRight",
                            2: "Right",
                            3: "SharpRight",
                            4: "DestinationReached",
                            5: "WaypointReached",
                            6: "Roundabout"
                        }, r = [];
                        for (n = 0; t && n < t.length; n++)
                            e = o[(i = t[n]).sign],
                            r.push({
                                type: e,
                                modifier: e,
                                text: i.text,
                                distance: i.distance,
                                time: 2 * i.time / 1e3,
                                index: i.interval[0],
                                exit: i.exit_number
                            });
                        return r
                    },
                    _mapWaypointIndices: function(t, e, n) {
                        var o, r, s = [], a = [];
                        for (a.push(0),
                        s.push(new i.Routing.Waypoint(n[0],t[0].name)),
                        o = 0; e && o < e.length; o++)
                            5 === e[o].sign && (r = e[o].interval[0],
                            a.push(r),
                            s.push({
                                latLng: n[r],
                                name: t[s.length + 1].name
                            }));
                        return a.push(n.length - 1),
                        s.push({
                            latLng: n[n.length - 1],
                            name: t[t.length - 1].name
                        }),
                        {
                            waypointIndices: a,
                            waypoints: s
                        }
                    }
                }),
                i.Routing.vmap = function(t, e) {
                    return new i.Routing.Vmap(t,e)
                }
                ,
                e.exports = i.Routing.Vmap
            }()
        }
        ).call(this, "undefined" != typeof global ? global : "undefined" != typeof self ? self : "undefined" != typeof window ? window : {})
    }
    , {
        corslite: 1,
        polyline: 2
    }]
}, {}, [3]);
