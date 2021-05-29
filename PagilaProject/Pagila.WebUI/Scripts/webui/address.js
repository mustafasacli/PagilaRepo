$(document).ready(function () {
    //setTimeout(function () {
    loadCityList();
    //}, 1000);
});

function loadCityList() {
    try {
        loadDropDown('CitySelect', $('#cityListUrl').val(), $('#CityId').val(), "Seçiniz", "CityId", "City", false);
    } catch (e) {
        console.error(e);
    }
}

function cityChanged() {
    $('#CityId').val($('#CitySelect').val());
}