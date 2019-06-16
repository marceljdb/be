function rotacionarCabeca() {
   // alert("teste");
    //$("#loader").show();
    $.ajax(
        {
            type: 'POST',
            url: 'RotacionarCabeca',
            dataType: 'html',
            data: { rotacionarCabeca: 2 },
            cache: false,
            async: true,
            success: function (data) {
                alert("Alterado com sucesso!");
            }
        });
}