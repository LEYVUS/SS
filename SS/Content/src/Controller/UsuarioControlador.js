appController.controller("usuarioCtrl", function ($scope, $location, $rootScope, $http, ModalService, servicioURL, tokenServicio) {

    $scope.usuarios = []
    $scope.usuario = {};
    $scope.rol = [];
    $scope.carrera = [];
    
    $scope.usuarioDTO = []

    $scope.FiltroR = 'Todo'
    $scope.FiltroD = 'Todo'
  
    ///
    $scope.ordenamiento = function (NombreColumna) {
        console.log(NombreColumna)
        $scope.myOrden = NombreColumna;
    }


    ///
    $scope.listarUsuarios = function () {
        $http({
            method: 'get',
            url: servicioURL + "SS/Usuario",
            headers: { 'Authorization': 'Bearer ' + tokenServicio.getUsuario() }
        }).then(
                function (respuestaExito) {
                    $scope.usuarios = angular.copy(respuestaExito.data);
                },
                function (respuestaError) {
                    $rootScope.loggedUser = null;
                    $location.path('/login');
                    tokenServicio.logOut();
                }
             );
    }


    ///


    ///

    $scope.mostrarOpciones = function (usuarioDTO) {
        if ($rootScope.loggedUser!= null && $rootScope.loggedUser.Correo === usuarioDTO.Correo) {
            return false;
        }
        return true;
    }

    ///


    $scope.buscarUsuario = function (Id, Rol) {
      
        if ($rootScope.modal) {
            $rootScope.modal = false;
            if (Rol === 'Coordinador') {
                $http({
                    method: 'get',
                    url: servicioURL + "SS/Carrera/"+ Id,
                    headers: { 'Authorization': 'Bearer ' + tokenServicio.getUsuario() }
                }).then (
                        function (respuestaExito) {
                            $scope.carrera = angular.copy(respuestaExito.data);

                            ModalService.showModal({
                                templateUrl: '../../Content/views/editar.html',
                                controller: "EditarController",
                                inputs: {
                                    carrera: $scope.carrera,
                                    usuario: $scope.carrera.usuario
                                }
                            }).then(function (modal) {
                                modal.element.modal();
                                modal.close.then(function (usuarioDTO) {
                                    $scope.modal = true;
                                    $http({
                                        method: 'put',
                                        url: servicioURL + "SS/Usuario",
                                        data:usuarioDTO,
                                        headers: { 'Authorization': 'Bearer ' + tokenServicio.getUsuario() }
                                    }).then(function () {
                                        location.reload();
                                    }, function (error) {
                                        mostrarModal(error.data.ExceptionMessage)
                                    });
                                });
                            });
                        });
            } else {
                $http({
                    method: 'get',
                    url: servicioURL + "SS/Usuario/"+ Id,
                    headers: { 'Authorization': 'Bearer ' + tokenServicio.getUsuario() }
                })
                .then (
                      function (respuestaExito) {
                          $scope.usuario = angular.copy(respuestaExito.data);
                          ModalService.showModal({
                              templateUrl: '../../Content/views/editar.html',
                              controller: "EditarController",
                              inputs: {
                                  carrera: null,
                                  usuario: $scope.usuario
                              }
                          }).then(function (modal) {
                              modal.element.modal();
                              modal.close.then(function (usuarioDTO) {
                                  $scope.modal = true;
                                  $http({
                                      method: 'put',
                                      url: servicioURL + "SS/Usuario",
                                      data: usuarioDTO,
                                      headers: { 'Authorization': 'Bearer ' + tokenServicio.getUsuario() }
                                  }).then(function () {
                                      location.reload();
                                  }, function (error) {             
                                      mostrarModal(error.data.ExceptionMessage)
                                  });
                              });
                          });
                      });
            }
        }
       
    }





  
    ///


    ///
    function mostrarModal(mensaje) {
        ModalService.showModal({
            templateUrl: '../../Content/views/mensaje.html',
            controller: "ModalController",
            inputs: {
                mensaje: mensaje
            }
        }).then(function (modal) {
            modal.element.modal();
            modal.close.then(function (result) {
                location.reload();
            });
        });
    }

    ///


    ///



        
});

appController.controller('ModalController', function ($scope, close, mensaje) {
    $scope.message = mensaje;
    $scope.close = function (result) {
        close(result, 300); // close, but give 500ms for bootstrap to animate
    };

});
appController.controller('EditarController', function ($scope, $rootScope, close, carrera, usuario) {
    $scope.usuario = usuario;
    $scope.carrera = carrera;
    $scope.close = function (result) {
        close(result, 500); // close, but give 500ms for bootstrap to animate
    };

    $scope.mostrarCarreras = function (rol) {

        if (rol != null && rol.Descripcion === 'Coordinador') {
            return true;
        }
        return false;
    };

    $scope.finalizar = function () {
        $rootScope.modal = true;
    };
 

    $scope.regex = {
        'correo': '^.*uabc.edu.mx.*$',
        'number': '/[a-z]/'
    };


});
appController.controller('BorrarController', function ($scope, close) {

    $scope.close = function (result) {
        close(result, 300); // close, but give 500ms for bootstrap to animate
    };



});
