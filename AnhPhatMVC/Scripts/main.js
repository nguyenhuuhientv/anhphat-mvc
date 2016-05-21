/**
 * Created by Hien Nguyen on 5/20/2016.
 */
$(document).ready(function ()  {
    $('ul.dropdown-menu a.expand-dropdown-menu').on('click', function(event){
        //The event won't be propagated to the document NODE and
        // therefore events delegated to document won't be fired
        // console.log(112);
        $('.collapse').collapse("hide");
        $(this).next().collapse("toggle");
        event.stopPropagation();
        event.preventDefault();
        // $('a.expand-dropdown-menu').parent().addClass('open');
        // console.log($('a.expand-dropdown-menu').parent().addClass('open'));
    });
    $('.navbar-top .dropdown').hover(function() {
        $(this).addClass('open').find('.dropdown-menu').first().stop(true, true).show();
    }, function() {
        $(this).removeClass('open').find('.dropdown-menu').first().stop(true, true).hide();
    });
});