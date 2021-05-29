function createCheckBox(name, id, text, value, onclickEvent, checkedCondition) {
    debugger;
    var checkbox = document.createElement('input');

    checkbox.setAttribute('type', 'checkbox');
    checkbox.setAttribute('id', id);
    checkbox.setAttribute('value', value);
    checkbox.setAttribute('name', name);
    if (checkedCondition)
        checkbox.checked = checkedCondition;

    if (isNotNullAndUndefined(onclickEvent)) {
        checkbox.addEventListener('onclick', function () {
            onclickEvent(e);
        });
    }

    var label = document.createElement('label');
    label.setAttribute('for', id);
    label.innerHTML = text;
    checkbox.innerHTML = label.outerHTML;

    return checkbox;
}