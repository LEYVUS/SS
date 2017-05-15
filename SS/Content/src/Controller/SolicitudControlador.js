/// <reference path="SolicitudControlador.js" />
appController.controller("solicitudCtrl", function ($scope, $location, $rootScope, $http, ModalService, servicioURL, tokenServicio) {

    $scope.solicitudDTO = {
        recurso_Solicitado: {
        }
    };
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
                    console.error('Error while fetching Users');
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
                   console.error('Error while fetching Users');
              }
        );
    };

    $scope.isCheckboxChecked = function () {
        return (($scope.solicitudDTO.recurso_Solicitado.Hospedaje || $scope.solicitudDTO.recurso_Solicitado.Viatico
     || $scope.solicitudDTO.recurso_Solicitado.Oficio_Comision || $scope.solicitudDTO.recurso_Solicitado.Otro
     || $scope.solicitudDTO.recurso_Solicitado.Combustible) && ($scope.solicitudDTO.Actividad.CACEI || $scope.solicitudDTO.Actividad.Licenciatura
             || $scope.solicitudDTO.Actividad.Personal || $scope.solicitudDTO.Actividad.ISO
             || $scope.solicitudDTO.Actividad.Posgrado || $scope.solicitudDTO.Actividad.Otro));
    };


    $scope.agregarSolicitud = function () {
        console.log($scope.solicitudDTO);
        $http.post(utileria.ObtenerURL() + 'Solicitud', $scope.solicitudDTO)
            .then(
                function (respuestaExito) {
                    console.log(respuestaExito);
                    $scope.mensajeDTO = angular.copy(respuestaExito.data.Respuesta);
                    
                    //if ($scope.mensajeDTO.Entidad != false) {
                    //    //mostrarModal($scope.mensajeDTO.Mensaje, '/SS/solicitud/listar');
                    //} else {
                    //   // mostrarModal($scope.mensajeDTO.Mensaje, '/SS/solicitud/agregar');
                    //}
                }
            );
    }
});