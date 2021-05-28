<!doctype html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <meta name="generator" content="">
    <title>{SystemName}系统注册</title>

  
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
                margin-bottom: 1px;
                border-bottom-right-radius: 0;
                border-bottom-left-radius: 0;
            }

            .form-signin input[type="password"] {
                margin-bottom: 1px;
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
        .btn1{
            margin-top:0px;
            width:49%;display:inline-block;
        }
    </style>
     
</head>
<body class="text-center">

    <form class="form-signin" method="post"  action="/User/RegistSubmit">
         <h1 class="h3 mb-3 font-weight-normal">{SystemName} 系统注册</h1>
        <label for="Account" class="sr-only">邮&nbsp;&nbsp;&nbsp;&nbsp;箱</label>
        <input type="email" id="Account" name="Account" class="form-control" placeholder="输入邮箱地址" required autofocus>
        <label for="pwd" class="sr-only">密&nbsp;&nbsp;&nbsp;&nbsp;码</label>
        <input type="password" id="pwd" name="pwd" class="form-control" placeholder="输入密码(至少6位的字母/数字/下划线)" onkeyup="this.value=this.value.replace(/[^\w_]/g,'');"  required>
        <label for="repwd" class="sr-only">确认密码</label>
        <input type="password" id="repwd" name="repwd" class="form-control" placeholder="再次输入密码" onkeyup="this.value=this.value.replace(/[^\w_]/g,'');"  required>
        <label for="vcode" class="sr-only">验&nbsp;证&nbsp;码</label>
        <input type="text" id="vcode" name="vcode" class="form-control" placeholder="再请输入验证码" required style="width:65%;display:inline-block" />
        <img src="/User/MixVerifyCode" id="imgvcode" onclick="this.src=this.src+'?'"  />
        <div class="checkbox mb-3">
            
        </div>
        <button class="btn1 btn btn-lg btn-primary btn-block"   style=" margin-top:0px;" type="submit">提交注册</button>
         <button class="btn1 btn btn-lg btn-success btn-block"   type="button"  onclick="javvascript:window.location.replace('/User/Login');return false;" style=" margin-top:0px;" >返回登录</button>
        <p class="mt-5 mb-3 text-muted">&copy; {Year}</p>
    </form>

    {foot}

</body>
</html>
