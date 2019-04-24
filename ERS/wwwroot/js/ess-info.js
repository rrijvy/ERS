(function () {
    const selectors = {
        employee_name: $('#employee-name'),
        designation: $('#designation'),
        workingArea: $('#workingArea'),
        employee_phone: $('#employee-phone'),

        division_btn: $('#division-btn'),
        division: $('#division'),
        division_clicked: $('.division-clicked'),
        division_selected: $('.division-selected'),

        district_btn: $('#zilla-btn'),
        district: $('#district'),
        district_clicked: $('.district-clicked'),
        district_selected: $('.district-selected'),

        upazila_btn: $('#upazila-btn'),
        upazila: $('#upazila'),
        upazila_clicked: $('.upazila-clicked'),
        upazila_selected: $('.upazila-selected'),

        reset_btn: $('#reset-btn'),
        submit_btn: $('#submit-btn')
    };

    selectors.division_btn.on('click', function (e) {
        e.preventDefault(); e.stopPropagation();

        selectors.division.dialog("open");
    });

    selectors.division_clicked.on('click', function (e) {
        e.preventDefault(); e.stopPropagation();

        let numberOfDivision = Number(sessionStorage.getItem('numberOfDivision'));

        if (numberOfDivision === undefined) {
            numberOfDivision = 1;
            sessionStorage.setItem('numberOfDivision', numberOfDivision);
        }

        let divisionName = $(this).val();

        $(this).toggleClass('btn-success');

        if ($(this).hasClass('btn-success')) {

            numberOfDivision++;

            sessionStorage.setItem('numberOfDivision', numberOfDivision);

            sessionStorage.setItem(`division[${numberOfDivision}]`, divisionName);

            let btn = `<div id="${divisionName.replace(" ", "")}" class="wrapper"><button class="btn btn-primary" value="${divisionName}">${divisionName}</button></div>`;

            selectors.division_selected.append(btn);

        } else {

            let numberOfDivision = Number(sessionStorage.getItem('numberOfDivision'));

            for (let i = 1; i <= numberOfDivision; i++) {
                let name = sessionStorage.getItem(`division[${i}]`);
                if (name === divisionName) {
                    sessionStorage.setItem(`division[${i}]`, 'empty');
                    $(`#${divisionName.replace(" ", "")}`).remove();
                }
            }
        }
    });

    selectors.district_btn.on('click', function (e) {
        e.preventDefault(); e.stopPropagation();

        selectors.district.dialog("open");
    });

    selectors.district_clicked.on('click', function (e) {
        e.preventDefault(); e.stopPropagation();

        let numberOfDistrict = Number(sessionStorage.getItem('numberOfDistrict'));

        if (numberOfDistrict === undefined) {
            numberOfDistrict = 1;
            sessionStorage.setItem('numberOfDistrict', numberOfDistrict);
        }

        let districtnName = $(this).val();

        $(this).toggleClass('btn-success');

        if ($(this).hasClass('btn-success')) {

            numberOfDistrict++;

            sessionStorage.setItem('numberOfDistrict', numberOfDistrict);

            sessionStorage.setItem(`district[${numberOfDistrict}]`, districtnName);

            let btn = `<div id="${districtnName.replace(" ", "")}" class="wrapper"><button class="btn btn-primary" value="${districtnName}">${districtnName}</button></div>`;

            selectors.district_selected.append(btn);

        } else {

            let numberOfDistrict = Number(sessionStorage.getItem('numberOfDistrict'));

            for (let i = 1; i <= numberOfDistrict; i++) {
                let name = sessionStorage.getItem(`district[${i}]`);
                if (name === districtnName) {
                    sessionStorage.setItem(`district[${i}]`, 'empty');
                    $(`#${districtnName.replace(" ", "")}`).remove();
                }
            }
        }
    });

    selectors.upazila_btn.on('click', function (e) {
        e.preventDefault(); e.stopPropagation();

        selectors.upazila.dialog("open");
    });

    selectors.upazila_clicked.on('click', function (e) {
        e.preventDefault(); e.stopPropagation();

        let numberOfUpazila = Number(sessionStorage.getItem('numberOfUpazila'));

        if (numberOfUpazila === undefined) {
            numberOfUpazila = 1;
            sessionStorage.setItem('numberOfUpazila', numberOfUpazila);
        }

        let upazilaName = $(this).val();

        $(this).toggleClass('btn-success');

        if ($(this).hasClass('btn-success')) {

            numberOfUpazila++;

            sessionStorage.setItem('numberOfUpazila', numberOfUpazila);

            sessionStorage.setItem(`upazila[${numberOfUpazila}]`, upazilaName);

            let btn = `<div id="${upazilaName.replace(" ", "")}" class="wrapper"><button class="btn btn-primary" value="${upazilaName}">${upazilaName}</button></div>`;

            selectors.upazila_selected.append(btn);

        } else {

            let numberOfUpazila = Number(sessionStorage.getItem('numberOfUpazila'));

            for (let i = 1; i <= numberOfUpazila; i++) {
                let name = sessionStorage.getItem(`upazila[${i}]`);
                if (name === upazilaName) {
                    sessionStorage.setItem(`upazila[${i}]`, 'empty');
                    $(`#${upazilaName.replace(" ", "")}`).remove();
                }
            }
        }
    });

    selectors.submit_btn.on('click', function (e) {
        e.preventDefault(); e.stopPropagation();

        let numberOfDivision = Number(sessionStorage.getItem('numberOfDivision'));
        let numberOfDistrict = Number(sessionStorage.getItem('numberOfDistrict'));
        let numberOfUpazila = Number(sessionStorage.getItem('numberOfUpazila'));

        let divisions = []; let districts = []; let upazilas = [];

        for (let i = 1; i <= numberOfDivision; i++) {
            let divisionName = sessionStorage.getItem(`division[${i}]`);
            if (divisionName === "empty") {
                continue;
            } else {
                divisions.push(divisionName);
            }
        }

        for (let i = 1; i <= numberOfDistrict; i++) {
            let districtName = sessionStorage.getItem(`district[${i}]`);
            if (districtName === "empty") {
                continue;
            } else {
                districts.push(districtName);
            }
        }

        for (let i = 1; i <= numberOfUpazila; i++) {
            let upazilaName = sessionStorage.getItem(`upazila[${i}]`);
            if (upazilaName === "empty") {
                continue;
            } else {
                upazilas.push(upazilaName);
            }
        }

        let postObject = {
            employeeName: selectors.employee_name.val(),
            designation: selectors.designation.val(),
            workingArea: selectors.workingArea.val(),
            employeePhone: selectors.employee_phone.val(),
            divisions: divisions,
            districts: districts,
            upazilas: upazilas
        };

        console.log(postObject);

        $.ajax({
            type: 'POST',
            url: '/ESSInfoes/Create',
            dataType: 'json',
            data: postObject,
            complete: function (response) {
                var x = document.getElementById("snackbar");
                x.className = "show";
                setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);

            }
            
        });
    });
})();

$('#upazila').on('dialogclose', function () {
    let numberOfUpazila = Number(sessionStorage.getItem('numberOfUpazila'));
    $('#upazilas').html(" ");
    for (let i = 1; i <= numberOfUpazila; i++) {
        let upazilaName = sessionStorage.getItem(`upazila[${i}]`);
        if (upazilaName === "empty") {
            continue;
        } else {
            let btn = `<div class="wrapper"><button class="btn btn-default" value="${upazilaName}">${upazilaName}</button></div>`;
            $('#upazilas').append(btn);
        }
    }
});

$('#district').on('dialogclose', function () {
    let numberOfDistrict = Number(sessionStorage.getItem('numberOfDistrict'));
    $('#districts').html(" ");
    for (let i = 1; i <= numberOfDistrict; i++) {
        let districtnName = sessionStorage.getItem(`district[${i}]`);
        if (districtnName === "empty") {
            continue;
        } else {
            let btn = `<div class="wrapper"><button class="btn btn-default" value="${districtnName}">${districtnName}</button></div>`;
            $('#districts').append(btn);
        }
    }
});

$('#division').on('dialogclose', function () {
    let numberOfDivision = Number(sessionStorage.getItem('numberOfDivision'));
    $('#divisions').html(" ");
    for (let i = 1; i <= numberOfDivision; i++) {
        let divisionName = sessionStorage.getItem(`division[${i}]`);
        if (divisionName === "empty") {
            continue;
        } else {
            let btn = `<div class="wrapper"><button class="btn btn-default" value="${divisionName}">${divisionName}</button></div>`;
            $('#divisions').append(btn);
        }
    }
});