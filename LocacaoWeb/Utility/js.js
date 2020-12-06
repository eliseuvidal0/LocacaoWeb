let dropdown = $('#marca');

dropdown.empty();

dropdown.append('<option selected="true" disabled>- Selecione -');
dropdown.prop('selectedIndex', 0);

const url = 'https://parallelum.com.br/fipe/api/v1/carros/marcas';

$.getJSON(url, function (data) {
    $.each(data, function (key, entry) {
        dropdown.append($('<option></option>').attr('value', entry.nome).text(entry.nome));
    })
});
