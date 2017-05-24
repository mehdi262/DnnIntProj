
        function LoadTableData(table_selector) {
            $.ajax({
                url: '/api/persons',
                type: 'GET',
                dataType: 'json',

                contentType: 'application/json; charset=utf-8',
                success: function (dataModel) {
                    debugger;
                    try {
                        table_selector.empty();
                        var usericon = "<img src='/Content/Icon/user.gif' class='img img-circle' style='width:30px; height:30px ;border-radius: 50%; border:1px solid; float:left' />";
                        $.each(dataModel, function (key, val) {
                            table_selector.append("<tr>" +
                                                                         "<td>" + usericon + val.Name + "  " + val.LastName + " <br/> " + val.UserName + "</td>" +
                                                                         "<td>" + val.Email + "</td>" +
                                                                         "<td>" + val.JoinedDate + "</td>" +
                                                                         "<td>" + 
                                                                        " <button class='btn btn-link js-delete' data-person-id='"+val.Id+"' id='delete'><span class='glyphicon glyphicon-remove'></span> </button>"+
                                                                        "<button class='btn btn-link js-edit' data-person-id='" + val.Id + "' id='Edit'><span class='glyphicon glyphicon-edit'></span></button>"
                                                                         +"</td>"+
                                                                     "</tr>");
                        });

                        setRowColours();

                    } catch (e) {
                        console.log('Error while formatting the data : ' + e.message)
                    }


                },
                error: function (xhrequest, error, thrownError) {
                    console.log('Error while ajax call: ' + error)
                }
            });
        }
$(function () {
    var name = $("#name"),
        email = $("#email"),
        lastName = $("#lastName"),
        userName = $("#userName"),
        allFields = $([]).add(name).add(email).add(lastName).add(userName),
        tips = $(".validateTips");



    function updateTips(t) {
        tips
            .text(t)
            .addClass("ui-state-highlight");
        setTimeout(function () {
            tips.removeClass("ui-state-highlight", 1500);
        }, 500);
    }

    function checkLength(o, n, min, max) {
        if (o.val().length > max || o.val().length < min) {
            o.addClass("ui-state-error");
            updateTips("Length of " + n + " must be between " +
                min + " and " + max + ".");

            return false;
        } else {
            return true;
        }
    }

    function checkRegexp(o, regexp, n) {
        if (!(regexp.test(o.val()))) {
            o.addClass("ui-state-error");
            updateTips(n);
            return false;
        } else {
            return true;
        }
    }


    $("#dialog-form").dialog({

        autoOpen: false,
        height: 300,
        width: 350,
        modal: true,
        buttons: {
            "Create a person": function () {
                var bValid = true;
                allFields.removeClass("ui-state-error");

                bValid = bValid && checkLength(name, "name", 3, 16);
                bValid = bValid && checkLength(lastName, "lastName", 3, 16);
                bValid = bValid && checkLength(email, "email", 6, 80);
                bValid = bValid && checkLength(userName, "userName", 5, 16);

                bValid = bValid && checkRegexp(name, /^[a-z]([0-9a-z])+$/i, "Name may consist of a-z, 0-9,  begin with a letter.");
                bValid = bValid && checkRegexp(lastName, /^[a-z]([0-9a-z])+$/i, "Last Name may consist of a-z, 0-9, begin with a letter.");

                // From jquery.validate.js (by joern), contributed by Scott Gonzalez: http://projects.scottsplayground.com/email_address_validation/

                bValid = bValid && checkRegexp(email, /^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i, "eg. ui@jquery.com");
                bValid = bValid && checkRegexp(userName, /^[a-z]([0-9a-z_])+$/i, "Username may consist of a-z, 0-9, underscores, begin with a letter.");

                if (bValid) {
                    var table_selector = $("#users tbody");
                    var d = new Date();

                    // create model for controller
                    var mod = {
                        name: $.trim(name.val()),
                        lastName: $.trim(lastName.val()),
                        userName: $.trim(userName.val()),
                        Email: $.trim(email.val().toLowerCase()),
                        picture: ''
                    };
                    var diag = $(this);
                    $.ajax({
                        url: '/api/persons',
                        type: 'POST',
                        dataType: 'json',

                        data: JSON.stringify(mod),

                        contentType: 'application/json; charset=utf-8',
                        success: function (data) {
                            LoadTableData(table_selector);
                            diag.dialog("close");


                        },
                        error: function (response) {
                            updateTips(response.responseText);

                        }
                    });

                }
            },
            Cancel: function () {
                allFields.val("");
            }
        },
        close: function () {
            allFields.val("").removeClass("ui-state-error");
        }
    });
  
    $("#create-user")
        .button()
        .click(function () {
            $("#dialog-form").dialog("open");
        });
});
