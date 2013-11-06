$(function () {
    $('#tbemail').change(function () {
        var $this = $(this),
            $mssgbox = $('#msgemail'),
            val = $this.val();

        $.post('/api/AccountChecks/email', { FieldName: 'email', FieldValue: val }, function (data) {
            if (data) {
                $mssgbox.show();
            }
            else {
                $mssgbox.hide();
            }
        }).error(function (e) {
        });
    });
});