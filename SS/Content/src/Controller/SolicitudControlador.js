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
    $scope.fechaSalida = new Date();
    $scope.fechaRegreso = new Date();


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
                $scope.solicitudes = angular.copy(respuestaExito.data);
               
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
            console.log($scope.solicitudDTO)
            var fechaSalida = $scope.solicitudDTO.Evento.Fecha_Hora_Salida.split('-');
            var dia = fechaSalida[2].split('T');
            var horaSalida = dia[1].split(':');
            $scope.fechaSalida = new Date(fechaSalida[0], fechaSalida[1], dia[0], horaSalida[0], horaSalida[1], horaSalida[2], '00');
            var fechaSalida = $scope.solicitudDTO.Evento.Fecha_Hora_Regreso.split('-');
            var dia = fechaSalida[2].split('T');
            var horaSalida = dia[1].split(':');
            $scope.fechaRegreso = new Date(fechaSalida[0], fechaSalida[1], dia[0], horaSalida[0], horaSalida[1], horaSalida[2], '00');

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

    $scope.isDateValid = function () {
        if ($scope.solicitudDTO.Evento && ($scope.solicitudDTO.Evento.Fecha_Hora_Salida < $scope.solicitudDTO.Evento.Fecha_Hora_Regreso)) {
            return true;
        }
        return false;
    }

    $scope.agregarSolicitud = function () {
  
        $http({
            method: 'post',
            url: servicioURL + "SS/Solicitud",
            headers: { 'Authorization': 'Bearer ' + tokenServicio.getUsuario() },
            data: $scope.solicitudDTO
        })
            .then(
                function (respuestaExito) {
                    mostrarModal(respuestaExito.data.Respuesta.Mensaje)
                    if (respuestaExito.data.Respuesta.Entidad) {
                        $location.path('/Inicio');
                    }
                },
                function (error) {
                    $rootScope.loggedUser = null;
                    $location.path('/login');
                    tokenServicio.logOut();
                }

            );
    }

    $scope.aceptar = function (usuario,id) {
        $http({
            method: 'post',
            url: servicioURL + "SS/Solicitud/Aceptar/" + id,
            headers: { 'Authorization': 'Bearer ' + tokenServicio.getUsuario() },
            data: usuario
        })
            .then(
                function (respuestaExito) {
                    mostrarModal(respuestaExito.data.Respuesta.Mensaje)
                    if (respuestaExito.data.Respuesta.Entidad) {
                        $location.path('/Inicio');
                    } 
                },
                function (error) {
                    $rootScope.loggedUser = null;
                    $location.path('/login');
                    tokenServicio.logOut();
                }
            );
    }

    $scope.rechazar = function () {
        $http({
            method: 'post',
            url: servicioURL + "SS/Solicitud/Rechazar",
            headers: { 'Authorization': 'Bearer ' + tokenServicio.getUsuario() },
            data: $scope.solicitudDTO
        })
            .then(
                function (respuestaExito) {
                    mostrarModal(respuestaExito.data.Mensaje)
                    if (respuestaExito.data.Entidad) {
                        $location.path('/Inicio');
                    } else {
                        mostrarModal(respuestaExito.data.Mensaje)
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