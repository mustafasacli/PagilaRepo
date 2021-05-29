var intMaxValue = 2147483647;
var longMaxValue = 9223372036854775807;

function loadDropDown(dropDownId, dropDownUrl, selectedValue, defaultText = "Seçiniz",
    valueProperty = "Value", textProperty = "Text", logReturnKeys = false) {
    let dropdown = $('#' + dropDownId);
    if (dropdown === null || dropdown === undefined)
        return;

    dropdown.empty();

    if (dropDownUrl === null || dropDownUrl === undefined)
        return;

    dropdown.append('<option value = "">' + defaultText + '</option>');

    if (textProperty === null || textProperty === undefined || valueProperty === null || valueProperty === undefined)
        return;

    $.getJSON(dropDownUrl, function (data) {
        $.each(data, function (key, entry) {
            dropdown.append($('<option></option>')
                .attr('value', entry[valueProperty])
                .text(entry[textProperty]));

            if (logReturnKeys)
                console.log(key);
        });
    }).done(function () {
        if (isNotNullAndUndefined(selectedValue)) {
            //setTimeout(function () {
            dropdown.val(selectedValue);
            //}, 500);
            // console.log(selectedValue);
        } else {
            dropdown.prop('selectedIndex', 0);
        }
    });

}

function GetDropdownSelectedText(dropDownName) {
    var e = document.getElementById(dropDownName);
    var result = e.options[e.selectedIndex].text;
    return result;
}

function isEmptyOrSpaces(str) {
    return str === null || str.match(/^ *$/) !== null;
}

function isNullOrWhiteSpace(value) {
    var result = true;
    if (isNotNullAndUndefined(value) === false) {
        return result;
    }
    if (value.length === 0) {
        return result;
    }
    var temp = value;
    temp = temp.trim();
    if (temp.length === 0) {
        return result;
    }

    result = false;
    return result;
}

function isNotNullAndUndefined(data) {
    var result = false;
    result = data !== null && data !== undefined;
    return result;
}

function toNullString(data) {
    var result = '';
    if (isNotNullAndUndefined(data)) {
        result = data.toString();
    }

    return result;
}

function toStringWithDefault(data, defaultValue = null) {
    var result = '';
    if (isNotNullAndUndefined(data)) {
        result = data.toString();
    } else if (isNotNullAndUndefined(defaultValue)) {
        result = toNullString(defaultValue);
    }

    return result;
}

function disableComponent(componentId) {
    if ($(componentId) !== null) {
        $(componentId).prop("disabled", true);
    }
}
function enableComponent(componentId) {
    if ($(componentId) !== null) {
        $(componentId).prop("disabled", false);
    }
}

function removeTableColumn(tableId, columnIndex) {
    if ($(tableId) !== null) {
        $(tableId + ' tr').find('th:eq(' + columnIndex + '), td:eq(' + columnIndex + ')').remove();
    }
}

function setCssRed(obj) {
    obj.css('border-color', 'Red');
}

function setCssLightGreen(obj) {
    obj.css('border-color', 'lightgrey');
}

function validateDropDown(dropDownObj, minValue) {
    isValid = false;
    var val = dropDownObj.val();
    if (isNotNullAndUndefined(val) == false || isNullOrWhiteSpace(val)) {
        isValid = false;
        setCssRed(dropDownObj);
    }

    if ((val * 1) < (minValue * 1)) {
        isValid = false;
        setCssRed(dropDownObj);
    }
    else {
        isValid = true;
        setCssLightGreen(dropDownObj);
    }
    return isValid;
}

function validateInput(inputObj, isRequired = true) {
    isValid = true;

    var val = inputObj.val();

    if (isRequired === true && isNullOrWhiteSpace(val)) {
        isValid = false;
        return isValid;
    }

    var maxLen = inputObj.attr('maxlength');
    if (maxLen !== null && maxLen !== undefined) {
        if ((maxLen * 1) < val.length) {
            isValid = false;
            return isValid;
        }
    }

    return isValid;
}

function validateEMail(inputMail) {
    //debugger;
    if (isNotNullAndUndefined(inputMail) === false)
        return false;

    if (isNullOrWhiteSpace(inputMail))
        return false;

    //var filter = /^([a-zA-Z0-9_\.\-])+\@@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    //return filter.test(inputMail);
    var result = false;
    const re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    result = re.test(String(inputMail).toLowerCase());
    return result;
}

function removeTurkishChars(inputText) {
    if (isNotNullAndUndefined(inputText) === false)
        return inputText;

    var deger = inputText;
    var str = [];
    for (var i = 0; i < deger.length; i++) {
        var ch = deger.charCodeAt(i);
        var c = deger.charAt(i);
        if (ch == 304) str.push('i');
        else if (ch == 305) str.push('i');
        else if (ch == 287) str.push('g');
        else if (ch == 286) str.push('g');
        else if (ch == 220) str.push('u');
        else if (ch == 252) str.push('u');
        else if (ch == 351) str.push('s');
        else if (ch == 350) str.push('s');
        else if (ch == 246) str.push('o');
        else if (ch == 214) str.push('o');
        else if (ch == 231) str.push('c');
        else if (ch == 199) str.push('c');
        else if (ch >= 97 && ch <= 122) str.push(c.toLowerCase());
        else str.push(c.toLowerCase());
    }
    deger = str.join('');
    email.value = deger;
}

function checkNumberInput() {
    try {
        $(".sayiKontrol").keydown(function (e) {
            if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
                (e.keyCode == 65 && (e.ctrlKey === true || e.metaKey === true)) ||
                (e.keyCode >= 35 && e.keyCode <= 40)) {
                return;
            }
            if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
                e.preventDefault();
            }
        });
    } catch (err) {
        console.error(err);
    }
}

function encodeAsHtml(controlId) {
    var ctrl = $(controlId);
    var returnValue = '';
    if (isNotNullAndUndefined(ctrl)) {
        var value = $(controlId).val();
        if (isNotNullAndUndefined(value)) {
            value = $('<div>').text(value).html();
            return value;
        }
    }

    return returnValue;
}

function checkValueGreaterThanIntMaxValue(componentId) {
    var result = false;
    result = (($(componentId).val() * 1) > intMaxValue);
    return result;
}

function checkValueGreaterThanLongMaxValue(componentId) {
    var result = false;
    result = (($(componentId).val() * 1) > longMaxValue);
    return result;
}

function setGivenTabActive(tabIndex) {
    try {
        //debugger;
        setTimeout(function () {
            $("a.tab_item")[tabIndex].click();
        }, 500);
    } catch (e) {
        console.error(e);
    }
}

function clearContent(div_id) {
    if (isNotNullAndUndefined($(div_id))) {
        $(div_id).html('');
    }
}

function objectifyForm(formArray) {
    //var form = $("#yurtTumBilgiForm");
    //var dataObj = form.serialize();
    //var dataObj = objectifyForm($('#yurtTumBilgiForm').serializeArray());
    //serialize data function
    var returnArray = {};
    for (var i = 0; i < formArray.length; i++) {
        returnArray[formArray[i]['name']] = formArray[i]['value'];
    }
    return returnArray;
}

function getFormValues(formId) {
    //debugger;
    var data = {};
    if (isNullOrWhiteSpace(formId)) {
        return data;
    }
    var element = document.getElementById(formId).elements;
    for (var i = 0; i < element.length; i++) {
        //debugger;
        if (isNullOrWhiteSpace(element[i].id))
            continue;

        switch (element[i].type) {
            case "hidden": data[element[i].id] = encodeAsHtml('#' + element[i].id); break;
            case "text": data[element[i].id] = encodeAsHtml('#' + element[i].id); break;
            case "checkbox": data[element[i].id] = element[i].checked; break;
            case "password": data[element[i].id] = encodeAsHtml('#' + element[i].id); break;
            case "textarea": data[element[i].id] = encodeAsHtml('#' + element[i].id); break;
            case "select-one": data[element[i].id] = encodeAsHtml('#' + element[i].id); break;
            case "input": data[element[i].id] = encodeAsHtml('#' + element[i].id); break;
            case "email": data[element[i].id] = encodeAsHtml('#' + element[i].id); break;
            case "tel": data[element[i].id] = encodeAsHtml('#' + element[i].id); break;
        }
    }
    //console.log(data);
    return data;
}

function kaydetVeIlerle(tabIndex) {
    try {
        //debugger;
        setTimeout(function () {
            $("a.tab_item")[tabIndex].click();
        }, 500);
    } catch (e) {
        console.error(e);
    }
}