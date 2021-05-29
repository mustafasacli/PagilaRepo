
function loadPartialTabFromUrl(divId, url, parameters,
    emptyDataText = '<p>Error</p>',
    errorText = "Error occured while getting partial view") {
    var isLoaded = false;
    $(divId).empty();

    $.ajax({
            type: 'POST',
            url: url,
            data: JSON.stringify(parameters),
            dataType: 'html',
            contentType: 'application/json',
            success: function (data) {
                if (isNotNullAndUndefined(data) && isNullOrWhiteSpace(data) == false) {
                    $(divId).html(data);
                    isLoaded = true;
                } else {
                    $(divId).fadeIn(1000).append(emptyDataText);
                }
            },
            error: function () {
                console.log(errorText);
            }
        });

    return isLoaded;
}