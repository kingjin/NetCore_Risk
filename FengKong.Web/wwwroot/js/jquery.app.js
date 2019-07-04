/**
 * Theme: Adminto Admin Template
 * Author: Coderthemes
 * Module/App: Main Js
 */


!function ($) {
    "use strict";

    var Sidemenu = function () {
        this.$body = $("body"),
            this.$openLeftBtn = $(".open-left"),
            this.$menuItem = $("#sidebar-menu a")
    };

    Sidemenu.prototype.openLeftBar = function () {
        $("#wrapper").toggleClass("enlarged");
        $("#wrapper").addClass("forced");

        if ($("#wrapper").hasClass("enlarged") && $("body").hasClass("fixed-left")) {
            $("body").removeClass("fixed-left").addClass("fixed-left-void");
        } else if (!$("#wrapper").hasClass("enlarged") && $("body").hasClass("fixed-left-void")) {
            $("body").removeClass("fixed-left-void").addClass("fixed-left");
        }

        if ($("#wrapper").hasClass("enlarged")) {
            $(".left ul").removeAttr("style");
        } else {
            $(".subdrop").siblings("ul:first").show();
        }

        //this.toggle_slimscroll(".slimscrollleft");
        $("body").trigger("resize");
        // for mobile screen re-intializing it
        if(jQuery.browser.mobile === true) {
            $('.slimscrollleft').getNiceScroll().resize();
        }
    },
    Sidemenu.prototype.toggle_slimscroll = function(item) {
        if($("#wrapper").hasClass("enlarged")){
          $(item).css("overflow","inherit").parent().css("overflow","inherit");
          $(item). siblings(".slimScrollBar").css("visibility","hidden");
        }else{
          $(item).css("overflow","hidden").parent().css("overflow","hidden");
          $(item). siblings(".slimScrollBar").css("visibility","visible");
        }
    },
        //menu item click
        Sidemenu.prototype.menuItemClick = function (e) {
            if (!$("#wrapper").hasClass("enlarged")) {
                if ($(this).parent().hasClass("has_sub")) {

                }
                if (!$(this).hasClass("subdrop")) {
                    // hide any open menus and remove all other classes
                    $("ul", $(this).parents("ul:first")).slideUp(350);
                    $("a", $(this).parents("ul:first")).removeClass("subdrop");
                    $("#sidebar-menu .pull-right i").removeClass("zmdi-chevron-down").addClass("zmdi-chevron-right");

                    // open our new menu and add the open class
                    $(this).next("ul").slideDown(100);
                    $(this).addClass("subdrop");
                    $(".drop-arrow i", $(this).parents(".has_sub:first")).removeClass("zmdi-chevron-right").addClass("zmdi-chevron-down");
                    $(".drop-arrow i", $(this).siblings("ul")).removeClass("zmdi-chevron-down").addClass("zmdi-chevron-right");
                } else if ($(this).hasClass("subdrop")) {
                    $(this).removeClass("subdrop");
                    $(this).next("ul").slideUp(100);
                    $(".drop-arrow i", $(this).parent()).removeClass("zmdi-chevron-down").addClass("zmdi-chevron-right");
                }
            }
            $('.slimscrollleft').getNiceScroll().resize();
        },

        //init sidemenu
        Sidemenu.prototype.init = function () {
            var $this = this;

            var ua = navigator.userAgent,
                event = (ua.match(/iP/i)) ? "touchstart" : "click";


            //bind on click
            this.$openLeftBtn.on(event, function (e) {
                e.stopPropagation();
                $this.openLeftBar();
            });

            // LEFT SIDE MAIN NAVIGATION
            $this.$menuItem.on(event, $this.menuItemClick);

            // NAVIGATION HIGHLIGHT & OPEN PARENT
            $("#sidebar-menu ul li.has_sub a.active").parents("li:last").children("a:first").addClass("active").trigger("click");
        },

        //init Sidemenu
        $.Sidemenu = new Sidemenu, $.Sidemenu.Constructor = Sidemenu

}(window.jQuery),


    function ($) {
        "use strict";

        var FullScreen = function () {
            this.$body = $("body"),
                this.$fullscreenBtn = $("#btn-fullscreen")
        };

        //turn on full screen
        // Thanks to http://davidwalsh.name/fullscreen
        FullScreen.prototype.launchFullscreen = function (element) {
            if (element.requestFullscreen) {
                element.requestFullscreen();
            } else if (element.mozRequestFullScreen) {
                element.mozRequestFullScreen();
            } else if (element.webkitRequestFullscreen) {
                element.webkitRequestFullscreen();
            } else if (element.msRequestFullscreen) {
                element.msRequestFullscreen();
            }
        },
            FullScreen.prototype.exitFullscreen = function () {
                if (document.exitFullscreen) {
                    document.exitFullscreen();
                } else if (document.mozCancelFullScreen) {
                    document.mozCancelFullScreen();
                } else if (document.webkitExitFullscreen) {
                    document.webkitExitFullscreen();
                }
            },
            //toggle screen
            FullScreen.prototype.toggle_fullscreen = function () {
                var $this = this;
                var fullscreenEnabled = document.fullscreenEnabled || document.mozFullScreenEnabled || document.webkitFullscreenEnabled;
                if (fullscreenEnabled) {
                    if (!document.fullscreenElement && !document.mozFullScreenElement && !document.webkitFullscreenElement && !document.msFullscreenElement) {
                        $this.launchFullscreen(document.documentElement);
                    } else {
                        $this.exitFullscreen();
                    }
                }
            },
            //init sidemenu
            FullScreen.prototype.init = function () {
                var $this = this;
                //bind
                $this.$fullscreenBtn.on('click', function () {
                    $this.toggle_fullscreen();
                });
            },
            //init FullScreen
            $.FullScreen = new FullScreen, $.FullScreen.Constructor = FullScreen

    }(window.jQuery),


//main app module
    function ($) {
        "use strict";

        var App = function () {
            this.VERSION = "1.2.0",
                this.AUTHOR = "Coderthemes",
                this.SUPPORT = "coderthemes@gmail.com",
                this.pageScrollElement = "html, body",
                this.$body = $("body")
        };

        //on doc load
        App.prototype.onDocReady = function (e) {
            var $this = this;


            $('.animate-number').each(function () {
                $(this).animateNumbers($(this).attr("data-value"), true, parseInt($(this).attr("data-duration")));
            });

            //RUN RESIZE ITEMS
            $("body").trigger("resize");

            // right side-bar toggle
            $('.right-bar-toggle').on('click', function (e) {

                $('#wrapper').toggleClass('right-bar-enabled');
            });

            var w = $(window).width();

            if (!$("#wrapper").hasClass("forced")) {
                if (w > 990) {
                    $("#wrapper").removeClass("enlarged");
                } else {
                    $("#wrapper").addClass("enlarged");
                    $(".left ul").removeAttr("style");
                }
            }
            $('.slimscroller').niceScroll({ cursorcolor: '#ebeff2',cursorwidth:'8px', cursorborderradius: '5px'});
            $('.slimscrollleft').niceScroll({smoothscroll:false, cursorcolor: '#ebeff2',cursorwidth:'8px', cursorborderradius: '5px'});
        },
            //initilizing
            App.prototype.init = function () {
                var $this = this;
                //document load initialization
                $(document).ready($this.onDocReady);

                //init side bar - left
                $.Sidemenu.init();
                //init fullscreen
                $.FullScreen.init();
            },

            $.App = new App, $.App.Constructor = App

    }(window.jQuery),

//initializing main application module
    function ($) {
        "use strict";
        $.App.init();
    }(window.jQuery);



