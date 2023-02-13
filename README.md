# IdentityServer4
OAuth 2.0 ve OpenID Connect protocol

<strong>Json Web Token:</strong> İletişim halindeki taraflar arasında güvenli şekilde veri alışverişini sağlayan standarttır. <br/>
IdentityServer4 bir frameworktür. OAuth 2.0 (Authorization) ve OpenId Connect(Authentication) protokollerini iplement eden bir frameworktür.
## OAuth 2.0 Çözdüğü Problem Nedir?
Bu protokol sayesinde kullanıcın bilgilerini direkt almadan güvenli bir şekilde ilgili sitelerden data almamızı veya data göndermemize imkan tanır. Token dağıtma işlemlerini yapar. OpenId protokol OAuth 2.0 üzerine iplement edilmiş bir protokoldür.
## OpenId Connect Çözdüğü Problem Nedir?
OpenId OAuth 2.0 üzerine kurulmuş bir katmandır. Kimlik doğrulama(authentication) işlemlerini yapar. Kişisel bilgilerle ilgili sorular sorar.
## Identity Server Çözdüğü Problem1
Diyelim ki 3 tane api bir client 'a bağlı olsun. Bu apilerin her biri jwt üretir. Bu durum kod israfına neden olmaktadır. Api'lere hangi client'lardan istek geleceğini ayarlamak ve böylece kötü niyetli client'ları ayıklayabilmek için gerecek çalışmalar mevcuttur. Bunun için IdentityServer4 kullanarak geliştirirsek  client, API'lara istekte bulunabilmek için  access token değerini Auth Server(Merkezi Server)'dan elde edecek ve bunu tüm apilere istek yaparken kullanabilecek.
## IdentityServer4 Çözdüğü Problem2
Birden fazla client'in veritabanı bağlantısı durumunda ayrı ayrı connection yapmak yerine merkezi bir bağlantı üzerinden tek bir connection için IdentityServer4 kullanılabilir. Tüm client'ların; misal, giriş işlemi için SQL veritabanına bağlanması gerekmektedir. Bu durum sistemdeki tüm client'ler için bir kodlama maliyeti ortaya koymaktadır. Client'ları tek bir Auth Server üzerinden SQL Database'e bağlamak maliyeti düşürür.
## IdentityServer4 Çözdüğü Problem3
Facebook Login, Google Login gibi OAuth 2.0 ve OpenID Connect protokollerinin kullanıldığı teknikleri ortak paydadan dolayı IdentityServer4 ile hızlıca uygulayabilir ve uygulamanıza entegre edebilirsiniz.
## Modern Mimari
<strong>Cookie-based Auth:</strong> Server tabanda çalışan uygulamalarda (web app)  kimlik doğrulama ve yetkilendirme cookie tabanlı gerçekleştirilir. Kullanıcı bilgileri claimler vs cookie de tutulur. Her istek yapıldığında cookie'ler server tarafına gider ve gelir ve bu sayede kimlik yetkilendirme sağlanır.
<strong>Token-Based Auth:</strong> Web SPA(React,angular,vue.js) ve mobil app (android,ios) gibi uygulamalarda yetkilendirme token bazlı gerçekleştirilir. Web App(Server tabanda çalışan) dış dünyayla iletişim kurabilmesi için Token bazlı kimlik doğrulaması yapabilir.
## Client Credentials
Client Credentials, AuthServer ile apileri koruma altına almaya dayanır. Başkaları erişemesin.<br>
Hangi client hangi apiye istek yapcak bunu AuthServer'a bildirmemiz lazım.<br>
**Client'lar api'lere istek yapabilmek ve token isteyebilmek için AuthServer'a giderler Client-Id ve Client-Secret ını gönderirler. AuthServer ilgili web app'e token döner. Bu token'la ilgili apiye istek yapabiliyor olacak. Almış olduğu tokenda Api2'ye ait bilgi yoksa Api2'ye istek yapamaycak. <br>
<strong>Discovery Endpoint:</strong> Discovery Endpoint, IdentityServer4’ün sunduğu özellikleri keşfedebilmek için kullanılan bir endpoint’tir.
<strong>Introspection Endpoint:</strong> Elimizdeki token ilgili api için aktif mi değil mi bu endpoint ile öğrenebilirm.
## OAuth 2.0 Grants(İzin Tipleri)
*Authorization code grant
*İmplicit grant
*Resource owner credentials grant
*Client credentials grant(Client token almak istiyorsa apilere bağlanmak için)(Üyelik sistemi gerektirmez)
Üyelik sisteminin olmadığı bir yapıda iki tane uygulamayı(machine to machine) birbiri ile konuşturmak için client credential grant tipini kullanırız.<br>
<strong>ApiResource:</strong> AuthServer hangi apilerden sorumlu olduğunu ifade eder.<br>
<strong>ApiScope:</strong> Üretilecek token değerinin API üzerindeki yetki alanını ifade eder. Client, Auth Service üzerinden elde ettiği token’da hangi scope değerlerine sahipse ancak o scope değerlerine sahip olan API’lara istekte bulunabilir.<br>
Json Web Token'ları imzalamak için 2 türlü şifre kullanılır simetrik ve asimetrik şifre.<br>
Simetrik: Aynı şifreyi hem jwt yi doğrulamak için hem de imzalamak için kullanıyorum.<br>
Asimetrik: Private key kimseyle paylaşılmaz public key şifreyi kim çözecekse onunla paylaşılır ve public keye sahip kişi private keye sahip datayı doğrulayabilir.<br>
<strong>Access Token (Erişim Belirteci):</strong> Bir kaynağa ulaşmak için verilmiş belirteçtir. <br>
<strong>Refresh Token (Yenileme Belirteci):</strong> Bir erişim belirtecinin geçersiz olduğu durumlarda kullanılmak üzere oluşturulmuş olan ve bu geçersiz belirtecin güncellenmesini/yenilenmesini sağlayan belirteçtir.Client Credentailde refresh token kullanamayız.Access token client tarafında private key ile imzalanmış api tarafında public key ile doğrulanması lazım. Apilerde yetkilendirme ve deoğrulama jwt ile gerçeklecek.<br>
## Authorization(Yetkilendirme)
<strong>Role Based Authorization:</strong> Kullanıcılara admin, user gibi roller atayabiliriz. Dezavantajı dataları ile ilgili verilerle işlem yapamayız bunun için claim bazlı yetkilendirme çıktı.<br>
<strong>Claim Based Authorization:</strong> Kullanıcının datası üzerinden bir yetkilendirme yapılır.<br>
## Authorization code grant 
Authorization code; Auth server açısından access token üretmek için kullanıcı bilgilerinin doğruluğunun yanında ayrı bir onay/yetki manasına gelmektedir. Eğer authorization code yanlışsa, kullanıcı bilgileri doğru olsa bile access token üretilmeyecektir. <br>
Resource Owner: Uygulamayı kullanan kullanıcı,kaynak sahibi.

User Agent: Kullanıcıya aracılık eden uygulama. Genellikle web tarayıcısıdır.

Authorization Server: Token dağıtan sunucumuz.

Client: Client'ın ta kendisi. SPA,Mobile,web app.

Authorization Code Grant client’ı yetkilendirmek için, önce authorization code’u arından da access token’ı zorunlu kıldığından dolayı iki aşamalı doğrulama gerçekleştirmektedir diyebiliriz.
## İmplicit Grant 
Authorization code granttan farklı olarak identityserverden token alır 2 kere gidip gelmez. Kullanıcı bilgileri girildikten sonra direkt access token döner. Authorize endpointinden token alır.
## Resoruce Owner Credentials Grand(password): 
Client ve identityserver biz kodlamışsak ve tanıyorsak hiç authorize endpointine gitmeme gerek yok direkt token endpointinden token alabiliriz. Token endpointinden token alır.
## Merkezi Üyelik Sistemi
Return Type
*code token (authorize code ve access token)
*code id_token (imzalanmış token access token değil kullanılma amacı client bana istediğim yerden mi bana token döndü.public keyle doğrulanır.)
*code id_token token
Birden fazla data isteme hibrit akış olarak adlandırılır.
## Proof Key for Code Exchange (PKCE)
SPA(react,angular) ve mobil uygulamalar içerisinde client secret gibi değerleri göndermek tehlike arz etmektedir. Bunun için güvenlik açısından farklı çözümler düşünülmüş ve Proff Key for Code Exchange yöntemi tasarlanmıştır.
