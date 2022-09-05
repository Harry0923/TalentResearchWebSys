<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="newResearch.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<!-- CSS only -->
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-gH2yIJqKdNHPEq0n4Mqa/HGKIhSkIHeL5AyhkYV8i59U5AR6csBvApHHNl/vI1Bx" crossorigin="anonymous">
<!-- JavaScript Bundle with Popper -->
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/js/bootstrap.bundle.min.js" integrity="sha384-A3rJD856KowSb7dwlZdYEkO39Gagi7vIsF0jrRAoQmDKKtQBHUuLZ9AsSv4jD4Xa" crossorigin="anonymous"></script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
<meta name="viewport" content="width=device-width, initial-scale=1.0"/>
<link rel = "stylesheet" href="style.css"/>
    <title></title>
<style>
/*body {
    margin: 0px;
    padding: 0px;
    font-family: sans-serif;
    background-image: url(image/main4.png);
    background-size: cover;
    overflow: hidden;
}*/ 
    .container-fluid{
        width:100%;
        height:100%;
        object-fit:cover;
    }
.Login-form{
    width: 800px;
    padding: 10px;
    position: absolute;
    font-size: 30px;
    top: 50%;
    left: 50%;
    transform: translate(-50%,-30%); /*水平位移x 垂直位移y */
    background: #E3E3E3;
    text-align: center;
    border-radius: 40px;
    box-shadow: 0 0 30px #000000;
    opacity: 0.95;
}
#Login-h1{
    color: mediumpurple;
    text-transform: uppercase;
    font-weight: 500; /*文字粗度 */
}
.Login-form input[type = "Text"], .Login-form input[type = "password"]{
    border: 0px;
    background: none;
    display: block; /*不顯示在同行*/
    margin: 20px auto;
    text-align: center;
    border: 3.5px solid#3498db;
    padding: 14px 10px;
    width: 250px;
    outline: none;
    color: black;
    transition: 0.25s;
    border-radius: 24px;
    font-size: 30px;
    border-color:mediumpurple
}
.Login-form input[type = "Text"]:focus, .Login-form input[type = "password"]:focus
{
    width: 300px;
    border-color: rebeccapurple;
    font-size: large;
}
.Login-form input[type = "button"]{
    border: 0px;
    background: none;
    display: block; /* 不顯示在同行 */
    margin: 20px auto;
    text-align: center;
    border: 3.5px solid;
    border-color:mediumpurple;
    padding: 14px 40px;
    width: 200px;
    outline: none;
    color: black;
    transition: 0.25s;
    border-radius: 24px;
    font-size: 30px;
    cursor: pointer; /*鼠標顯示 */
}
.Login-form input[type="button"]:hover{
    background: #2ecc71;
    background-color:mediumpurple;
}
</style>
</head>
<body>
    <section>
        <img src="image/master7.png" class="container-fluid"/>
    <form id="form1" runat="server" class="Login-form"  method="post" >
       <div id="div-Login">
            <h1 id="Login-h1">歡迎光臨，請輸入帳號及密碼</h1>
           <br />
            <h3 style="color: #CC99FF;font-weight:900">使用者員工卡號(User ID):</h3>
            <input type="text" name = "" placeholder="User ID"/> <!-- placeholder 用於文字格底下預設字 --->
            <h3 style="color: #CC99FF;font-weight:900">密碼(Password):</h3>
            <h3 style="color: palevioletred;font-weight:900">(密碼大小寫有區別)</h3>
            <input type="password" name = "" placeholder="Password"/>
            
            <input type="button" name = "" value="Login"/>
           <br />
           <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="#CC99FF" Font-Bold="true">本站使用說明手冊</asp:LinkButton>
        </div>
    </form>
        </section>
</body>
</html>
