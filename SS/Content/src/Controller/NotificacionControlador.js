appController.controller("notificacionCtrl", function ($scope, $location, $rootScope, $interval, localStorageService,$http) {

    $scope.notificaciones = []


    $scope.notificacionesListar = function (usuario) {
        $http.post(utileria.ObtenerURL() + 'Solicitud/Rol', usuario)
            .then(
                function (respuestaExito) {
                    $scope.notificaciones = angular.copy(respuestaExito.data);
                    console.log($scope.notificaciones)
                },
                function (respuestaError) {
                    console.error('No se encontraron solicitudes');
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