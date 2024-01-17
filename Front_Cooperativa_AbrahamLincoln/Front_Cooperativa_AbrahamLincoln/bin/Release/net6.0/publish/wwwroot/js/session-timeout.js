document.addEventListener("DOMContentLoaded", function () {
    // Establecer el tiempo de expiración de la sesión
    // Por ejemplo, a los 30 minutos
    var expirationTime = 30 * 60 * 1000;
    //var expirationTime = 10 * 1000;
    
    // Función para revisar si la sesión expiró
    function checkSessionExpired() {

        var currentTime = new Date().getTime();
        console.log(currentTime);
        var sessionExpired = currentTime - sessionStartTime > expirationTime;
        console.log(sessionExpired);
        if (sessionExpired) {
            // Mostrar alerta
            Swal.fire({
                title: 'Sesión expirada',
                text: 'Su sesión ha expirado por inactividad, por favor ingrese nuevamente',
                icon: 'warning'
            }).then(() => {
                // Redirigir a la página de login
                window.location.href = '/Login/login';
            });
        } else {
            // Programar la próxima verificación en X segundos
            setTimeout(checkSessionExpired, 600000); // 10 minutos
        }
    }
    // Guardar hora de inicio de sesión
    var sessionStartTime = new Date().getTime();
    console.log(sessionStartTime);
    // Ejecutar la primera verificación
    checkSessionExpired();


});