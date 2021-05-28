

<!doctype html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">

    <title>{SystemName} 工单</title>
    <link href="/assets/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet">



    <style>
        .panel {
            height: 300px;
            margin: 10px;
            border: 1px solid #808080;
            border-radius: 5px;
            padding: 5px;
        }
    </style>

    <!-- Custom styles for this template -->

</head>
<body class="text-center">

    <style>
        .bd-placeholder-img {
            font-size: 1.125rem;
            text-anchor: middle;
            -webkit-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            user-select: none;
        }

        body {
            min-height: 75rem;
            padding-top: 4.5rem;
        }
    </style>
    

    <div class="container">

        <div class="row">
                 <div class="input-group mb-3  ">
                    <div class="input-group-prepend">
                        <span class="input-group-text" id="inputGroup-sizing-default" style="width:250px;">问题描述</span>
                    </div>
                    <input type="text" class="form-control" disabled="disabled" name="Content" id="Content" aria-describedby="inputGroup-sizing-default" value="">
                </div>
                <div class="input-group mb-3  ">
                    <div class="input-group-prepend">
                        <span class="input-group-text" id="inputGroup-sizing-default" style="width:250px;">创建时间</span>
                    </div>
                    <input type="text" class="form-control" disabled="disabled" name="CreateTime" id="CreateTime" aria-describedby="inputGroup-sizing-default" value="">
                </div>


                <div class="input-group mb-3  ">
                    <div class="input-group-prepend">
                        <span class="input-group-text" id="inputGroup-sizing-default" style="width:250px;">状态</span>
                    </div>
                    <input type="text" class="form-control" disabled="disabled" name="State" id="State" aria-describedby="inputGroup-sizing-default" value="">
                </div>
             
         </div>

        <div class="row">

            <table class="table">
                <thead>
                    <tr>
                        <th scope="col">对话内容</th>
                        <th scope="col">时间</th>
                    </tr>
                </thead>
                <tbody id="reply"> 
                </tbody>
            </table>
        </div>
        <div id="replydiv">
            <div class="row">
                <form id="fm1" name="fm1" style="width:100%;">
                    <div class="input-group">
                        <div class="input-group-prepend">
                            <span class="input-group-text">回复内容</span>
                        </div>
                        <textarea class="form-control" name="ReplyContent" id="ReplyContent" aria-label="回复内容"></textarea>
                    </div>
                    <input type="hidden" id="cid" name="cid" value="" />
                </form>
            </div>
            <div class="row">
                <div class="col" style="padding:5px;">
                    <button type="button" class="btn btn-primary" onclick="ReplySubmit()">
                        提交回复
                    </button>
                </div>

            </div>
        </div>
    </div>


</body>

 {foot} 
<script>
    $(function () {
        var cid = getUrlParam('cid');
        $("#cid").val(cid);
        tGet("/User/GetWorkOrderById?cid="+cid, function (rt) {
            var r = JSON.parse(rt);
            if (r.Content && r.Content != "") {
                $("#Content").val(r.Content);
                $("#CreateTime").val(r.CreateTime);
                $("#State").val(r.State);
                if (r.State == "已关闭") {
                    $("#replydiv").hide();
                }
                else {
                    $("#replydiv").show();
                }
                var dlst = r.dlst;
                if (dlst && dlst != null) {
                    var html = "";
                    for (var i = 0; i < dlst.length; i++) {
                        var d = dlst[i];
                        html += '<tr><td style = "text-align:left; " > ' + d.WodType + '： ' + d.Content + '</td ><td>' + d.CreateTime+'</td></tr>';
                    }
                    $("#reply").html(html);
                }
            }
        });


    });
    function ReplySubmit() {
        var id = $("#cid").val();
        if ($("#ReplyContent").val() == "") {
            tMsg("请输入回复内容");
            return;
        }
        if (confirm("是否确认提交？") == true) {
            tPost("/User/WorkOrderReplySubmit?" + Math.random() + "&cid=" + id , $("#fm1").serialize(), function (rt) {
                var rr = JSON.parse(rt);
                if (rr.Msg != "") {
                    tMsg(rr.Msg);
                }
                else {
                    tMsg("提交成功", function () { window.location.reload(); });
                }
                return;
            });
        }
    }
    


</script>

</html>
