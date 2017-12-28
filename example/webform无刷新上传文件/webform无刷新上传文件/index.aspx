<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="webform无刷新上传文件.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="./js/jquery-1.7.1.min.js"></script>
    <script src="./js/jquery.ui.widget.js"></script>
    <script src="./js/jquery.fileupload.js"></script>
</head>
<body>
    <form id="form1">
        <div style="margin: 0 auto; text-align: center;">
            <p>
                <img id="img" src="" />
            </p>
            <p>
                <input name="file" id="fUpLoad" type="file" />
            </p>
        </div>
    </form>
    <script>
        $('#fUpLoad').fileupload({
            url: './UpServer.ashx',
            dataType: 'json',
            done: function (e, data) {
                alert(JSON.stringify(data.result));
                console.log(data.result);
            },
            progressall: function (e, data) {

            }
        })
    </script>
</body>
</html>
