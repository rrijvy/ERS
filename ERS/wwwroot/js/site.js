$(window).bind('beforeunload', function () {
    sessionStorage.clear();
});