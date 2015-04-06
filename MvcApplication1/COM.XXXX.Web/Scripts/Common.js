/// <reference path="jquery-easyui-1.4.2/jquery.min.js" />
// 对Date的扩展，将 Date 转化为指定格式的String   
// 月(M)、日(d)、小时(h)、分(m)、秒(s)、季度(q) 可以用 1-2 个占位符，   
// 年(y)可以用 1-4 个占位符，毫秒(S)只能用 1 个占位符(是 1-3 位的数字)   
// 例子：   
// (new Date()).Format("yyyy-MM-dd hh:mm:ss.S") ==> 2006-07-02 08:09:04.423   
// (new Date()).Format("yyyy-M-d h:m:s.S")      ==> 2006-7-2 8:9:4.18   
Date.prototype.Format = function (fmt) { //author: meizz   
    var o = {
        "M+": this.getMonth() + 1,                 //月份   
        "d+": this.getDate(),                    //日   
        "h+": this.getHours(),                   //小时   
        "m+": this.getMinutes(),                 //分   
        "s+": this.getSeconds(),                 //秒   
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度   
        "S": this.getMilliseconds()             //毫秒   
    };
    if (/(y+)/.test(fmt))
        fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o)
        if (new RegExp("(" + k + ")").test(fmt))
            fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
    return fmt;
}

function fixHeight(percent) {
    return (document.body.clientHeight) * percent;
}

function fixWidth(percent) {
    return (document.body.clientWidth - 5) * percent;
}

function ShowDate(value) {
    var unixTimestamp = new Date(value);
    return unixTimestamp.Format("yyyy-MM-dd");
}

function ShowDateTime(value) {
    var unixTimestamp = new Date(value);
    return unixTimestamp.Format("yyyy-MM-dd hh:mm:ss");
}

function ShowSex(value) {
    if (value == 'man') {
        return "<span style='background-color:green'>男</span>";
    } else if (value == "woman") {
        return "<span style='background-color:red'>女</span>";
    }
};
function ShowState(value) {
    if (value == true) {
        return "是";
    } else if (value == false) {
        return "否";
    }
};
//分页方法
(function ($) {
    function pagerFilter(data) {
        if ($.isArray(data)) {    // is array  
            data = {
                total: data.length,
                rows: data
            }
        }
        var dg = $(this);
        var state = dg.data('treegrid');
        var opts = dg.treegrid('options');
        var pager = dg.treegrid('getPager');
        pager.pagination({
            onSelectPage: function (pageNum, pageSize) {
                opts.pageNumber = pageNum;
                opts.pageSize = pageSize;
                pager.pagination('refresh', {
                    pageNumber: pageNum,
                    pageSize: pageSize
                });
                dg.treegrid('loadData', state.allRows);
            }
        });
        opts.pageNumber = pager.pagination('options').pageNumber || 1;
        if (!state.allRows) {
            state.allRows = data.rows;
        }
        var topRows = [];
        var childRows = [];
        $.map(state.allRows, function (row) {
            row._parentId ? childRows.push(row) : topRows.push(row);
        });
        data.total = topRows.length;
        var start = (opts.pageNumber - 1) * parseInt(opts.pageSize);
        var end = start + parseInt(opts.pageSize);
        data.rows = $.extend(true, [], topRows.slice(start, end).concat(childRows));
        return data;
    }

    var appendMethod = $.fn.treegrid.methods.append;
    var removeMethod = $.fn.treegrid.methods.remove;
    var loadDataMethod = $.fn.treegrid.methods.loadData;
    $.extend($.fn.treegrid.methods, {
        clientPaging: function (jq) {
            return jq.each(function () {
                var state = $(this).data('treegrid');
                var opts = state.options;
                opts.loadFilter = pagerFilter;
                var onBeforeLoad = opts.onBeforeLoad;
                opts.onBeforeLoad = function (row, param) {
                    state.allRows = null;
                    return onBeforeLoad.call(this, row, param);
                }
                $(this).treegrid('loadData', state.data);
                if (opts.url) {
                    $(this).treegrid('reload');
                }
            });
        },
        loadData: function (jq, data) {
            jq.each(function () {
                $(this).data('treegrid').allRows = null;
            });
            return loadDataMethod.call($.fn.treegrid.methods, jq, data);
        },
        append: function (jq, param) {
            return jq.each(function () {
                var state = $(this).data('treegrid');
                if (state.options.loadFilter == pagerFilter) {
                    $.map(param.data, function (row) {
                        row._parentId = row._parentId || param.parent;
                        state.allRows.push(row);
                    });
                    $(this).treegrid('loadData', state.allRows);
                } else {
                    appendMethod.call($.fn.treegrid.methods, $(this), param);
                }
            })
        },
        remove: function (jq, id) {
            return jq.each(function () {
                if ($(this).treegrid('find', id)) {
                    removeMethod.call($.fn.treegrid.methods, $(this), id);
                }
                var state = $(this).data('treegrid');
                if (state.options.loadFilter == pagerFilter) {
                    for (var i = 0; i < state.allRows.length; i++) {
                        if (state.allRows[i][state.options.idField] == id) {
                            state.allRows.splice(i, 1);
                            break;
                        }
                    }
                    $(this).treegrid('loadData', state.allRows);
                }
            })
        },
        getAllRows: function (jq) {
            return jq.data('treegrid').allRows;
        }
    });

})(jQuery);


(function ($) {
    function datagridPagerFilter(data) {
        if ($.isArray(data)) {	// is array
            data = {
                total: data.length,
                rows: data
            }
        }
        var dg = $(this);
        var state = dg.data('datagrid');
        var opts = dg.datagrid('options');
        if (!state.allRows) {
            state.allRows = (data.rows);
        }
        var start = (opts.pageNumber - 1) * parseInt(opts.pageSize);
        var end = start + parseInt(opts.pageSize);
        data.rows = $.extend(true, [], state.allRows.slice(start, end));
        return data;
    }

    var datagridLoadDataMethod = $.fn.datagrid.methods.loadData;
    $.extend($.fn.datagrid.methods, {
        clientPaging: function (jq) {
            return jq.each(function () {
                var dg = $(this);
                var state = dg.data('datagrid');
                var opts = state.options;
                opts.loadFilter = datagridPagerFilter;
                var onBeforeLoad = opts.onBeforeLoad;
                opts.onBeforeLoad = function (param) {
                    state.allRows = null;
                    return onBeforeLoad.call(this, param);
                }
                dg.datagrid('getPager').pagination({
                    onSelectPage: function (pageNum, pageSize) {
                        opts.pageNumber = pageNum;
                        opts.pageSize = pageSize;
                        $(this).pagination('refresh', {
                            pageNumber: pageNum,
                            pageSize: pageSize
                        });
                        dg.datagrid('loadData', state.allRows);
                    }
                });
                $(this).datagrid('loadData', state.data);
                if (opts.url) {
                    $(this).datagrid('reload');
                }
            });
        },
        loadData: function (jq, data) {
            jq.each(function () {
                $(this).data('datagrid').allRows = null;
            });
            return datagridLoadDataMethod.call($.fn.datagrid.methods, jq, data);
        },
        getAllRows: function (jq) {
            return jq.data('datagrid').allRows;
        }
    })
})(jQuery);


function form2Json(id) {
    var arr = $("#" + id).serializeArray();
    var jsonStr = "";

    jsonStr += '{';
    for (var i = 0; i < arr.length; i++) {
        jsonStr += '"' + arr[i].name + '":"' + arr[i].value + '",';
    }
    jsonStr = jsonStr.substring(0, (jsonStr.length - 1));
    jsonStr += '}';

    var json = JSON.parse(jsonStr);
    return json;
};
function RadioGroupCheck(name, value) {
    var radios = document.getElementsByName(name);
    for (var i = 0; i < radios.length; i++) {
        if (radios[i].value == value) {
            radios[i].checked = true;
        }
    }
};

function GetRadioGroupChecked(name) {
    var radios = document.getElementsByName(name);
    for (var i = 0; i < radios.length; i++) {
        if (radios[i].checked) {
            return radios[i].value;
        }
    }
};
//}{
//    iconCls: 'icon-add',
//    plain: true,
//    text: '增添',
//    onClick: function () {
//        add();
//    }
//}, '-', {
//iconCls: 'icon-edit',
//plain: true,
//text: '编辑',
//onClick: function () {
//    edit();
//}
//}, '-', {
//    iconCls: 'icon-remove',
//    plain: true,
//    text: '删除',
//    onClick: function () {
//        remove();
//    }
//}