<%@ Control Language="C#" AutoEventWireup="true" CodeFile="JWSmallGroupList.ascx.cs" Inherits="RockWeb.Blocks.Utility.JWSmallGroupList" %>

<asp:Panel runat="server" ID="pnlContent" CssClass="panel panel-block">
    <asp:Repeater ID="rptGroups" runat="server" OnItemCommand="rptGroups_ItemCommand">
        <HeaderTemplate>
            <ul class="list-group">
        </HeaderTemplate>
            <%-- link to small group detail --%>
            <ItemTemplate>
                <li class="list-group-item">
                    <asp:LinkButton runat="server" 
                        CommandName="ViewGroup" 
                        CommandArgument='<%# Eval("Id") %>' 
                        Text='<%# Eval("Name") %>' 
                        CssClass="btn btn-link"
                        OnClientClick='<%# "window.location.href=\"" + GetGroupDetailUrl(Eval("Id")) + "\"; return false;" %>' />
                </li>
            </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
</asp:Panel>