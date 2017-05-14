app.factory('loginServicio', function ($http, $q, servicioURL, usuarioServicio) {
    
    function ObtenerToken(usuario) {
        var login = { 'username': usuario.Correo, 'password': usuario.Contrasenia, 'grant_type': 'password' };
        Object.toparams = function ObjectsToParams(login) {
            var p = [];
            for (var key in login) {
                p.push(key + '=' + encodeURIComponent(login[key]));
            }
            return p.join('&');
        }

        var defer = $q.defer();
        $http({
            method: 'post',
            url: servicioURL + "token",
            data: Object.toparams(login),
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
        }).then(function (response) {
            usuarioServicio.setUsuario(response.data);
            defer.resolve(response.data);
        }, function (error) {
            defer.reject(error.data);
        })
        return defer.promise;
    }

    function logOut() {
       usuarioServicio.logout()
    }

    function ObtenerUsuarioLogeado() {
        var defer = $q.defer();
        $http({
            method: 'get',
            url: servicioURL + "SS/Login",
            headers: {'Authorization': 'Bearer ' + usuarioServicio.getUsuario()}
        }).then(function (response) {
            defer.resolve(response.data);
        }, function (error) {
            defer.reject(error.data);
        })
        return defer.promise;
    }
 
    return {
        ObtenerToken: ObtenerToken,
        ObtenerUsuarioLogeado: ObtenerUsuarioLogeado,
        logOut: logOut
    };
});