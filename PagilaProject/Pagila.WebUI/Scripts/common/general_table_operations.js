function loadDataTable(dataTableId, filter = false, ajaxSource, columns,
    processingText = "Yükleniyor...",
    zeroRecords = "Eşleşen Kayıt Bulunamadı",
    infoEmpty = "Kayıt Yok",
    infoFiltered = "Kayıt İçerisinden Bulunan",
    first = "İlk",
    previous = "Önceki",
    next = "Sonraki",
    last = "Son"
) {
    var tableId = '#' + dataTableId;
    if ($.fn.dataTable.isDataTable(tableId)) {
        table._fnDraw();
    } else {
        table = $(tableId).dataTable(
            {
                "bServerSide": true,
                "bFilter": filter,
                "sAjaxSource": ajaxSource,
                "bProcessing": true,
                "responsive": true,
                "bStateSave": true,
                "bSortCellsTop": true,
                "iCookieDuration": 60 * 2,
                "aoColumns": columns,
                "columnDefs": [
                    {
                        "render": function (data, type, row) {
                            return data;
                        },
                        "targets": -1
                    }
                ],
                "dom": '<"top"if>rt<"bottom"lp><"clear">',
                "language": {
                    "sProcessing": processingText,
                    "sLengthMenu": "_MENU_",
                    "sZeroRecords": zeroRecords,
                    "sInfo": "  _TOTAL_ Kayıttan _START_ - _END_ Arası Kayıtlar",
                    "sInfoEmpty": infoEmpty,
                    "sInfoFiltered": "( _MAX_ " + infoFiltered + ")",
                    "sInfoPostFix": "",
                    "sSearch": "",
                    "sSearchPlaceholder": "",
                    "sUrl": "",
                    "oPaginate": {
                        "sFirst": first,
                        "sPrevious": previous,
                        "sNext": next,
                        "sLast": last
                    }
                }
            });
    }
}