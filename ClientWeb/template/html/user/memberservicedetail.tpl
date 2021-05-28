

<!doctype html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">

    <title>{SystemName} 服务详情</title>
    <link href="/assets/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet">



    <style>
        .panel {
            height: 300px;
            margin: 10px;
            border: 1px solid #808080;
            border-radius: 5px;
            padding: 5px;
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
    
    </style>

    <!-- Custom styles for this template -->

</head>
<body class="text-center">

    <style>
        .container {
            max-width: 960px;
        }

        .lh-condensed {
            line-height: 1.25;
        }
        .line{
            border-bottom:1px solid silver;
        }

    </style>


    <div class="container" style="text-align:left;padding-left:1em;">
        <form class="needs-validation" novalidate>
            <div class="row">
                <div class="col-12 mb-3">
                    <label>Clash配置文件</label>
                    <input type="text" class="form-control" id="ClashConfig" disabled="disabled" value="{Domain}/Config/ClashConfig?u={token}" />
                </div>
                <div class="col-12 mb-3">
                    <label>Clash客户端下载</label>
                    <div class="line">
                        <a href="/soft/ClashWin.exe" target="_blank">window客户端</a>
                        &nbsp;&nbsp;
                        <a href="/soft/ClashX.dmg" target="_blank">Mac客户端</a>
                        &nbsp;&nbsp;
                        <a href="/soft/ClashV7.apk" target="_blank">安卓ARMV7</a>
                        &nbsp;&nbsp;
                        <a href="/soft/ClashV8.apk" target="_blank">安卓ARMV8</a>
                        &nbsp;&nbsp;
                        <a href="/soft/ClashU.apk" target="_blank">安卓Universal</a>
                    </div>
                </div>


                <div class="col-12 mb-3">
                    <label>Surge配置文件(IOS)</label>
                    <input type="text" class="form-control" id="SurgeConfig" disabled="disabled" value="{Domain}/Config/SurgeConfig?u={token}" />
                </div>
                <div class="col-12 mb-3">
                    <label>Surge配置文件(Mac)</label>
                    <input type="text" class="form-control" id="SurgeConfig" disabled="disabled" value="{Domain}/Config/SurgeConfig?u={token}&tfo=0" />
                </div>
                <div class="col-12 mb-3">
                    <label>Surge节点文件</label>
                    <input type="text" class="form-control" id="SurgeNode" disabled="disabled" value="{Domain}/Config/SurgeNode?u={token}" />
                </div>
                <div class="col-12 mb-3">
                    <label>Surge客户端下载</label>
                    <div class="line">
                        <a href="https://nssurge.com/" target="_blank">Mac客户端</a>
                        &nbsp;&nbsp;
                        <a href="https://apps.apple.com/us/app/surge-4/id1442620678" target="_blank">IOS客户端</a>
                    </div>
                </div>


                <div class="col-12 mb-3">
                    <label>Loon配置文件</label>
                    <input type="text" class="form-control" id="LoonConfig" disabled="disabled" value="{Domain}/Config/LoonConfig?u={token}" />
                </div>

                <div class="col-12 mb-3">
                    <label>LoonServer文件</label>
                    <input type="text" class="form-control" id="LoonConfigSIP002" disabled="disabled" value="{Domain}/Config/SSConfigSIP002?u={token}" />
                </div>
                <div class="col-12 mb-3">
                    <label>Loon客户端下载</label>
                    <div class="line">
                        <a href="https://apps.apple.com/us/app/quantumult/id1252015438" target="_blank">IOS客户端</a>
                    </div>
                </div>
                


                <div class="col-12 mb-3">
                    <label>Quantumult X配置文件</label>
                    <input type="text" class="form-control" id="QuantumultXConfig" disabled="disabled" value="{Domain}/Config/QuantumultXConfig?u={token}" />
                </div>
                <div class="col-12 mb-3">
                    <label>SSR节点</label>
                    <input type="text" class="form-control" id="SSRNode" disabled="disabled" value="{Domain}/Config/SSRNode?u={token}" />
                </div>
                <div class="col-12 mb-3">
                    <label>SS节点</label>
                    <input type="text" class="form-control" id="SSNode" disabled="disabled" value="{Domain}/Config/SSNode?u={token}" />
                </div>





                <div class="col-12 mb-3">
                    <label>Quantumult X客户端</label>
                    <div class="line">
                        <a href="https://apps.apple.com/us/app/quantumult-x/id1443988620" target="_blank">IOS客户端</a>
                    </div>
                </div>



                <div class="col-12 mb-3">
                    <label>Quantumult Rules规则文件</label>
                    <input type="text" class="form-control" id="QuantumultRules" disabled="disabled" value="{Domain}/Config/QuantumultRules?u={token}" />
                </div>
                <div class="col-12 mb-3">
                    <label>Quantumult Server服务器文件</label>
                    <input type="text" class="form-control" id="QuantumultServers" disabled="disabled" value="{Domain}/Config/QuantumultServers?u={token}" />
                </div>
                <div class="col-12 mb-3">
                    <label>Quantumult客户端</label>
                    <div class="line">
                        <a href="https://apps.apple.com/us/app/quantumult/id1252015438" target="_blank">IOS客户端</a>
                    </div>
                </div>


                <div class="col-12 mb-3">
                    <label>ShadowsocksR配置文件</label>
                    <input type="text" class="form-control" id="SSRConfig" disabled="disabled" value="{Domain}/Config/SSRConfig?u={token}" />
                </div>
                <div class="col-12 mb-3">
                    <label>ShadowsocksR客户端下载</label>
                    <div class="line">
                        <a href="/soft/SsrWin.zip" target="_blank">window客户端</a>
                        &nbsp;&nbsp;
                        <a href="/soft/SsrMac.zip" target="_blank">Mac客户端</a>
                        &nbsp;&nbsp;
                        <a href="/soft/SsrAndroid.apk" target="_blank">安卓客户端</a>
                        &nbsp;&nbsp;
                        <a href="https://apps.apple.com/us/app/shadowrocket/id932747118" target="_blank">IOS客户端</a>
                    </div>
                </div>
                <div class="col-12 mb-3">
                    <label>Shadowsocks配置文件</label>
                    <input type="text" class="form-control" id="SSConfig" disabled="disabled" value="{Domain}/Config/SSConfig?u={token}" />
                </div>
                <div class="col-12 mb-3">
                    <label>Shadowsocks配置文件（SIP002）</label>
                    <input type="text" class="form-control" id="SSConfigSIP002" disabled="disabled" value="{Domain}/Config/SSConfigSIP002?u={token}" />
                </div>
            </div>

            </form>
    </div>


</body>

 {foot}
<script>
    $(function () {
        
    });
     
</script>

</html>
