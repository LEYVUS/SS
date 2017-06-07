appController.controller("notificacionCtrl", ['$scope', '$location', '$rootScope', '$http', 'servicioURL', 'tokenServicio', function ($scope, $location, $rootScope, $http, servicioURL, tokenServicio) {

    $scope.notificaciones = []
    $scope.paginacion = 0;
    $scope.pages = []
    $scope.cantidadPaginador = 10;
    $scope.carreras = [];
    $scope.Filtro = { usuario: '' }

    $scope.notificacionesListar = function (usuario, paginacion) {
     
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
        if ($scope.Filtro.Nombre == null) {
            $scope.Filtro.Nombre == "";
        }
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
        $rootScope.noNotificaciones = notificacion;
        var longitud = Math.ceil(notificacion/ 10);
      
        for (var i = 1; i <= longitud; i++) {
            $scope.pages.push({
                no: i
            })
        }
    }
    ///

    ///
    $scope.notificacionesDocente = function (usuario, paginacion) {
       var usuarioSinRol = angular.copy(usuario);
       usuarioSinRol.Rol = null;
       $scope.Filtro.usuario = usuarioSinRol;
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
}]);