appController.controller("solicitudCtrl", function ($scope, $location, $rootScope, $http, ModalService, servicioURL, tokenServicio, $routeParams) {

    $scope.solicitudDTO = {
        Id: 1, Folio: 1, Leido: "", Fecha_Creacion: new Date(), Fecha_Modificacion: new Date(), Comentario_Rechazado: "",
        Correo_Solicitante: $rootScope.loggedUser.Correo,
        Validacion: { Administrador: false, Coordinador: false, Director: false, Id: "", Posgrado: false, Subdirector: false }
    }

    $scope.otroRecurso = false;
    $scope.otraActividad = false;
    $scope.carreras = [];
    $scope.categorias = [];


    $scope.obtenerValores = function () {
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
            method: 'get',
            url: servicioURL + "SS/Categoria",
            headers: { 'Authorization': 'Bearer ' + tokenServicio.getUsuario() }
        })
          .then(
             function (respuestaExito) {
                 $scope.categorias = angular.copy(respuestaExito.data);
             },
             function (respuestaError) {
                 $rootScope.loggedUser = null;
                 $location.path('/login');
                 tokenServicio.logOut();
             }
        );
    };

    $scope.obtenerSolicitudesCorreo = function () {
        $http({
            method: 'post',
            url: servicioURL + "SS/Docente",
            headers: { 'Authorization': 'Bearer ' + tokenServicio.getUsuario() },
            data: $rootScope.loggedUser
        })
            .then(
                function (respuestaExito) {
                    console.log(respuestaExito);
                    $scope.solicitudes = angular.copy(respuestaExito.data);
                }, function (respuestaError) {
                    console.error('Error al enlistar Solicitudes')
                });
    }

    $scope.obtenerSolicitudes = function () {
        $http({
            method: 'get',
            url: servicioURL + "SS/Historial",
            headers: { 'Authorization': 'Bearer ' + tokenServicio.getUsuario() }
        })
        .then(
            function (respuestaExito) {
                console.log(respuestaExito);
                $scope.solicitudes = angular.copy(respuestaExito.data);
                console.log($scope.solicitudes);
            },
            function (respuestaError) {
                console.error('Error al enlistar Solicitudes')
            });
    };

    $scope.mostrarSolicitud = function () {
        var id = $routeParams.id;

        $http({
            method: 'get',
            url: servicioURL + "SS/Solicitud/ " + id,
            headers: { 'Authorization': 'Bearer ' + tokenServicio.getUsuario() }
        })
        .then(
        function(respuestaExito){
            $scope.solicitudDTO = angular.copy(respuestaExito.data);
            console.log(respuestaExito)
        },
                    function (respuestaError) {
                        console.error('Error al buscar la  solicitud')
                    });
    };

    $scope.isCheckboxChecked = function () {
        return (($scope.solicitudDTO.Recurso_Solicitado.Hospedaje || $scope.solicitudDTO.Recurso_Solicitado.Viatico
     || $scope.solicitudDTO.Recurso_Solicitado.Oficio_Comision || $scope.otroRecurso
     || $scope.solicitudDTO.Recurso_Solicitado.Combustible) && ($scope.solicitudDTO.Actividad.CACEI || $scope.solicitudDTO.Actividad.Licenciatura
             || $scope.solicitudDTO.Actividad.Personal || $scope.solicitudDTO.Actividad.ISO
             || $scope.solicitudDTO.Actividad.Posgrado || $scope.otraActividad));
    };


    $scope.agregarSolicitud = function () {
        $http({
            method: 'post',
            url: servicioURL + "SS/Solicitud",
            headers: { 'Authorization': 'Bearer ' + tokenServicio.getUsuario() },
            data: $scope.solicitudDTO
        })
            .then(
                function (respuestaExito) {
                    console.log(respuestaExito);
                    $scope.mensajeDTO = angular.copy(respuestaExito.data.Respuesta);


                },
                function (error) {
                    $rootScope.loggedUser = null;
                    $location.path('/login');
                    tokenServicio.logOut();
                }

            );
    }

});