app.directive('myheader', function () {
    return {
        restrict: 'A',
        templateUrl: '../../Content/views/header.html'
    };

});
app.directive('mymenu', function () {
    return {
        restrict: 'A',
        templateUrl: '../../Content/views/menu.html'
    };

});
app.directive('myfooter', function () {
    return {
        restrict: 'A',
        templateUrl: '../../Content/views/footer.html'
    };

});

