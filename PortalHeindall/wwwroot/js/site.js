
$('#importar').click(function (event) {
    // Previna que o link redirecione para outra página
    event.preventDefault();

    // Realize uma requisição AJAX POST para o endpoint da sua API
    $.ajax({
        url: '/Home/Importar',
        type: 'POST',
        success: function (result) {
            // Faça algo com o resultado retornado pela API
        },
        error: function (xhr, status, error) {
            // Trate os erros que podem ocorrer durante a requisição
        }
    });
});
