
//以窗体打开连接
function openWindow(id, title, width, height, href, icon,ismodal) {
   var win = $('#' + id);
   win.window("clear");
   //win.window("close");
   win.window({
        title: title,
        width: width,
        height: height,
        closed: false,
        border: false,
        cache: false,
        iconCls:icon,
        content:'<iframe id="iframe_content" scrolling="no" frameborder="0"  src="' + href + '" style="width:100%;height:100%;overflow:hidden"></iframe>',
        modal: ismodal,
        onResize: function(width, height) {
            //win.window("doLayout");
        }
   });
   //window.setInterval("reinitIframe()", 200);
 
}
function reinitIframe() {
    var iframe = document.getElementById("iframe_content");
    try {
        var bHeight = iframe.contentWindow.document.body.scrollHeight-1;
        var dHeight = iframe.contentWindow.document.documentElement.scrollHeight;
        var height = Math.max(bHeight, dHeight);
        iframe.height = height;
    } catch (ex) { }
}

function OpenTab(id, title, href, icon) {
    var tt = $('#'+id);
    if (tt.tabs('exists', title)) {//如果tab已经存在,则选中并刷新该tab          
        tt.tabs('select', title);
        refreshTab({ tabTitle: title, url: href });
    } else {
        var content;
        if (href) {
            content = '<iframe scrolling="no" frameborder="0"  src="' + href + '" style="width:100%;height:100%;overflow:hidden"></iframe>';
        } else {
            content = '未实现';
        }
        tt.tabs('add', {
            title: title,
            closable: true,
            content: content,
            iconCls: icon || 'icon-default'
        });
    }
}
/**     
 * 刷新tab 
 *example: {tabTitle:'tabTitle',url:'refreshUrl'} 
 *如果tabTitle为空，则默认刷新当前选中的tab 
 *如果url为空，则默认以原来的url进行reload 
 */
function refreshTab(cfg) {
    var refresh_tab = cfg.tabTitle ? $('#content').tabs('getTab', cfg.tabTitle) : $('#content').tabs('getSelected');
    if (refresh_tab && refresh_tab.find('iframe').length > 0) {
        var _refresh_ifram = refresh_tab.find('iframe')[0];
        var refresh_url = cfg.url ? cfg.url : _refresh_ifram.src;
        //_refresh_ifram.src = refresh_url;  
        _refresh_ifram.contentWindow.location.href = refresh_url;
    }
}