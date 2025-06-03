<%@ Control Language="C#" AutoEventWireup="true" CodeFile="JWSmallGroupDetail.ascx.cs" Inherits="RockWeb.Blocks.Utility.JWSmallGroupDetail" %>

<asp:Panel runat="server" ID="pnlContent" CssClass="panel panel-block">
    <div class="panel-heading">
        <h1 class="panel-title"><asp:Literal runat="server" ID="ltlName" /></h1>
    </div>
    <div class="panel-body">
        <asp:Literal runat="server" ID="ltlDescription" /><br /><br />
        <strong>Date Created:</strong> <asp:Literal runat="server" ID="ltlDateCreated" /><br />
        <strong>Date Modified:</strong> <asp:Literal runat="server" ID="ltlDateModified" /><br />
        <strong>Capacity:</strong> <asp:Literal runat="server" ID="ltlCapacity" />
    </div>
</asp:Panel>