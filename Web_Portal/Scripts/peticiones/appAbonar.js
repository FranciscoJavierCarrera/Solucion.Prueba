(function () {

    $('#Abonar').click(function () {
        var cl = {};
        cl["CuentaId"] = $('#CuentaId').val();
        cl["TipoMovimientoId"] = $('#TipoMovimientoId').val();
        cl["Monto"] = $('#Monto').val();

        peticionServ("/Cuenta/Abonar", cl);
    });

});

function peticionServ(url, datos) {
    $.ajax({
        type: "POST",
        url: url,
        data: JSON.stringify(datos),
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (response.href != null) {
                window.location.href = response.href;
            }
            if (response.message != null) {
                toastr.warning(response.message);
            }
        }, error: function (xhr, textStatus, errorThrown) {
            console.log("Validar con el administrador " + textStatus);
        }
    }).done(function (data, textStatus, jqXHR) {
        console.log("La solicitud se ha completado correctamente" + textStatus);
    }).fail(function (jqXHR, textStatus, errorThrown) {
        console.log("La solicitud a fallado: " + textStatus);
    });
}

