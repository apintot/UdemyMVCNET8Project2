var dataTable;

$(document).ready(function () {
    createDataTable();
})

function createDataTable() {
    dataTable = $("#tblCategory").dataTable({
        "ajax": {
            "url": "/admin/Categories/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "width": "5%" },
            { "data": "name", "width": "50%" },
            { "data": "order", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                            <a href="/Admin/Categories/Edit/${data}" class="btn btn-success text-white" style="cursor:pointer; width:125px;">
                            <i class="far fa-edit"></i> Edit 
                            </a>
                            &nbsp;
                            <a onclick=Delete("/Admin/Categories/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer; width:125px; height:25xp">
                            <i class="far fa-trash-alt"></i> Delete 
                            </a>
                            </div>
                    `;
                }, "width": "25%"
            }
        ],

    });
}

function Delete(url) {
    swal({
        title: "Are you sure?",
        text: "This content cannot be recovered",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "yes, delete it",
        closeOnconfirm:true
    },
    function() {
        $.ajax({
            type: 'DELETE',
            url: url,
            success: function (data) {
                if (data.success) {
                    toastr.success(data.message);
                    dataTable.ajax.reload();
                }
                else {
                    toastr.error(data.message);
                }
            }
        });        
    });
}