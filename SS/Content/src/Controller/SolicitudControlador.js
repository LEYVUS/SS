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
    $scope.paginacion = 0;
    $scope.pages = []
    $scope.cantidadPaginador = 10;
    $scope.Filtro = { usuario: '' }

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
    $scope.fileUpload = function (files) {
        var fd = new FormData();
        fd.append("file", files[0]);
        $http.post(servicioURL + "OficioComision/Upload" , fd, {
            transformRequest: angular.identity,
            headers: {'Content-Type': undefined,
            'Authorization': 'Bearer ' + tokenServicio.getUsuario()}
        }).then(
            function (respuestaExito) {
               // mostrarModal(respuestaExito.data.Respuesta.Mensaje);
            },
            function (respuestaError) {
                //$rootScope.loggedUser = null;
                //$location.path('/login');
                //tokenServicio.logOut();
            }
       );

    }
    $scope.aceptarTotalmente = function (id) {

        $http({
            method: 'get',
            url: servicioURL + "SS/Solicitud/Aceptar/Totalmente/" + id,
            headers: { 'Authorization': 'Bearer ' + tokenServicio.getUsuario() }
        })
         .then(
            function (respuestaExito) {
                mostrarModal(respuestaExito.data.Respuesta.Mensaje);
            },
            function (respuestaError) {
                $rootScope.loggedUser = null;
                $location.path('/login');
                tokenServicio.logOut();
            }
       );
    }

    $scope.rechazarTotalmente = function (id) {
        $http({
            method: 'get',
            url: servicioURL + "SS/Solicitud/Rechazar/Totalmente/" + id,
            headers: { 'Authorization': 'Bearer ' + tokenServicio.getUsuario() }
        })
       .then(
          function (respuestaExito) {
              mostrarModal(respuestaExito.data.Respuesta.Mensaje);
          },
          function (respuestaError) {
              $rootScope.loggedUser = null;
              $location.path('/login');
              tokenServicio.logOut();
          }
     );
    }

    $scope.obtenerSolicitudesCorreo = function (usuario, paginacion) {

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
        $http({
            method: 'post',
            url: servicioURL + "SS/Solicitud/Correo/" + paginacion,
            headers: { 'Authorization': 'Bearer ' + tokenServicio.getUsuario() },
            data: $scope.Filtro
        })
            .then(
                function (respuestaExito) {
                    contarNotificaciones(respuestaExito.data.largo);
                    $scope.solicitudes = angular.copy(respuestaExito.data.Respuesta.Entidad);
                }, function (respuestaError) {
                    console.error('Error al enlistar Solicitudes')
                });
    }

    function contarNotificaciones(notificacion) {
        $scope.pages = [];
        var longitud = Math.ceil(notificacion / 10);

        for (var i = 1; i <= longitud; i++) {
            $scope.pages.push({
                no: i
            })
        }
    }

    $scope.obtenerSolicitudes = function (usuario, paginacion) {
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
        $http({
            method: 'post',
            url: servicioURL + "SS/Historial/" + paginacion,
            headers: { 'Authorization': 'Bearer ' + tokenServicio.getUsuario() },
            data: $scope.Filtro
        })
        .then(
            function (respuestaExito) {
                contarNotificaciones(respuestaExito.data.largo);
                $scope.solicitudes = angular.copy(respuestaExito.data.Respuesta.Entidad);          
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

    $scope.editar = function () {
        var id = $routeParams.id;
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


        $http({
            method: 'get',
            url: servicioURL + "SS/Solicitud/ " + id,
            headers: { 'Authorization': 'Bearer ' + tokenServicio.getUsuario() }
        })
        .then(
        function (respuestaExito) {
            $scope.solicitudDTO = angular.copy(respuestaExito.data);
            var fechaSalida = $scope.solicitudDTO.Evento.Fecha_Hora_Salida.split('-');
            var dia = fechaSalida[2].split('T');
            var horaSalida = dia[1].split(':');
            $scope.fechaSalida = new Date(fechaSalida[0], fechaSalida[1], dia[0], horaSalida[0], horaSalida[1], horaSalida[2]);
            $scope.horaSalida = $scope.fechaSalida.toLocaleTimeString();
            var fechaSalida = $scope.solicitudDTO.Evento.Fecha_Hora_Regreso.split('-');
            var dia = fechaSalida[2].split('T');
            var horaSalida = dia[1].split(':');
            $scope.fechaRegreso = new Date(fechaSalida[0], fechaSalida[1], dia[0], horaSalida[0], horaSalida[1], horaSalida[2]);
            $scope.horaRegreso = $scope.fechaRegreso.toLocaleTimeString();
        },
           function (respuestaError) {
               console.error('Error al buscar la  solicitud')
           });

    }

    $scope.CrearPDF = function (id) {       
        $http({
            method: 'get',
            url: servicioURL + "OficioComision/PDF/" + id,
            headers: { 'Authorization': 'Bearer ' + tokenServicio.getUsuario() },
            responseType: 'arraybuffer'
        }).then(
         function (respuestaExito) {
             console.log(respuestaExito)
             var file = new Blob([respuestaExito.data], { type: 'application/pdf' });
             var fileURL = URL.createObjectURL(file);
             window.open(fileURL);

         },
         function (respuestaError) {

         });
    }

   $scope.editarSolicitud = function () {
        $http({
            method: 'put',
            url: servicioURL + "SS/Solicitud " ,
            headers: { 'Authorization': 'Bearer ' + tokenServicio.getUsuario() },
            data: $scope.solicitudDTO
        }).then(
         function (respuestaExito) {
             mostrarModal(respuestaExito.data.Respuesta.Mensaje)
             if (respuestaExito.data.Respuesta.Entidad) {
                 $location.path('/Inicio');
             }
         },
         function (respuestaError) {

         });
    }



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
                    $location.path('/Inicio');
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