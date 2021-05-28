<!doctype html>
<html lang="en">
<head>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
	<meta name="description" content="">
	<meta name="author" content="">
	<meta name="generator" content="">
	<title>{SystemName} 个人中心</title>


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
			padding:0;
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
        .btn1 {
            margin-top: 0px;
            width: 35%;
            display: inline-block;
			margin-right:3px;
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
								首页 <span class="sr-only">(current)</span>
							</a>
						</li>
						<li class="nav-item">
							<a class="nav-link" href="/User/MemberService">
								<span data-feather="shopping-cart"></span>
								服务
							</a>
						</li>
						<li class="nav-item">
							<a class="nav-link" href="/User/WorkOrderList">
								<span data-feather="file"></span>
								工单
							</a>
						</li>
						<li class="nav-item">
							<a class="nav-link" href="/User/PayLog">
								<span data-feather="bar-chart-2"></span>
								支付记录
							</a>
						</li>
					</ul>
				</div>
			</nav>

			<main role="main" class="col-md-9 ml-sm-auto col-lg-10 px-md-4">
				<div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
					<h1 class="h2">欢迎您，{UserName}</h1>
					<div class="btn-toolbar mb-2 mb-md-0">

					</div>
				</div>

				<div class="jumbotron text-center">
					 
					<div class="card-deck mb-3 text-center row">


						<div class="card col-md-3 shadow-sm">
							<div class="card-header">
								<h4 class="my-0 font-weight-normal" >最新公告</h4>
							</div>
							<div class="card-body">
								<p class="card-text" style="text-align:left;" id="newscontent"></p>
								<div class="d-flex justify-content-between align-items-center">
									<div class="btn-group"> 
										<button type="button" class="btn btn-sm btn-outline-secondary" onclick="window.location.href='/User/NewsList'">更多</button>
									</div>
									<small class="text-muted" id="newscreatetime"></small>
								</div>
							</div>
						</div>

					</div>

					<div class="card-deck mb-3 text-center row" id="usersercive">

 


					</div>

				</div>
				 


			</main>

	




		</div>
	</div>


	<script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" crossorigin="anonymous"></script>

	{foot}

	<script src="https://cdn.jsdelivr.net/npm/feather-icons@4.28.0/dist/feather.min.js"></script>

	<script>feather.replace();

        $(function(){
            tGet("/User/GetLastNews", function (rt) {
                var r = JSON.parse(rt);
                if (r.Content && r.Content != "") {
                    $("#newscontent").html(r.Content);
                    $("#newscreatetime").html(r.CreateTime); 
                }
                
            });
            tGet("/User/GetAllMemberService", function (rt) {
                var r = JSON.parse(rt);
				if (r.mslst && r.mslst != "") {
					var html = "";
					for (var i = 0; i < r.mslst.length; i++) {
						var rr = r.mslst[i];
                        html += '<div class="card col-md-3 shadow-sm"><div class="card-header" ><h4 class="my-0 font-weight-normal">当前服务' + i + '</h4></div ><div class="card-body"><ul class="list-unstyled mt-3 mb-4"><li>到期时间：' + rr.EndTime + '</li><li>当前流量：' + rr.UsedTraffic + ' | ' + rr.Traffic + ' GB</li><li>下次刷新：' + rr.NextDueTime + '</li></ul> <button class="btn1 btn btn-md btn-primary btn-block" onclick="OpenMsDetail(' + rr.Id + ')"   type="submit" style=" margin-top:0px;">详细</button><button type="button" class="btn1 btn btn-md btn-block btn-outline-primary" onclick="window.location.href=\'/User/ContinueService?sid=' + rr.Id + '\'" style=" margin-top:0px;">续费</button></div></div >'; 
                    } 
                    $("#usersercive").html(html); 
                }
                
            });

		});
		function OpenMsDetail(id) {
			 
				layer.open({
			  type: 2,
			  title: '服务详情',
			  shadeClose: true,
			  shade: 0.8,
			 area: ['70%', '90%'],
			  content: "/User/MemberServiceDetail?cid="+id 
			}); 
        }

	</script>
</body>
</html>
