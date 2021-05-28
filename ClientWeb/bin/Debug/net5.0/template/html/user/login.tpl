<!doctype html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <meta name="generator" content="">
    <title>系统登录</title>

  
    <link href="/assets/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet">
     
    <style>
        html,
        body {
            height: 100%;
        }

        body {
            display: -ms-flexbox;
            display: flex;
            -ms-flex-align: center;
            align-items: center;
            padding-top: 40px;
            padding-bottom: 40px;
            background-color: #f5f5f5;
        }

        .form-signin {
            width: 100%;
            max-width: 330px;
            padding: 15px;
            margin: auto;
        }

            .form-signin .checkbox {
                font-weight: 400;
            }

            .form-signin .form-control {
                position: relative;
                box-sizing: border-box;
                height: auto;
                padding: 10px;
                font-size: 16px;
            }

                .form-signin .form-control:focus {
                    z-index: 2;
                }

            .form-signin input[type="email"] {
                margin-bottom: -1px;
                border-bottom-right-radius: 0;
                border-bottom-left-radius: 0;
            }

            .form-signin input[type="password"] {
                margin-bottom: 10px;
                border-top-left-radius: 0;
                border-top-right-radius: 0;
            }

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
        .btn1 {
            margin-top: 0px;
            width: 49%;
            display: inline-block;
        }
    </style>
     
</head>
<body class="text-center">

    <form class="form-signin" method="post"   action="/User/LoginSubmit">
       
        <h1 class="h3 mb-3 font-weight-normal">{SystemName} 系统登录</h1>
        <label for="Account" class="sr-only">邮  箱</label>
        <input type="email" id="Account" name="Account" class="form-control" placeholder="输入邮箱地址" required autofocus>
        <label for="pwd" class="sr-only">密  码</label>
        <input type="password" id="pwd" name="pwd" class="form-control" placeholder="输入密码" required>
        <div class="checkbox mb-3" >
            
        </div>
        <button class="btn1 btn btn-lg btn-primary btn-block" style=" margin-top:0px;" type="submit">登录系统</button>
        <button class="btn1 btn btn-lg btn-success btn-block" type="button" onclick="javvascript:window.location.replace('/User/Regist');return false;" style=" margin-top:0px;">免费注册</button> 
          <!--<button class="  btn btn-lg btn-outline-primary btn-block" type="button" onclick="javvascript:window.location.replace('/Home/Index');return false;" style=" margin-top:2px;display:inline-block;">返回首页</button>-->
        <p class="mt-5 mb-3 text-muted">&copy; {Year}</p>
    </form>

    {foot}

</body>
</html>
