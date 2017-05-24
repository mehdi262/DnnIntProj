

    $('thead .div-asc').click(
        function () {
            var image = $(this);
            var table = $(this).parents('table').eq(0)
            var rows = table.find('tr:gt(0)').toArray().sort(comparer(2))
            rows = rows.reverse();
            for (var i = 0; i < rows.length; i++) { table.append(rows[i]) }
            setRowColours();
        });
$('thead .div-des').click(
   function () {
       var image = $(this);
       var table = $(this).parents('table').eq(0)
       var rows = table.find('tr:gt(0)').toArray().sort(comparer(2))
       for (var i = 0; i < rows.length; i++) { table.append(rows[i]) }
       setRowColours();
   });
function comparer(index) {
    return function (a, b) {
        var valA = getCellValue(a, index), valB = getCellValue(b, index)
        if (valA == valB) {
            valA = getCellValue(a,0 );
            valB = getCellValue(b, 0);

            if (valA == valB) {
                valA = getCellValue(a, 1);
                valB = getCellValue(b, 1);
            }
        }

        if ($.isNumeric(valA) && $.isNumeric(valB))
            return valA - valB;
        else
            return valA.localeCompare(valB);
    }
}
function getCellValue(row, index) { return $(row).children('td').eq(index).html() }

$("#searchInput").keyup(function () {
    //split the current value of searchInput
    var data = this.value.toUpperCase().split(" ");
    //create a jquery object of the rows
    var jo = $("#fbody").find("tr");
    if (this.value == "") {
        jo.show();
        setRowColours();
        return;
    }
    //hide all the rows
    jo.hide();

    //Recusively filter the jquery object to get results.
    jo.filter(function (i, v) {
        var $t = $(this).children(":eq(" + 0 + ")");
        for (var d = 0; d < data.length; ++d) {
            if ($t.text().toUpperCase().indexOf(data[d]) > -1) {
                return true;
            }
        }
        return false;
    })
    //show the rows that match.
    .show();
    //$("table").find("tr").removeClass("alt").filter(":odd").addClass("alt");
    setRowColours();

}).focus(function () {
    this.value = "";
    $(this).css({
        "color": "black"
    });
    $(this).unbind('focus');
}).css({
    "color": "#C0C0C0"
});

function setRowColours() {
    $("table").find("tr").removeClass("alt")
    $('table tr:visible:even').addClass("alt");

}

function updateTips(t, tips) {
    tips
        .text(t)
        .addClass("ui-state-highlight");
    setTimeout(function () {
        tips.removeClass("ui-state-highlight", 1500);
    }, 500);
}
function checkLength(o, n, min, max, tipHolder) {
    if (o.val().length > max || o.val().length < min) {
        o.addClass("ui-state-error");
        updateTips("Length of " + n + " must be between " +
            min + " and " + max + ".",tipHolder);

        return false;
    } else {
        return true;
    }
}

function checkRegexp(o, regexp, n, tipHolder) {
    if (!(regexp.test(o.val()))) {
        o.addClass("ui-state-error");
        updateTips(n, tipHolder);
        return false;
    } else {
        return true;
    }
}


$(document).ready(function () {

    ts = $("#users tbody");
    LoadTableData(ts);

    $("#users").on("click", ".js-delete",
        function () {
            var btn = $(this);
            bootbox.confirm("Do you really want to permenantly delete this Person!?",
                function (result) {
                    if (result) {
                        $.ajax({
                            url: "/Api/Persons/" + btn.attr("data-person-id"),
                            method: "DELETE",
                            success: function () {
                                LoadTableData(ts);
                            }

                        });
                    }
                });

        });
    $(document).on("click", ".js-edit", function () {
        var btn = $(this);
        var myId = btn.data('person-id');
        $.ajax({
            url: '/api/persons/'+myId,
            type: 'GET',
            dataType: 'json',

            contentType: 'application/json; charset=utf-8',
            success: function (dataModel) {
              
                try {
                    $(".modal-title #id").text(myId);

                    $(".modal-body #name").val(dataModel.Name);
                    $(".modal-body #lastName").val(dataModel.LastName);
                    $(".modal-body #email").val(dataModel.Email);
                    $(".modal-body #userName").val(dataModel.UserName);
                    $(".modal-footer .js-update").attr("data-id", myId);

                    $(".modal-body #age").val( dataModel.Age);





                } catch (e) {
                    console.log('Error while formatting the data : ' + e.message)
                }


            },
            error: function (xhrequest, error, thrownError) {
                console.log('Error while ajax call: ' + error)
            }
        });
    });

    $("body").on("click", "#myModal-Edit .js-update", function () {
        var tipholder = $(".validateTipsEdit");
        var btn = $(this);
        var name = $(".modal-body #name"),
            email = $(".modal-body #email"),
            lastName = $(".modal-body #lastName"),
            userName = $(".modal-body #userName"),
            age = $(".modal-body #age"),
            allFields = $([]).add(name).add(email).add(lastName).add(userName).add(age);

        bootbox.confirm("Do you really want to permenantly update the details for this Person!?",
           function (result) {
               
               if (result) {

                   var bValid = true;
                
                   allFields.removeClass("ui-state-error");
                   bValid = bValid && checkRegexp(name, /^[a-z]([0-9a-z]){2,14}$/i, "Name should have 3 to 15 charechter which may consist of a-z, 0-9,  begin with a letter.", tipholder);

                   bValid = bValid && checkRegexp(lastName, /^[a-z]([0-9a-z]){2,14}$/i, "Last  should have 3 to 15 charechter which Name may consist of a-z, 0-9, begin with a letter.", tipholder);

                   bValid = bValid && checkRegexp(email, /^([a-z\d!#$%&'*+\-\/=?^_`{|}~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]+(\.[a-z\d!#$%&'*+\-\/=?^_`{|}~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]+)*|"((([ \t]*\r\n)?[ \t]+)?([\x01-\x08\x0b\x0c\x0e-\x1f\x7f\x21\x23-\x5b\x5d-\x7e\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|\\[\x01-\x09\x0b\x0c\x0d-\x7f\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))*(([ \t]*\r\n)?[ \t]+)?")@(([a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|[a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF][a-z\d\-._~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]*[a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])\.)+([a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|[a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF][a-z\d\-._~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]*[a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])\.?$/i, "Email  should have 6 to 80 charechter which maylike  ui@jquery.com", tipholder);
                   bValid = bValid && checkRegexp(userName, /^[a-z]|[\w.-]{4,19}$/i, "Username  should have 5 to 20 charechter which may consist of a-z, 0-9, underscores, begin with a letter.", tipholder);
                   bValid = bValid && checkRegexp(age, /^(0?[1-9]|[1-9][0-9])$/i, "Age may be between 00 to 99", tipholder);

                   if (bValid) {
                       var mod = {
                           name: $.trim($(".modal-body #name").val()),
                           lastName: $.trim($(".modal-body #lastName").val()),
                           userName: $.trim($(".modal-body #userName").val()),
                           Email: $.trim($(".modal-body #email").val()),
                           Age: $.trim($(".modal-body #age").val()),
                           picture: ''
                       };
                       $.ajax({
                           url: "/Api/Persons/" + btn.attr("data-id"),
                           method: "PUT",
                           data: JSON.stringify(mod),
                           contentType: 'application/json; charset=utf-8',

                           success: function (data) {
                               LoadTableData(ts);
                               bootbox.alert("The record is updated ", function () {
                                   $('#myModal-Edit').modal('toggle');
                               }
                               );
                           },
                           error: function (response) {
                               updateTips(response.responseText, tipholder);

                           }

                       });

                   }

                   
               }
           });
        
    });


    $("body").on("click", "#myModal-add .js-add", function () {
        var btn = $(this);
        var tipholder = $("#myModal-add .validateTipsAdd");
        var name = $(".modal-body #aname"),
            email = $(".modal-body #aemail"),
            lastName = $(".modal-body #alastName"),
            userName = $(".modal-body #auserName"),
            age = $(".modal-body #aage"),
            allFields = $([]).add(name).add(email).add(lastName).add(userName).add(age);
        var mod = {
            name: $.trim(name.val()),
            lastName: $.trim(lastName.val()),
            userName: $.trim(userName.val()),
            Email: $.trim(email.val().toLowerCase()),
            age:$.trim(age.val()),
            picture: ''
        };
        var bValid = true;
                
        allFields.removeClass("ui-state-error");

        bValid = bValid && checkRegexp(name, /^[a-z]([0-9a-z]){2,14}$/i, "Name should have 3 to 15 charechter which may consist of a-z, 0-9,  begin with a letter.", tipholder);

        bValid = bValid && checkRegexp(lastName, /^[a-z]([0-9a-z]){2,14}$/i, "Last  should have 3 to 15 charechter which Name may consist of a-z, 0-9, begin with a letter.", tipholder);
                                     
        bValid = bValid && checkRegexp(email, /^([a-z\d!#$%&'*+\-\/=?^_`{|}~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]+(\.[a-z\d!#$%&'*+\-\/=?^_`{|}~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]+)*|"((([ \t]*\r\n)?[ \t]+)?([\x01-\x08\x0b\x0c\x0e-\x1f\x7f\x21\x23-\x5b\x5d-\x7e\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|\\[\x01-\x09\x0b\x0c\x0d-\x7f\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))*(([ \t]*\r\n)?[ \t]+)?")@(([a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|[a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF][a-z\d\-._~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]*[a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])\.)+([a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|[a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF][a-z\d\-._~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]*[a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])\.?$/i, "Email  should have 6 to 80 charechter which maylike  ui@jquery.com", tipholder);
        bValid = bValid && checkRegexp(userName, /^[a-z]|[\w.-]{4,19}$/i, "Username  should have 5 to 20 charechter which may consist of a-z, 0-9, underscores, begin with a letter.", tipholder);
        bValid = bValid && checkRegexp(age, /^(0?[1-9]|[1-9][0-9])$/i, "Age may be between 00 to 99", tipholder);
        if (bValid) {

            $.ajax({
                url: '/api/persons',
                type: 'POST',
                dataType: 'json',

                data: JSON.stringify(mod),

                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    LoadTableData(ts)
                    $('#myModal-add').modal('toggle');
                },
                error: function (response)
                {
                    
                    updateTips(response.responseText,tipholder);
                }
            });
        }
    });

    
});


