appController.controller("logoutCtrl", function ($scope, $location, $rootScope, $interval, localStorageService) {
    $scope.countTime = 0;
    $scope.show = true;
    $rootScope.modal = true;

    $scope.logOut = function () {
        $rootScope.loggedUser = null;
        localStorageService.remove('user');
        localStorageService.remove('token');
        $location.path('/login');
    }



    $scope.clearTime = function() {
        $scope.countTime = 0;
        $scope.startTime();
    }

    $scope.startTime = function () {
        stop = $interval(function () {
            if ($scope.countTime >= 2058197) {
                $scope.logOut();
                $location.path('/logout');
            } else {
                $scope.countTime++;
            }
        });
    }

    $scope.redirect = function (path) {
        $location.path(path);
    }

    $scope.redireccionar = function (URL) {
        $location.path(URL);
    }

    $scope.regex = {
        'correo': '^.*uabc.edu.mx.*$',
        'number': '/[a-z]/'
    };

});
