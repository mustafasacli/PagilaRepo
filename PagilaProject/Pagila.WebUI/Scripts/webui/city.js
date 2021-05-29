$(document).ready(function () {
    //setTimeout(function () {
    loadCountryList();
    //}, 1000);
});

function loadCountryList() {
    try {
        loadDropDown(
            'CountrySelect', $('#countryListUrl').val(), $('#CountryId').val(), "Seçiniz", "CountryId", "Country", false
        );
    } catch (e) {
        console.error(e);
    }
}

function countryChanged() {
    $('#CountryId').val($('#CountrySelect').val());
}