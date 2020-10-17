(function ($) {

    $.fn.uploader = function (options) {
        var settings = $.extend({
            acceptedFileTypes: ['pdf', 'jpg', 'jpeg', 'png', 'doc', 'docx']
        }, options);

        var uploadId = 1;

        $('.file-uploader__message-area p').text(options.MessageAreaText || settings.MessageAreaText);

        //create and add the file list and the hidden input list
        var fileList = $('<ul class="file-list"></ul>');
        var hiddenInputs = $('<div class="hidden-inputs hidden" style="display:none"></div>');
        $('.file-uploader__message-area').after(fileList);
        $('.file-list').after(hiddenInputs);

        //xử lý khi chọn file
        $('.file-chooser__input').on('change', function () {
            var file = $('.file-chooser__input').val();
            var fileName = (file.match(/([^\\\/]+)$/)[0]);
            $('.file-chooser__input').attr('name', 'FileUploads')
            //validate the file
            var check = checkFile(fileName);
            if (check === "valid") {
                // move the 'real' one to hidden list
                $('.hidden-inputs').append($('.file-chooser__input'));


                //insert a clone after the hiddens (copy the event handlers too)
                $('.file-chooser').append($('.file-chooser__input').clone({ withDataAndEvents: true }));

                //add the name and a remove button to the file-list
                $('.file-list tbody').append('<tr><td>' + fileName + '<td class="table_action"><button class="btn-action btn-delete removal-button" data-uploadid="' + uploadId + '"><i class="fa fa-trash-o"></i> </button></td></tr>');
                //$('.file-list').find("li:last").show(800);

                //removal button handler


                //so the event handler works on the new "real" one
                $('.hidden-inputs .file-chooser__input').removeClass('file-chooser__input').attr('data-uploadId', uploadId);


                uploadId++;

                $('.removal-button').on('click', function (e) {
                    e.preventDefault();
                    //remove the corresponding hidden input
                    $('.hidden-inputs input[data-uploadid="' + $(this).data('uploadid') + '"]').remove();

                    //remove the name from file-list that corresponds to the button clicked
                    $(this).parent().parent().hide("puff").delay(10).queue(function () { $(this).remove(); });


                });

            } else {

            }
            $('.file-chooser__input').attr('name', '');
        });

        var checkFile = function (fileName) {
            var accepted = "invalid",
                acceptedFileTypes = this.acceptedFileTypes || settings.acceptedFileTypes,
                regex;

            for (var i = 0; i < acceptedFileTypes.length; i++) {
                regex = new RegExp("\\." + acceptedFileTypes[i] + "$", "i");

                if (regex.test(fileName)) {
                    accepted = "valid";
                    break;
                } else {
                    accepted = "badFileName";
                }
            }

            return accepted;
        };
    };
}(jQuery));

//init
$(document).ready(function () {
    $('.fileUploader').uploader({
        MessageAreaText: "No files selected. Please select a file."
    });
});
