$(function () {
    var url = window.location.href;
    var str = url.split('/');
    var name = str[str.length - 1];
    $.getJSON('ashx/GetButton.ashx?pageName=' + name, function (msg) {
        var str = '';
        for (var i = 0; i < msg.length; i++) {
            str += '&nbsp;&nbsp;<a href="javascript:void(0)" onclick="' + msg[i].BtnCode + '()"><span class="' + msg[i].Icon + '">&nbsp;</span>' + msg[i].ButtonName + '</a>';

        }
        $('.btabs').append(str);
    })
});