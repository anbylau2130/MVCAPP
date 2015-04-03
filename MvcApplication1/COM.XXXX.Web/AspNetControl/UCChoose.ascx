<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCChoose.ascx.cs" Inherits="COM.XXXX.Web.AspNetControl.UCChoose" %>

<div id="win">
    <input id="btnTypeid" type="hidden" />
    <table style="border: 0; height: 300px; width: 500px;margin-top:20px" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td width="45%" valign="top">
                <div style="width: 100%; height: 400px; border: 1px solid #b3daf4;">
                    <ul id="tree1" style="margin:10px"></ul>
                </div>
            </td>
            <td align="center">
                <input type="button" id="add"  class="button1" onclick="winadd()" style="margin: 1px;" value="增加"><br />
                <br />
                <input type="button" id="delete" class="button1" onclick="windelete()" style="margin: 1px;" value="删除"><br />
                <br />
                <input type="button" id="confirm" class="button1"  onclick="winconfirm()" style="margin: 1px;" value="确定"><br />
                <br />
                <input type="button" id="cancel" class="button1" onclick="winclose()" style="margin: 1px;" value="取消"><br />
                <br />
            </td>
            <td width="45%" valign="top">
                <div style="width: 100%; height: 400px; border: 1px solid #b3daf4;">
                    <ul id="tree2" style="margin:10px"></ul>
                </div>
            </td>
        </tr>
    </table>
</div>

