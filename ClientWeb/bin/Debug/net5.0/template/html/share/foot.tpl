<link href="/assets/bootstrap/dist/css/bootstrap-grid.css" rel="stylesheet" />


<script src="/lib/jquery/dist/jquery.js"></script>

<script src="/assets/bootstrap/dist/js/bootstrap.js"></script>
<script src="/lib/layer/layer.js" charset="utf-8"></script> 
<script src="/js/jquery.cookie.js"></script> 


 <script src="/assets/bootstrap/dist/js/bootstrap.bundle.min.js"></script>

<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.29.0/moment.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/tempusdominus-bootstrap-4/5.39.0/js/tempusdominus-bootstrap-4.min.js"></script>
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/tempusdominus-bootstrap-4/5.39.0/css/tempusdominus-bootstrap-4.min.css" />
<script>

    function tMsg(title, callback) {
		layer.msg(title, {
			time: 1800
		}, function () {
			if (callback) callback();
		});
	}
    function tAlert(obj, callback) {
        var title = "提示";
        var content = "";
        var btn = "确定";
        if (obj) {
            if (obj.title) title = obj.title;
            if (obj.btn) btn = obj.btn;
            if (obj.content) content = obj.content;
            else content = obj;
            layer.open({
                title: title,
                btn: [btn],
                content: content,
                yes: function (index) {
                    layer.close(index);
                },
                end: function () {
                    if (callback) {
                        callback();
                    }
                }
            });;
        }
    }
    function tPost(url, formdata, successCallback, errorCallback, loading) {
        var loadIndex = 0;
        if (loading == true) {
            loadIndex = layer.load(1, {
                shade: [0.1, '#fff']
            });
        }
        $.ajax({
            type: 'POST',
            url: url,
            data: formdata,
            dataType: 'json',
            success: function (data) {
                if (loading == true) {
                    layer.close(loadIndex);
                }
                if (data.rt == true) {
                    if (successCallback) {
                        successCallback(data.msg);
                    }
                }
                else {
                    if (errorCallback) {
                        errorCallback(data.msg);
                    }
                    else {
                        if (data.msg) {
                            tAlert(data.msg);
                        }
                        else {
                            tAlert("服务器正忙！");
                        }
                    }
                }

            },
            error: function (error) {
                if (loading == true) {
                    layer.close(loadIndex);
                }
                if (errorCallback) {
                    errorCallback();
                }
            }
        });
    }


    function tGet(url, successCallback, errorCallback, loading) {
        var loadIndex = 0;
        if (loading == true) {
            loadIndex = layer.load(1, {
                shade: [0.1, '#fff']
            });
        }

        $.ajax({
            type: 'GET',
            url: url,
            dataType: 'json',
            success: function (data) {
                if (loading == true) {
                    layer.close(loadIndex);
                }
                if (data.rt == true) {
                    if (successCallback) {
                        successCallback(data.msg);
                    }
                }
                else {
                    if (errorCallback) {
                        errorCallback(data.msg);
                    }
                    else {
                        if (data.msg) {
                            tAlert(data.msg);
                        }
                        else {
                            tAlert("服务器正忙！");
                        }
                    }
                }

            },
            error: function (error) {
                if (loading == true) {
                    layer.close(loadIndex);
                }
                if (errorCallback) {
                    errorCallback();
                }
            }
        });
    }

    
    function tConfirm(title, successCallback, failCallback) {
        layer.confirm(title, {
            btn: ['确认', '取消']  
        }, function (index) {
            if (successCallback) successCallback();
            layer.close(index);
        }, function () {
            if (failCallback) failCallback();
        });
    }

    $(function () {
        var msg = getUrlParam('msg');
        if (msg && msg != null) {
            setTimeout(function () {
                tMsg(msg);
            }, 500);
        }
        var alertinfo = getUrlParam('alert');
        if (alertinfo && alertinfo != null) {
            setTimeout(function () {
                tAlert(alertinfo);
            }, 500);
        }
    });
    function getUrlParam(name) {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");  
        var r = decodeURI(window.location.search).substr(1).match(reg);  
        if (r != null) return unescape(r[2]); return null; 
    }
</script>