﻿function Delete(id) {
    $.ajax({
        type: "DELETE",
        url: $("#delete").data("request-url"),
        data: {

            empId: id
        },
        ContentType: "application/Json",
        datatype: "Json",
        success: function (result) {
            alert("Object with Id: " + id + " deleted successfully");
            $("#employeeTable").html(result);

        }
    });

}
