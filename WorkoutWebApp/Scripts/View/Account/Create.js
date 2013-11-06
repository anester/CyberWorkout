$(function () {
    var $msgemail = $('#msgemail'),
        $msghandle = $('#msghandle');

    $('#tbemail').change(function () {
        var $this = $(this),
            $mssgbox = $('#msgemail'),
            val = $this.val(),
            $btn = $('#btncreate');

        $.post('/api/AccountChecks', { FieldName: 'email', FieldValue: val }, function (data) {
            if (data) {
                $mssgbox.show();
                $btn.prop('disabled', true);
            }
            else {
                $mssgbox.hide();
                if (!$msgemail.is(':visible') && !$msghandle.is(':visible')) {
                    $btn.prop('disabled', false);
                }
            }
        }).error(function (e) {
        });
    });

    $('#tbhandle').change(function () {
        var $this = $(this),
            $mssgbox = $('#msghandle'),
            val = $this.val(),
            $btn = $('#btncreate');

        $.post('/api/AccountChecks', { FieldName: 'handle', FieldValue: val }, function (data) {
            if (data) {
                $mssgbox.show();
                $btn.prop('disabled', true);
            }
            else {
                $mssgbox.hide();
                if (!$msgemail.is(':visible') && !$msghandle.is(':visible')) {
                    $btn.prop('disabled', false);
                }
            }
        }).error(function (e) {
        });
    });
});