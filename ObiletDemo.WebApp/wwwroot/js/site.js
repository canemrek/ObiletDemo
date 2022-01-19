const departureCookie = "departureCookie";
const arrivalCookie = "arrivalCookie";
const departureDateCookie = "departureDateCookie";
let selectedDeparture;
let selectedDepartureIndex;
let selectedArrivalIndex;
let req;
$(document).ready(function () {
    $("#departure").val($("#DepartureId option:selected").text());
    $("#arrival").val($("#ArrivalId option:selected").text());
    //initializeSelect();
    var date = new Date($('#DepartureDate').val());
    $('#date').datepicker({
        format: 'dd MM yyyy DD',
        startDate: 'd',
        showOnFocus: true,
        language: 'tr',
        autoclose: true
    });
    $('#date').datepicker('setDate', date);
    $('#date').datepicker('update');

    //GetUserDate();
    $('#date').datepicker().on('changeDate', function (e) {
        var val = $(this).datepicker('getDate');
        $('#DepartureDate').val(e.format('mm/dd/yyyy'));
        $.cookie("departureDateCookie", e.format('mm/dd/yyyy'), { expires: 30 });
    });

    $("#departure").click(function (e) {
        e.stopPropagation();
        $(this).val('');
        search($(".departure"), $(this), selectedDepartureIndex);
        var se = $(".departure");
        se.show();
        se[0].size = 5;
    });

    $("#departure").keyup(function () {
        var text = $(this).val();
        console.log(text);
        if (text.length > 3) {

            search($(".departure"), $(this));
        }
    });

    $('#DepartureId').on('change', function () {

        var current = $("#DepartureId option:selected").val();
        var currentArrival = $("#ArrivalId option:selected").val();
        if (current == currentArrival) {
            $(this).val(selectedDepartureIndex);
        }
        var text = $("#DepartureId option:selected").text();
        $("#DepartureId option[value='" + current + "']").attr('selected', true);
        selectedDepartureIndex = $("#DepartureId option:selected").val();
        setCookie(departureCookie, selectedDepartureIndex);
        $("#departure").val(text);
        $(".departure").hide();
    });

    $("#arrival").click(function (e) {
        e.stopPropagation();
        $(this).val('');
        search($(".arrival"), $(this), selectedArrivalIndex);
        var se = $(".arrival");
        se.show();
        se[0].size = 5;
    });

    $("#arrival").keyup(function () {
        var text = $(this).val();
        console.log(text);
        if (text.length > 3) {
            search($(".arrival"), $(this));
        }
    });

    $('#ArrivalId').on('change', function () {
        //var current = parseInt($(this).val());
        var current = $("#ArrivalId option:selected").val();
        var currentDeparture = $("#DepartureId option:selected").val();

        if (current == currentDeparture) {
            $(this).val(selectedArrivalIndex);
        }
        selectedArrivalIndex = $("#ArrivalId option:selected").val();
        setCookie(arrivalCookie, selectedArrivalIndex);

        var text = $("#ArrivalId option:selected").text();
        $("#arrival").val(text);
        $(".arrival").hide();

    });

})


function SetDate(val) {
    let date = new Date();
    if (val == 1)
        date.setDate(date.getDate() + 1);

    $('#date').datepicker('setDate', date);
    $('#date').datepicker('update');
}

function GetUserDate() {
    if (!!getCookie(departureDateCookie)) {
        var setDate = new Date(getCookie(departureDateCookie));
        $('#date').datepicker('setDate', setDate);
        $('#DepartureDate').datepicker('setDate', setDate);

    }
    else {
        $('#date').datepicker('setDate', new Date());
        $('#DepartureDate').datepicker('setDate', new Date());
    }
    $('#date').datepicker('update');
}

/* select işlemleri */
function search(element, textbox, selectedVal) {
    let serachKey = $(textbox).val();
    if (req != null) req.abort();
    req = $.ajax({
        type: 'GET',
        url: '/Ajax/Index',
        dataType: "json",
        data: { term: serachKey },
        success: function (result) {
            $(element).html('');
            $.each(result, function (i, item) {
                $(element).append($('<option>', {
                    value: item.id,
                    text: item.name,
                    selected: item.name == selectedVal ? true : false
                }));
            });

        }
    });
}

function changeSelect(depVal, arVal) {
    var departure = $('.departure');
    var arrival = $('.arrival');
    $.ajax({
        type: 'GET',
        url: '/Ajax/Index',
        data: { size: 10 },
        dataType: "json",
        success: function (result) {
            selectedDeparture;
            var arrivalSelected;

            $.each(result, function (i, item) {
                var selected = item.id == depVal ? true : false;
                if (selected) {
                    selectedDeparture = item;
                    $("#departure").val(selectedDeparture.name);
                    selectedDepartureIndex = selectedDeparture.id;
                    setCookie(departureCookie, selectedDepartureIndex);
                }
                $(departure).append($('<option>', {
                    value: item.id,
                    text: item.name,
                    selected: selected
                }));
            });
            //$('.departure').val(selectedDeparture.id);

            selectedArrival = 0;
            $.each(result, function (i, item) {
                if (!arrivalSelected) {
                    arrivalSelected = item.id == arVal ? true : false;
                    if (arrivalSelected) {
                        selectedArrival = item.id;
                        $("#arrival").val(item.name);
                        selectedArrivalIndex = item.id;
                        setCookie(arrivalCookie, selectedArrivalIndex);

                    }
                }
                var selectedForArrival = item.id == selectedArrival ? true : false;

                $(arrival).append($('<option>', {
                    value: item.id,
                    text: item.name,
                    selected: selectedForArrival
                }));
            });
            //$('.arrive').val(selectedArrivalIndex);
        }
    });
}

function initializeSelect() {
    var departure = $('.departure');
    var arrival = $('.arrival');
    $.ajax({
        type: 'GET',
        url: '/Ajax/Index',
        data: { size: 10 },
        dataType: "json",
        success: function (result) {
            selectedDeparture;
            var arrivalSelected;

            $.each(result, function (i, item) {
                var selected = getCookie(departureCookie) != '' ? item.id == getCookie(departureCookie) ? true : i == 0 ? true : false : false;
                if (selected) {
                    selectedDeparture = item;
                    $("#departure").val(selectedDeparture.name);
                    selectedDepartureIndex = selectedDeparture.id;
                }
                $(departure).append($('<option>', {
                    value: item.id,
                    text: item.name,
                    selected: selected
                }));
            });
            //$('.departure').val(selectedDeparture.id);

            selectedArrival = 0;
            $.each(result, function (i, item) {
                if (!arrivalSelected) {
                    var cookieVal = getCookie(arrivalCookie);
                    //if (!!getCookie(arrivalCookie) && item.id == cookieVal) {
                    //    arrivalSelected = true;
                    //}
                    //else if (getCookie(arrivalCookie)=="undefined" && item.id != selectedDeparture.id && item.parentid != selectedDeparture.parentid) {
                    //    arrivalSelected = true;

                    //}
                    //else {
                    //    arrivalSelected = false;

                    //}
                    arrivalSelected = !!getCookie(arrivalCookie) && item.id == cookieVal ? true : getCookie(arrivalCookie) == "undefined" && item.id != selectedDeparture.id && item.parentid != selectedDeparture.parentid ? true : false;

                    if (arrivalSelected) {
                        selectedArrival = item.id;
                        $("#arrival").val(item.name);
                        selectedArrivalIndex = item.id;
                    }
                }
                var selectedForArrival = item.id == selectedArrival ? true : false;

                $(arrival).append($('<option>', {
                    value: item.id,
                    text: item.name,
                    selected: selectedForArrival
                }));
            });
            //$('.arrive').val(selectedArrivalIndex);
        }
    });
}
/* select işlemleri */

function swap() {
    changeSelect($("#ArrivalId option:selected").val(), $("#DepartureId option:selected").val())
}
/* Cookie işlemleri */
function setCookie(name, value) {
    $.cookie(name, value);
}

function getCookie(name) {
    return $.cookie(name);
}
/* Cookie işlemleri  */
