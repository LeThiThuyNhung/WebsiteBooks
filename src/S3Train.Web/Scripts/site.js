﻿$(document).ready(function () {
    console.log('hello world!!!');

    var cssMenu = $('#cssmenu');
    if (cssMenu.length > 0) {
        $(cssMenu).load('/Menu/CategoriesMenu', function () {
            console.log('category loaded successfully!');
        });
    }
});