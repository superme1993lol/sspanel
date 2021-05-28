<!doctype html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <meta name="generator" content="">
    <title>{SystemName} 新闻公告</title>


    <link href="/assets/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet">



    <style>
        .bd-placeholder-img {
            font-size: 1.125rem;
            text-anchor: middle;
            -webkit-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            user-select: none;
        }

        @media (min-width: 768px) {
            .bd-placeholder-img-lg {
                font-size: 3.5rem;
            }
        }

        body {
            font-size: .875rem;
        }

        .feather {
            width: 16px;
            height: 16px;
            vertical-align: text-bottom;
        }

        /*
        * Sidebar
        */





        .sidebar-sticky {
            position: relative;
            top: 0;
            height: calc(100vh - 48px);
            padding-top: .5rem;
            overflow-x: hidden;
            overflow-y: auto; /* Scrollable contents if viewport is shorter than content. */
        }

        @supports ((position: -webkit-sticky) or (position: sticky)) {
            .sidebar-sticky {
                position: -webkit-sticky;
                position: sticky;
            }
        }

        .sidebar .nav-link {
            font-weight: 500;
            color: #333;
        }

            .sidebar .nav-link .feather {
                margin-right: 4px;
                color: #999;
            }

            .sidebar .nav-link.active {
                color: #007bff;
            }

                .sidebar .nav-link:hover .feather,
                .sidebar .nav-link.active .feather {
                    color: inherit;
                }

        .sidebar-heading {
            font-size: .75rem;
            text-transform: uppercase;
        }

        /*
        * Navbar
        */

        .navbar-brand {
            padding-top: .75rem;
            padding-bottom: .75rem;
            font-size: 1rem;
            background-color: rgba(0, 0, 0, .25);
            box-shadow: inset -1px 0 0 rgba(0, 0, 0, .25);
        }

        .navbar .navbar-toggler {
            top: .25rem;
            right: 1rem;
        }

        .navbar .form-control {
            padding: .75rem 1rem;
            border-width: 0;
            border-radius: 0;
        }

        .form-control-dark {
            color: #fff;
            background-color: rgba(255, 255, 255, .1);
            border-color: rgba(255, 255, 255, .1);
        }

            .form-control-dark:focus {
                border-color: transparent;
                box-shadow: 0 0 0 3px rgba(255, 255, 255, .25);
            }







        .pricing-header {
            max-width: 700px;
        }

        .card-deck .card {
            min-width: 220px;
            padding: 0;
        }

        @media (min-width: 768px) {
            .bd-placeholder-img-lg {
                font-size: 3.5rem;
            }
        }


        .jumbotron {
            padding-top: 3rem;
            padding-bottom: 3rem;
            margin-bottom: 0;
            background-color: #fff;
        }



            .jumbotron p:last-child {
                margin-bottom: 0;
            }

            .jumbotron h1 {
                font-weight: 300;
            }

            .jumbotron .container {
                max-width: 40rem;
            }

        footer {
            padding-top: 3rem;
            padding-bottom: 3rem;
        }

            footer p {
                margin-bottom: .25rem;
            }
    </style>



</head>
<body>

    <nav class="navbar navbar-dark sticky-top bg-dark flex-md-nowrap p-0 shadow">
        <a class="navbar-brand col-md-3 col-lg-2 mr-0 px-3" href="#">{SystemName}</a>

        <ul class="navbar-nav px-3">
            <li class="nav-item text-nowrap">
                <a class="nav-link" href="/User/LoginOut">退出登录</a>
            </li>
        </ul>
    </nav>

    <div class="container-fluid">
        <div class="row">
            <nav id="sidebarMenu" class="col-md-3 col-lg-2 d-md-block bg-light sidebar collapse">
                <div class="sidebar-sticky pt-3">
                    <ul class="nav flex-column">
                        <li class="nav-item">
                            <a class="nav-link active" href="/User/Main">
                                <span data-feather="home"></span>
                                首页
                                 <span class="sr-only">(current)</span>
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="/User/MemberService">
                                <span data-feather="shopping-cart"></span>
                                服务
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link " href="/User/WorkOrderList">
                                <span data-feather="file"></span>
                                工单
                               
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link " href="/User/PayLog">
                                <span data-feather="bar-chart-2"></span>
                                支付记录
                              
                            </a>
                        </li>
                    </ul>
                </div>
            </nav>

            <main role="main" class="col-md-9 ml-sm-auto col-lg-10 px-md-4">
                <h2>新闻公告</h2>
                <div class="table-responsive">
                    <table class="table table-striped table-sm">
                        <thead>
                            <tr>
                                <th>标题</th> 
                                <th>创建时间</th> 
                                <th>操作</th>
                            </tr>
                        </thead>
                        <tbody id="list">
                        </tbody>
                    </table>
                </div>

                <div style="width:100%;text-align:center;">
                    <ul class="pagination">
                    </ul>
                </div>
            </main>






        </div>
    </div>


    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" crossorigin="anonymous"></script>

    {foot}

    <script src="https://cdn.jsdelivr.net/npm/feather-icons@4.28.0/dist/feather.min.js"></script>

    <script>
        feather.replace();
        var pageindex = 1;
        var pagenum = 1;
        $(function(){
            tGet("/User/GetNewsPageMax", function (rt) {
                var r = JSON.parse(rt);
                if (r.count ) {
                    pagenum = r.count;
                    html = '<li class="page-item" id="prev"><a class="page-link" href="javascript:Pre()">上一页</a></li>';
                    for (var i = 1; i <= pagenum; i++) {
                        html += '<li class="page-item" id="page'+i+'"><a class="page-link" href="javascript:Go('+i+')">1</a></li>';
                    }
                    html += '<li class="page-item" id="next"><a class="page-link" href="javascript:Next()">下一页</a></li>';

                    $(".pagination").html(html);
                    GetList();
                }
            });
        });

        
        

        function Pre() {
            if (pageindex == 1) {
                return;
            }
            pageindex = pageindex-1;
            GetList();
        }

        function Next() {
            if (pageindex >= pagenum) {
                return;
            }
            pageindex = pageindex + 1;
            GetList();
        }

        function Go(n) {
            pageindex = n;
            GetList();
        }
        function Open(content,title) {
            layer.open({
                type: 1  
                , area: ['500px', '300px']
                , title:title
                , shade: 0.6 
                , maxmin: true 
                , anim: 1
                , content: '<div style="padding:10px;">'+content+'</div>'
            }); 
        }

        function GetList() {
            $(".page-item").removeClass("disabled");
            $("#page" + pageindex).addClass("disabled");
            if (pageindex == 1) {
                $("#prev").addClass("disabled");
            }
            if (pageindex >= pagenum) {
                $("#next").addClass("disabled");
            }

            tGet("/User/GetNews?pageindex" + pageindex, function (rt) {
                var r = JSON.parse(rt);
                if (r.list && r.list != null) {
                    var lst = r.list;
                    var html = "";
                    for (var i = 0; i < lst.length; i++) {
                        var r = lst[i];
                        var sContent = r.Content;
                        if (r.Content.length > 50) {
                            sContent = sContent.substring(0, 50) + "...";
                        }
                        html += '<tr><td>' + r.Title + '</td><td>' + r.CreateTime  + '</td><td><a href="javascript:Open(\'' + r.Content +'\',\''+r.Title+'\')">详细</a></td></tr >';
                    }
                    $("#list").html(html);
                }
            });
        }
    </script>
</body>
</html>
