var datatable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    datatable = $('#tblDatos').DataTable({
        "rowReorder": {
            "selector": 'td:nth-child(2)'
        },
        "responsive": true,
        "scrollX": true,
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.10.21/i18n/Spanish.json"
        },
        "ajax": {
            "url": "/Admin/Cliente/ObtenerTodos"
        },
        "columns": [
            { "data": "nombreCliente", "width": "20%" },
            { "data": "apellido1", "width": "20%" },
            { "data": "apellido2", "width": "20%" },
            { "data": "cedula", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="text-center">
                            <a href="/Admin/ConsultaCliente/Upsert/${data}" class="btn btn-outline-info" style="cursor:pointer">
                                <i class="fas fa-info-circle"></i>
                            </a>
                        </div>
                        `;
                }, "width": "20%"
            }
        ]
    });
}