(function ($) {
    "use strict";

    // Handle click on toggle search button
    $('#toggle-search').on('click', function () {
        $('.search').toggleClass('open');
        return false;
    });

    // Handle click on search submit button
    $('#search-form input[type=submit]').on('click', function () {
        $('.search').toggleClass('open');
        return true;
    });

    //New Arrival Carousel Area
    $(".new-arrival-carousel").owlCarousel({
        autoPlay: false,
        slideSpeed: 2000,
        items: 5,
        pagination: false,
        navigation: true,
        navigationText: ["<i class='fa fa-angle-left'></i>", "<i class='fa fa-angle-right'></i>"],
        itemsDesktop: [1199, 4],
        itemsDesktopSmall: [979, 3],
        itemsTablet: [768, 2],
        itemsMobile: [479, 1]
    });
    //Features Tab Carousel
    $(".single-p-slide").owlCarousel({
        autoPlay: false,
        slideSpeed: 2000,
        items: 4,
        pagination: false,
        navigation: true,
        navigationText: ["<i class='fa fa-angle-left'></i>", "<i class='fa fa-angle-right'></i>"],
        itemsDesktop: [1199, 3],
        itemsDesktopSmall: [979, 2],
        itemsLargeMobile: [767, 2],
        itemsMobile: [450, 1]
    });
    //Features Tab Bottom Carousel
    $(".single-p-slide-bottom").owlCarousel({
        autoPlay: false,
        slideSpeed: 2000,
        items: 4,
        pagination: false,
        navigation: true,
        navigationText: ["<i class='fa fa-angle-left'></i>", "<i class='fa fa-angle-right'></i>"],
        itemsDesktop: [1199, 3],
        itemsDesktopSmall: [979, 3],
        itemsLargeMobile: [767, 2],
        itemsMobile: [450, 1]
    });
    // Brand Carousel
    $(".brand-wrapper").owlCarousel({
        autoPlay: false,
        slideSpeed: 2000,
        items: 5,
        pagination: false,
        navigation: false,
        itemsDesktop: [1199, 4],
        itemsDesktopSmall: [979, 3],
        itemsLargeMobile: [767, 2],
        itemsMobile: [450, 1]
    });
    //Shop Grid/List Page Price-slider js
    $("#slider-range").slider({
        range: true,
        min: 0,
        max: 1250,
        values: [100, 600],
        slide: function (event, ui) {
            $("#amount").val("$" + ui.values[0] + " - $" + ui.values[1]);
        }
    });
    $("#amount").val("$" + $("#slider-range").slider("values", 0) +
        " - $" + $("#slider-range").slider("values", 1));
    $("#price-slider-input").on("submit", function (event) {
        event.preventDefault();
        $.get("/Shop/Filter", { minPrice: $("#slider-range").slider("values", 0), maxPrice: $("#slider-range").slider("values", 1) }, function (data) {
            if ($(".list-view").hasClass("active")) {
                $("#main-products").html(data);
                $(".grid-view").removeClass("active");
                $("#grid").removeClass("active");
                $("#grid").removeClass("show");
                $(".list-view").addClass("active");
                $("#list").addClass("active");
                $("#list").addClass("show");
            }
            else {
                $("#main-products").html(data);
            }
        });
    });

    //Shop Grid/List Page Category-Filter js
    $(".category-filter-input").on("submit", function (event) {
        event.preventDefault();
        var item = this;
        $.get("/Shop/FilterByCategory", { categoryName: $(item).children().val() }, function (data) {
            if ($(".list-view").hasClass("active")) {
                $("#main-products").html(data);
                $(".grid-view").removeClass("active");
                $("#grid").removeClass("active");
                $("#grid").removeClass("show");
                $(".list-view").addClass("active");
                $("#list").addClass("active");
                $("#list").addClass("show");
            }
            else {
                $("#main-products").html(data);
            }
        });
    });

    //Shop Grid/List Page Product-Sort js
    $("#product-sort").on("change", function (event) {
        event.preventDefault();
        $.get("/Shop/Sort", { sortBy: $("#product-sort option:selected").val() }, function (data) {
            if ($(".list-view").hasClass("active")) {
                $("#main-products").html(data);
                $(".grid-view").removeClass("active");
                $("#grid").removeClass("active");
                $("#grid").removeClass("show");
                $(".list-view").addClass("active");
                $("#list").addClass("active");
                $("#list").addClass("show");
            }
            else {
                $("#main-products").html(data);
            }
        });
    });

    //Product Details Page BX Slider
    $('.bxslider').bxSlider({
        minSlides: 4,
        maxSlides: 4,
        slideWidth: 270,
        nextSelector: '#slider-next',
        prevSelector: '#slider-prev',
        prevText: '<i class="fa fa-angle-left"></i>',
        nextText: '<i class="fa fa-angle-right"></i>'
    });
    //Countdown
    $('[data-countdown]').each(function () {
        var $this = $(this), finalDate = $(this).data('countdown');
        $this.countdown(finalDate, function (event) {
            $this.html(event.strftime('<h4 class="cdown days"><span class="counting">%-D</span></h4><h4 class="cdown hours"><span class="counting">%-H</span></h4><h4 class="cdown minutes"><span class="counting">%M</span></h4><h4 class="cdown seconds"><span><span class="counting">%S</span></h4>'));
        });
    });
    //ScollUp
    $.scrollUp({
        scrollName: 'scrollUp',
        scrollText: '<i class="fa fa-angle-up"></i>',
        easingType: 'linear',
        scrollSpeed: 900,
        animation: 'fade',
        animationInSpeed: 2000
    });
    //Elevate Zoom
    $('.zoom_01').elevateZoom({
        easing: true,
        cursor: "crosshair",
        zoomWindowFadeIn: 300,
        zoomWindowFadeOut: 350
    });
    //MeanMenu Js
    jQuery('nav#dropdown').meanmenu();

    //Product Details Page Plus Minus Button
    $(".cart-plus-minus").append('<div class="dec qtybutton">-</div><div class="inc qtybutton">+</div>');
    $(".qtybutton").on("click", function () {
        var $button = $(this);
        var oldValue = $button.parent().find("input").val();
        if ($button.text() == "+") {
            var newVal = parseFloat(oldValue) + 1;
        } else {
            // Don't allow decrementing below zero
            if (oldValue > 0) {
                var newVal = parseFloat(oldValue) - 1;
            } else {
                newVal = 0;
            }
        }
        $button.parent().find("input").val(newVal);
    });

})(jQuery);    