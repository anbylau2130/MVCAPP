//导航
var treePanel = function (title, data) {
    return {
        region: 'west',
        xtype:'treepanel',
        collapsible: true,
        title: title,
        width: 200,
        autoScroll: true,
        split: true,
        loader: new Ext.tree.TreeLoader(),
        root: new Ext.tree.AsyncTreeNode({
            expanded: true,
            children: data
        }),
        rootVisible: false,
        listeners: {
            click: function (n) {
                tab.AddTabItem(n.attributes.url, n.attributes.text, n.attributes.id, Ext.getCmp("content"))
            }
        }
    });
}