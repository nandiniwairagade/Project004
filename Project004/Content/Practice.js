$(document).ready(function () {
    GetPracticeList();
});

var savereg = function () {
    var id = $("#hdnid").val();
    var name = $("#txtName").val();
    var last_name = $("#txtLast_Name").val();
    var mobile_no = $("#txtMobile_no").val();
    var email_id = $("#txtEmail_id").val();
    var city = $("#txtCity").val();
    var model = { Name: name, Last_Name: last_name, Mobile_No: mobile_no, Email_id: email_id, City: city };
    $.ajax({
        url: "/Practice/SaveReg",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charsel=utf-8",
        dataType: "json",
        success: function (responce) {
            alert("responce.message");
        }
    })
}; 
var GetPracticeList = function () {

    $.ajax({
        url: "/Practice/GetPracticeList",
        method: "post",
        contentType: "application/json;charsel=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#lstPractice tbody").empty();
            $.each(response.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.srno +
                    "</td><td>" + elementValue.ID +
                    "</td><td>" + elementValue.Name +
                    "</td><td>" + elementValue.Last_Name +
                    "</td><td>" + elementValue.Mobile_no +
                    "</td><td>" + elementValue.Email_id +
                    "</td><td>" + elementValue.City +
                    "</td><td><input type='button' value='delete' onclick='deletePractice(" + elementValue.ID +")'/></td ></tr >"; 
                   
            });
            $("#lstPractice tbody").append(html);
        }


    
    });
}
var deletePractice = function ( ID) {
    debugger
    model = { ID: ID }
    $.ajax({
        url: "/Practice/deletePractice",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charsel=utf-8",
        dataType: "json",

        success: function (response) {
            alert(response.model);
            GetPracticeList();
        },
        error: function (response) {
            alert(response.model);
        },








    });    
}