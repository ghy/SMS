/*
Copyright (c) 2003-2011, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function (config) {
    // Define changes to default configuration here. For example:
    config.language = $.cookie("CULTUREKEY");
    config.toolbar = [
//                ['Source', '-', 'DocProps', 'Preview', 'Print', '-', 'Templates'],
//                ['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord', '-', 'Undo', 'Redo'],
//                ['Find', 'Replace', '-', 'SelectAll', '-', 'SpellChecker', 'Scayt'],
//                ['Form', 'Checkbox', 'Radio', 'TextField', 'Textarea', 'Select', 'Button', 'ImageButton', 'HiddenField'],
//                ['Bold', 'Italic', 'Underline', 'Strike', 'Subscript', 'Superscript', '-', 'RemoveFormat'],
//                ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', '-', 'Blockquote', 'CreateDiv', '-', 'JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock', '-', 'BidiLtr', 'BidiRtl'],
//                ['Link', 'Unlink', 'Anchor'],
//                ['Image', 'Flash', 'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak', 'Iframe'],
//                ['Styles', 'Format', 'Font', 'FontSize'],
//                ['TextColor', 'BGColor'],
    //                ['Maximize', 'ShowBlocks']
                ['Source', 'Styles', 'Format', 'Font', 'FontSize'],
                ['TextColor', 'BGColor'],
                ['Bold', 'Italic', 'Underline', 'Strike', 'Subscript', 'Superscript'], ['RemoveFormat',
                'NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', '-', 'Blockquote', 'CreateDiv', '-', 'JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock', '-', 'BidiLtr', 'BidiRtl'],
                ['Maximize']
            ];
    config.enterMode = CKEDITOR.ENTER_BR;
};
