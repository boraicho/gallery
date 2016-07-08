/// <reference path="jquery-2.2.4.js" />
/// <reference path="jquery.validate.min.js" />
$('#login').validate({
    rules: {
        login: 'required',
        password: 'required'
    },
    message: {
        required: 'The field must not be empty'
    }
});
$('#registration').validate({
    rules: {
        login: 'required',
        password: {
            required: true,
            rangelength:[6,20]
        },
        password2: {
            equalTo: '#password'
        }
    },
    message: {
        login: {
            required: "The field must not be empty"
        },
        password: {
            required: 'The field must not be empty',
            rangelenght: 'The password must contain 6 to 20 characters'
        },
        password2: {
            equalTo: 'The passwords must match'
        }
    }
});
$('#photo-add').validate({
    rules: {
        uploaded: {
            required: true,
            accept: 'image/jpg,image/jpeg,image/png'
        }
    },
    message: {
        required: 'The field must not be empty',
        accept: 'file format should be: jpeg, png'
    }
});