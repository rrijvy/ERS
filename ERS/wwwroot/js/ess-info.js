(function () {
    const selectors = {
        ess_code: $('#ess-code'),

        employee_name: $('#employee-name'),
        designation: $('#designation'),
        workingArea: $('#workingArea'),
        employee_phone: $('#employee-phone'),

        product_info_btn: $('#product-info-btn'),
        product_info: $('#product-info'),
        product_name: $('#product-name'),
        prodcut_submit_btn: $('#prodcut-submit-btn'),

        product_template_btn: $('#product-template-btn'),
        product_template: $('#product-template'),
        prodcut_template_add_btn: $('#prodcut-template-add-btn'),
        product_id: $('#product-id'),
        product_quantity: $('#product-quantity'),
        product_price: $('#product-price'),
        template_body: $('#template-body'),
        save_template_btn: $('#save-template-btn'),
        template_name: $('#template-name'),

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

    let templateProducts = [];

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

            let btn = `<div id="${divisionName.replace(" ", "")}" class="wrapper"><button class="btn-link" value="${divisionName}">${divisionName}</button></div>`;

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

            let btn = `<div id="${districtnName.replace(" ", "")}" class="wrapper"><button class="btn-link" value="${districtnName}">${districtnName}</button></div>`;

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

            let btn = `<div id="${upazilaName.replace(" ", "")}" class="wrapper"><button class="btn-link" value="${upazilaName}">${upazilaName}</button></div>`;

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

    selectors.product_info_btn.on('click', function (e) {
        e.preventDefault(); e.stopPropagation();

        selectors.product_info.dialog("open");
    });

    selectors.prodcut_submit_btn.on('click', function (e) {
        e.preventDefault(); e.stopPropagation();

        let productName = selectors.product_name.val();
        $.ajax({
            type: 'POST',
            url: '/Products/Create',
            dataType: 'json',
            data: { productName: productName }
        });
        selectors.product_info.dialog('close');
        selectors.product_name.val(null);
    });

    selectors.product_template_btn.on('click', function (e) {
        e.preventDefault(); e.stopPropagation();

        selectors.product_template.dialog("open");
    });

    selectors.prodcut_template_add_btn.on('click', function (e) {
        e.preventDefault(); e.stopPropagation();
        let product = {
            name: document.getElementById('product-id').options[document.getElementById('product-id').selectedIndex].text,
            id: selectors.product_id.val(),
            price: selectors.product_price.val(),
            quantity: selectors.product_quantity.val()
        };

        let tableRow = `<tr>
                            <td>${product.name}</td>
                            <td>${product.quantity}</td>
                            <td>${product.price}</td>
                        </tr>`;

        templateProducts.push(product);

        selectors.template_body.append(tableRow);

    });

    selectors.save_template_btn.on('click', function (e) {
        e.preventDefault(); e.stopPropagation();

        if (templateProducts.length !== 0) {
            let template = {
                templateName: selectors.template_name.val(),
                products: templateProducts
            };
            $.ajax({
                type: 'POST',
                url: '/ProductTemplates/Create',
                dataType: 'json',
                data: template
            });
        }

        templateProducts.length = 0;

        $("#product-template").dialog('close');
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
            success: function (response) {
                selectors.ess_code.val(response);
            },
            complete: function () {
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