/// <reference path="jquery-2.2.4.js" />
$('.photo-info').on('click', '.get-user-photo', function () {
    var $IdUser = $(this).next('.user-identity-load').val(),
        $StringRequest = '/User/User.cshtml?IdUser=' + $IdUser;
    $('#images').load($StringRequest);
});