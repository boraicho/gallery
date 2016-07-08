/// <reference path="jquery-1.9.1.js" />
$('.image-remove').on('click', '.image-delete', function () {
    var $value = $(this).siblings('.image-remove').find('.image-identity').val()
        $.ajax({
            url: '/Photo/Delete',
            type: 'post',
            data: {
                Id: $value
            }
        }).success(function () {
            document.location.reload();
        });
    });