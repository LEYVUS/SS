appController.controller("notificacionCtrl", function ($scope, $location, $rootScope, $http, servicioURL, tokenServicio) {

    $scope.notificaciones = []


    $scope.notificacionesListar = function (usuario) {
        $http({
            method: 'post',
            url: servicioURL + "SS/Solicitud/Rol",
            headers: { 'Authorization': 'Bearer ' + tokenServicio.getUsuario() },
            data:usuario
        })
            .then(
                function (respuestaExito) {
                    $scope.notificaciones = angular.copy(respuestaExito.data);
                    console.log($scope.notificaciones)
                },
                function (respuestaError) {
                    $rootScope.loggedUser = null;
                    $location.path('/login');
                    tokenServicio.logOut();
                }
            );

        $scope.verificacion = function(Rol) {
            if(Rol == null){
                return false;
            }
            return true;
        }
    }
});