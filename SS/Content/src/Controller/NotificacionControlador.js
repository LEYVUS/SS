appController.controller("notificacionCtrl", function ($scope, $location, $rootScope, $http, servicioURL, tokenServicio) {

    $scope.notificaciones = []
    $scope.paginacion = 0;
    $scope.pages = []
    $scope.cantidadPaginador = 10;
    $scope.carreras = [];
    $scope.Filtro = { usuario: '' }

    $scope.notificacionesListar = function (usuario, paginacion) {
        console.log(usuario)
        $scope.Filtro.usuario = usuario;
       
        $http({
            method: 'get',
            url: servicioURL + "SS/Carrera",
            headers: { 'Authorization': 'Bearer ' + tokenServicio.getUsuario() }
        }).then(
         function (respuestaExito) {
             $scope.carreras = angular.copy(respuestaExito.data);

         },
          function (respuestaError) {
              $rootScope.loggedUser = null;
              $location.path('/login');
              tokenServicio.logOut();
          }
      );
        console.log($scope.Filtro)
        $http({
            method: 'post',
            url: servicioURL + "SS/Solicitud/Rol/" + paginacion,
            headers: { 'Authorization': 'Bearer ' + tokenServicio.getUsuario() },
            data: $scope.Filtro
        })
            .then(
                function (respuestaExito) {
                    contarNotificaciones(respuestaExito.data.largo);
                    $scope.notificaciones = angular.copy(respuestaExito.data.Respuesta.Entidad);
                    
                },
                function (respuestaError) {
                    $rootScope.loggedUser = null;
                    $location.path('/login');
                    tokenServicio.logOut();
                }
            );
    }

    function contarNotificaciones(notificacion) {
        $scope.pages = [];
        var longitud = Math.ceil(notificacion/ 10);
       console.log(longitud)
        for (var i = 1; i <= longitud; i++) {
            $scope.pages.push({
                no: i
            })
        }
    }

    $scope.verificacion = function (Rol) {
        if (Rol == null) {
            return false;
        }
        return true;
    }
});