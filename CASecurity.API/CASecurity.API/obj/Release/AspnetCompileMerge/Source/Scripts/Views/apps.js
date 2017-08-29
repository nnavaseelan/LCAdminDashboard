$(document).ready(function()
{
    loadAppList();
    //alert("loading");
    $('#btnSave').click(function (e) {
        e.preventDefault();

        var formData = {
            'BankId': $('#BankId').val(),
            'Name': $('input[name=Name]').val(),
            'BRC': $('input[name=BRC]').val(),
            'Address': $('input[name=Address]').val(),
            'Code': $('input[name=Code]').val(),
            'RedirectTo': 'App'
        };
        console.log(formData);

        $.ajax({
            url: "../Admin/Merchant",
            type: "post",
            data: formData,
            success: function (d) {

                clearMerchantInputs();
                location.reload();

            }
        });

    });
    $('#btnAppSave').click(function (e) {
        e.preventDefault;

        var formData = {
            'BankId': $('#BankId').val(),
            'MerchantId': $('#MerchantId').val(),
            //'BMCode': $('input[name=BMCode]').val(),
            'Name': $('input[name=AppName]').val(),
            'Package': $('input[name=AppPackage]').val(),
            'Address': $('input[name=AppAddress]').val(),
            'Code': $('input[name=AppCode]').val(),
            'PlatForm': $('input[name=AppPlatForm]').val(),
            'Production': $('input[name=AppProduction]').val(),
            'SandBox': $('input[name=AppSandBox]').val(),
            'JustPayCode': '-'
        };
    
        $.ajax({
            url: "../Admin/App",
            type: "post",
            data: formData,
            success: function (d) {
                loadAppList();
                clearAppInputs();
            }
        });

    });


    $('#btnAdd').click(function () {
        var bank = $('#BankId option:selected').text();
        $('#spnBank').html(bank)
        clearMerchantInputs();
        $('#myModal').modal();
    });


    $('#btnAddApp').click(function () {
        clearAppInputs();
        $('#myAppModal').modal();
    });

    $('#MerchantId').change(function () {
        loadAppList();
    });

    function loadAppList()
    {
        var bankId = $('#BankId').val();
        var merchantId = $('#MerchantId').val();

        url = "../Admin/AppList?bankId=" + bankId + "&merchantId=" + merchantId;

        $.ajax({
            url: url,
            type: "get",
            dataType: 'html',
            contentType: 'application/html;'
        }).
            success(function (data) {
                $('#divAppList').html(data);
            })
    }
    function clearAppInputs() {
        $('input[name=AppName]').focus();
        $('input[name=AppName]').val("");
        $('input[name=AppPackage]').val("");
        $('input[name=AppAddress]').val("");
        $('input[name=AppCode]').val("");
        $('input[name=AppPlatForm]').val("");
        $('input[name=AppProduction]').val("");
        $('input[name=AppSandBox]').val("");
    }
    function clearMerchantInputs() {
        $('input[name=Name]').focus();
        $('input[name=Name]').val("");
        $('input[name=BRC]').val("");
        $('input[name=Address]').val("");
        $('input[name=Code]').val("");
    }

    
});
