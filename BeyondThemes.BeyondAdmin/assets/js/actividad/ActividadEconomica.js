function SelectDivision(select) {
    var IdSeccion = $(select).find('option:selected').val();
    var id = $(select).data("id");
    $.ajax({
        type: 'POST',
        url: '/Widget/ParcialDivisiones?IdSeccion=' + IdSeccion + '&establecimiento=' + id,
        DataType: 'json',
        success: function (data) {
            $("#divisiones-" + id).html(data);
            SelectGrupo("#divisiones-" + id + " > select:first");
        }
    });
}
function SelectGrupo(select) {
    var IdDivision = $(select).find('option:selected').val();
    var id = $(select).data("id");
    $.ajax({
        type: 'POST',
        url: '/Widget/ParcialGrupos?IdDivision=' + IdDivision + '&establecimiento=' + id,
        DataType: 'json',
        success: function (data) {
            $("#grupos-" + id).html(data);
            SelectClase("#grupos-" + id + " > select:first");
        }
    });
}
function SelectClase(select) {
    var IdGrupo = $(select).find('option:selected').val();
    var id = $(select).data("id");
    $.ajax({
        type: 'POST',
        url: '/Widget/ParcialClases?IdGrupo=' + IdGrupo + '&establecimiento=' + id,
        DataType: 'json',
        success: function (data) {
            $("#clases-" + id).html(data);         
        }
    });
}
