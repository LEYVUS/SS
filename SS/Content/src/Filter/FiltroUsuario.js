appController.filter('nombre', function () {
    return function (usuarios, filtro) {
        var filtrado = [];
        angular.forEach(usuarios, function (usuario) {
            if (usuario.Rol.Nombre === filtro) {
                filtrado.push(usuario);
            }
            if (filtro == 'Todo') {
                filtrado.push(usuario);
            }
        });
        return filtrado;
    }
});
appController.filter('descripcion', function () {
    return function (usuarios, filtro) {
        var filtrado = [];
        angular.forEach(usuarios, function (usuario) {
            if (usuario.Rol.Descripcion === filtro) {
                filtrado.push(usuario);
            }
            if (filtro == 'Todo') {
                filtrado.push(usuario);
            }
        });
        return filtrado;
    }
});