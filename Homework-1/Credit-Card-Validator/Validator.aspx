<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validator.aspx.cs" Inherits="Credit_Card_Validator.Validator" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Credit Card Verification</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" integrity="sha384-rbsA2VBKQhggwzxH7pPCaAqO46MgnOM80zW1RWuH61DGLwZJEdK2Kadq2F9CUG65" crossorigin="anonymous">
    <style>
        .error {
            color: red;
            font-weight: bold;
            font-size: 0.8rem;
            margin-top: 0.25rem;
        }
    </style>
</head>
<body>
 <div class="d-flex align-items-lg-start m-lg-5"> <!-- Centering container -->
    <form id="creditCardForm" runat="server" class="w-50 h-50">
        <h1 class="mb-5">Credit Card Verification</h1>
        <div class="row">
            <div class="col-md-6 mb-3">
                <label for="cardNumber" class="form-label">Card Number:</label>
                <asp:TextBox ID="cardNumber" runat="server" CssClass="form-control"></asp:TextBox>
                
            </div>
            <div class="col-md-6 mb-3">
                <label for="cardholderName" class="form-label">Cardholder Name:</label>
                <asp:TextBox ID="cardholderName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-4 mb-3">
                <label for="cardholderName" class="form-label">CVV:</label>
                <asp:TextBox ID="cardCVV" runat="server" CssClass="form-control"></asp:TextBox>
                
            </div>
            <div class="col-md-8 mb-3">
                <label for="expirationMonth" class="form-label">Expiration Date:</label>
                <div class="row">
                    <div class="col-md-6">
                        <asp:DropDownList ID="expirationMonth" runat="server" CssClass="form-select">
                            <asp:ListItem Text="Month" Value="" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="January" Value="01"></asp:ListItem>
                            <asp:ListItem Text="February" Value="02"></asp:ListItem>
                            <asp:ListItem Text="March" Value="03"></asp:ListItem>
                            <asp:ListItem Text="April" Value="04"></asp:ListItem>
                            <asp:ListItem Text="May" Value="05"></asp:ListItem>
                            <asp:ListItem Text="June" Value="06"></asp:ListItem>
                            <asp:ListItem Text="July" Value="07"></asp:ListItem>
                            <asp:ListItem Text="August" Value="08"></asp:ListItem>
                            <asp:ListItem Text="September" Value="09"></asp:ListItem>
                            <asp:ListItem Text="October" Value="10"></asp:ListItem>
                            <asp:ListItem Text="November" Value="11"></asp:ListItem>
                            <asp:ListItem Text="December" Value="12"></asp:ListItem>
                        </asp:DropDownList>
                       
                    </div>
                    <div class="col-md-6">
                        <asp:DropDownList ID="expirationYear" runat="server" CssClass="form-select">
                            <asp:ListItem Text="Year" Value="" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="2024" Value="2024"></asp:ListItem>
                            <asp:ListItem Text="2025" Value="2025"></asp:ListItem>
                            <asp:ListItem Text="2026" Value="2026"></asp:ListItem>
                            <asp:ListItem Text="2027" Value="2027"></asp:ListItem>
                            <asp:ListItem Text="2028" Value="2028"></asp:ListItem>
                            <asp:ListItem Text="2029" Value="2029"></asp:ListItem>
                            <asp:ListItem Text="2030" Value="2030"></asp:ListItem>
                        </asp:DropDownList>
                       
                    </div>
                </div>
            </div>
            <div class="col-md-6 mb-3">
                <label class="form-label">Card Type:</label>
                <asp:Image ID="cardTypeImage" runat="server" CssClass="card-type-image" Width="50" Height="50" />
            </div>
            <div class="col-12">
                <asp:Button ID="submitButton" runat="server" Text="Verify Card" CssClass="btn btn-primary" OnClick="SubmitButton_Click" />
                <asp:Label ID="errorMessageLabel" runat="server" CssClass="error" Visible="false"></asp:Label>
            </div>
        </div>
    </form>
</div>

</body>
</html>
