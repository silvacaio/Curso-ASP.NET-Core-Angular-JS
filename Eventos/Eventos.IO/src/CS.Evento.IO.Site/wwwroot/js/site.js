function ValidacoesEvento() {
    $.validator.methods.range = function (value, element, param) {
        var globalizedValue = value.replace(",", ".");
        return this.optional(element) || (globalizedValue >= param[0] && globalizedValue <= param[1]);
    };

    $.validator.methods.number = function (value, element) {
        return this.optional(element) || /^-?(?:\d+|\d{1,3}(?:[\s\.,]\d{3})+)(?:[\.,]\d+)?$/.test(value);
    };

    toastr.options = {
        "closeButton": false,
        "debug": false,
        "newestOnTop": false,
        "progressBar": false,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    };

    $("#DataInicio").datepicker({
        format: "dd/mm/yyyy",
        startDate: "tomorrow",
        language: "pt-BR",
        orientation: "bottom right",
        autoclose: true
    });

    $("#DateFinal").datepicker({
        format: "dd/mm/yyyy",
        startDate: "tomorrow",
        language: "pt-BR",
        orientation: "bottom right",
        autoclose: true
    });

    // Validações de exibição do endereço
    $(function () {
        let $inputOnline = $("#Online");

        MostrarEndereco();

        $inputOnline.click(function () {
            MostrarEndereco();
        });

        function MostrarEndereco() {
            let $form = $("#EnderecoForm");
            if ($inputOnline.is(":checked"))
                $form.hide();
            else
                $form.show();
        }

        let $inputGratuito = $("#Gratuito");
        MostrarValor();
        $inputGratuito.click(function () {
            MostrarValor();
        });

        function MostrarValor() {
            let $inputValor = $("#Valor");
            if ($inputGratuito.is(":checked")) {
                $inputValor.val("0");
                $inputValor.prop("disabled", true);
            }
            else {
                $inputValor.prop("disabled", false);
            }
        }

    });
}

function AjaxModal() {
    $(function () {
        $.ajaxSetup({ cache: false });

        $("a[data-modal]").on("click", function (e) {
            $("#myModalContent").load(this.href,
                function () {
                    $("#myModal").modal({
                        keyboard: true
                    },
                        "show");
                    bindForm(this);
                });
            return false;
        });
    });


    function bindForm(dialog) {
        $("form", dialog).submit(function () {
            $.ajax({
                url: this.action,
                type: this.method,
                data: $(this).serialize(),
                success: function (result) {
                    if (result.success) {
                        $("#myModal").modal("hide");
                        $("#EnderecoTarget").load(result.url); //Carrega o resultado do HTML para a div
                    } else {
                        $("#myModalContent").html(result);
                        bindForm(dialog);
                    }
                }
            });
            return false;
        });
    }

}