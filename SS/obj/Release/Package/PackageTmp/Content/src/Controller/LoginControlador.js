appController.controller("loginCtrl", ['$scope', '$location', '$rootScope', 'ModalService', 'localStorageService', 'loginServicio', function ($scope, $location, $rootScope, ModalService, localStorageService, loginServicio) {
    $scope.mensajeDTO = {}
    $scope.usuarioDTO = {}

    $scope.IniciarSesion = function () {

        if (localStorageService.get('user') == null && $rootScope.modal) {
            loginServicio.ObtenerToken($scope.usuarioDTO).then(function (data) {
                loginServicio.ObtenerUsuarioLogeado().then(function (usuario) {
                        localStorageService.set('user', angular.copy(usuario));
                        $location.path('/SS/Inicio');
                  }, function (error) {
                      loginServicio.logOut();
                      $rootScope.loggedUser = null;
                      $location.path('/login');

                    })
            }, function (error) {
                mostrarModal(error.error_description)
            })
        }
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

}]);
///


///
appController.controller('MensajeControlador', ['$scope', 'close', 'mensaje', '$rootScope', function ($scope, close, mensaje, $rootScope) {
    $scope.message = mensaje;
    $scope.close = function (resultado) {
        close(resultado, 400); 
    };

    $scope.activarModal = function (){
        $rootScope.modal = true;
    }

}]);