
Ext.QuickTips.init();
LoginWindow = Ext.extend(Ext.Window, {
    title: '登陆系统',
    width: 275,
    height: 155,
    collapsible: true,
    defaults: {
        border: false
    },
    buttonAlign: 'center',

    createFormPanel: function () {

        //表单重置函数
        function reset() {
            myform.form.reset();
        };

        //表单提交函数
        function surely() {
            if (myform.getForm().isValid()) {
                myform.form.submit({
                    waitMsg: '正在登录......',
                    url: '../../../index/login',
                    timeout: 3000,
                    success: function (form, action) {

                        if (action.result.type == 0)//OP
                            window.location.href = '../op/index.html';
                        else//CP
                            window.location.href = 'index.html';

                    },
                    failure: function (form, action) {
                        form.reset();
                        if (action.failureType == Ext.form.Action.SERVER_INVALID)
                            Ext.MessageBox.alert('警告', action.result.errors.msg);
                    }
                });
            }
        };

        var myform = new Ext.form.FormPanel({
            bodyStyle: 'padding-top:6px',
            defaultType: 'textfield',
            labelAlign: 'right',
            labelWidth: 55,
            labelPad: 2,
            //frame : true,
            method: 'POST',
            //增加表单键盘事件
            keys: [
             {
                 key: [10, 13],
                 fn: surely
             }],
            defaults: {
                allowBlank: false,
                width: 158
            },
            items: [{
                cls: 'user',
                name: 'username',
                fieldLabel: '帐 号',
                blankText: '帐号不能为空'
            }, {
                cls: 'key',
                name: 'password',
                fieldLabel: '密 码',
                blankText: '密码不能为空',
                inputType: 'password'
            }, {
                cls: 'key',
                name: 'randCode',
                id: 'randCode',
                fieldLabel: '验证码',
                width: 70,
                blankText: '验证码不能为空'
            }],
            buttons: [
            {
                text: '确定',
                id: 'sure',
                handler: surely
            },
            {
                text: '重置',
                id: 'clear',
                handler: reset
            }]
        });
        return myform;
    },

    initComponent: function () {

        LoginWindow.superclass.initComponent.call(this);
        this.fp = this.createFormPanel();
        this.add(this.fp);

    }
});


Ext.onReady(function () {
    var win = new LoginWindow();

    win.show();
    var bd = Ext.getDom('randCode');
    var bd2 = Ext.get(bd.parentNode);
    bd2.createChild({ tag: 'img', src: 'code.php', align: 'absbottom' });

});



//  body {
//    background-color:#29B3FB
//}

//<script type="text/javascript">
//    var uname = new Ext.form.TextField({
//        id: 'uname',
//        frame:false,
//        labelStyle: 'margin-top:10px;margin-left:20px;',
//        style: 'margin-top:15px;margin-left:20px;',
//        fieldLabel: '用户名',
//        name: 'name',//元素名称
//        //anchor:'95%',//也可用此定义自适应宽度
//        allowBlank: false,//不允许为空
//        value: "admin",
//        blankText: '用户名不能为空'//错误提示内容
//    });
//var pwd = new Ext.form.TextField({
//    id: 'pwd',
//    labelStyle: 'margin-top:10px;margin-left:20px;',
//    style:'margin-top:10px;margin-left:20px;',
//    //xtype: 'textfield',
//    inputType: 'password',
//    fieldLabel: '密　码',
//    //anchor:'95%',
//    maxLength: 10,
//    name: 'password',
//    allowBlank: false,
//    value: "12345",
//    blankText: '密码不能为空'
//});

//Ext.onReady(function () {
//    //使用表单提示
//    Ext.QuickTips.init();
//    Ext.form.Field.prototype.msgTarget = 'side';

//    //定义表单
//    var simple = new Ext.FormPanel({
//        title:"登陆",
//        labelWidth: 75,
//        defaults: {
//            width: 150
//        },
//        defaultType: 'textfield',//默认字段类型
//        bodyStyle: 'background: #cdcdcd;padding:50 0 0 50;',
//        border: false,
//        buttonAlign: 'center',
//        border: false,
//        id: "form",
//        //定义表单元素
//        items: [uname, pwd],
//        buttons: [{
//            text: '登录',
//            type: 'submit',
//            id: 'sb',
//            //定义表单提交事件
//            handler: save,
                   
//        }, {
//            text: '重置',
//            handler: function () {
//                simple.form.reset();
//            }
//        }],
//        keys: [{
//            key: Ext.EventObject.ENTER,
//            fn: save,
//            scope: this
//        }]
//    });
//    function save() {
//        var userName = uname.getValue();
//        var userPass = pwd.getValue();
//        //验证合法后使用加载进度条
//        if (simple.form.isValid()) {
//            //提交到服务器操作
//            simple.form.submit({
//                waitMsg: '正在进行登陆验证,请稍后...',
//                url: 'login!checkUser.action',
//                method: 'post',
//                params: {
//                    userName: userName,
//                    userPass: userPass
//                },
//                //提交成功的回调函数
//                success: function (form, action) {
//                    if (action.result.msg == 'OK') {
//                        window.location.href = "login!index.action?userName=" + userName;
//                    } else if (action.result.msg == 'ERROR') {
//                        window.location.href = "index.jsp";
//                    }
//                },
//                //提交失败的回调函数
//                failure: function (form, action) {
//                    switch (action.failureType) {
//                        case Ext.form.Action.CLIENT_INVALID:
//                            Ext.Msg.alert('错误提示', '表单数据非法请核实后重新输入！');
//                            break;
//                        case Ext.form.Action.CONNECT_FAILURE:
//                            Ext.Msg.alert('错误提示', '网络连接异常！');
//                            break;
//                        case Ext.form.Action.SERVER_INVALID:
//                            Ext.Msg.alert('错误提示', "您的输入用户信息有误，请核实后重新输入！");
//                            simple.form.reset();
//                    }
//                }
//            });
//        }
//    };
//    //定义窗体
//    var win = new Ext.Window({
//        id: 'win',
//        layout: 'fit', //自适应布局   
//        align: 'center',
//        width: 330,
//        height: 182,
//        resizable: false,
//        draggable: false,
//        border: false,
//        bodyStyle: 'padding:5px;background:gray',
//        maximizable: false,//禁止最大化
//        closeAction: 'close',
//        closable: false,//禁止关闭,
//        items: simple
//        //将表单作为窗体元素嵌套布局
//    });
//    win.show();//显示窗体
//    pwd.focus(false, 100);
//});
//</script>