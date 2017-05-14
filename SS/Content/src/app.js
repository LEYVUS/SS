var app = angular.module("app", ['ngRoute', 'app.controllers', 'LocalStorageModule']);
app.config(function ($routeProvider, localStorageServiceProvider) {
    $routeProvider
        .when('/', {
            templateUrl: '../Content/views/login.html',
            controller: 'loginCtrl'
        })
        .when('/login', {
            templateUrl: '../Content/views/login.html',
            controller: 'loginCtrl'
        })
        .when('/SS/usuario/listar', {
            templateUrl: '../Content/views/listar.html',
            controller: 'usuarioCtrl'

        })
        .when('/SS/Inicio', {
            templateUrl: '../Content/views/inicio.html',
        })
         .when('/SS/Solicitud', {
             templateUrl: '../Content/views/agregar.html',
         })
        .otherwise({
            redirectTo: '/login'
        })
    localStorageServiceProvider
  .setPrefix('SS');

});

app.run(function ($rootScope, $location, localStorageService) {
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
                
                        $location.path("/SS/usuario/listar");
                } else {
                        $location.path("/SS/Inicio");
                  }
            } 
            if (next.templateUrl == "../Content/views/login.html") {
                $location.path("/SS/Inicio");
            }
        }
    });
})

