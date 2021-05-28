#!MANAGED-CONFIG {url} interval=43200

[General]
// General
http-listen = 0.0.0.0:8888
socks5-listen = 0.0.0.0:8889

external-controller-access = lhie1@0.0.0.0:6170

internet-test-url = http://www.gstatic.com/generate_204
proxy-test-url = http://www.gstatic.com/generate_204

test-timeout = 3
ipv6 = false
show-error-page-for-reject = true

// DNS
dns-server = system, 119.29.29.29, 119.28.28.28, 1.2.4.8, 182.254.116.116

// Advanced
loglevel = notify
skip-proxy = 127.0.0.1, 192.168.0.0/16, 10.0.0.0/8, 172.16.0.0/12, 100.64.0.0/10, 17.0.0.0/8, localhost, *.local, *.crashlytics.com
exclude-simple-hostnames = true
use-default-policy-if-wifi-not-primary = false

// Others
allow-wifi-access = true
enhanced-mode-by-rule = false
// network-framework = true

[Replica]
hide-apple-request = true
hide-crashlytics-request = true
hide-udp = false
keyword-filter-type = false


[Proxy]
Direct = direct
{serverinfo}

[Proxy Group]
{SystemName} = select,{allserver_main}
Domestic = select, Direct, {SystemName}, {chinaserver}
🍎 Apple = select, Direct, {SystemName}, {allserver}
🎵 Tiktok = select, Direct, {SystemName}, {allserver}
🎵 YouTube Music= select, {SystemName}, Direct, {allserver}
🎬 YouTube = select, {SystemName}, Direct, {allserver}
🎬 iQiyi = select, Direct, {SystemName}, {allserver}
🎬 Bilibili = select, Direct, {SystemName}, {allserver}
🎬 myTVSUPER = select, {SystemName}, Direct, {allserver}
📺 Netflix = select, {SystemName}, Direct, {allserver}
📽 GlobalMedia = select, {SystemName}, Direct, {allserver}
🌐 Google = select, {SystemName}, Direct, {allserver}
🖥 Microsoft = select, {SystemName}, Direct, {allserver}
📟 Twitter = select, {SystemName}, Direct, {allserver}
📲 LineTV = select, {SystemName}, Direct, {allserver}
📲 Telegram = select, {SystemName}, Direct, {allserver}
📡 Global = select, {SystemName}, Direct, {allserver}
🧭 Final = select, {SystemName}, Direct, {allserver}

[Rule]
{EmbyNode}# > Spotify
DOMAIN-SUFFIX,ap.spotify.com,Direct
# > Client
# > Proxy
PROCESS-NAME,v2ray,Direct
PROCESS-NAME,ss-local,Direct
PROCESS-NAME,UUBooster,Direct

# > Download
PROCESS-NAME,aria2c,Direct
PROCESS-NAME,fdm,Direct
PROCESS-NAME,Folx,Direct
PROCESS-NAME,NetTransport,Direct
PROCESS-NAME,Thunder,Direct
PROCESS-NAME,Transmission,Direct
PROCESS-NAME,uTorrent,Direct
PROCESS-NAME,WebTorrent,Direct
PROCESS-NAME,WebTorrent Helper,Direct

# ------Rulesets (规则集）------
# > Advertising (广告)
#RULE-SET, https://raw.githubusercontent.com/DivineEngine/Profiles/master/Surge/Ruleset/Guard/Advertising.list, 🚫 ℬ𝒶𝓃𝓁𝒾𝓈𝓉𝓈

# > Privacy (隐私)
#RULE-SET, https://raw.githubusercontent.com/DivineEngine/Profiles/master/Surge/Ruleset/Guard/Privacy.list, 🔰 ℋ𝒾𝒿𝒶𝒸𝓀𝒾𝓃ℊ

# > Hijacking (运营商劫持或恶意网站)
#RULE-SET, https://raw.githubusercontent.com/DivineEngine/Profiles/master/Surge/Ruleset/Guard/Hijacking.list, 🔰 ℋ𝒾𝒿𝒶𝒸𝓀𝒾𝓃ℊ

RULE-SET,https://raw.githubusercontent.com/lhie1/Rules/master/Surge/Surge%203/Provider/Media/Bilibili.list, 🎬 Bilibili

RULE-SET,https://raw.githubusercontent.com/lhie1/Rules/master/Surge/Surge%203/Provider/Media/myTV%20SUPER.list, 🎬 myTVSUPER

RULE-SET,https://raw.githubusercontent.com/lhie1/Rules/master/Surge/Surge%203/Provider/Media/Line%20TV.list, 📲 LineTV

RULE-SET,https://raw.githubusercontent.com/lhie1/Rules/master/Surge/Surge%203/Provider/Media/iQiyi.list, 🎬 iQiyi

# > TikTok
RULE-SET, https://raw.githubusercontent.com/DivineEngine/Profiles/master/Surge/Ruleset/StreamingMedia/Video/TikTok.list, 🎵 Tiktok

# > YouTube Music
RULE-SET,https://raw.githubusercontent.com/DivineEngine/Profiles/master/Surge/Ruleset/StreamingMedia/Music/YouTube-Music.list, 🎵 YouTube Music

# > YouTube
RULE-SET, https://raw.githubusercontent.com/DivineEngine/Profiles/master/Surge/Ruleset/StreamingMedia/Video/YouTube.list, 🎬 YouTube

# > Netflix
RULE-SET, https://raw.githubusercontent.com/DivineEngine/Profiles/master/Surge/Ruleset/StreamingMedia/Video/Netflix.list, 📺 Netflix

# > GlobalMedia
RULE-SET, https://raw.githubusercontent.com/DivineEngine/Profiles/master/Surge/Ruleset/StreamingMedia/Streaming.list, 📽 GlobalMedia

# > Google
RULE-SET, https://raw.githubusercontent.com/blackmatrix7/ios_rule_script/master/rule/Surge/Google/Google.list, 🌐 Google

# > Microsoft
RULE-SET, https://raw.githubusercontent.com/blackmatrix7/ios_rule_script/master/rule/Surge/Microsoft/Microsoft.list, 🖥 Microsoft

# > Twitter
RULE-SET, https://raw.githubusercontent.com/DivineEngine/Profiles/master/Surge/Ruleset/Extra/Twitter.list, 📟 Twitter

# > Telegram
RULE-SET, https://raw.githubusercontent.com/DivineEngine/Profiles/master/Surge/Ruleset/Extra/Telegram/Telegram.list, 📲 Telegram

# > Global
RULE-SET, https://raw.githubusercontent.com/DivineEngine/Profiles/master/Surge/Ruleset/Global.list, 📡 Global

# > Apple
RULE-SET, https://raw.githubusercontent.com/eHpo1/Rules/master/Surge4/Ruleset/Apple_CDN.list, 🍎 Apple
RULE-SET, https://raw.githubusercontent.com/eHpo1/Rules/master/Surge4/Ruleset/Apple_API.list, 🍎 Apple

# > NetEaseMusic
#RULE-SET, https://raw.githubusercontent.com/blackmatrix7/ios_rule_script/master/rule/Surge/NetEaseMusic/NetEaseMusic.list, 🎸 𝒩ℯ𝓉ℯ𝒶𝓈ℯℳ𝓊𝓈𝒾𝒸

# > China
RULE-SET, https://raw.githubusercontent.com/DivineEngine/Profiles/master/Surge/Ruleset/China.list, Direct

# > Local Area Network 局域网
IP-CIDR,192.168.0.0/16,Direct
IP-CIDR,10.0.0.0/8,Direct
IP-CIDR,172.16.0.0/12,Direct
IP-CIDR,127.0.0.0/8,Direct
IP-CIDR,100.64.0.0/10,Direct
IP-CIDR,224.0.0.0/4,Direct

# > ChinaIP
# 使用来自 ipipdotnet 的 ChinaIP 以解决数据不准确的问题，使用 ChinaIP.list 时禁用「GEOIP,CN」规则
RULE-SET, https://raw.githubusercontent.com/DivineEngine/Profiles/master/Surge/Ruleset/Extra/ChinaIP.list,Direct

# > GeoIP China(若启用，则禁用 ChinaIP.list)
# GEOIP,CN,Direct

# > DNS 查询失败走 Final 规则
FINAL,🧭 Final,dns-failed

#===============================================================================




# 覆盖系统DNS，设置和配置本地DNS映射记录
[Host]
# > 该段定义本地 DNS 记录
# > 该功能等同于 /etc/hosts，加上了泛解析和别名支持。

# > Firebase Cloud Messaging
mtalk.google.com = 108.177.125.188

#===============================================================================




# 该段定义针对 HTTP 请求的 URL 重定向规则
[URL Rewrite]
# > 有两种重定向方式: 'header' 和 '302'
# > 建议用模块

# > Redirect Google Search Service
^(http|https):\/\/(www.)?(g|google)\.cn https://www.google.com 302
# AbeamTV Unlock
^https?:\/\/api\.abema\.io\/v\d\/ip\/check - reject

# Redirect Google Service
^https?:\/\/(www.)?g\.cn https://www.google.com 302
^https?:\/\/(www.)?google\.cn https://www.google.com 302

# Redirect HTTP to HTTPS
^https?:\/\/(www.)?taobao\.com\/ https://www.taobao.com/ 302
^https?:\/\/(www.)?jd\.com\/ https://www.jd.com/ 302
^https?:\/\/(www.)?mi\.com\/ https://www.mi.com/ 302
^https?:\/\/you\.163\.com\/ https://you.163.com/ 302
^https?:\/\/(www.)?suning\.com/ https://suning.com/ 302
^https?:\/\/(www.)?yhd\.com https://yhd.com/ 302


#===============================================================================




[MITM]
enable = true
tcp-connection = false
skip-server-cert-verify = true
hostname = %APPEND% *.abema.tv, *.amemv.com, *.chelaile.net.cn, *.didistatic.com, *.google-analytics.com, *.googlevideo.com, *.iydsj.com, *.k.sohu.com, *.kfc.com, *.kingsoft-office-service.com, *.meituan.net, *.ofo.com, *.pixiv.net, *.pstatp.com, *.rixcloudservice.com, *.snssdk.com, *.uve.weibo.com, *.wikipedia.org, *.wikiwand.com, *.ydstatic.com, *.youdao.com, *.youtube.com, *.zhuishushenqi.com, 119.18.193.135, 123.59.31.1, 153.3.236.81, 180.101.212.22, 218.11.3.70, 59.151.53.6, a.apicloud.com, a.applovin.com, a.qiumibao.com, a.sfansclub.com, a.wkanx.com, abema.tv, acs.m.taobao.com, act.vip.iqiyi.com, adse.ximalaya.com, api*.amemv.com, api*.musical.ly, api*.tiktokv.com, api-release.wuta-cam.com, api.abema.io, api.bilibili.com, api.daydaycook.com.cn, api.gotokeep.com, api.intsig.net, api.jr.mi.com, api.jxedt.com, api.kkmh.com, api.m.jd.com, api.mgzf.com, api.psy-1.com, api.rr.tv, api.smzdm.com, api.tv.sohu.com, api.wallstreetcn.com, api.weibo.cn, api.xiachufang.com, api.zhihu.com, api.zhuishushenqi.com, api5.futunn.com, app.10086.cn, app.58.com, app.api.ke.com, app.bilibili.com, app.mixcapp.com, app.variflight.com, app.wy.guahao.com, b.zhuishushenqi.com, c.m.163.com, cap.caocaokeji.cn, capi.mwee.cn, cdn.moji.com, channel.beitaichufang.com, client.mail.163.com, cms.daydaycook.com.cn, dspsdk.abreader.com, fdfs.xmcdn.com, gateway.shouqiev.com, gw-passenger.01zhuanche.com, gw.alicdn.com, huichuan.sm.cn, i.weread.qq.com, i.ys7.com, iapi.bishijie.com, iface.iqiyi.com, img*.doubanio.com, img.jiemian.com, interface.music.163.com, ios.wps.cn, m*.amap.com, m.client.10010.com, m.creditcard.ecitic.com, m.ibuscloud.com, m.yap.yahoo.com, mapi.mafengwo.cn, mapi.weibo.com, media.qyer.com, mi.gdt.qq.com, mob.mddcloud.com.cn, mobile-api2011.elong.com, mp.weixin.qq.com, mrobot.pcauto.com.cn, mrobot.pconline.com.cn, ms.jr.jd.com, msspjh.emarbox.com, newsso.map.qq.com, nnapp.cloudbae.cn, open.qyer.com, portal-xunyou.qingcdn.com, pss.txffp.com, r.inews.qq.com, render.alipay.com, res-release.wuta-cam.com, richmanapi.jxedt.com, service.4gtv.tv, smkmp.96225.com, snailsleep.net, sp.kaola.com, ssl.kohsocialapp.qq.com, static.vuevideo.net, static1.keepcdn.com, support.you.163.com, thor.weidian.com, www.dandanzan.com, www.flyertea.com, www.zhihu.com, youtubei.googleapis.com, zhidao.baidu.com, *.music.163.com, *.music.126.net, music.163.com, music.126.net, api.weibo.cn, mapi.weibo.com, *.uve.weibo.com, ios.prod.ftl.netflix.com,  trade-acs.m.taobao.com, api.gotokeep.com
ca-passphrase = {MITM_passphrase}
ca-p12 = {MITM_p12}
#===============================================================================




# 使用 JavaScript 来对修改请求体、响应体、定时执行脚本、特定事件执行脚本、规则判定、policy-group判定、执行DNS解析等
[Script]

