/// <reference path="jquery-2.2.4.js" />
$('.photo-rating').on('click', '.rating-up', function () {
    var $IdUser = $(this).siblings('.form-group').find('.user-identity').val(),
        $IdPhoto = $(this).siblings('.form-group').find('.photo-identity').val()

    if (!$(this).hasClass('glyphicon-chevron-up-sucses')) {
        $.ajax({
            url: '/Photo/AddScore',
            type: 'post',
            data: {
                IdUser: $IdUser,
                IdPhoto: $IdPhoto,
                Score: 1
            }
        }).success(function () {
            document.location.reload();
        });
    }
});

$('.photo-rating').on('click', '.rating-down', function () {
    var $IdUser = $(this).siblings('.form-group').find('.user-identity').val(),
        $IdPhoto = $(this).siblings('.form-group').find('.photo-identity').val()

    if (!$(this).hasClass('glyphicon-chevron-down-sucses')) {
        $.ajax({
            url: '/Photo/AddScore',
            type: 'post',
            data: {
                IdUser: $IdUser,
                IdPhoto: $IdPhoto,
                Score: -1
            }
        }).success(function () {
            document.location.reload();
        });
    }
});