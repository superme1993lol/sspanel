[General]
# IPv6 支持
ipv6 = false
# > 跳过某个域名或者IP段
skip-proxy = 127.0.0.1,192.168.0.0/16,10.0.0.0/8,172.16.0.0/12,100.64.0.0/10,localhost,*.local,passenger.t3go.cn,passenger.t3go.cn
bypass-tun = 10.0.0.0/8,100.64.0.0/10,127.0.0.0/8,169.254.0.0/16,172.16.0.0/12,192.0.0.0/24,192.0.2.0/24,192.88.99.0/24,192.168.0.0/16,198.18.0.0/15,198.51.100.0/24,203.0.113.0/24,224.0.0.0/4,255.255.255.255/32
# DNS 服务器
dns-server = system,119.29.29.29,114.114.114.114,223.5.5.5
# Wi-Fi 访问
# > 允许 Wi-Fi 网络下其它设备访问
allow-udp-proxy = true
allow-wifi-access = false
wifi-access-http-port = 7222
wifi-access-socket5-port = 7221
# > 解决一些ip请求无法匹配域名类规则的问题。real-ip指定的域名将不返回fake ip响应，直接将dns请求发往目标dns服务器
#real-ip = msftconnecttest.com, msftncsi.com, *.msftconnecttest.com, *.msftncsi.com, *.srv.nintendo.net, *.stun.playstation.net, xbox.*.microsoft.com, *.xboxlive.com, *.battlenet.com.cn, *.battlenet.com, *.blzstatic.cn, *.battle.net
# > 代理测速 URL
proxy-test-url = http://www.gstatic.com/generate_204
# > 测速超时 (s)
test-timeout = 5
# 解析器
resource-parser = https://raw.githubusercontent.com/Peng-YM/Sub-Store/master/scripts/sub-store-parser.js
# ssid-trigger参数，用于指定SSID下流量模式切换，（default表示默认，cellular表示蜂窝，目前支持三种值：rule，direct，proxy） 
#ssid-trigger = "default":rule, "cellular":rule,"ASUS_5G":direct

[Host]
*.taobao.com = server:223.5.5.5
*.tmall.com = server:223.5.5.5
*.jd.com = server:119.28.28.28
*.qq.com = server:119.28.28.28
*.tencent.com = server:119.28.28.28
*.alicdn.com = server:223.5.5.5
*.aliyun.com = server:223.5.5.5
*.weixin.com = server:119.28.28.28
*.163.com = server:119.29.29.29
*.126.com = server:119.29.29.29
*.126.net = server:119.29.29.29
*.127.net = server:119.29.29.29
*.netease.com = server:119.29.29.29
*.mi.com = server:119.29.29.29
*.xiaomi.com = server:119.29.29.29
*.bilibili.com = server:119.29.29.29
*testflight.apple.com = server:8.8.4.4
mtalk.google.com = 108.177.125.188
dl.google.com = server:119.29.29.29
dl.l.google.com = server:119.29.29.29

[Proxy]

[Remote Proxy]
{SystemName} = {ProxyUrl},udp=true,fast-open=true

[Proxy Group]
#FINAL = select,PROXY,DIRECT,img-url = https://raw.githubusercontent.com/Koolson/Qure/master/IconSet/Color/Final.png
PROXY = select,{SystemName},DIRECT,img-url = https://raw.githubusercontent.com/Koolson/Qure/master/IconSet/Color/Proxy.png
Apple = select,DIRECT,PROXY,{SystemName},img-url = https://raw.githubusercontent.com/Koolson/Qure/master/IconSet/Color/Apple.png
Netflix = select,PROXY,DIRECT,{SystemName},img-url = https://raw.githubusercontent.com/Koolson/Qure/master/IconSet/Color/Netflix.png
Disney+ = select,PROXY,DIRECT,{SystemName},img-url = https://raw.githubusercontent.com/Koolson/Qure/master/IconSet/Color/Disney.png
TikTok = select,PROXY,DIRECT,{SystemName},img-url = https://raw.githubusercontent.com/Koolson/Qure/master/IconSet/Color/TikTok.png
Emby = select,PROXY,DIRECT,{SystemName},img-url = https://raw.githubusercontent.com/Koolson/Qure/master/IconSet/Color/Emby.png
YouTube = select,PROXY,DIRECT,{SystemName},img-url = https://raw.githubusercontent.com/Koolson/Qure/master/IconSet/Color/YouTube.png
Bahamut = select,PROXY,DIRECT,{SystemName},img-url = https://raw.githubusercontent.com/Koolson/Qure/master/IconSet/Color/Bahamut.png
Telegram = select,PROXY,DIRECT,{SystemName},img-url = https://raw.githubusercontent.com/Koolson/Qure/master/IconSet/Color/Telegram.png
Speedtest = select,PROXY,DIRECT,{SystemName},img-url = https://raw.githubusercontent.com/Koolson/Qure/master/IconSet/Color/Speedtest.png
HKMTMedia = select,PROXY,DIRECT,{SystemName},img-url = https://raw.githubusercontent.com/Koolson/Qure/master/IconSet/Color/StreamingSE.png
#HK = select,香港,img-url = https://raw.githubusercontent.com/Koolson/Qure/master/IconSet/Color/Hong_Kong.png
#SG = select,新加坡,img-url = https://raw.githubusercontent.com/Koolson/Qure/master/IconSet/Color/Singapore.png
#US = select,美国,img-url = https://raw.githubusercontent.com/Koolson/Qure/master/IconSet/Color/United_States.png
#JP = select,日本,img-url = https://raw.githubusercontent.com/Koolson/Qure/master/IconSet/Color/Japan.png
#TW = select,台湾,img-url = https://raw.githubusercontent.com/Koolson/Qure/master/IconSet/Color/Taiwan.png

[Remote Filter]
香港 = NameRegex, FilterKey = "Hong Kong \d+ \[Premium\]"
新加坡 = NameRegex, FilterKey = "Singapore \d+ \[Premium\]"
日本 = NameRegex, FilterKey = "Japan \d+ \[Premium\]"
美国 = NameRegex, FilterKey = "United States \d+ \[Premium\]"
台湾 = NameKeyword, FilterKey = "Taiwan"

[URL Rewrite]
enable = true

[Remote Rewrite]

[Script]
enable = true

[Remote Script]

[Remote Rule]
https://raw.githubusercontent.com/DivineEngine/Profiles/master/Surge/Ruleset/Guard/Advertising.list, policy=REJECT, tag=REJECT, enabled=true
https://raw.githubusercontent.com/DivineEngine/Profiles/master/Surge/Ruleset/Guard/Hijacking.list, policy=REJECT, tag=REJECT, enabled=true
https://raw.githubusercontent.com/DivineEngine/Profiles/master/Surge/Ruleset/Guard/Privacy.list, policy=REJECT, tag=REJECT, enabled=true
https://raw.githubusercontent.com/blackmatrix7/ios_rule_script/master/rule/Loon/TestFlight/TestFlight.list, policy=PROXY, tag=Apple, enabled=true
https://raw.githubusercontent.com/blackmatrix7/ios_rule_script/master/rule/Loon/Apple/Apple.list, policy=Apple, tag=Apple, enabled=true
https://raw.githubusercontent.com/blackmatrix7/ios_rule_script/master/rule/Loon/Disney/Disney.list, policy=Disney+, tag=Disney+, enabled=true
https://raw.githubusercontent.com/Tartarus2014/For-own-use/master/Ruleset/Emby/Emby.list, policy=Emby, tag=Emby, enabled=true
https://raw.githubusercontent.com/blackmatrix7/ios_rule_script/master/rule/Loon/TikTok/TikTok.list, policy=TikTok, tag=TikTok, enabled=true
https://raw.githubusercontent.com/blackmatrix7/ios_rule_script/master/rule/Loon/Bahamut/Bahamut.list, policy=Bahamut, tag=Bahamut, enabled=true
https://raw.githubusercontent.com/blackmatrix7/ios_rule_script/master/rule/Loon/YouTube/YouTube.list, policy=YouTube, tag=YouTube, enabled=true
https://raw.githubusercontent.com/blackmatrix7/ios_rule_script/master/rule/Loon/BiliBili/BiliBili.list, policy=HKMTMedia, tag=HKMTMedia, enabled=true
https://raw.githubusercontent.com/blackmatrix7/ios_rule_script/master/rule/Loon/Speedtest/Speedtest.list, policy=Speedtest, tag=Speedtest, enabled=true
https://raw.githubusercontent.com/blackmatrix7/ios_rule_script/master/rule/Loon/Telegram/Telegram.list, policy=Telegram, tag=Telegram, enabled=true
https://raw.githubusercontent.com/blackmatrix7/ios_rule_script/master/rule/Loon/Proxy/Proxy.list, policy=PROXY, tag=PROXY, enabled=true
https://raw.githubusercontent.com/blackmatrix7/ios_rule_script/master/rule/Loon/Proxy/Proxy_Domain.list, policy=PROXY, tag=PROXY, enabled=true
https://raw.githubusercontent.com/blackmatrix7/ios_rule_script/master/rule/Loon/China/China.list, policy=DIRECT, tag=Domestic, enabled=true

[Plugin]
https://raw.githubusercontent.com/Tartarus2014/Loon-Script/master/Plugin/General.plugin, tag=General, enabled=true
https://subweb.oss-cn-hongkong.aliyuncs.com/Module/embyUnlocked.plugin, tag=Emby, enabled=true
https://raw.githubusercontent.com/blackmatrix7/ios_rule_script/master/external/Loon/TikTokUnlock/TikTokJP.plugin, tag=TiktokJP, enabled=false
https://raw.githubusercontent.com/blackmatrix7/ios_rule_script/master/external/Loon/TikTokUnlock/TikTokKR.plugin, tag=TiktokKR, enabled=false
https://raw.githubusercontent.com/blackmatrix7/ios_rule_script/master/external/Loon/TikTokUnlock/TikTokUS.plugin, tag=TiktokUS, enabled=false
https://raw.githubusercontent.com/blackmatrix7/ios_rule_script/master/external/Loon/TikTokUnlock/TikTokTW.plugin, tag=TiktokTW, enabled=false

[Rule]
GEOIP,CN,DIRECT
FINAL,PROXY

[Mitm]
skip-server-cert-verify = true
enable = true
ca-passphrase ={MITM_passphrase}
ca-p12 ={MITM_p12}
hostname =*.music.163.com, music.163.com, *.music.126.net, music.126.net, *.abema.tv, *.amemv.com, abema.tv, api.abema.io