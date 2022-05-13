
var cnty = "IE";
var yr = 2017;


const ajax = (Country, Year) => {

    $.ajax({
        type: 'GET',
        url: "https://date.nager.at/api/v3/publicholidays/" + Year + "/" + Country,
        mimeType: 'json',
        success: function (data) {
            $.each(data, function (i, data) {
                var body = "<tr>";
                body += "<td>" + data.date + "</td>";
                body += "<td>" + data.name + "</td>";
                body += "<td>" + data.counties + "</td>";
                body += "<td>" + `<button id='btn-save'  id='save-btn' onclick="saveHoliday(${data})" class='btn btn-success'>` + "Save" + "</button>" + "</td>";
                body += "</tr>";
                $("#myTable tbody").append(body);

            });

            $("#myTable").DataTable({
                searching: false,
                paging: false,
                info: false,
                destroy: true,
                dom: 'Bfrtip',
                buttons: [
                    'csv'
                ]
            });
        },
        error: function () {
            alert('Fail!');
        }
    });


}

$(document).ready(function () {
    ajax(cnty, yr);
});

function getByCountry(counrty) {
    cnty = counrty;
    $("#myTable tr").remove();
    ajax(cnty, yr);
}

function getByYear(year) {
    yr = year;
    $("#myTable tr").remove();
    ajax(cnty, yr);
}


function saveHoliday(data) {
    $.ajax({
        url: 'https://localhost:44351/SavePublicHoliday/',
        type: 'POST',
        dataType: "json",
        data: {
            Date: data.date,
            Name: data.name,
            Countrys: data.counties
        },
        success: function (response) {
        }
    });
}
