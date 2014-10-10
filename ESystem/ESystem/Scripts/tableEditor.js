﻿(function() {
    $(".remove-node").click(function (event) {
        event.preventDefault();
        var url = $(this).data('url');

        var parent = $(this).closest('tr');
        $.ajax(
        {
            url: url,
            success: function () {
                parent.hide();
            },
            erorr: function () {
                errorHandler(null, parent);
            }
        });
    });
    (function () {
        $('table').on('mousedown', function (event) {
            //  event.preventDefault();
        });

        $('.dynamic-content').on('dblclick', function () {

            var curEditor = $(document).find('#editor');

            var parent = null;

            if (curEditor.length) {
                parent = curEditor.closest('tr');

                completeEdit(parent.data('id'), curEditor.find('input').val(), parent.data('parent'), curEditor.closest('.dynamic-content'), parent);
            }

            var self = $(this);
            parent = self.closest('tr');

            var editor = $("<div id='editor' class='form-inline'/>");

            var textarea = $("<input type='text' class='form-control' style='margin-right:5px;min-width: 650px;'>").val(self.text());

            var saveBtn = $("<button class='btn btn-success glyphicon glyphicon-ok'></button>");

            saveBtn.on('click', function () {
                completeEdit(parent.data('id'), editor.find('input').val(), parent.data('parent'), self, parent);
            });

            editor.append(textarea).append(saveBtn);

            self.html(editor);

        });
    })();

    function completeEdit(id, value, parentId, container, parent) {
        container.html(value);

        var params = {
            id: id,
            data: value,
            parentId: parentId
        };

        $.ajax('SaveQue', {
            data: params, success: function (response) {
                if (response) {
                    if (response.code == 0) {
                        container.append('<span class="label label-success pull-right" id="state">Успешно сохранено!</span>');
                        parent.addClass('success');
                    } else {
                        errorHandler(container, parent);
                        container.html($('<span class="label label-danger pull-right" >Не сохранено!Ошибка!</span>'));
                        parent.addClass('error');
                    }
                }
                setTimeout(function () {
                    $('#state').remove();
                    parent.removeClass('success error');
                }, 3000);
            }, error: function () { errorHandler(container, parent); }
        });
    }

    function errorHandler(container, parent) {
        if (container)
            container.html($('<span class="label label-danger" >Не сохранено! Ошибка!</span>'));

        parent.addClass('error');
    }

    function setActive(parentId) {

        $(document).find('tbody tr').removeClass('active');

        if (!parseInt(parentId)) return;

        var $elem = $(document).find('tbody').find('[data-id=' + parentId + ']');

        $('html, body').animate({
            scrollTop: $elem.offset().top
        }, 1000);

        $elem.addClass('active');
    }
})();
