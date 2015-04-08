<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IconPiker.ascx.cs" Inherits="COM.XXXX.Web.AspNetControl.IconPicker" %>
<%@ Import Namespace="System.IO" %>
<style>
    .iconwidth {
        width:16px;
        height:16px;
        margin:1px;
        display: inline-block;
    }
</style>
<input id="<%=this.ID %>" name="<%=this.ID %>" style="<%=this.Style%>"> 
<div id="<%=this.NewGuid %>">
    <div style="padding: 10px">
        <%
            string path = Server.MapPath(Com.XXXX.Class.ConstHelper.IconPath);

            DirectoryInfo icondir = new DirectoryInfo(path);

            foreach (FileInfo item in icondir.GetFiles())
            {

                string iconclass = "icon-" + item.Name.Split('.')[0];
        %>
                 <span class="iconwidth <%=iconclass %>" value="<%=iconclass %>" onclick="seticon(this)">&nbsp;&nbsp;</span>
        <%  
            } 
        %>
    </div>
</div>

<script type="text/javascript">
    
    $(function() {
        $('#<%=this.ID %>').combo({
            width: 200,
            height: 20,
            panelWidth: 400,
            panelHeight: 400
        });
        $('#<%=this.NewGuid %>').appendTo($('#<%=this.ID %>').combo('panel'));
    })
    function seticon(span) {
        if (span) {
            $('#<%=this.ID %>').combo("setText", $(span).attr("value"));
            $('#<%=this.ID %>').combo("setValue", $(span).attr("value"));
        }
    }

</script>