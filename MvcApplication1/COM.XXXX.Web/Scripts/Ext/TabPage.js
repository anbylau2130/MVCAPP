//通过其他按钮生成tab页
TabPage = function () {

}
//生成tab页 url：页面路径 ;nodeText tab页的显示名称
//示例  BuidTabPage('Default2.aspx'); 根据url自动去xml文件查找相对应的名称
////示例  BuidTabPage('Default2.aspx','Tab名称'); 不去查找XML文件中与Default2.aspx路径相关的名称与Id
TabPage.prototype.AddTab = function (url, nodeText, nodeId,val) {
    if (nodeId == undefined || nodeId == null)
        nodeId = nodeText;
    //var WinIndex = window.parent.parent.window == undefined || window.parent.parent.window == null ? window.parent.window : window.parent.parent.window;
var WinIndex;
	if(val == undefined || val == null)
		WinIndex = window.parent.window;
	else
		WinIndex = window;
    if (WinIndex == undefined || WinIndex == null) {
        return;
    }

    //var contentPanel = WinIndex.contentPanel;
    //var contentPanel = WinIndex.document.body.children.content;
    var contentPanel = WinIndex.Ext.getCmp("content");
    try {
        WinIndex.event.stopEvent();
    } catch (e) {

    }
    try {
        var n = contentPanel.getComponent(nodeId);
        var iframeId = 'if_' + nodeId;
        if (n != undefined && n) { //判断是否已经打开该面板 
            contentPanel.remove(nodeId);
        }
        n ={
            'id': nodeId,
            'title': nodeText,
            closable: true,  //通过html载入目标页
            html: '<iframe id =' + iframeId + ' name =' + iframeId + ' scrolling="auto" frameborder="0" width="100%" height="100%" src=' + unescape(url) + '></iframe>'
        };
        contentPanel.add(n)
        contentPanel.setActiveTab(n);
    } catch (e) {
        // alert("生成tab页出错：" + e.Message);
    }
}
TabPage.prototype.RemoveTab = function (nodeId) {
    try {
        var WinIndex = window.parent.parent.window == undefined || window.parent.parent.window == null ? window.parent.window : window.parent.parent.window;
        WinIndex.contentPanel.remove(nodeId);
    } catch (e) {

    }
}

TabPage.prototype.AddTabItem = function (url,nodetext,nodeid,tabpanel) {
    var url = url;
    var id = nodeid;
    if (url) {
        if (!tabpanel) {
            tabpanel.setActiveTab(p);
        } else {
            var p = tabpanel.getComponent(nodeid);
            if (p != undefined || p)
            {
                tabpanel.remove(p);
            }
                
            p = new Ext.Panel({
                title: nodetext,
                closable: true,
                autoScroll: true,
                layout: 'fit',
                id: id,
                items: [{
                    html: "<iframe id=\"ifmain\" width=\"100%\" height=\"100%\" scrolling=\"auto\" frameborder=\"0\" src=\"" + url + "\" ></iframe>"
                }]
            });
            tabpanel.add(p);
            tabpanel.setActiveTab(p);
        }
    }
}

TabPage.prototype.RefrashTab = function (tabNodeId, nodeText, url) {
    try {
        var WinIndex = window.parent.parent.window == undefined || window.parent.parent.window == null ? window.parent.window : window.parent.parent.window;
        if (WinIndex == undefined || WinIndex == null) {
            return;
        }
        var contentPanel = WinIndex.contentPanel;
        var n = contentPanel.getComponent(tabNodeId);

        if (n != undefined && n) { //判断是否已经打开该面板 
            var tabPage = window.parent == null || window.parent == undefined ? window.parent.parent.frames[nodeId] : window.parent.frames[nodeId];
            if (tabPage != null && tabPage != undefined) {
                try {
                    tabPage.location.reload();
                } catch (e) {
                    tab.AddTab(url, nodeText, tabNodeId);
                }
            }
            contentPanel.setActiveTab(n);
        }
    } catch (e) {

    }
}
var tab = new TabPage();


