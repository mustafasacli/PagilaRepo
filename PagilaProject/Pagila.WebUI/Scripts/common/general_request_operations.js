function callAjaxOperation(requestUrl, requestData, requestDataType = 'json', requestType, requestCache = false, requestContentType, successFunction, errorFunction) {
    //debugger;
    $.ajax({
        url: requestUrl,
        data: requestData,//JSON.stringify(dataObj),
        dataType: requestDataType,
        type: requestType,//"POST",
        cache: requestCache,//false
        contentType: requestContentType,//"application/json;charset=utf-8", //'html'
        success: function (response) {
            //debugger;
            if (isNotNullAndUndefined(successFunction)) {
                successFunction(response);
            }
            //console.log(response);
        },
        error: function (error) {
            if (isNotNullAndUndefined(errorFunction)) {
                errorFunction(error);
            }
            console.error(error);
        }
    });
}

function callAjaxPostOperation(requestUrl, requestData, requestDataType = 'json', requestCache = false, requestContentType = "application/json;charset=utf-8", successFunction, errorFunction) {
    callAjaxOperation(requestUrl, requestData, requestDataType,requestType = "POST", requestCache, requestContentType, successFunction, errorFunction);
}

function callAjaxGetOperation(requestUrl, requestData, requestDataType = 'json', requestCache = false, requestContentType = "application/json;charset=utf-8", successFunction, errorFunction) {
    callAjaxOperation(requestUrl, requestData, requestDataType,requestType = "GET", requestCache, requestContentType, successFunction, errorFunction);
}