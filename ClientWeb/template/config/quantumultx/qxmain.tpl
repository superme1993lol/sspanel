[general]
server_check_url=http://www.gstatic.com/generate_204
excluded_routes=192.168.0.0/16, 193.168.0.0/24, 10.0.0.0/8, 172.16.0.0/12, 100.64.0.0/10, 17.0.0.0/8
dns_exclusion_list = *.cmpassport.com,  *.jegotrip.com.cn, *.icitymobile.mobi, *.pingan.com.cn, *.cmbchina.com

[dns]
server=119.29.29.29
server=223.5.5.5

[policy]
static=🔰 proxy, proxy, {servername}, img-url=https://raw.githubusercontent.com/Koolson/Qure/master/IconSet/China.png
static=📲 Telegram, 🔰 proxy, direct, {servername}, img-url=https://raw.githubusercontent.com/HuiDoY/Koolson-Qure/master/IconSet/Color/Telegram.png
static=🎵 YouTube Music, 🔰 proxy, direct, {servername}, img-url=https://raw.githubusercontent.com/HuiDoY/Koolson-Qure/master/IconSet/Color/YouTube_Music.png
static=🎬 YouTube, 🔰 proxy, direct, {servername}, img-url=https://raw.githubusercontent.com/HuiDoY/Koolson-Qure/master/IconSet/Color/YouTube.png
static=🎥 NETFLIX, 🔰 proxy, direct, {servername}, img-url=https://raw.githubusercontent.com/HuiDoY/Koolson-Qure/master/IconSet/Color/Netflix.png
static=🎬 Emby, {servername_emby}, 🔰 proxy, direct, {servername}, img-url=https://raw.githubusercontent.com/HuiDoY/Koolson-Qure/master/IconSet/Color/Emby.png
static=📺 巴哈姆特, 🔰 proxy, direct, {servername}, img-url=https://raw.githubusercontent.com/Koolson/Qure/master/IconSet/Bahamut.png
static=📺 AbemaTV, 🔰 proxy, direct, {servername}, img-url=https://raw.githubusercontent.com/Koolson/Qure/master/IconSet/AbemaTV.png
static=🌏 BiliBili, direct, 🔰 proxy, {servername}, img-url=https://raw.githubusercontent.com/HuiDoY/Koolson-Qure/master/IconSet/Color/bilibili.png
static=🍎 Apple, 🔰 proxy, direct, {servername}, img-url=https://raw.githubusercontent.com/HuiDoY/Koolson-Qure/master/IconSet/Color/Apple.png
static=🎵 Tiktok, 🔰 proxy, direct, {servername}, img-url=https://raw.githubusercontent.com/HuiDoY/Koolson-Qure/master/IconSet/Color/TikTok.png
static=📽 GlobalMedia, 🔰 proxy, direct, {servername}, img-url=https://raw.githubusercontent.com/HuiDoY/Koolson-Qure/master/IconSet/Color/Final.png
static=📡 Global, 🔰 proxy, direct, {servername}, img-url=https://raw.githubusercontent.com/HuiDoY/Koolson-Qure/master/IconSet/Color/Final.png
static=China, direct, 🔰 proxy, {servername}, img-url=https://raw.githubusercontent.com/Koolson/Qure/master/IconSet/China.png
static=Final, 🔰 proxy, direct, {servername}, img-url=https://raw.githubusercontent.com/Koolson/Qure/master/IconSet/China.png

[server_remote]
{Domain}/Config/SurgeNode?token={token}, tag={SystemName}, enabled=true, img-url=https://raw.githubusercontent.com/Koolson/Qure/master/IconSet/China.png, update-interval=86400

[filter_remote]
# ------Rulesets (规则集）------
# > China
https://raw.githubusercontent.com/chuheme/DivineEngine/master/QuantumultX/Filter/China.list, tag=China, enabled=true
# > Advertising (广告)
# https://raw.githubusercontent.com/DivineEngine/Profiles/master/Surge/Ruleset/Guard/Advertising.list, 🚫 ℬ𝒶𝓃𝓁𝒾𝓈𝓉𝓈, enabled=true
# > Privacy (隐私)
# https://raw.githubusercontent.com/DivineEngine/Profiles/master/Surge/Ruleset/Guard/Privacy.list, 🔰 ℋ𝒾𝒿𝒶𝒸𝓀𝒾𝓃ℊ, enabled=true
# > Hijacking (运营商劫持或恶意网站)
# https://raw.githubusercontent.com/DivineEngine/Profiles/master/Surge/Ruleset/Guard/Hijacking.list, 🔰 ℋ𝒾𝒿𝒶𝒸𝓀𝒾𝓃ℊ, enabled=true
# > NetEaseMusic
# https://raw.githubusercontent.com/blackmatrix7/ios_rule_script/master/rule/Surge/NetEaseMusic/NetEaseMusic.list, tag=🎸 𝒩ℯ𝓉ℯ𝒶𝓈ℯℳ𝓊𝓈𝒾𝒸, enabled=true

[rewrite_remote]
https://raw.githubusercontent.com/DivineEngine/Profiles/master/Quantumult/Rewrite/General.conf, tag=🔀General, enabled=true
https://subweb.oss-cn-hongkong.aliyuncs.com/Module/embyUnlocked.conf, tag=🔀General, enabled=true
https://raw.githubusercontent.com/Tartarus2014/QuantumultX-Script/main/Unlock/TiktokJP.conf, tag=Tiktok, enabled=false

[server_local]

[filter_local]

# > Telegram
DOMAIN-SUFFIX,t.me,📲 Telegram
DOMAIN-SUFFIX,tdesktop.com,📲 Telegram
DOMAIN-SUFFIX,telegra.ph,📲 Telegram
DOMAIN-SUFFIX,telegram.me,📲 Telegram
DOMAIN-SUFFIX,telegram.org,📲 Telegram
ip-cidr, 91.108.4.0/22,📲 Telegram
ip-cidr, 91.108.8.0/22,📲 Telegram
ip-cidr, 91.108.12.0/22,📲 Telegram
ip-cidr, 91.108.16.0/22,📲 Telegram
ip-cidr, 91.108.56.0/22,📲 Telegram
ip-cidr, 149.154.160.0/20,📲 Telegram

# > YouTube Music
# ⚠️ 注意，需要放置在 YouTube.list 之前
USER-AGENT,com.google.ios.youtubemusic*,🎵 YouTube Music
USER-AGENT,YouTubeMusic*,🎵 YouTube Music

# > YouTube
USER-AGENT,com.google.ios.youtube*,🎬 YouTube
USER-AGENT,YouTube*,🎬 YouTube
DOMAIN-KEYWORD,youtube,🎬 YouTube
DOMAIN-SUFFIX,youtu.be,🎬 YouTube
DOMAIN-SUFFIX,googlevideo.com,🎬 YouTube
DOMAIN-SUFFIX,ytimg.com,🎬 YouTube
DOMAIN-SUFFIX,ggpht.com,🎬 YouTube
DOMAIN-SUFFIX,gvt2.com,🎬 YouTube
DOMAIN-SUFFIX,app-measurement.com,🎬 YouTube
DOMAIN-SUFFIX,appspot.com,🎬 YouTube
DOMAIN-SUFFIX,blogger.com,🎬 YouTube
DOMAIN-SUFFIX,getoutline.org,🎬 YouTube
DOMAIN-SUFFIX,gvt0.com,🎬 YouTube
DOMAIN-SUFFIX,gvt3.com,🎬 YouTube
DOMAIN-SUFFIX,xn--ngstr-lra8j.com,🎬 YouTube
DOMAIN-KEYWORD,google,🎬 YouTube
DOMAIN-KEYWORD,.blogspot.,🎬 YouTube

# > 🎥 NETFLIX
USER-AGENT,Argo*,🎥 NETFLIX
DOMAIN-KEYWORD,netflix,🎥 NETFLIX
DOMAIN-SUFFIX,fast.com,🎥 NETFLIX
DOMAIN-SUFFIX,nflxext.com,🎥 NETFLIX
DOMAIN-SUFFIX,nflximg.com,🎥 NETFLIX
DOMAIN-SUFFIX,nflximg.net,🎥 NETFLIX
DOMAIN-SUFFIX,nflxso.net,🎥 NETFLIX
DOMAIN-SUFFIX,nflxvideo.net,🎥 NETFLIX
IP-CIDR,23.246.0.0/18,🎥 NETFLIX,no-resolve
IP-CIDR,37.77.184.0/21,🎥 NETFLIX,no-resolve
IP-CIDR,45.57.0.0/17,🎥 NETFLIX,no-resolve
IP-CIDR,64.120.128.0/17,🎥 NETFLIX,no-resolve
IP-CIDR,66.197.128.0/17,🎥 NETFLIX,no-resolve
IP-CIDR,108.175.32.0/20,🎥 NETFLIX,no-resolve
IP-CIDR,192.173.64.0/18,🎥 NETFLIX,no-resolve
IP-CIDR,198.38.96.0/19,🎥 NETFLIX,no-resolve
IP-CIDR,198.45.48.0/20,🎥 NETFLIX,no-resolve
IP-CIDR,8.41.4.0/24,🎥 NETFLIX,no-resolve
IP-CIDR,69.53.224.0/19,🎥 NETFLIX,no-resolve
IP-CIDR,185.2.220.0/22,🎥 NETFLIX,no-resolve
IP-CIDR,185.9.188.0/22,🎥 NETFLIX,no-resolve
IP-CIDR,203.75.0.0/16,🎥 NETFLIX,no-resolve
IP-CIDR,207.45.72.0/22,🎥 NETFLIX,no-resolve
IP-CIDR,208.75.76.0/22,🎥 NETFLIX,no-resolve

# > 📺 巴哈姆特
USER-AGENT,Anime*,📺 巴哈姆特
DOMAIN-SUFFIX,bahamut.com.tw,📺 巴哈姆特
DOMAIN-SUFFIX,gamer.com.tw,📺 巴哈姆特
DOMAIN,gamer-cds.cdn.hinet.net,📺 巴哈姆特
DOMAIN,gamer2-cds.cdn.hinet.net,📺 巴哈姆特

# > 📺 AbemaTV
USER-AGENT,AbemaTV*,📺 AbemaTV
DOMAIN-KEYWORD,abema,📺 AbemaTV
DOMAIN-KEYWORD,ameba,📺 AbemaTV
DOMAIN-SUFFIX,hayabusa.io,📺 AbemaTV

# > 🌏 BiliBili
DOMAIN-KEYWORD,qiyi,🌏 BiliBili
DOMAIN-SUFFIX,qy.net,🌏 BiliBili
IP-CIDR,101.227.0.0/16,🌏 BiliBili,no-resolve
IP-CIDR,101.224.0.0/13,🌏 BiliBili,no-resolve
IP-CIDR,119.176.0.0/12,🌏 BiliBili,no-resolve
DOMAIN-KEYWORD,epic,🌏 BiliBili
USER-AGENT,bili*,🌏 BiliBili
USER-AGENT,Bilibili*,🌏 BiliBili
DOMAIN-SUFFIX,acg.tv,🌏 BiliBili
DOMAIN-SUFFIX,acgvideo.com,🌏 BiliBili
DOMAIN-SUFFIX,b23.tv,🌏 BiliBili
DOMAIN-SUFFIX,bigfun.cn,🌏 BiliBili
DOMAIN-SUFFIX,bigfunapp.cn,🌏 BiliBili
DOMAIN-SUFFIX,biliapi.com,🌏 BiliBili
DOMAIN-SUFFIX,biliapi.net,🌏 BiliBili
DOMAIN-SUFFIX,bilibili.com,🌏 BiliBili
DOMAIN-SUFFIX,bilibili.tv,🌏 BiliBili
DOMAIN-SUFFIX,biligame.com,🌏 BiliBili
DOMAIN-SUFFIX,biligame.net,🌏 BiliBili
DOMAIN-SUFFIX,bilivideo.com,🌏 BiliBili
DOMAIN-SUFFIX,hdslb.com,🌏 BiliBili
DOMAIN-SUFFIX,im9.com,🌏 BiliBili
DOMAIN,upos-hz-mirrorakam.akamaized.net,🌏 BiliBili
DOMAIN-SUFFIX,smtcdns.net,🌏 BiliBili

# > Apple
DOMAIN-SUFFIX,aaplimg.com,🍎 Apple
DOMAIN-SUFFIX,apple.co,🍎 Apple
DOMAIN-SUFFIX,apple.com,🍎 Apple
DOMAIN-SUFFIX,apple-cloudkit.com,🍎 Apple
DOMAIN-SUFFIX,appstore.com,🍎 Apple
DOMAIN-SUFFIX,cdn-apple.com,🍎 Apple
DOMAIN-SUFFIX,crashlytics.com,🍎 Apple
DOMAIN-SUFFIX,icloud.com,🍎 Apple
DOMAIN-SUFFIX,icloud-content.com,🍎 Apple
DOMAIN-SUFFIX,me.com,🍎 Apple
DOMAIN-SUFFIX,mzstatic.com,🍎 Apple
host,www-cdn.icloud.com.akadns.net,🍎 Apple

# > 🎵 Tiktok
DOMAIN-SUFFIX,byteoversea.com,🎵 Tiktok
DOMAIN-SUFFIX,ibytedtos.com,🎵 Tiktok
DOMAIN-SUFFIX,ipstatp.com,🎵 Tiktok
DOMAIN-SUFFIX,muscdn.com,🎵 Tiktok
DOMAIN-SUFFIX,musical.ly,🎵 Tiktok
DOMAIN-SUFFIX,tiktok.com,🎵 Tiktok
DOMAIN-SUFFIX,tik-tokapi.com,🎵 Tiktok
DOMAIN-SUFFIX,tiktokcdn.com,🎵 Tiktok
DOMAIN-SUFFIX,tiktokv.com,🎵 Tiktok
DOMAIN-KEYWORD,-tiktokcdn-com,🎵 Tiktok

# (GlobalMedia)
# (Music)
# > Deezer
user-agent,Deezer*,📽 GlobalMedia
DOMAIN-SUFFIX,deezer.com,📽 GlobalMedia
DOMAIN-SUFFIX,dzcdn.net,📽 GlobalMedia
# > KKBOX
DOMAIN-SUFFIX,kkbox.com,📽 GlobalMedia
DOMAIN-SUFFIX,kkbox.com.tw,📽 GlobalMedia
DOMAIN-SUFFIX,kfs.io,📽 GlobalMedia
# > JOOX
user-agent,WeMusic*,📽 GlobalMedia
user-agent,JOOX*,📽 GlobalMedia
DOMAIN-SUFFIX,joox.com,📽 GlobalMedia
# > Pandora
user-agent,Pandora*,📽 GlobalMedia
DOMAIN-SUFFIX,pandora.com,📽 GlobalMedia
# > SoundCloud
user-agent,SoundCloud*,📽 GlobalMedia
DOMAIN-SUFFIX,p-cdn.us,📽 GlobalMedia
DOMAIN-SUFFIX,sndcdn.com,📽 GlobalMedia
DOMAIN-SUFFIX,soundcloud.com,📽 GlobalMedia
# > Spotify
user-agent,Spotify*,📽 GlobalMedia
DOMAIN-SUFFIX,pscdn.co,📽 GlobalMedia
DOMAIN-SUFFIX,scdn.co,📽 GlobalMedia
DOMAIN-SUFFIX,spotify.com,📽 GlobalMedia
DOMAIN-SUFFIX,spoti.fi,📽 GlobalMedia
host-keyword,spotify.com,📽 GlobalMedia
host-keyword,-spotify-com,📽 GlobalMedia
# > TIDAL
user-agent,TIDAL*,📽 GlobalMedia
DOMAIN-SUFFIX,tidal.com,📽 GlobalMedia
# > YouTubeMusic
user-agent,com.google.ios.youtubemusic*,📽 GlobalMedia
user-agent,YouTubeMusic*,📽 GlobalMedia
# (Video)
# > All4
user-agent,All4*,📽 GlobalMedia
DOMAIN-SUFFIX,c4assets.com,📽 GlobalMedia
DOMAIN-SUFFIX,channel4.com,📽 GlobalMedia
# > AbemaTV
user-agent,AbemaTV*,📽 GlobalMedia
DOMAIN-SUFFIX,abema.io,📽 GlobalMedia
DOMAIN-SUFFIX,ameba.jp,📽 GlobalMedia
DOMAIN-SUFFIX,abema.tv,📽 GlobalMedia
DOMAIN-SUFFIX,hayabusa.io,📽 GlobalMedia
host,abematv.akamaized.net,📽 GlobalMedia
host,ds-linear-abematv.akamaized.net,📽 GlobalMedia
host,ds-vod-abematv.akamaized.net,📽 GlobalMedia
host,linear-abematv.akamaized.net,📽 GlobalMedia
# > Amazon Prime Video
user-agent,InstantVideo.US*,📽 GlobalMedia
user-agent,Prime%20Video*,📽 GlobalMedia
DOMAIN-SUFFIX,aiv-cdn.net,📽 GlobalMedia
DOMAIN-SUFFIX,aiv-delivery.net,📽 GlobalMedia
DOMAIN-SUFFIX,amazonvideo.com,📽 GlobalMedia
DOMAIN-SUFFIX,primevideo.com,📽 GlobalMedia
host,avodmp4s3ww-a.akamaihd.net,📽 GlobalMedia
host,d25xi40x97liuc.cloudfront.net,📽 GlobalMedia
host,dmqdd6hw24ucf.cloudfront.net,📽 GlobalMedia
host,d22qjgkvxw22r6.cloudfront.net,📽 GlobalMedia
host,d1v5ir2lpwr8os.cloudfront.net,📽 GlobalMedia
host-keyword,avoddashs,📽 GlobalMedia
# > Bahamut
user-agent,Anime*,📽 GlobalMedia
DOMAIN-SUFFIX,bahamut.com.tw,📽 GlobalMedia
DOMAIN-SUFFIX,gamer.com.tw,📽 GlobalMedia
host,gamer-cds.cdn.hinet.net,📽 GlobalMedia
host,gamer2-cds.cdn.hinet.net,📽 GlobalMedia
# > BBC iPlayer
user-agent,BBCiPlayer*,📽 GlobalMedia
DOMAIN-SUFFIX,bbc.co.uk,📽 GlobalMedia
DOMAIN-SUFFIX,bbci.co.uk,📽 GlobalMedia
host-keyword,bbcfmt,📽 GlobalMedia
host-keyword,uk-live,📽 GlobalMedia
# > DAZN
user-agent,DAZN*,📽 GlobalMedia
DOMAIN-SUFFIX,dazn.com,📽 GlobalMedia
DOMAIN-SUFFIX,dazn-api.com,📽 GlobalMedia
host,d151l6v8er5bdm.cloudfront.net,📽 GlobalMedia
host-keyword,voddazn,📽 GlobalMedia
# > Disney+
user-agent,Disney+*,📽 GlobalMedia
DOMAIN-SUFFIX,bamgrid.com,📽 GlobalMedia
DOMAIN-SUFFIX,disney-plus.net,📽 GlobalMedia
DOMAIN-SUFFIX,disneyplus.com,📽 GlobalMedia
DOMAIN-SUFFIX,dssott.com,📽 GlobalMedia
host,cdn.registerdisney.go.com,📽 GlobalMedia
# > encoreTVB
user-agent,encoreTVB*,📽 GlobalMedia
DOMAIN-SUFFIX,encoretvb.com,📽 GlobalMedia
host,edge.api.brightcove.com,📽 GlobalMedia
host,bcbolt446c5271-a.akamaihd.net,📽 GlobalMedia
# > FOX NOW
user-agent,FOX%20NOW*,📽 GlobalMedia
DOMAIN-SUFFIX,fox.com,📽 GlobalMedia
DOMAIN-SUFFIX,foxdcg.com,📽 GlobalMedia
DOMAIN-SUFFIX,theplatform.com,📽 GlobalMedia
DOMAIN-SUFFIX,uplynk.com,📽 GlobalMedia
# > HBO NOW
user-agent,HBO%20NOW*,📽 GlobalMedia
DOMAIN-SUFFIX,hbo.com,📽 GlobalMedia
DOMAIN-SUFFIX,hbogo.com,📽 GlobalMedia
DOMAIN-SUFFIX,hbonow.com,📽 GlobalMedia
# > HBO GO HKG
user-agent,HBO%20GO%20PROD%20HKG*,📽 GlobalMedia
DOMAIN-SUFFIX,hbogoasia.com,📽 GlobalMedia
DOMAIN-SUFFIX,hbogoasia.hk,📽 GlobalMedia
host,bcbolthboa-a.akamaihd.net,📽 GlobalMedia
host,players.brightcove.net,📽 GlobalMedia
host,s3-ap-southeast-1.amazonaws.com,📽 GlobalMedia
host,dai3fd1oh325y.cloudfront.net,📽 GlobalMedia
host,44wilhpljf.execute-api.ap-southeast-1.amazonaws.com,📽 GlobalMedia
host,hboasia1-i.akamaihd.net,📽 GlobalMedia
host,hboasia2-i.akamaihd.net,📽 GlobalMedia
host,hboasia3-i.akamaihd.net,📽 GlobalMedia
host,hboasia4-i.akamaihd.net,📽 GlobalMedia
host,hboasia5-i.akamaihd.net,📽 GlobalMedia
host,cf-images.ap-southeast-1.prod.boltdns.net,📽 GlobalMedia
# > 华文电视
user-agent,HWTVMobile*,📽 GlobalMedia
DOMAIN-SUFFIX,5itv.tv,📽 GlobalMedia
DOMAIN-SUFFIX,ocnttv.com,📽 GlobalMedia
# > Hulu
DOMAIN-SUFFIX,hulu.com,📽 GlobalMedia
DOMAIN-SUFFIX,huluim.com,📽 GlobalMedia
DOMAIN-SUFFIX,hulustream.com,📽 GlobalMedia
# > Hulu(フールー)
DOMAIN-SUFFIX,happyon.jp,📽 GlobalMedia
DOMAIN-SUFFIX,hulu.jp,📽 GlobalMedia
# > ITV
user-agent,ITV_Player*,📽 GlobalMedia
DOMAIN-SUFFIX,itv.com,📽 GlobalMedia
DOMAIN-SUFFIX,itvstatic.com,📽 GlobalMedia
host,itvpnpmobile-a.akamaihd.net,📽 GlobalMedia
# > KKTV
user-agent,KKTV*,📽 GlobalMedia
user-agent,com.kktv.ios.kktv*,📽 GlobalMedia
DOMAIN-SUFFIX,kktv.com.tw,📽 GlobalMedia
DOMAIN-SUFFIX,kktv.me,📽 GlobalMedia
host,kktv-theater.kk.stream,📽 GlobalMedia
# > Line TV
user-agent,LINE%20TV*,📽 GlobalMedia
DOMAIN-SUFFIX,linetv.tw,📽 GlobalMedia
host,d3c7rimkq79yfu.cloudfront.net,📽 GlobalMedia
# > LiTV
DOMAIN-SUFFIX,litv.tv,📽 GlobalMedia
host,litvfreemobile-hichannel.cdn.hinet.net,📽 GlobalMedia
# > My5
user-agent,My5*,📽 GlobalMedia
DOMAIN-SUFFIX,channel5.com,📽 GlobalMedia
DOMAIN-SUFFIX,my5.tv,📽 GlobalMedia
host,d349g9zuie06uo.cloudfront.net,📽 GlobalMedia
# > myTV SUPER
user-agent,mytv*,📽 GlobalMedia
DOMAIN-SUFFIX,mytvsuper.com,📽 GlobalMedia
DOMAIN-SUFFIX,tvb.com,📽 GlobalMedia
# > Netflix
user-agent,Argo*,📽 GlobalMedia
DOMAIN-SUFFIX,netflix.com,📽 GlobalMedia
DOMAIN-SUFFIX,netflix.net,📽 GlobalMedia
DOMAIN-SUFFIX,nflxext.com,📽 GlobalMedia
DOMAIN-SUFFIX,nflximg.com,📽 GlobalMedia
DOMAIN-SUFFIX,nflximg.net,📽 GlobalMedia
DOMAIN-SUFFIX,nflxso.net,📽 GlobalMedia
DOMAIN-SUFFIX,nflxvideo.net,📽 GlobalMedia
DOMAIN-SUFFIX,netflixdnstest0.com,📽 GlobalMedia
DOMAIN-SUFFIX,netflixdnstest1.com,📽 GlobalMedia
DOMAIN-SUFFIX,netflixdnstest2.com,📽 GlobalMedia
DOMAIN-SUFFIX,netflixdnstest3.com,📽 GlobalMedia
DOMAIN-SUFFIX,netflixdnstest4.com,📽 GlobalMedia
DOMAIN-SUFFIX,netflixdnstest5.com,📽 GlobalMedia
DOMAIN-SUFFIX,netflixdnstest6.com,📽 GlobalMedia
DOMAIN-SUFFIX,netflixdnstest7.com,📽 GlobalMedia
DOMAIN-SUFFIX,netflixdnstest8.com,📽 GlobalMedia
DOMAIN-SUFFIX,netflixdnstest9.com,📽 GlobalMedia
ip-cidr, 23.246.0.0/18,📽 GlobalMedia
ip-cidr, 37.77.184.0/21,📽 GlobalMedia
ip-cidr, 45.57.0.0/17,📽 GlobalMedia
ip-cidr, 64.120.128.0/17,📽 GlobalMedia
ip-cidr, 66.197.128.0/17,📽 GlobalMedia
ip-cidr, 108.175.32.0/20,📽 GlobalMedia
ip-cidr, 192.173.64.0/18,📽 GlobalMedia
ip-cidr, 198.38.96.0/19,📽 GlobalMedia
ip-cidr, 198.45.48.0/20,📽 GlobalMedia
# > niconico
user-agent,Niconico*,📽 GlobalMedia
DOMAIN-SUFFIX,dmc.nico,📽 GlobalMedia
DOMAIN-SUFFIX,nicovideo.jp,📽 GlobalMedia
DOMAIN-SUFFIX,nimg.jp,📽 GlobalMedia
DOMAIN-SUFFIX,socdm.com,📽 GlobalMedia
# > PBS
user-agent,PBS*,📽 GlobalMedia
DOMAIN-SUFFIX,pbs.org,📽 GlobalMedia
# > Pornhub
DOMAIN-SUFFIX,phncdn.com,📽 GlobalMedia
DOMAIN-SUFFIX,pornhub.com,📽 GlobalMedia
DOMAIN-SUFFIX,pornhubpremium.com,📽 GlobalMedia
# > 台湾好
user-agent,TaiwanGood*,📽 GlobalMedia
DOMAIN-SUFFIX,skyking.com.tw,📽 GlobalMedia
host,hamifans.emome.net,📽 GlobalMedia
# > Twitch
DOMAIN-SUFFIX,twitch.tv,📽 GlobalMedia
DOMAIN-SUFFIX,twitchcdn.net,📽 GlobalMedia
DOMAIN-SUFFIX,ttvnw.net,📽 GlobalMedia
DOMAIN-SUFFIX,jtvnw.net,📽 GlobalMedia
# > ViuTV
user-agent,Viu*,📽 GlobalMedia
user-agent,ViuTV*,📽 GlobalMedia
DOMAIN-SUFFIX,viu.com,📽 GlobalMedia
DOMAIN-SUFFIX,viu.tv,📽 GlobalMedia
host,api.viu.now.com,📽 GlobalMedia
host,d1k2us671qcoau.cloudfront.net,📽 GlobalMedia
host,d2anahhhmp1ffz.cloudfront.net,📽 GlobalMedia
host,dfp6rglgjqszk.cloudfront.net,📽 GlobalMedia
# > YouTube
user-agent,com.google.ios.youtube*,📽 GlobalMedia
user-agent,YouTube*,📽 GlobalMedia
DOMAIN-SUFFIX,googlevideo.com,📽 GlobalMedia
DOMAIN-SUFFIX,youtube.com,📽 GlobalMedia
host,youtubei.googleapis.com,📽 GlobalMedia

# (DNS Cache Pollution Protection)
# > Google
DOMAIN-SUFFIX,ampproject.org,📡 Global
DOMAIN-SUFFIX,appspot.com,📡 Global
DOMAIN-SUFFIX,blogger.com,📡 Global
DOMAIN-SUFFIX,getoutline.org,📡 Global
DOMAIN-SUFFIX,gvt0.com,📡 Global
DOMAIN-SUFFIX,gvt1.com,📡 Global
DOMAIN-SUFFIX,gvt3.com,📡 Global
DOMAIN-SUFFIX,xn--ngstr-lra8j.com,📡 Global
host-keyword,google,📡 Global
host-keyword,blogspot,📡 Global
# > Microsoft
DOMAIN-SUFFIX,onedrive.live.com,📡 Global
DOMAIN-SUFFIX,xboxlive.com,📡 Global
# > Facebook
DOMAIN-SUFFIX,cdninstagram.com,📡 Global
DOMAIN-SUFFIX,fb.com,📡 Global
DOMAIN-SUFFIX,fb.me,📡 Global
DOMAIN-SUFFIX,fbaddins.com,📡 Global
DOMAIN-SUFFIX,fbcdn.net,📡 Global
DOMAIN-SUFFIX,fbsbx.com,📡 Global
DOMAIN-SUFFIX,fbworkmail.com,📡 Global
DOMAIN-SUFFIX,instagram.com,📡 Global
DOMAIN-SUFFIX,m.me,📡 Global
DOMAIN-SUFFIX,messenger.com,📡 Global
DOMAIN-SUFFIX,oculus.com,📡 Global
DOMAIN-SUFFIX,oculuscdn.com,📡 Global
DOMAIN-SUFFIX,rocksdb.org,📡 Global
DOMAIN-SUFFIX,whatsapp.com,📡 Global
DOMAIN-SUFFIX,whatsapp.net,📡 Global
host-keyword,facebook,📡 Global
ip-cidr, 3.123.36.126/32,📡 Global
ip-cidr, 35.157.215.84/32,📡 Global
ip-cidr, 35.157.217.255/32,📡 Global
ip-cidr, 52.58.209.134/32,📡 Global
ip-cidr, 54.93.124.31/32,📡 Global
ip-cidr, 54.162.243.80/32,📡 Global
ip-cidr, 54.173.34.141/32,📡 Global
ip-cidr, 54.235.23.242/32,📡 Global
ip-cidr, 169.45.248.118/32,📡 Global
# > Twitter
DOMAIN-SUFFIX,pscp.tv,📡 Global
DOMAIN-SUFFIX,periscope.tv,📡 Global
DOMAIN-SUFFIX,t.co,📡 Global
DOMAIN-SUFFIX,twimg.co,📡 Global
DOMAIN-SUFFIX,twimg.com,📡 Global
DOMAIN-SUFFIX,twitpic.com,📡 Global
DOMAIN-SUFFIX,vine.co,📡 Global
host-keyword,twitter,📡 Global
# > Telegram
DOMAIN-SUFFIX,t.me,📡 Global
DOMAIN-SUFFIX,tdesktop.com,📡 Global
DOMAIN-SUFFIX,telegra.ph,📡 Global
DOMAIN-SUFFIX,telegram.me,📡 Global
DOMAIN-SUFFIX,telegram.org,📡 Global
ip-cidr, 91.108.4.0/22,📡 Global
ip-cidr, 91.108.8.0/22,📡 Global
ip-cidr, 91.108.12.0/22,📡 Global
ip-cidr, 91.108.16.0/22,📡 Global
ip-cidr, 91.108.56.0/22,📡 Global
ip-cidr, 149.154.160.0/20,📡 Global
# > Line
DOMAIN-SUFFIX,line.me,📡 Global
DOMAIN-SUFFIX,line-apps.com,📡 Global
DOMAIN-SUFFIX,line-scdn.net,📡 Global
DOMAIN-SUFFIX,naver.jp,📡 Global
ip-cidr, 103.2.30.0/23,📡 Global
ip-cidr, 125.209.208.0/20,📡 Global
ip-cidr, 147.92.128.0/17,📡 Global
ip-cidr, 203.104.144.0/21,📡 Global
# > Other
DOMAIN-SUFFIX,4shared.com,📡 Global
DOMAIN-SUFFIX,520cc.cc,📡 Global
DOMAIN-SUFFIX,881903.com,📡 Global
DOMAIN-SUFFIX,9cache.com,📡 Global
DOMAIN-SUFFIX,9gag.com,📡 Global
DOMAIN-SUFFIX,abc.com,📡 Global
DOMAIN-SUFFIX,abc.net.au,📡 Global
DOMAIN-SUFFIX,abebooks.com,📡 Global
DOMAIN-SUFFIX,amazon.co.jp,📡 Global
DOMAIN-SUFFIX,apigee.com,📡 Global
DOMAIN-SUFFIX,apk-dl.com,📡 Global
DOMAIN-SUFFIX,apkfind.com,📡 Global
DOMAIN-SUFFIX,apkmirror.com,📡 Global
DOMAIN-SUFFIX,apkmonk.com,📡 Global
DOMAIN-SUFFIX,apkpure.com,📡 Global
DOMAIN-SUFFIX,aptoide.com,📡 Global
DOMAIN-SUFFIX,archive.is,📡 Global
DOMAIN-SUFFIX,archive.org,📡 Global
DOMAIN-SUFFIX,arte.tv,📡 Global
DOMAIN-SUFFIX,artstation.com,📡 Global
DOMAIN-SUFFIX,arukas.io,📡 Global
DOMAIN-SUFFIX,ask.com,📡 Global
DOMAIN-SUFFIX,avg.com,📡 Global
DOMAIN-SUFFIX,avgle.com,📡 Global
DOMAIN-SUFFIX,badoo.com,📡 Global
DOMAIN-SUFFIX,bandwagonhost.com,📡 Global
DOMAIN-SUFFIX,bbc.com,📡 Global
DOMAIN-SUFFIX,behance.net,📡 Global
DOMAIN-SUFFIX,bibox.com,📡 Global
DOMAIN-SUFFIX,biggo.com.tw,📡 Global
DOMAIN-SUFFIX,binance.com,📡 Global
DOMAIN-SUFFIX,bitcointalk.org,📡 Global
DOMAIN-SUFFIX,bitfinex.com,📡 Global
DOMAIN-SUFFIX,bitmex.com,📡 Global
DOMAIN-SUFFIX,bit-z.com,📡 Global
DOMAIN-SUFFIX,bloglovin.com,📡 Global
DOMAIN-SUFFIX,bloomberg.cn,📡 Global
DOMAIN-SUFFIX,bloomberg.com,📡 Global
DOMAIN-SUFFIX,blubrry.com,📡 Global
DOMAIN-SUFFIX,book.com.tw,📡 Global
DOMAIN-SUFFIX,booklive.jp,📡 Global
DOMAIN-SUFFIX,books.com.tw,📡 Global
DOMAIN-SUFFIX,boslife.net,📡 Global
DOMAIN-SUFFIX,box.com,📡 Global
DOMAIN-SUFFIX,businessinsider.com,📡 Global
DOMAIN-SUFFIX,bwh1.net,📡 Global
DOMAIN-SUFFIX,castbox.fm,📡 Global
DOMAIN-SUFFIX,cbc.ca,📡 Global
DOMAIN-SUFFIX,cdw.com,📡 Global
DOMAIN-SUFFIX,change.org,📡 Global
DOMAIN-SUFFIX,channelnewsasia.com,📡 Global
DOMAIN-SUFFIX,ck101.com,📡 Global
DOMAIN-SUFFIX,clarionproject.org,📡 Global
DOMAIN-SUFFIX,clyp.it,📡 Global
DOMAIN-SUFFIX,cna.com.tw,📡 Global
DOMAIN-SUFFIX,comparitech.com,📡 Global
DOMAIN-SUFFIX,conoha.jp,📡 Global
DOMAIN-SUFFIX,crucial.com,📡 Global
DOMAIN-SUFFIX,cts.com.tw,📡 Global
DOMAIN-SUFFIX,cw.com.tw,📡 Global
DOMAIN-SUFFIX,cyberctm.com,📡 Global
DOMAIN-SUFFIX,dailymotion.com,📡 Global
DOMAIN-SUFFIX,dailyview.tw,📡 Global
DOMAIN-SUFFIX,daum.net,📡 Global
DOMAIN-SUFFIX,daumcdn.net,📡 Global
DOMAIN-SUFFIX,dcard.tw,📡 Global
DOMAIN-SUFFIX,deepdiscount.com,📡 Global
DOMAIN-SUFFIX,depositphotos.com,📡 Global
DOMAIN-SUFFIX,deviantart.com,📡 Global
DOMAIN-SUFFIX,disconnect.me,📡 Global
DOMAIN-SUFFIX,discordapp.com,📡 Global
DOMAIN-SUFFIX,discordapp.net,📡 Global
DOMAIN-SUFFIX,disqus.com,📡 Global
DOMAIN-SUFFIX,dlercloud.com,📡 Global
DOMAIN-SUFFIX,dns2go.com,📡 Global
DOMAIN-SUFFIX,dowjones.com,📡 Global
DOMAIN-SUFFIX,dropbox.com,📡 Global
DOMAIN-SUFFIX,dropboxusercontent.com,📡 Global
DOMAIN-SUFFIX,duckduckgo.com,📡 Global
DOMAIN-SUFFIX,dw.com,📡 Global
DOMAIN-SUFFIX,dynu.com,📡 Global
DOMAIN-SUFFIX,earthcam.com,📡 Global
DOMAIN-SUFFIX,ebookservice.tw,📡 Global
DOMAIN-SUFFIX,economist.com,📡 Global
DOMAIN-SUFFIX,edgecastcdn.net,📡 Global
DOMAIN-SUFFIX,edu,📡 Global
DOMAIN-SUFFIX,elpais.com,📡 Global
DOMAIN-SUFFIX,enanyang.my,📡 Global
DOMAIN-SUFFIX,encyclopedia.com,📡 Global
DOMAIN-SUFFIX,esoir.be,📡 Global
DOMAIN-SUFFIX,etherscan.io,📡 Global
DOMAIN-SUFFIX,euronews.com,📡 Global
DOMAIN-SUFFIX,evozi.com,📡 Global
DOMAIN-SUFFIX,feedly.com,📡 Global
DOMAIN-SUFFIX,firech.at,📡 Global
DOMAIN-SUFFIX,flickr.com,📡 Global
DOMAIN-SUFFIX,flitto.com,📡 Global
DOMAIN-SUFFIX,foreignpolicy.com,📡 Global
DOMAIN-SUFFIX,freebrowser.org,📡 Global
DOMAIN-SUFFIX,freewechat.com,📡 Global
DOMAIN-SUFFIX,freeweibo.com,📡 Global
DOMAIN-SUFFIX,friday.tw,📡 Global
DOMAIN-SUFFIX,ftchinese.com,📡 Global
DOMAIN-SUFFIX,ftimg.net,📡 Global
DOMAIN-SUFFIX,gate.io,📡 Global
DOMAIN-SUFFIX,getlantern.org,📡 Global
DOMAIN-SUFFIX,getsync.com,📡 Global
DOMAIN-SUFFIX,globalvoices.org,📡 Global
DOMAIN-SUFFIX,goo.ne.jp,📡 Global
DOMAIN-SUFFIX,goodreads.com,📡 Global
DOMAIN-SUFFIX,gov,📡 Global
DOMAIN-SUFFIX,gov.tw,📡 Global
DOMAIN-SUFFIX,greatfire.org,📡 Global
DOMAIN-SUFFIX,gumroad.com,📡 Global
DOMAIN-SUFFIX,hbg.com,📡 Global
DOMAIN-SUFFIX,heroku.com,📡 Global
DOMAIN-SUFFIX,hightail.com,📡 Global
DOMAIN-SUFFIX,hk01.com,📡 Global
DOMAIN-SUFFIX,hkbf.org,📡 Global
DOMAIN-SUFFIX,hkbookcity.com,📡 Global
DOMAIN-SUFFIX,hkej.com,📡 Global
DOMAIN-SUFFIX,hket.com,📡 Global
DOMAIN-SUFFIX,hkgolden.com,📡 Global
DOMAIN-SUFFIX,hootsuite.com,📡 Global
DOMAIN-SUFFIX,hudson.org,📡 Global
DOMAIN-SUFFIX,hyread.com.tw,📡 Global
DOMAIN-SUFFIX,ibtimes.com,📡 Global
DOMAIN-SUFFIX,i-cable.com,📡 Global
DOMAIN-SUFFIX,icij.org,📡 Global
DOMAIN-SUFFIX,icoco.com,📡 Global
DOMAIN-SUFFIX,imgur.com,📡 Global
DOMAIN-SUFFIX,initiummall.com,📡 Global
DOMAIN-SUFFIX,insecam.org,📡 Global
DOMAIN-SUFFIX,ipfs.io,📡 Global
DOMAIN-SUFFIX,issuu.com,📡 Global
DOMAIN-SUFFIX,istockphoto.com,📡 Global
DOMAIN-SUFFIX,japantimes.co.jp,📡 Global
DOMAIN-SUFFIX,jiji.com,📡 Global
DOMAIN-SUFFIX,jinx.com,📡 Global
DOMAIN-SUFFIX,jkforum.net,📡 Global
DOMAIN-SUFFIX,joinmastodon.org,📡 Global
DOMAIN-SUFFIX,justmysocks.net,📡 Global
DOMAIN-SUFFIX,justpaste.it,📡 Global
DOMAIN-SUFFIX,kakao.com,📡 Global
DOMAIN-SUFFIX,kakaocorp.com,📡 Global
DOMAIN-SUFFIX,kik.com,📡 Global
DOMAIN-SUFFIX,kobo.com,📡 Global
DOMAIN-SUFFIX,kobobooks.com,📡 Global
DOMAIN-SUFFIX,kodingen.com,📡 Global
DOMAIN-SUFFIX,lemonde.fr,📡 Global
DOMAIN-SUFFIX,lepoint.fr,📡 Global
DOMAIN-SUFFIX,lihkg.com,📡 Global
DOMAIN-SUFFIX,listennotes.com,📡 Global
DOMAIN-SUFFIX,livestream.com,📡 Global
DOMAIN-SUFFIX,logmein.com,📡 Global
DOMAIN-SUFFIX,mail.ru,📡 Global
DOMAIN-SUFFIX,mailchimp.com,📡 Global
DOMAIN-SUFFIX,marc.info,📡 Global
DOMAIN-SUFFIX,matters.news,📡 Global
DOMAIN-SUFFIX,maying.co,📡 Global
DOMAIN-SUFFIX,medium.com,📡 Global
DOMAIN-SUFFIX,mega.nz,📡 Global
DOMAIN-SUFFIX,mil,📡 Global
DOMAIN-SUFFIX,mingpao.com,📡 Global
DOMAIN-SUFFIX,mobile01.com,📡 Global
DOMAIN-SUFFIX,myspace.com,📡 Global
DOMAIN-SUFFIX,myspacecdn.com,📡 Global
DOMAIN-SUFFIX,nanyang.com,📡 Global
DOMAIN-SUFFIX,naver.com,📡 Global
DOMAIN-SUFFIX,neowin.net,📡 Global
DOMAIN-SUFFIX,newstapa.org,📡 Global
DOMAIN-SUFFIX,nhk.or.jp,📡 Global
DOMAIN-SUFFIX,nii.ac.jp,📡 Global
DOMAIN-SUFFIX,nikkei.com,📡 Global
DOMAIN-SUFFIX,nofile.io,📡 Global
DOMAIN-SUFFIX,now.com,📡 Global
DOMAIN-SUFFIX,nrk.no,📡 Global
DOMAIN-SUFFIX,nyt.com,📡 Global
DOMAIN-SUFFIX,nytchina.com,📡 Global
DOMAIN-SUFFIX,nytcn.me,📡 Global
DOMAIN-SUFFIX,nytco.com,📡 Global
DOMAIN-SUFFIX,nytimes.com,📡 Global
DOMAIN-SUFFIX,nytimg.com,📡 Global
DOMAIN-SUFFIX,nytlog.com,📡 Global
DOMAIN-SUFFIX,nytstyle.com,📡 Global
DOMAIN-SUFFIX,ok.ru,📡 Global
DOMAIN-SUFFIX,okex.com,📡 Global
DOMAIN-SUFFIX,on.cc,📡 Global
DOMAIN-SUFFIX,orientaldaily.com.my,📡 Global
DOMAIN-SUFFIX,overcast.fm,📡 Global
DOMAIN-SUFFIX,paltalk.com,📡 Global
DOMAIN-SUFFIX,pao-pao.net,📡 Global
DOMAIN-SUFFIX,parsevideo.com,📡 Global
DOMAIN-SUFFIX,pbxes.com,📡 Global
DOMAIN-SUFFIX,pcdvd.com.tw,📡 Global
DOMAIN-SUFFIX,pchome.com.tw,📡 Global
DOMAIN-SUFFIX,pcloud.com,📡 Global
DOMAIN-SUFFIX,picacomic.com,📡 Global
DOMAIN-SUFFIX,pinimg.com,📡 Global
DOMAIN-SUFFIX,pixiv.net,📡 Global
DOMAIN-SUFFIX,player.fm,📡 Global
DOMAIN-SUFFIX,plurk.com,📡 Global
DOMAIN-SUFFIX,po18.tw,📡 Global
DOMAIN-SUFFIX,potato.im,📡 Global
DOMAIN-SUFFIX,potatso.com,📡 Global
DOMAIN-SUFFIX,prism-break.org,📡 Global
DOMAIN-SUFFIX,proxifier.com,📡 Global
DOMAIN-SUFFIX,pt.im,📡 Global
DOMAIN-SUFFIX,pts.org.tw,📡 Global
DOMAIN-SUFFIX,pubu.com.tw,📡 Global
DOMAIN-SUFFIX,pubu.tw,📡 Global
DOMAIN-SUFFIX,pureapk.com,📡 Global
DOMAIN-SUFFIX,quora.com,📡 Global
DOMAIN-SUFFIX,quoracdn.net,📡 Global
DOMAIN-SUFFIX,rakuten.co.jp,📡 Global
DOMAIN-SUFFIX,readingtimes.com.tw,📡 Global
DOMAIN-SUFFIX,readmoo.com,📡 Global
DOMAIN-SUFFIX,redbubble.com,📡 Global
DOMAIN-SUFFIX,reddit.com,📡 Global
DOMAIN-SUFFIX,redditmedia.com,📡 Global
DOMAIN-SUFFIX,resilio.com,📡 Global
DOMAIN-SUFFIX,reuters.com,📡 Global
DOMAIN-SUFFIX,reutersmedia.net,📡 Global
DOMAIN-SUFFIX,rfi.fr,📡 Global
DOMAIN-SUFFIX,rixcloud.com,📡 Global
DOMAIN-SUFFIX,roadshow.hk,📡 Global
DOMAIN-SUFFIX,scmp.com,📡 Global
DOMAIN-SUFFIX,scribd.com,📡 Global
DOMAIN-SUFFIX,seatguru.com,📡 Global
DOMAIN-SUFFIX,shadowsocks.org,📡 Global
DOMAIN-SUFFIX,shopee.tw,📡 Global
DOMAIN-SUFFIX,slideshare.net,📡 Global
DOMAIN-SUFFIX,softfamous.com,📡 Global
DOMAIN-SUFFIX,ssrcloud.org,📡 Global
DOMAIN-SUFFIX,startpage.com,📡 Global
DOMAIN-SUFFIX,steamcommunity.com,📡 Global
DOMAIN-SUFFIX,steemit.com,📡 Global
DOMAIN-SUFFIX,steemitwallet.com,📡 Global
DOMAIN-SUFFIX,t66y.com,📡 Global
DOMAIN-SUFFIX,tapatalk.com,📡 Global
DOMAIN-SUFFIX,teco-hk.org,📡 Global
DOMAIN-SUFFIX,teco-mo.org,📡 Global
DOMAIN-SUFFIX,teddysun.com,📡 Global
DOMAIN-SUFFIX,textnow.me,📡 Global
DOMAIN-SUFFIX,theguardian.com,📡 Global
DOMAIN-SUFFIX,theinitium.com,📡 Global
DOMAIN-SUFFIX,thetvdb.com,📡 Global
DOMAIN-SUFFIX,tineye.com,📡 Global
DOMAIN-SUFFIX,torproject.org,📡 Global
DOMAIN-SUFFIX,tumblr.com,📡 Global
DOMAIN-SUFFIX,turbobit.net,📡 Global
DOMAIN-SUFFIX,tutanota.com,📡 Global
DOMAIN-SUFFIX,tvboxnow.com,📡 Global
DOMAIN-SUFFIX,udn.com,📡 Global
DOMAIN-SUFFIX,unseen.is,📡 Global
DOMAIN-SUFFIX,upmedia.mg,📡 Global
DOMAIN-SUFFIX,uptodown.com,📡 Global
DOMAIN-SUFFIX,urbandictionary.com,📡 Global
DOMAIN-SUFFIX,ustream.tv,📡 Global
DOMAIN-SUFFIX,uwants.com,📡 Global
DOMAIN-SUFFIX,v2ray.com,📡 Global
DOMAIN-SUFFIX,viber.com,📡 Global
DOMAIN-SUFFIX,videopress.com,📡 Global
DOMAIN-SUFFIX,vimeo.com,📡 Global
DOMAIN-SUFFIX,voachinese.com,📡 Global
DOMAIN-SUFFIX,voanews.com,📡 Global
DOMAIN-SUFFIX,voxer.com,📡 Global
DOMAIN-SUFFIX,vzw.com,📡 Global
DOMAIN-SUFFIX,w3schools.com,📡 Global
DOMAIN-SUFFIX,washingtonpost.com,📡 Global
DOMAIN-SUFFIX,wattpad.com,📡 Global
DOMAIN-SUFFIX,whoer.net,📡 Global
DOMAIN-SUFFIX,wikimapia.org,📡 Global
DOMAIN-SUFFIX,wikipedia.org,📡 Global
DOMAIN-SUFFIX,wikiquote.org,📡 Global
DOMAIN-SUFFIX,wikiwand.com,📡 Global
DOMAIN-SUFFIX,winudf.com,📡 Global
DOMAIN-SUFFIX,wire.com,📡 Global
DOMAIN-SUFFIX,wordpress.com,📡 Global
DOMAIN-SUFFIX,workflow.is,📡 Global
DOMAIN-SUFFIX,worldcat.org,📡 Global
DOMAIN-SUFFIX,wsj.com,📡 Global
DOMAIN-SUFFIX,wsj.net,📡 Global
DOMAIN-SUFFIX,xhamster.com,📡 Global
DOMAIN-SUFFIX,xn--90wwvt03e.com,📡 Global
DOMAIN-SUFFIX,xn--i2ru8q2qg.com,📡 Global
DOMAIN-SUFFIX,xnxx.com,📡 Global
DOMAIN-SUFFIX,xvideos.com,📡 Global
DOMAIN-SUFFIX,yahoo.com,📡 Global
DOMAIN-SUFFIX,yandex.ru,📡 Global
DOMAIN-SUFFIX,ycombinator.com,📡 Global
DOMAIN-SUFFIX,yesasia.com,📡 Global
DOMAIN-SUFFIX,yes-news.com,📡 Global
DOMAIN-SUFFIX,yomiuri.co.jp,📡 Global
DOMAIN-SUFFIX,you-get.org,📡 Global
DOMAIN-SUFFIX,zaobao.com,📡 Global
DOMAIN-SUFFIX,zb.com,📡 Global
DOMAIN-SUFFIX,zello.com,📡 Global
DOMAIN-SUFFIX,zeronet.io,📡 Global
DOMAIN-SUFFIX,zoom.us,📡 Global
host-keyword,github,📡 Global
host-keyword,jav,📡 Global
host-keyword,pinterest,📡 Global
host-keyword,porn,📡 Global
host-keyword,wikileaks,📡 Global

# (Region-Restricted Access Denied)
DOMAIN-SUFFIX,apartmentratings.com,📡 Global
DOMAIN-SUFFIX,apartments.com,📡 Global
DOMAIN-SUFFIX,bankmobilevibe.com,📡 Global
DOMAIN-SUFFIX,bing.com,📡 Global
DOMAIN-SUFFIX,booktopia.com.au,📡 Global
DOMAIN-SUFFIX,cccat.io,📡 Global
DOMAIN-SUFFIX,centauro.com.br,📡 Global
DOMAIN-SUFFIX,clearsurance.com,📡 Global
DOMAIN-SUFFIX,costco.com,📡 Global
DOMAIN-SUFFIX,crackle.com,📡 Global
DOMAIN-SUFFIX,depositphotos.cn,📡 Global
DOMAIN-SUFFIX,dish.com,📡 Global
DOMAIN-SUFFIX,dmm.co.jp,📡 Global
DOMAIN-SUFFIX,dmm.com,📡 Global
DOMAIN-SUFFIX,dnvod.tv,📡 Global
DOMAIN-SUFFIX,esurance.com,📡 Global
DOMAIN-SUFFIX,extmatrix.com,📡 Global
DOMAIN-SUFFIX,fastpic.ru,📡 Global
DOMAIN-SUFFIX,flipboard.com,📡 Global
DOMAIN-SUFFIX,fnac.be,📡 Global
DOMAIN-SUFFIX,fnac.com,📡 Global
DOMAIN-SUFFIX,funkyimg.com,📡 Global
DOMAIN-SUFFIX,fxnetworks.com,📡 Global
DOMAIN-SUFFIX,gettyimages.com,📡 Global
DOMAIN-SUFFIX,go.com,📡 Global
DOMAIN-SUFFIX,here.com,📡 Global
DOMAIN-SUFFIX,jcpenney.com,📡 Global
DOMAIN-SUFFIX,jiehua.tv,📡 Global
DOMAIN-SUFFIX,mailfence.com,📡 Global
DOMAIN-SUFFIX,nationwide.com,📡 Global
DOMAIN-SUFFIX,nbc.com,📡 Global
DOMAIN-SUFFIX,nexon.com,📡 Global
DOMAIN-SUFFIX,nordstrom.com,📡 Global
DOMAIN-SUFFIX,nordstromimage.com,📡 Global
DOMAIN-SUFFIX,nordstromrack.com,📡 Global
DOMAIN-SUFFIX,superpages.com,📡 Global
DOMAIN-SUFFIX,target.com,📡 Global
DOMAIN-SUFFIX,thinkgeek.com,📡 Global
DOMAIN-SUFFIX,tracfone.com,📡 Global
DOMAIN-SUFFIX,unity3d.com,📡 Global
DOMAIN-SUFFIX,uploader.jp,📡 Global
DOMAIN-SUFFIX,vevo.com,📡 Global
DOMAIN-SUFFIX,viu.tv,📡 Global
DOMAIN-SUFFIX,vk.com,📡 Global
DOMAIN-SUFFIX,vsco.co,📡 Global
DOMAIN-SUFFIX,xfinity.com,📡 Global
DOMAIN-SUFFIX,zattoo.com,📡 Global
user-agent,Roam*,📡 Global

# (The Most Popular Sites)
# > Apple
# >> TestFlight
host,testflight.apple.com,📡 Global
# >> Apple URL Shortener
DOMAIN-SUFFIX,appsto.re,📡 Global
# >> iBooks Store download
host,books.itunes.apple.com,📡 Global
# >> iTunes Store Moveis Trailers
host,hls.itunes.apple.com,📡 Global
# >> Spotlight
host,api-glb-sea.smoot.apple.com,📡 Global
# >> Dictionary
host,lookup-api.apple.com,📡 Global
# > Google
DOMAIN-SUFFIX,abc.xyz,📡 Global
DOMAIN-SUFFIX,android.com,📡 Global
DOMAIN-SUFFIX,androidify.com,📡 Global
DOMAIN-SUFFIX,dialogflow.com,📡 Global
DOMAIN-SUFFIX,autodraw.com,📡 Global
DOMAIN-SUFFIX,capitalg.com,📡 Global
DOMAIN-SUFFIX,certificate-transparency.org,📡 Global
DOMAIN-SUFFIX,chrome.com,📡 Global
DOMAIN-SUFFIX,chromeexperiments.com,📡 Global
DOMAIN-SUFFIX,chromestatus.com,📡 Global
DOMAIN-SUFFIX,chromium.org,📡 Global
DOMAIN-SUFFIX,creativelab5.com,📡 Global
DOMAIN-SUFFIX,debug.com,📡 Global
DOMAIN-SUFFIX,deepmind.com,📡 Global
DOMAIN-SUFFIX,firebaseio.com,📡 Global
DOMAIN-SUFFIX,getmdl.io,📡 Global
DOMAIN-SUFFIX,ggpht.com,📡 Global
DOMAIN-SUFFIX,gmail.com,📡 Global
DOMAIN-SUFFIX,gmodules.com,📡 Global
DOMAIN-SUFFIX,godoc.org,📡 Global
DOMAIN-SUFFIX,golang.org,📡 Global
DOMAIN-SUFFIX,gstatic.com,📡 Global
DOMAIN-SUFFIX,gv.com,📡 Global
DOMAIN-SUFFIX,gwtproject.org,📡 Global
DOMAIN-SUFFIX,itasoftware.com,📡 Global
DOMAIN-SUFFIX,madewithcode.com,📡 Global
DOMAIN-SUFFIX,material.io,📡 Global
DOMAIN-SUFFIX,polymer-project.org,📡 Global
DOMAIN-SUFFIX,admin.recaptcha.net,📡 Global
DOMAIN-SUFFIX,recaptcha.net,📡 Global
DOMAIN-SUFFIX,shattered.io,📡 Global
DOMAIN-SUFFIX,synergyse.com,📡 Global
DOMAIN-SUFFIX,tensorflow.org,📡 Global
DOMAIN-SUFFIX,tfhub.dev,📡 Global
DOMAIN-SUFFIX,tiltbrush.com,📡 Global
DOMAIN-SUFFIX,waveprotocol.org,📡 Global
DOMAIN-SUFFIX,waymo.com,📡 Global
DOMAIN-SUFFIX,webmproject.org,📡 Global
DOMAIN-SUFFIX,webrtc.org,📡 Global
DOMAIN-SUFFIX,whatbrowser.org,📡 Global
DOMAIN-SUFFIX,widevine.com,📡 Global
DOMAIN-SUFFIX,x.company,📡 Global
DOMAIN-SUFFIX,youtu.be,📡 Global
DOMAIN-SUFFIX,yt.be,📡 Global
DOMAIN-SUFFIX,ytimg.com,📡 Global
# > Microsoft
# >> Microsoft OneDrive
DOMAIN-SUFFIX,1drv.com,📡 Global
DOMAIN-SUFFIX,1drv.ms,📡 Global
DOMAIN-SUFFIX,blob.core.windows.net,📡 Global
DOMAIN-SUFFIX,livefilestore.com,📡 Global
DOMAIN-SUFFIX,onedrive.com,📡 Global
DOMAIN-SUFFIX,storage.live.com,📡 Global
DOMAIN-SUFFIX,storage.msn.com,📡 Global
host,oneclient.sfx.ms,📡 Global
# > Other
DOMAIN-SUFFIX,0rz.tw,📡 Global
DOMAIN-SUFFIX,4bluestones.biz,📡 Global
DOMAIN-SUFFIX,9bis.net,📡 Global
DOMAIN-SUFFIX,allconnected.co,📡 Global
DOMAIN-SUFFIX,aol.com,📡 Global
DOMAIN-SUFFIX,bcc.com.tw,📡 Global
DOMAIN-SUFFIX,bit.ly,📡 Global
DOMAIN-SUFFIX,bitshare.com,📡 Global
DOMAIN-SUFFIX,blog.jp,📡 Global
DOMAIN-SUFFIX,blogimg.jp,📡 Global
DOMAIN-SUFFIX,blogtd.org,📡 Global
DOMAIN-SUFFIX,broadcast.co.nz,📡 Global
DOMAIN-SUFFIX,camfrog.com,📡 Global
DOMAIN-SUFFIX,cfos.de,📡 Global
DOMAIN-SUFFIX,citypopulation.de,📡 Global
DOMAIN-SUFFIX,cloudfront.net,📡 Global
DOMAIN-SUFFIX,ctitv.com.tw,📡 Global
DOMAIN-SUFFIX,cuhk.edu.hk,📡 Global
DOMAIN-SUFFIX,cusu.hk,📡 Global
DOMAIN-SUFFIX,discord.gg,📡 Global
DOMAIN-SUFFIX,discuss.com.hk,📡 Global
DOMAIN-SUFFIX,dropboxapi.com,📡 Global
DOMAIN-SUFFIX,duolingo.cn,📡 Global
DOMAIN-SUFFIX,edditstatic.com,📡 Global
DOMAIN-SUFFIX,flickriver.com,📡 Global
DOMAIN-SUFFIX,focustaiwan.tw,📡 Global
DOMAIN-SUFFIX,free.fr,📡 Global
DOMAIN-SUFFIX,gigacircle.com,📡 Global
DOMAIN-SUFFIX,hk-pub.com,📡 Global
DOMAIN-SUFFIX,hosting.co.uk,📡 Global
DOMAIN-SUFFIX,hwcdn.net,📡 Global
DOMAIN-SUFFIX,ifixit.com,📡 Global
DOMAIN-SUFFIX,iphone4hongkong.com,📡 Global
DOMAIN-SUFFIX,iphonetaiwan.org,📡 Global
DOMAIN-SUFFIX,iptvbin.com,📡 Global
DOMAIN-SUFFIX,linksalpha.com,📡 Global
DOMAIN-SUFFIX,manyvids.com,📡 Global
DOMAIN-SUFFIX,myactimes.com,📡 Global
DOMAIN-SUFFIX,newsblur.com,📡 Global
DOMAIN-SUFFIX,now.im,📡 Global
DOMAIN-SUFFIX,nowe.com,📡 Global
DOMAIN-SUFFIX,redditlist.com,📡 Global
DOMAIN-SUFFIX,s3.amazonaws.com,📡 Global
DOMAIN-SUFFIX,signal.org,📡 Global
DOMAIN-SUFFIX,smartmailcloud.com,📡 Global
DOMAIN-SUFFIX,sparknotes.com,📡 Global
DOMAIN-SUFFIX,streetvoice.com,📡 Global
DOMAIN-SUFFIX,supertop.co,📡 Global
DOMAIN-SUFFIX,tv.com,📡 Global
DOMAIN-SUFFIX,typepad.com,📡 Global
DOMAIN-SUFFIX,udnbkk.com,📡 Global
DOMAIN-SUFFIX,urbanairship.com,📡 Global
DOMAIN-SUFFIX,whispersystems.org,📡 Global
DOMAIN-SUFFIX,wikia.com,📡 Global
DOMAIN-SUFFIX,wn.com,📡 Global
DOMAIN-SUFFIX,wolframalpha.com,📡 Global
DOMAIN-SUFFIX,x-art.com,📡 Global
DOMAIN-SUFFIX,yimg.com,📡 Global
host,api.steampowered.com,📡 Global
host,store.steampowered.com,📡 Global

# China Area Network
# > 360
DOMAIN-SUFFIX,qhres.com,China
DOMAIN-SUFFIX,qhimg.com,China
# > Akamai
DOMAIN-SUFFIX,akadns.net,China
# DOMAIN-SUFFIX,akamai.net,China
# DOMAIN-SUFFIX,akamaiedge.net,China
# DOMAIN-SUFFIX,akamaihd.net,China
# DOMAIN-SUFFIX,akamaistream.net,China
# DOMAIN-SUFFIX,akamaized.net,China
# > Alibaba
user-agent,%E4%BC%98%E9%85%B7*,China
DOMAIN-SUFFIX,alibaba.com,China
DOMAIN-SUFFIX,alicdn.com,China
DOMAIN-SUFFIX,alikunlun.com,China
DOMAIN-SUFFIX,alipay.com,China
DOMAIN-SUFFIX,amap.com,China
DOMAIN-SUFFIX,autonavi.com,China
DOMAIN-SUFFIX,dingtalk.com,China
DOMAIN-SUFFIX,mxhichina.com,China
DOMAIN-SUFFIX,soku.com,China
DOMAIN-SUFFIX,taobao.com,China
DOMAIN-SUFFIX,tmall.com,China
DOMAIN-SUFFIX,tmall.hk,China
DOMAIN-SUFFIX,ykimg.com,China
DOMAIN-SUFFIX,youku.com,China
DOMAIN-SUFFIX,xiami.com,China
DOMAIN-SUFFIX,xiami.net,China
# > Apple
DOMAIN-SUFFIX,aaplimg.com,China
DOMAIN-SUFFIX,apple.co,China
DOMAIN-SUFFIX,apple.com,China
DOMAIN-SUFFIX,apple-cloudkit.com,China
DOMAIN-SUFFIX,appstore.com,China
DOMAIN-SUFFIX,cdn-apple.com,China
DOMAIN-SUFFIX,crashlytics.com,China
DOMAIN-SUFFIX,icloud.com,China
DOMAIN-SUFFIX,icloud-content.com,China
DOMAIN-SUFFIX,me.com,China
DOMAIN-SUFFIX,mzstatic.com,China
host,www-cdn.icloud.com.akadns.net,China
# > Baidu
DOMAIN-SUFFIX,baidu.com,China
DOMAIN-SUFFIX,baidubcr.com,China
DOMAIN-SUFFIX,bdstatic.com,China
DOMAIN-SUFFIX,yunjiasu-cdn.net,China
# > bilibili
DOMAIN-SUFFIX,acgvideo.com,China
DOMAIN-SUFFIX,biliapi.com,China
DOMAIN-SUFFIX,biliapi.net,China
DOMAIN-SUFFIX,bilibili.com,China
DOMAIN-SUFFIX,bilibili.tv,China
DOMAIN-SUFFIX,hdslb.com,China
# > Blizzard
DOMAIN-SUFFIX,blizzard.com,China
DOMAIN-SUFFIX,battle.net,China
host,blzddist1-a.akamaihd.net,China
# > ByteDance
DOMAIN-SUFFIX,feiliao.com,China
DOMAIN-SUFFIX,pstatp.com,China
DOMAIN-SUFFIX,snssdk.com,China
DOMAIN-SUFFIX,iesdouyin.com,China
DOMAIN-SUFFIX,toutiao.com,China
# > CCTV
DOMAIN-SUFFIX,cctv.com,China
DOMAIN-SUFFIX,cctvpic.com,China
DOMAIN-SUFFIX,livechina.com,China
# > DiDi
DOMAIN-SUFFIX,didialift.com,China
DOMAIN-SUFFIX,didiglobal.com,China
DOMAIN-SUFFIX,udache.com,China
# > 蛋蛋赞
DOMAIN-SUFFIX,343480.com,China
DOMAIN-SUFFIX,baduziyuan.com,China
DOMAIN-SUFFIX,com-hs-hkdy.com,China
DOMAIN-SUFFIX,czybjz.com,China
DOMAIN-SUFFIX,dandanzan.com,China
DOMAIN-SUFFIX,fjhps.com,China
DOMAIN-SUFFIX,kuyunbo.club,China
# > ChinaNet
DOMAIN-SUFFIX,21cn.com,China
# > HunanTV
DOMAIN-SUFFIX,hitv.com,China
DOMAIN-SUFFIX,mgtv.com,China
# > iQiyi
DOMAIN-SUFFIX,iqiyi.com,China
DOMAIN-SUFFIX,iqiyipic.com,China
DOMAIN-SUFFIX,71.am.com,China
# > JD
DOMAIN-SUFFIX,jd.com,China
DOMAIN-SUFFIX,jd.hk,China
DOMAIN-SUFFIX,jdpay.com,China
DOMAIN-SUFFIX,360buyimg.com,China
# > Kingsoft
DOMAIN-SUFFIX,iciba.com,China
DOMAIN-SUFFIX,ksosoft.com,China
# > Meitu
DOMAIN-SUFFIX,meitu.com,China
DOMAIN-SUFFIX,meitudata.com,China
DOMAIN-SUFFIX,meitustat.com,China
DOMAIN-SUFFIX,meipai.com,China
# > MI
DOMAIN-SUFFIX,duokan.com,China
DOMAIN-SUFFIX,mi-img.com,China
DOMAIN-SUFFIX,miui.com,China
DOMAIN-SUFFIX,miwifi.com,China
DOMAIN-SUFFIX,xiaomi.com,China
# > Microsoft
DOMAIN-SUFFIX,microsoft.com,China
DOMAIN-SUFFIX,msecnd.net,China
DOMAIN-SUFFIX,office365.com,China
DOMAIN-SUFFIX,outlook.com,China
DOMAIN-SUFFIX,s-microsoft.com,China
DOMAIN-SUFFIX,visualstudio.com,China
DOMAIN-SUFFIX,windows.com,China
DOMAIN-SUFFIX,windowsupdate.com,China
host,officecdn-microsoft-com.akamaized.net,China
# > NetEase
user-agent,NeteaseMusic*,China
user-agent,%E7%BD%91%E6%98%93%E4%BA%91%E9%9F%B3%E4%B9%90*,China
DOMAIN-SUFFIX,163.com,China
DOMAIN-SUFFIX,126.net,China
DOMAIN-SUFFIX,127.net,China
DOMAIN-SUFFIX,163yun.com,China
DOMAIN-SUFFIX,lofter.com,China
DOMAIN-SUFFIX,netease.com,China
DOMAIN-SUFFIX,ydstatic.com,China
# > Sina
DOMAIN-SUFFIX,sina.com,China
DOMAIN-SUFFIX,weibo.com,China
DOMAIN-SUFFIX,weibocdn.com,China
# > Sohu
DOMAIN-SUFFIX,sohu.com,China
DOMAIN-SUFFIX,sohucs.com,China
DOMAIN-SUFFIX,sohu-inc.com,China
DOMAIN-SUFFIX,v-56.com,China
# > Sogo
DOMAIN-SUFFIX,sogo.com,China
DOMAIN-SUFFIX,sogou.com,China
DOMAIN-SUFFIX,sogoucdn.com,China
# > Steam
DOMAIN-SUFFIX,steampowered.com,China
DOMAIN-SUFFIX,steam-chat.com,China
DOMAIN-SUFFIX,steamgames.com,China
DOMAIN-SUFFIX,steamusercontent.com,China
DOMAIN-SUFFIX,steamcontent.com,China
DOMAIN-SUFFIX,steamstatic.com,China
DOMAIN-SUFFIX,steamcdn-a.akamaihd.net,China
DOMAIN-SUFFIX,steamstat.us,China
# > Tencent
user-agent,MicroMessenger%20Client,China
user-agent,WeChat*,China
DOMAIN-SUFFIX,gtimg.com,China
DOMAIN-SUFFIX,idqqimg.com,China
DOMAIN-SUFFIX,igamecj.com,China
DOMAIN-SUFFIX,myapp.com,China
DOMAIN-SUFFIX,myqcloud.com,China
DOMAIN-SUFFIX,qq.com,China
DOMAIN-SUFFIX,tencent.com,China
DOMAIN-SUFFIX,tencent-cloud.net,China
# > YYeTs
user-agent,YYeTs*,China
DOMAIN-SUFFIX,jstucdn.com,China
DOMAIN-SUFFIX,zimuzu.io,China
DOMAIN-SUFFIX,zimuzu.tv,China
DOMAIN-SUFFIX,zmz2019.com,China
DOMAIN-SUFFIX,zmzapi.com,China
DOMAIN-SUFFIX,zmzapi.net,China
DOMAIN-SUFFIX,zmzfile.com,China
# > Content Delivery Network
DOMAIN-SUFFIX,ccgslb.com,China
DOMAIN-SUFFIX,ccgslb.net,China
DOMAIN-SUFFIX,chinanetcenter.com,China
DOMAIN-SUFFIX,meixincdn.com,China
DOMAIN-SUFFIX,ourdvs.com,China
DOMAIN-SUFFIX,staticdn.net,China
DOMAIN-SUFFIX,wangsu.com,China
# > IP Query
DOMAIN-SUFFIX,ipip.net,China
DOMAIN-SUFFIX,ip.la,China
DOMAIN-SUFFIX,ip-cdn.com,China
DOMAIN-SUFFIX,ipv6-test.com,China
DOMAIN-SUFFIX,test-ipv6.com,China
DOMAIN-SUFFIX,whatismyip.com,China
# > Speed Test
# DOMAIN-SUFFIX,speedtest.net,China
DOMAIN-SUFFIX,netspeedtestmaster.com,China
host,speedtest.macpaw.com,China
# > Private Tracker
DOMAIN-SUFFIX,awesome-hd.me,China
DOMAIN-SUFFIX,broadcasthe.net,China
DOMAIN-SUFFIX,chdbits.co,China
DOMAIN-SUFFIX,classix-unlimited.co.uk,China
DOMAIN-SUFFIX,empornium.me,China
DOMAIN-SUFFIX,gazellegames.net,China
DOMAIN-SUFFIX,hdchina.org,China
DOMAIN-SUFFIX,hdsky.me,China
DOMAIN-SUFFIX,icetorrent.org,China
DOMAIN-SUFFIX,jpopsuki.eu,China
DOMAIN-SUFFIX,keepfrds.com,China
DOMAIN-SUFFIX,madsrevolution.net,China
DOMAIN-SUFFIX,m-team.cc,China
DOMAIN-SUFFIX,nanyangpt.com,China
DOMAIN-SUFFIX,ncore.cc,China
DOMAIN-SUFFIX,open.cd,China
DOMAIN-SUFFIX,ourbits.club,China
DOMAIN-SUFFIX,passthepopcorn.me,China
DOMAIN-SUFFIX,privatehd.to,China
DOMAIN-SUFFIX,redacted.ch,China
DOMAIN-SUFFIX,springsunday.net,China
DOMAIN-SUFFIX,tjupt.org,China
DOMAIN-SUFFIX,totheglory.im,China
# > Scholar
DOMAIN-SUFFIX,acm.org,China
DOMAIN-SUFFIX,acs.org,China
DOMAIN-SUFFIX,aip.org,China
DOMAIN-SUFFIX,ams.org,China
DOMAIN-SUFFIX,annualreviews.org,China
DOMAIN-SUFFIX,aps.org,China
DOMAIN-SUFFIX,ascelibrary.org,China
DOMAIN-SUFFIX,asm.org,China
DOMAIN-SUFFIX,asme.org,China
DOMAIN-SUFFIX,astm.org,China
DOMAIN-SUFFIX,bmj.com,China
DOMAIN-SUFFIX,cambridge.org,China
DOMAIN-SUFFIX,cas.org,China
DOMAIN-SUFFIX,clarivate.com,China
DOMAIN-SUFFIX,ebscohost.com,China
DOMAIN-SUFFIX,emerald.com,China
DOMAIN-SUFFIX,engineeringvillage.com,China
DOMAIN-SUFFIX,icevirtuallibrary.com,China
DOMAIN-SUFFIX,ieee.org,China
DOMAIN-SUFFIX,imf.org,China
DOMAIN-SUFFIX,iop.org,China
DOMAIN-SUFFIX,jamanetwork.com,China
DOMAIN-SUFFIX,jhu.edu,China
DOMAIN-SUFFIX,jstor.org,China
DOMAIN-SUFFIX,karger.com,China
DOMAIN-SUFFIX,libguides.com,China
DOMAIN-SUFFIX,madsrevolution.net,China
DOMAIN-SUFFIX,mpg.de,China
DOMAIN-SUFFIX,myilibrary.com,China
DOMAIN-SUFFIX,nature.com,China
DOMAIN-SUFFIX,oecd-ilibrary.org,China
DOMAIN-SUFFIX,osapublishing.org,China
DOMAIN-SUFFIX,oup.com,China
DOMAIN-SUFFIX,ovid.com,China
DOMAIN-SUFFIX,oxfordartonline.com,China
DOMAIN-SUFFIX,oxfordbibliographies.com,China
DOMAIN-SUFFIX,oxfordmusiconline.com,China
DOMAIN-SUFFIX,pnas.org,China
DOMAIN-SUFFIX,proquest.com,China
DOMAIN-SUFFIX,rsc.org,China
DOMAIN-SUFFIX,sagepub.com,China
DOMAIN-SUFFIX,sciencedirect.com,China
DOMAIN-SUFFIX,sciencemag.org,China
DOMAIN-SUFFIX,scopus.com,China
DOMAIN-SUFFIX,siam.org,China
DOMAIN-SUFFIX,spiedigitallibrary.org,China
DOMAIN-SUFFIX,springer.com,China
DOMAIN-SUFFIX,springerlink.com,China
DOMAIN-SUFFIX,tandfonline.com,China
DOMAIN-SUFFIX,un.org,China
DOMAIN-SUFFIX,uni-bielefeld.de,China
DOMAIN-SUFFIX,webofknowledge.com,China
DOMAIN-SUFFIX,westlaw.com,China
DOMAIN-SUFFIX,wiley.com,China
DOMAIN-SUFFIX,worldbank.org,China
DOMAIN-SUFFIX,worldscientific.com,China
# > Other
DOMAIN-SUFFIX,cn,China
DOMAIN-SUFFIX,360in.com,China
DOMAIN-SUFFIX,51ym.me,China
DOMAIN-SUFFIX,8686c.com,China
DOMAIN-SUFFIX,abchina.com,China
DOMAIN-SUFFIX,accuweather.com,China
DOMAIN-SUFFIX,aicoinstorge.com,China
DOMAIN-SUFFIX,air-matters.com,China
DOMAIN-SUFFIX,air-matters.io,China
DOMAIN-SUFFIX,aixifan.com,China
DOMAIN-SUFFIX,amd.com,China
DOMAIN-SUFFIX,b612.net,China
DOMAIN-SUFFIX,bdatu.com,China
DOMAIN-SUFFIX,beitaichufang.com,China
DOMAIN-SUFFIX,bjango.com,China
DOMAIN-SUFFIX,booking.com,China
DOMAIN-SUFFIX,bstatic.com,China
DOMAIN-SUFFIX,cailianpress.com,China
DOMAIN-SUFFIX,camera360.com,China
DOMAIN-SUFFIX,chinaso.com,China
DOMAIN-SUFFIX,chua.pro,China
DOMAIN-SUFFIX,chuimg.com,China
DOMAIN-SUFFIX,chunyu.mobi,China
DOMAIN-SUFFIX,chushou.tv,China
DOMAIN-SUFFIX,cmbchina.com,China
DOMAIN-SUFFIX,cmbimg.com,China
DOMAIN-SUFFIX,ctrip.com,China
DOMAIN-SUFFIX,dfcfw.com,China
DOMAIN-SUFFIX,docschina.org,China
DOMAIN-SUFFIX,douban.com,China
DOMAIN-SUFFIX,doubanio.com,China
DOMAIN-SUFFIX,douyu.com,China
DOMAIN-SUFFIX,dxycdn.com,China
DOMAIN-SUFFIX,dytt8.net,China
DOMAIN-SUFFIX,eastmoney.com,China
DOMAIN-SUFFIX,eudic.net,China
DOMAIN-SUFFIX,feng.com,China
DOMAIN-SUFFIX,fengkongcloud.com,China
DOMAIN-SUFFIX,frdic.com,China
DOMAIN-SUFFIX,futu5.com,China
DOMAIN-SUFFIX,futunn.com,China
DOMAIN-SUFFIX,gandi.net,China
DOMAIN-SUFFIX,geilicdn.com,China
DOMAIN-SUFFIX,getpricetag.com,China
DOMAIN-SUFFIX,gifshow.com,China
DOMAIN-SUFFIX,godic.net,China
DOMAIN-SUFFIX,hicloud.com,China
DOMAIN-SUFFIX,hongxiu.com,China
DOMAIN-SUFFIX,hostbuf.com,China
DOMAIN-SUFFIX,huxiucdn.com,China
DOMAIN-SUFFIX,huya.com,China
DOMAIN-SUFFIX,infinitynewtab.com,China
DOMAIN-SUFFIX,ithome.com,China
DOMAIN-SUFFIX,java.com,China
DOMAIN-SUFFIX,jidian.im,China
DOMAIN-SUFFIX,kaiyanapp.com,China
DOMAIN-SUFFIX,kaspersky-labs.com,China
DOMAIN-SUFFIX,keepcdn.com,China
DOMAIN-SUFFIX,kkmh.com,China
DOMAIN-SUFFIX,licdn.com,China
DOMAIN-SUFFIX,linkedin.com,China
DOMAIN-SUFFIX,loli.net,China
DOMAIN-SUFFIX,luojilab.com,China
DOMAIN-SUFFIX,maoyan.com,China
DOMAIN-SUFFIX,maoyun.tv,China
DOMAIN-SUFFIX,meituan.com,China
DOMAIN-SUFFIX,meituan.net,China
DOMAIN-SUFFIX,mobike.com,China
DOMAIN-SUFFIX,moke.com,China
DOMAIN-SUFFIX,mubu.com,China
DOMAIN-SUFFIX,myzaker.com,China
DOMAIN-SUFFIX,nim-lang-cn.org,China
DOMAIN-SUFFIX,nvidia.com,China
DOMAIN-SUFFIX,oracle.com,China
DOMAIN-SUFFIX,paypal.com,China
DOMAIN-SUFFIX,paypalobjects.com,China
DOMAIN-SUFFIX,qdaily.com,China
DOMAIN-SUFFIX,qidian.com,China
DOMAIN-SUFFIX,qyer.com,China
DOMAIN-SUFFIX,qyerstatic.com,China
DOMAIN-SUFFIX,raychase.net,China
DOMAIN-SUFFIX,ronghub.com,China
DOMAIN-SUFFIX,ruguoapp.com,China
DOMAIN-SUFFIX,s-reader.com,China
DOMAIN-SUFFIX,sankuai.com,China
DOMAIN-SUFFIX,scomper.me,China
DOMAIN-SUFFIX,seafile.com,China
DOMAIN-SUFFIX,sm.ms,China
DOMAIN-SUFFIX,smzdm.com,China
DOMAIN-SUFFIX,snapdrop.net,China
DOMAIN-SUFFIX,snwx.com,China
DOMAIN-SUFFIX,sspai.com,China
DOMAIN-SUFFIX,takungpao.com,China
DOMAIN-SUFFIX,teamviewer.com,China
DOMAIN-SUFFIX,tianyancha.com,China
DOMAIN-SUFFIX,udacity.com,China
DOMAIN-SUFFIX,uning.com,China
DOMAIN-SUFFIX,vmware.com,China
DOMAIN-SUFFIX,weather.com,China
DOMAIN-SUFFIX,weico.cc,China
DOMAIN-SUFFIX,weidian.com,China
DOMAIN-SUFFIX,xiachufang.com,China
DOMAIN-SUFFIX,ximalaya.com,China
DOMAIN-SUFFIX,xinhuanet.com,China
DOMAIN-SUFFIX,xmcdn.com,China
DOMAIN-SUFFIX,yangkeduo.com,China
DOMAIN-SUFFIX,zhangzishi.cc,China
DOMAIN-SUFFIX,zhihu.com,China
DOMAIN-SUFFIX,zhimg.com,China
DOMAIN-SUFFIX,zhuihd.com,China
host,download.jetbrains.com,China
host,images-cn.ssl-images-amazon.com,China

# DNSPod Public DNS+
ip-cidr, 119.28.28.28/32,China

ip-cidr, 10.0.0.0/8, direct
ip-cidr, 127.0.0.0/8, direct
ip-cidr, 172.16.0.0/12, direct
ip-cidr, 192.168.0.0/16, direct
ip-cidr, 224.0.0.0/24, direct
geoip, cn, China
final, Final

[rewrite_local]
#TikTok需要其他国家自行修改JP
[mitm]
hostname = *.music.163.com, music.163.com, *.music.126.net, music.126.net, *.abema.tv, *.amemv.com, abema.tv, api.abema.io
p12={MITM_p12}
passphrase={MITM_passphrase}