appController.controller("solicitudCtrl", function ($scope, $location, $rootScope, $http, ModalService, servicioURL, tokenServicio, $routeParams) {

    $scope.solicitudDTO = {
        Id: 1, Folio: 1, Leido: "", Fecha_Creacion: new Date(), Fecha_Modificacion: new Date(), Comentario_Rechazado: "",
        Correo_Solicitante: $rootScope.loggedUser.Correo,
        Validacion: { Administrador: false, Coordinador: false, Director: false, Id: "", Posgrado: false, Subdirector: false }
    }

    $scope.hoy = new Date();
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
             || $scope.solicitudDTO.Actividad.Posgrado || $scope.otraActividad && $scope.solicitudDTO.Evento.Fecha_Salida > new Date()
            && $scope.solicitudDTO.Evento.Fecha_Regreso > new Date()));
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
                    mostrarModal(respuestaExito.data.Mensaje)
                    if (respuestaExito.data.Entidad) {
                        $location.path('/Inicio');
                    } else {
                        $location.path('/Solicitud');
                    }
                },
                function (error) {
                    $rootScope.loggedUser = null;
                    $location.path('/login');
                    tokenServicio.logOut();
                }

            );
    }

    function mostrarModal(mensaje) {
        if ($rootScope.modal) {
            $rootScope.modal = false;
            ModalService.showModal({
                templateUrl: '../../Content/views/mensaje.html',
                controller: "MensajeControlador",
                inputs: {
                    mensaje: mensaje
                }
            }).then(function (modal) {
                modal.element.modal();
                modal.close.then(function (resultado) {
                    $rootScope.modal = true;
                });
            });
        }

    }

});

appController.controller('MensajeControlador', function ($scope, close, mensaje, $rootScope) {
    $scope.message = mensaje;
    $scope.close = function (resultado) {
        close(resultado, 400);
    };

    $scope.activarModal = function () {
        $rootScope.modal = true;
    }

});