var app = angular.module("app", ['ngRoute', 'app.controllers', 'LocalStorageModule']);
app.config(['$routeProvider', 'localStorageServiceProvider', function ($routeProvider, localStorageServiceProvider) {
    $routeProvider
        .when('/', {
            templateUrl: '../Content/views/login.html',
            controller: 'loginCtrl'
        })
        .when('/login', {
            templateUrl: '../Content/views/login.html',
            controller: 'loginCtrl'
        })
        .when('/SS/Solicitud/Administrativo', {
            templateUrl: '../Content/views/historial-administrativo.html',
            controller: 'solicitudCtrl'
        })
       .when('/SS/Solicitud/Visualizar/:id', {
            templateUrl: '../Content/views/Visualizar.html',
            controller: 'solicitudCtrl'
         })
        .when('/SS/Solicitud/Docente', {
            templateUrl: '../Content/views/historial-docente.html',
            controller: 'solicitudCtrl'
        })
        .when('/SS/Inicio', {
            templateUrl: '../Content/views/inicio.html',
            controller: 'notificacionCtrl'
        })
         .when('/SS/Solicitud', {
             templateUrl: '../Content/views/solicitud.html',
         })
         .when('/SS/Solicitud/:id', {
             templateUrl: '../Content/views/revision-solicitud.html',             
         })
    
        .when('/SS/Notificacion', {
              templateUrl: '../Content/views/notificaciones.html',
              controller: "notificacionCtrl"
        })
        .when('/SS/Notificacion/Docente', {
               templateUrl: '../Content/views/notificacionesDocente.html',
               controller: "notificacionCtrl"
        })
        .when('/SS/Usuario', {
            templateUrl: '../Content/views/listar.html',
            controller: "usuarioCtrl"
        })
        .when('/SS/Solicitud/Editar/:id', {
            templateUrl: '../Content/views/editarNotificacion.html',
            controller: "usuarioCtrl"
         })
        .otherwise({
            redirectTo: '/login'
        })
    localStorageServiceProvider
  .setPrefix('SS');

}]);

app.run(['$rootScope', '$location', 'localStorageService', function ($rootScope, $location, localStorageService) {
    $rootScope.$on("$routeChangeStart", function (event, next, current) {
         $rootScope.loggedUser = localStorageService.get('user');
     
        if ($rootScope.loggedUser == null ) {
            // no logged user, we should be going to #login
            if (next.templateUrl == "../Content/views/login.html") {
                // already going to #login, no redirect needed
            } else {
                // not going to #login, we should redirect now
                $location.path("/login");
            }

        } 
       
        if ($rootScope.loggedUser != null) {
            if (next.templateUrl == "../Content/views/listar.html") {
                if ($rootScope.loggedUser.Rol != null && $rootScope.loggedUser.Rol.Nombre === 'Administrador') {
                        $location.path("/SS/Usuario");
                } else {
                        $location.path("/SS/Inicio");
                  }
            } 
            if (next.templateUrl == "../Content/views/login.html") {
                $location.path("/SS/Inicio");
            }

            if (next.templateUrl == "../Content/views/historial-administrativo.html") {
                $location.path("/SS/Solicitud/Administrativo");
            } 
        }
    });
}])

