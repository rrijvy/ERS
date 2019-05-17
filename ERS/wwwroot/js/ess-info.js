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
        templateList: $('#templateList'),

        division_btn: $('#division-btn'),
        division: $('#division'),
        divisions: $('#divisions'),
        division_clicked: $('.division-clicked'),
        division_selected: $('.division-selected'),

        district_btn: $('#zilla-btn'),
        district: $('#district'),
        districts: $('#districts'),
        district_clicked: $('.district-clicked'),
        district_selected: $('.district-selected'),

        upazila_btn: $('#upazila-btn'),
        upazila: $('#upazila'),
        upazilas: $('#upazilas'),
        upazila_clicked: $('.upazila-clicked'),
        upazila_selected: $('.upazila-selected'),

        addedProducts: $('#addedProducts'),
        productQuantity: $('#productQuantity'),
        productPrice: $('#productPrice'),
        individualProductAdd: $('#individualProductAdd'),

        deleteUncheckedItems: $('#deleteUncheckedItems'),
        reset_btn: $('#reset-btn'),
        submit_btn: $('#submit-btn')
    };

    let existed_division = document.getElementsByClassName("existed-division");
    let existed_district = document.getElementsByClassName("existed-district");
    let existed_upazila = document.getElementsByClassName("existed-upazila");

    for (let item of existed_division) {
        divisionName = item.getAttribute('value');

        let numberOfDivision = Number(sessionStorage.getItem('numberOfDivision'));

        if (numberOfDivision === undefined) {
            numberOfDivision = 1;
            sessionStorage.setItem('numberOfDivision', numberOfDivision);
        }

        numberOfDivision++;

        sessionStorage.setItem('numberOfDivision', numberOfDivision);

        sessionStorage.setItem(`division[${numberOfDivision}]`, divisionName);
    }

    for (let item of existed_district) {
        districtnName = item.getAttribute('value');

        let numberOfDistrict = Number(sessionStorage.getItem('numberOfDistrict'));

        if (numberOfDistrict === undefined) {
            numberOfDistrict = 1;
            sessionStorage.setItem('numberOfDistrict', numberOfDistrict);
        }

        numberOfDistrict++;

        sessionStorage.setItem('numberOfDistrict', numberOfDistrict);

        sessionStorage.setItem(`district[${numberOfDistrict}]`, districtnName);
    }

    for (let item of existed_upazila) {
        upazilaName = item.getAttribute('value');

        let numberOfUpazila = Number(sessionStorage.getItem('numberOfUpazila'));

        if (numberOfUpazila === undefined) {
            numberOfUpazila = 1;
            sessionStorage.setItem('numberOfUpazila', numberOfUpazila);
        }

        numberOfUpazila++;

        sessionStorage.setItem('numberOfUpazila', numberOfUpazila);

        sessionStorage.setItem(`upazila[${numberOfUpazila}]`, upazilaName);
    }

    let templateProducts = [];
    let productList = [];

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
            data: { productName: productName },
            success: function (response) {
                let productList = document.getElementById('productList');
                productList.innerHTML = " ";
                for (let i = 0; i < response.length; i++) {
                    let option = document.createElement('option');
                    option.value = response[i].id;
                    option.innerHTML = response[i].name;
                    productList.appendChild(option);
                }
                productList.value = null;

                let product_id = document.getElementById('product-id');
                product_id.innerHTML = " ";
                for (let i = 0; i < response.length; i++) {
                    let option = document.createElement('option');
                    option.value = response[i].id;
                    option.innerHTML = response[i].name;
                    product_id.appendChild(option);
                }
                product_id.value = null;
            }
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
        let dataAvailable = false;
        let product = {
            name: document.getElementById('product-id').options[document.getElementById('product-id').selectedIndex].text,
            id: selectors.product_id.val(),
            price: selectors.product_price.val(),
            quantity: selectors.product_quantity.val()
        };

        let tableRow = `<tr id="${product.id}">
                            <td>${product.name}</td>
                            <td>${product.quantity}</td>
                            <td>${product.price}</td>
                        </tr>`;

        for (let i = 0; i < templateProducts.length; i++) {
            if (templateProducts[i].id === product.id) {
                templateProducts[i] = product;

                tableRow = `<td>${product.name}</td>
                            <td>${product.quantity}</td>
                            <td>${product.price}</td>`;

                $(`#${product.id}`).html(tableRow);

                dataAvailable = true;

                break;
            }
        }

        if (dataAvailable === false) {
            templateProducts.push(product);

            selectors.template_body.append(tableRow);
        }
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
                data: template,
                success: function (response) {
                    let templateList = document.getElementById('templateList');
                    templateList.innerHTML = " ";
                    for (let i = 0; i < response.length; i++) {
                        let option = document.createElement('option');
                        option.value = response[i];
                        option.innerHTML = response[i];
                        templateList.appendChild(option);
                    }
                    templateList.value = null;
                }
            });
        }

        selectors.template_body.html(" ");

        templateProducts.length = 0;

        $("#product-template").dialog('close');
    });

    selectors.templateList.on('change', function (e) {
        e.preventDefault(); e.stopPropagation();

        let template = $(this).val();

        $.ajax({
            type: 'GET',
            url: '/ProductTemplates/Details/?templateName=' + template,
            cache: false,
            dataType: "JSON",
            contentType: "application/x-www-form-urlencoded",
            success: function (response) {
                for (let i = 0; i < response.length; i++) {
                    let product = {
                        name: response[i].product.name,
                        id: response[i].productId,
                        quantity: response[i].quantity,
                        price: response[i].price
                    };
                    let tableRow = `<tr>
                                        <td><input type="checkbox" value="${Number(response[i].productId) + Number(response[i].price)}" checked></td>
                                        <td>${response[i].product.name}</td>
                                        <td>${response[i].quantity}</td>
                                        <td>${response[i].price}</td>
                                    </tr>`;

                    productList.push(product);
                    selectors.addedProducts.append(tableRow);
                }
            }
        });

    });

    selectors.individualProductAdd.on('click', function (e) {
        e.preventDefault(); e.stopPropagation();
        let dataAvailable = false;

        let product = {
            name: document.getElementById('productList').options[document.getElementById('productList').selectedIndex].text,
            id: Number(document.getElementById('productList').options[document.getElementById('productList').selectedIndex].value),
            quantity: selectors.productQuantity.val(),
            price: selectors.productPrice.val()
        };

        let tableRow = `<tr>
                            <td><input type="checkbox" value="${Number(product.id) + Number(product.price)}" checked /></td>
                            <td>${product.name}</td>
                            <td>${product.quantity}</td>
                            <td>${product.price}</td>
                        </tr>`;
        if (dataAvailable === false) {
            selectors.addedProducts.append(tableRow);
            productList.push(product);
        }
        selectors.productQuantity.val("");
        selectors.productPrice.val("");
    });

    selectors.deleteUncheckedItems.on('click', function (e) {
        e.preventDefault(); e.stopPropagation();

        $('#addedProducts tr').each(function () {
            let value = Number($(this).find('td input:unchecked').attr('value'));
            if (value !== undefined) {
                for (let i = 0; i < productList.length; i++) {
                    let val = Number(productList[i].id) + Number(productList[i].price);
                    if (val === value) {
                        productList.splice(i, 1);
                        i--;
                    }
                }
            }
            $(this).find('td input:unchecked').closest('tr').remove();
        });
        console.log(productList);
    });

    selectors.reset_btn.on('click', function (e) {
        e.preventDefault(); e.stopPropagation();
        sessionStorage.clear();
        templateProducts.length = 0;
        selectors.ess_code.val(null);
        selectors.employee_name.val(null);
        selectors.employee_phone.val(null);
        selectors.designation.val(null);
        selectors.workingArea.val(null);
        selectors.template_body.html(" ");
        selectors.divisions.html(" ");
        selectors.districts.html(" ");
        selectors.upazilas.html(" ");
        selectors.addedProducts.html(" ");
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
            eSSCode: selectors.ess_code.val(),
            employeeId: $('#employeeId').val(),
            employeeName: selectors.employee_name.val(),
            designation: selectors.designation.val(),
            workingArea: selectors.workingArea.val(),
            employeePhone: selectors.employee_phone.val(),
            divisions: divisions,
            districts: districts,
            upazilas: upazilas,
            products: productList
        };

        console.log(postObject);

        $.ajax({
            type: 'POST',
            url: '/ESSInfoes/Create',
            dataType: 'json',
            data: postObject,
            success: function (response) {
                console.log(response);
                selectors.ess_code.val(response.essCode);
                $('#employeeId').val(response.employeeId);
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