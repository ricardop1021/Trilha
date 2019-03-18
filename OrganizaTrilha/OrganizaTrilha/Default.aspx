<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OrganizaTrilha._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron" style="text-align:center">
        <h2>Ricardo Pereira de Fátima</h2>
        <p class="lead">Teste back-end C#</p>
        <p> Telefone: (31)9859-1441</p>
       
    </div>
    
    <div class="row">
       
        <asp:GridView ID="GVtrilhas" runat="server" AutoGenerateColumns="false" CellPadding="3" ForeColor="#333333" GridLines="None" horizontalalign="Center" Width="650px" >

            <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
            <Columns>

                <asp:TemplateField HeaderText="Horário">
                    <ItemTemplate ><%#Eval("Hr_inicio") %>    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Palestra">
                    <ItemTemplate><%#Eval("Nome") %>    </ItemTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Duração">
                    <ItemTemplate><%#Eval("Tempo") %>    </ItemTemplate>
                </asp:TemplateField>





            </Columns>
            
            <EditRowStyle BackColor="#2461BF"></EditRowStyle>

            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

            <PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

            <RowStyle BackColor="#E6E8FA"></RowStyle>

            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

            <SortedAscendingCellStyle BackColor="#E6E8FA"></SortedAscendingCellStyle>

            <SortedAscendingHeaderStyle BackColor="#6D95E1"></SortedAscendingHeaderStyle>

            <SortedDescendingCellStyle BackColor="#E9EBEF"></SortedDescendingCellStyle>

            <SortedDescendingHeaderStyle BackColor="#4870BE"></SortedDescendingHeaderStyle>
        </asp:GridView>

    </div>



</asp:Content>
