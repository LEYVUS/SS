app.factory('usuarioServicio', function (localStorageService) {
    var usuarioActual = {};

    function setUsuario(token) {
        localStorageService.set('token', token.access_token);
    }

    function getUsuario() {
        return localStorageService.get('token');
    }
    function logOut() {
        localStorageService.remove('user');
        localStorageService.remove('token');
    }
    return {
        setUsuario: setUsuario,
        getUsuario: getUsuario,
        logOut: logOut
    };
});