$(document).ready(function()
{
    //alert("loading");
    $('#btnSave').click(function (e) {
       e.preventDefault();      
       $('#createForm').submit();

        //$("form[name='createForm']").validate({
        //    // Specify validation rules
        //    rules: {
        //        // The key name on the left side is the name attribute
        //        // of an input field. Validation rules are defined
        //        // on the right side
        //        name: "required",
        //        address: "required",
        //        contactPersonEmailId: {
        //            required: true,
        //            // Specify that email should be validated
        //            // by the built-in "email" rule
        //            email: true
        //        },
        //        code: {
        //            required: true,
        //            minlength:4
        //        }
        //    },
        //    // Specify validation error messages
        //    messages: {
        //        name: "Please enter your firstname",
        //        address: "Please enter your lastname",
        //        code: {
        //            required: "Please provide a password",
        //            minlength: "Your password must be at least 5 characters long"
        //        },
        //        contactPersonEmailId: "Please enter a valid email address"
        //    },
        //    // Make sure the form is submitted to the destination defined
        //    // in the "action" attribute of the form when valid
        //    submitHandler: function (form) {
        //        form.submit();
        //    }
        //});
        
    });
        
 

    $('#btnCreate').click(function () {
        $('#myModal input:first-child').focus();
        $('#myModal').modal();
    });

});
