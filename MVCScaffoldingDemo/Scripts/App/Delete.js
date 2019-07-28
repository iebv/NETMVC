function Delete(id) {
    $.ajax({
        url: $("#delete").data("request-url"),
        type: "DELETE",
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
