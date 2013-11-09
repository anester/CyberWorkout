(function Main() {
    var $btnCreate = $('#btnCreate'),
        $newExerciseDiv = $('#newExerciseDiv');
    $btnCreate.click(function () {

        $(function Ready() {
            $.get("/Exercise/CreateExerciseFormPart")
             .done(function (data) {
                 $newExerciseDiv.html(data).dialog({
                     width: 800,
                     height: 600,
                     buttons: {
                         "Create": function () {
                             var obj = {};

                             $('.form-control', $newExerciseDiv).each(function (i, elem) {
                                 var $cont = $(elem);

                                 obj[$cont.attr('data-prop')] = $cont.val();
                             });

                             $.post('/api/ExerciseJson', obj).done(function () {

                             });
                         }
                     }
                 });
             }).error(function (e) {
                 alert(e);
             });
        })
    });
})();