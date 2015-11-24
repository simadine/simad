var InitiateListaDeEmpresas = function () {
    return {
        init: function () {
            //Datatable Initiating
            var oTable = $('#ListaDeEmpresas').dataTable({
                "bServerSide": true,
                "sAjaxSource": "/Directorio/ListaDeEmpresas",
                "bProcessing": true,
                "sDom": "Tflt<'row DTTTFooter'<'col-sm-6'i><'col-sm-6'p>>",
                "iDisplayLength": 5,
                "oTableTools": {
                    "aButtons": [],
                    "sSwfPath": "assets/swf/copy_csv_xls_pdf.swf"
                },
                "language": {
                    "search": "",
                    "sLengthMenu": "_MENU_",
                    "oPaginate": {
                        "sPrevious": "Anterior",
                        "sNext": "Siguiente"
                    }
                },
                "aoColumns": [
                        {"sName": "RUT",},
                        { "sName": "RAZON_SOCIAL" },
                        { "sName": "COMUNA" },
                        { "sName": "REPRESENTANTE_LEGAL" },
                        {
                            bSortable: false,
                            mRender: function (data, type, row) {

                                return '<a href="/Directorio/ActualizarEmpresa?IdEmpresa=' + row[0] + '" class="btn btn-info btn-xs"><i class="fa fa-edit"></i> Actualizar (' + row[4] + ')</a>';
                            }
                        }
                ],
                "aaSorting": []
            });

            //Check All Functionality
            $('#ListaDeEmpresas thead th input[type=checkbox]').change(function () {
                var set = $("#ListaDeEmpresas tbody tr input[type=checkbox]");
                var checked = $(this).is(":checked");
                $(set).each(function () {
                    if (checked) {
                        $(this).prop("checked", true);
                        $(this).parents('tr').addClass("active");
                    } else {
                        $(this).prop("checked", false);
                        $(this).parents('tr').removeClass("active");
                    }
                });

            });
            $('#ListaDeEmpresas tbody tr input[type=checkbox]').change(function () {
                $(this).parents('tr').toggleClass("active");
            });

        }

    };

}();

var InitiateListaDeEstablecimientos = function () {
    return {
        init: function () {
            //Datatable Initiating
            var oTable = $('#ListaDeEstablecimientos').dataTable({
                "bServerSide": true,
                "sAjaxSource": "/Directorio/ListaDeEstablecimientos",
                "bProcessing": true,
                "sDom": "Tflt<'row DTTTFooter'<'col-sm-6'i><'col-sm-6'p>>",
                "iDisplayLength": 5,
                "oTableTools": {
                    "aButtons": [],
                    "sSwfPath": "assets/swf/copy_csv_xls_pdf.swf"
                },
                "language": {
                    "search": "",
                    "sLengthMenu": "_MENU_",
                    "oPaginate": {
                        "sPrevious": "Anterior",
                        "sNext": "Siguiente"
                    }
                },
                "aoColumns": [
                        { "sName": "ROL", },
                        { "sName": "RUT" },
                        { "sName": "RAZON SOCIAL" },
                        { "sName": "ESTABLECIMIENTO" },
                        { "sName": "COMUNA"},
                        {
                            bSortable: false,
                            mRender: function (data, type, row) {

                                return '<a href="/Directorio/ActualizarEmpresa?IdEmpresa=' + row[1] + '#est-'+row[0]+'" class="btn btn-info btn-xs"><i class="fa fa-edit"></i> Actualizar</a> ';
                            }
                        }
                ],
                "aaSorting": []
            });

            //Check All Functionality
            $('#ListaDeEstablecimientos thead th input[type=checkbox]').change(function () {
                var set = $("#ListaDeEstablecimientos tbody tr input[type=checkbox]");
                var checked = $(this).is(":checked");
                $(set).each(function () {
                    if (checked) {
                        $(this).prop("checked", true);
                        $(this).parents('tr').addClass("active");
                    } else {
                        $(this).prop("checked", false);
                        $(this).parents('tr').removeClass("active");
                    }
                });

            });
            $('#ListaDeEstablecimientos tbody tr input[type=checkbox]').change(function () {
                $(this).parents('tr').toggleClass("active");
            });

        }

    };

}();

var InitiateListaDeEncuestas = function () {
    return {
        init: function () {
            //Datatable Initiating
            var oTable = $('#ListaDeEncuestas').dataTable({
                "bServerSide": true,
                "sAjaxSource": "/Encuestas/ListaDeEncuestas",
                "bProcessing": true,
                "sDom": "Tflt<'row DTTTFooter'<'col-sm-6'i><'col-sm-6'p>>",
                "iDisplayLength": 5,
                "oTableTools": {
                    "aButtons": [],
                    "sSwfPath": "assets/swf/copy_csv_xls_pdf.swf"
                },
                "language": {
                    "search": "",
                    "sLengthMenu": "_MENU_",
                    "oPaginate": {
                        "sPrevious": "Anterior",
                        "sNext": "Siguiente"
                    }
                },
                "aoColumns": [
                        { "sName": "RUT", },
                        { "sName": "RAZON_SOCIAL" },
                        { "sName": "COMUNA" },
                        { "sName": "REPRESENTANTE_LEGAL" },
                        { "sName": "TIPO" },
                        {
                            bSortable: false,
                            mRender: function (data, type, row) {

                                return '<a href="/Encuestas/ActualizarEncuesta?IdEncuesta=' + row[0] + '" class="btn btn-info btn-xs"><i class="fa fa-edit"></i> Detalles</a>';
                            }
                        }
                ],
                "aaSorting": []
            });

            //Check All Functionality
            $('#ListaDeEncuestas thead th input[type=checkbox]').change(function () {
                var set = $("#ListaDeEncuestas tbody tr input[type=checkbox]");
                var checked = $(this).is(":checked");
                $(set).each(function () {
                    if (checked) {
                        $(this).prop("checked", true);
                        $(this).parents('tr').addClass("active");
                    } else {
                        $(this).prop("checked", false);
                        $(this).parents('tr').removeClass("active");
                    }
                });

            });
            $('#ListaDeEncuestas tbody tr input[type=checkbox]').change(function () {
                $(this).parents('tr').toggleClass("active");
            });

        }

    };

}();

var InitiateMuestra = function () {
    return {
        init: function () {
            var IdEncuesta = $('#Muestra').data("idencuesta");
            var oTable = $('#Muestra').dataTable({
                "bServerSide": true,
                "sAjaxSource": "/Encuestas/Muestra?IdEncuesta=" + IdEncuesta,
                "bProcessing": true,
                "sDom": "Tflt<'row DTTTFooter'<'col-sm-6'i><'col-sm-6'p>>",
                "iDisplayLength": 5,
                "oTableTools": {
                    "aButtons": [],
                    "sSwfPath": "assets/swf/copy_csv_xls_pdf.swf"
                },
                "language": {
                    "search": "",
                    "sLengthMenu": "_MENU_",
                    "oPaginate": {
                        "sPrevious": "Anterior",
                        "sNext": "Siguiente"
                    }
                },
                "aoColumns": [
                        { "sName": "RUT", },
                        { "sName": "RAZON_SOCIAL" },
                        { "sName": "COMUNA" },
                        { "sName": "REPRESENTANTE_LEGAL" },
                        {
                            bSortable: false,
                            mRender: function (data, type, row) {

                                return '<a href="/Encuestas/ActualizarEncuesta?IdEncuesta=' + row[0] + '" class="btn btn-info btn-xs"><i class="fa fa-edit"></i> Detalles</a>';
                            }
                        }
                ],
                "aaSorting": []
            });

            //Check All Functionality
            $('#Muestra thead th input[type=checkbox]').change(function () {
                var set = $("#Muestra tbody tr input[type=checkbox]");
                var checked = $(this).is(":checked");
                $(set).each(function () {
                    if (checked) {
                        $(this).prop("checked", true);
                        $(this).parents('tr').addClass("active");
                        var table = $('#MuestraAnterior').DataTable();
                        var rows = table.rows('.active').data();
                        for (indice in rows) {
                            muestra.push(rows[indice][1]);
                            console.log(rows[indice][1]);
                        }
                    } else {
                        $(this).prop("checked", false);
                        $(this).parents('tr').removeClass("active");
                        var table = $('#MuestraAnterior').DataTable();
                        var rows = table.rows('.active').data();
                        for (indice in rows) {
                            muestra.push(rows[indice][1]);
                            console.log(rows[indice][1]);
                        }
                    }
                });

            });
            $('#Muestra tbody tr input[type=checkbox]').change(function () {
                $(this).parents('tr').toggleClass("active");
                
            });

        }

    };

}();

var InitiateMuestraAnterior = function () {
    return {
        init: function () {
            //Datatable Initiating                     "sRowSelect": "multiple",
            var oTable = $('#MuestraAnterior').dataTable({
                "sDom": "Tflt<'row DTTTFooter'<'col-sm-6'i><'col-sm-6'p>>",
                "iDisplayLength": 5,
                "oTableTools": {
                    "sRowSelect": "multi",
                    "aButtons": ["select_all", "select_none"],
                    "sSwfPath": "assets/swf/copy_csv_xls_pdf.swf"
                },
                "language": {
                    "search": "",
                    "sLengthMenu": "_MENU_",
                    "oPaginate": {
                        "sPrevious": "Prev",
                        "sNext": "Next"
                    }
                },
                "aoColumns": [
                  null,
                  { "bSortable": false }
                ],
                "aaSorting": []
            });

            //Check All Functionality
            $('#MuestraAnterior thead th input[type=checkbox]').change(function () {
                var set = $("#MuestraAnterior tbody tr input[type=checkbox]");
                var checked = $(this).is(":checked");
                $(set).each(function () {
                    if (checked) {
                        $(this).prop("checked", true);
                        $(this).parents('tr').addClass("active");
                        console.log("agregar clase");
                    } else {
                        $(this).prop("checked", false);
                        $(this).parents('tr').removeClass("active");
                        console.log("quitar clases");
                    }
                });

            });
            $('#MuestraAnterior tbody tr input[type=checkbox]').change(function () {
             
                var chk = $(this).is(":checked");
                var id = $(this).parents('tr').data("id");
              
          
                $("#"+id).removeClass("active");
             
            });
        }
    };
}();

var InitiateSimpleDataTable = function () {
    return {
        init: function () {
            //Datatable Initiating
            var oTable = $('#simpledatatable').dataTable({
                "sDom": "Tflt<'row DTTTFooter'<'col-sm-6'i><'col-sm-6'p>>",
                "iDisplayLength": 5,
                "oTableTools": {
                    "aButtons": [
                        "copy", "csv", "xls", "pdf", "print"
                    ],
                    "sSwfPath": "assets/swf/copy_csv_xls_pdf.swf"
                },
                "language": {
                    "search": "",
                    "sLengthMenu": "_MENU_",
                    "oPaginate": {
                        "sPrevious": "Prev",
                        "sNext": "Next"
                    }
                },
                "aoColumns": [
                    {
                        "bSortable": false ,
                        "width":'45px'
                    },
                  null,
                  { "bSortable": false },
                  null,
                  { "bSortable": false }
                ],
                "aaSorting": []
            });

            //Check All Functionality
            $('#simpledatatable thead th input[type=checkbox]').change(function () {
                var set = $("#simpledatatable tbody tr input[type=checkbox]");
                var checked = $(this).is(":checked");
                $(set).each(function () {
                    if (checked) {
                        $(this).prop("checked", true);
                        $(this).parents('tr').addClass("active");
                    } else {
                        $(this).prop("checked", false);
                        $(this).parents('tr').removeClass("active");
                    }
                });

            });
            $('#simpledatatable tbody tr input[type=checkbox]').change(function () {
                $(this).parents('tr').toggleClass("active");
            });

        }

    };

}();


var InitiateEditableDataTable = function () {
    return {
        init: function () {
            //Datatable Initiating
            var oTable = $('#editabledatatable').dataTable({
                "aLengthMenu": [
                    [5, 15, 20, 100, -1],
                    [5, 15, 20, 100, "All"]
                ],
                "iDisplayLength": 5,
                "sPaginationType": "bootstrap",
                "sDom": "Tflt<'row DTTTFooter'<'col-sm-6'i><'col-sm-6'p>>",
                "oTableTools": {
                    "aButtons": [
				        "copy",
				        "print",
				        {
				            "sExtends": "collection",
				            "sButtonText": "Save <i class=\"fa fa-angle-down\"></i>",
				            "aButtons": ["csv", "xls", "pdf"]
				        }],
                    "sSwfPath": "assets/swf/copy_csv_xls_pdf.swf"
                },
                "language": {
                    "search": "",
                    "sLengthMenu": "_MENU_",
                    "oPaginate": {
                        "sPrevious": "Prev",
                        "sNext": "Next"
                    }
                },
                "aoColumns": [
                  null,
                  null,
                  null,
                  null,
                  { "bSortable": false }
                ]
            });

            var isEditing = null;

            //Add New Row
            $('#editabledatatable_new').click(function (e) {
                e.preventDefault();
                var aiNew = oTable.fnAddData(['', '', '', '',
                        '<a href="#" class="btn btn-success btn-xs save"><i class="fa fa-edit"></i> Save</a> <a href="#" class="btn btn-warning btn-xs cancel" data-mode="new"><i class="fa fa-times"></i> Cancel</a>'
                ]);
                var nRow = oTable.fnGetNodes(aiNew[0]);
                editAddedRow(oTable, nRow);
                isEditing = nRow;
            });

            //Delete an Existing Row
            $('#editabledatatable').on("click", 'a.delete', function (e) {
                e.preventDefault();

                if (confirm("Are You Sure To Delete This Row?") == false) {
                    return;
                }

                var nRow = $(this).parents('tr')[0];
                oTable.fnDeleteRow(nRow);
                alert("Row Has Been Deleted!");
            });

            //Cancel Editing or Adding a Row
            $('#editabledatatable').on("click", 'a.cancel', function (e) {
                e.preventDefault();
                if ($(this).attr("data-mode") == "new") {
                    var nRow = $(this).parents('tr')[0];
                    oTable.fnDeleteRow(nRow);
                    isEditing = null;
                } else {
                    restoreRow(oTable, isEditing);
                    isEditing = null;
                }
            });

            //Edit A Row
            $('#editabledatatable').on("click", 'a.edit', function (e) {
                e.preventDefault();

                var nRow = $(this).parents('tr')[0];

                if (isEditing !== null && isEditing != nRow) {
                    restoreRow(oTable, isEditing);
                    editRow(oTable, nRow);
                    isEditing = nRow;
                } else {
                    editRow(oTable, nRow);
                    isEditing = nRow;
                }
            });

            //Save an Editing Row
            $('#editabledatatable').on("click", 'a.save', function (e) {
                e.preventDefault();
                if (this.innerHTML.indexOf("Save") >= 0) {
                    saveRow(oTable, isEditing);
                    isEditing = null;
                    //Some Code to Highlight Updated Row
                }
            });


            function restoreRow(oTable, nRow) {
                var aData = oTable.fnGetData(nRow);
                var jqTds = $('>td', nRow);

                for (var i = 0, iLen = jqTds.length; i < iLen; i++) {
                    oTable.fnUpdate(aData[i], nRow, i, false);
                }

                oTable.fnDraw();
            }

            function editRow(oTable, nRow) {
                var aData = oTable.fnGetData(nRow);
                var jqTds = $('>td', nRow);
                jqTds[0].innerHTML = '<input type="text" class="form-control input-small" value="' + aData[0] + '">';
                jqTds[1].innerHTML = '<input type="text" class="form-control input-small" value="' + aData[1] + '">';
                jqTds[2].innerHTML = '<input type="text" class="form-control input-small" value="' + aData[2] + '">';
                jqTds[3].innerHTML = '<input type="text" class="form-control input-small" value="' + aData[3] + '">';
                jqTds[4].innerHTML = '<a href="#" class="btn btn-success btn-xs save"><i class="fa fa-save"></i> Save</a> <a href="#" class="btn btn-warning btn-xs cancel"><i class="fa fa-times"></i> Cancel</a>';
            }

            function editAddedRow(oTable, nRow) {
                var aData = oTable.fnGetData(nRow);
                var jqTds = $('>td', nRow);
                jqTds[0].innerHTML = '<input type="text" class="form-control input-small" value="' + aData[0] + '">';
                jqTds[1].innerHTML = '<input type="text" class="form-control input-small" value="' + aData[1] + '">';
                jqTds[2].innerHTML = '<input type="text" class="form-control input-small" value="' + aData[2] + '">';
                jqTds[3].innerHTML = '<input type="text" class="form-control input-small" value="' + aData[3] + '">';
                jqTds[4].innerHTML = aData[4];
            }

            function saveRow(oTable, nRow) {
                var jqInputs = $('input', nRow);
                oTable.fnUpdate(jqInputs[0].value, nRow, 0, false);
                oTable.fnUpdate(jqInputs[1].value, nRow, 1, false);
                oTable.fnUpdate(jqInputs[2].value, nRow, 2, false);
                oTable.fnUpdate(jqInputs[3].value, nRow, 3, false);
                oTable.fnUpdate('<a href="#" class="btn btn-info btn-xs edit"><i class="fa fa-edit"></i> Edit</a> <a href="#" class="btn btn-danger btn-xs delete"><i class="fa fa-trash-o"></i> Delete</a>', nRow, 4, false);
                oTable.fnDraw();
            }

            function cancelEditRow(oTable, nRow) {
                var jqInputs = $('input', nRow);
                oTable.fnUpdate(jqInputs[0].value, nRow, 0, false);
                oTable.fnUpdate(jqInputs[1].value, nRow, 1, false);
                oTable.fnUpdate(jqInputs[2].value, nRow, 2, false);
                oTable.fnUpdate(jqInputs[3].value, nRow, 3, false);
                oTable.fnUpdate('<a href="#" class="btn btn-info btn-xs edit"><i class="fa fa-edit"></i> Edit</a> <a href="#" class="btn btn-danger btn-xs delete"><i class="fa fa-trash-o"></i> Delete</a>', nRow, 4, false);
                oTable.fnDraw();
            }
        }

    };
}();
var InitiateExpandableDataTable = function () {
    return {
        init: function () {
            /* Formatting function for row details */
            function fnFormatDetails(oTable, nTr) {
                var aData = oTable.fnGetData(nTr);
                var sOut = '<table>';
                sOut += '<tr><td rowspan="5" style="padding:0 10px 0 0;"><img src="assets/img/avatars/' + aData[6] + '"/></td><td>Name:</td><td>' + aData[1] + '</td></tr>';
                sOut += '<tr><td>Family:</td><td>' + aData[2] + '</td></tr>';
                sOut += '<tr><td>Age:</td><td>' + aData[3] + '</td></tr>';
                sOut += '<tr><td>Positon:</td><td>' + aData[4] + '</td></tr>';
                sOut += '<tr><td>Others:</td><td><a href="">Personal WebSite</a></td></tr>';
                sOut += '</table>';
                return sOut;
            }

            /*
             * Insert a 'details' column to the table
             */
            var nCloneTh = document.createElement('th');
            var nCloneTd = document.createElement('td');
            nCloneTd.innerHTML = '<i class="fa fa-plus-square-o row-details"></i>';

            $('#expandabledatatable thead tr').each(function () {
                this.insertBefore(nCloneTh, this.childNodes[0]);
            });

            $('#expandabledatatable tbody tr').each(function () {
                this.insertBefore(nCloneTd.cloneNode(true), this.childNodes[0]);
            });

            /*
             * Initialize DataTables, with no sorting on the 'details' column
             */
            var oTable = $('#expandabledatatable').dataTable({
                "sDom": "Tflt<'row DTTTFooter'<'col-sm-6'i><'col-sm-6'p>>",
                "aoColumnDefs": [
                    { "bSortable": false, "aTargets": [0] },
                    { "bVisible": false, "aTargets": [6] }
                ],
                "aaSorting": [[1, 'asc']],
                "aLengthMenu": [
                   [5, 15, 20, -1],
                   [5, 15, 20, "All"]
                ],
                "iDisplayLength": 5,
                "oTableTools": {
                    "aButtons": [
				        "copy",
				        "print",
				        {
				            "sExtends": "collection",
				            "sButtonText": "Save <i class=\"fa fa-angle-down\"></i>",
				            "aButtons": ["csv", "xls", "pdf"]
				        }],
                    "sSwfPath": "assets/swf/copy_csv_xls_pdf.swf"
                },
                "language": {
                    "search": "",
                    "sLengthMenu": "_MENU_",
                    "oPaginate": {
                        "sPrevious": "Prev",
                        "sNext": "Next"
                    }
                }
            });


            $('#expandabledatatable').on('click', ' tbody td .row-details', function () {
                var nTr = $(this).parents('tr')[0];
                if (oTable.fnIsOpen(nTr)) {
                    /* This row is already open - close it */
                    $(this).addClass("fa-plus-square-o").removeClass("fa-minus-square-o");
                    oTable.fnClose(nTr);
                }
                else {
                    /* Open this row */
                    $(this).addClass("fa-minus-square-o").removeClass("fa-plus-square-o");;
                    oTable.fnOpen(nTr, fnFormatDetails(oTable, nTr), 'details');
                }
            });

            $('#expandabledatatable_column_toggler input[type="checkbox"]').change(function () {
                var iCol = parseInt($(this).attr("data-column"));
                var bVis = oTable.fnSettings().aoColumns[iCol].bVisible;
                oTable.fnSetColumnVis(iCol, (bVis ? false : true));
            });

            $('body').on('click', '.dropdown-menu.hold-on-click', function (e) {
                e.stopPropagation();
            })
        }
    };
}();
var InitiateSearchableDataTable = function () {
    return {
        init: function () {
            var oTable = $('#searchable').dataTable({
                "sDom": "Tflt<'row DTTTFooter'<'col-sm-6'i><'col-sm-6'p>>",
                "aaSorting": [[1, 'asc']],
                "aLengthMenu": [
                   [5, 15, 20, -1],
                   [5, 15, 20, "All"]
                ],
                "iDisplayLength": 10,
                "oTableTools": {
                    "aButtons": [
				        "copy",
				        "print",
				        {
				            "sExtends": "collection",
				            "sButtonText": "Save <i class=\"fa fa-angle-down\"></i>",
				            "aButtons": ["csv", "xls", "pdf"]
				        }],
                    "sSwfPath": "assets/swf/copy_csv_xls_pdf.swf"
                },
                "language": {
                    "search": "",
                    "sLengthMenu": "_MENU_",
                    "oPaginate": {
                        "sPrevious": "Prev",
                        "sNext": "Next"
                    }
                }
            });

            $("tfoot input").keyup(function () {
                /* Filter on the column (the index) of this element */
                oTable.fnFilter(this.value, $("tfoot input").index(this));
            });

        }
    }
}();
