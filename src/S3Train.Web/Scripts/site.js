﻿$(document).ready(function () {
    console.log('hello world!!!');

    var cssMenu = $('#cssmenu');
    if (cssMenu.length > 0) {
        $(cssMenu).load('/Menu/CategoriesMenu', function () {
            console.log('category loaded successfully!');
        });
    }

    var loginForm = $('#loginForm');
    if (loginForm.length > 0) {
        $(loginForm).load('/Account/Login', function () {
            console.log('login form loaded successfully!');
        });
    }
});