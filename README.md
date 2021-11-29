# SPACE-MINERS
Oyun programlama ders vizesi için geliştirdiğimiz oyun projesi

## GitHub link
https://github.com/adem-pelit/space-miners/

## Oyun sitesi
https://adem-pelit.itch.io/spaceship

## Oyun Tanıtımı
### Temel Bilgiler
Oyunda savaş gemisi ile uzay boşluğunda kolonileşmiş blokları en kısa sürede patlatmak gerekmektedir. Oyun `Unity - C#` ile yazılmış olup `WebGl` için üretilmiştir.

![Ekran Görüntüsü (53)](https://user-images.githubusercontent.com/55463533/143926154-55b20e5e-3fff-43c9-aa95-104c043838c7.png)

### Tuş Bilgisi
* **W** tuşu ile uzay gemimiz ileri yönde hareket etmektedir.
* **S** tuşu ile uzay gemimiz geri yönde hareket etmektedir.
* **A** tuşu ile uzay gemimiz sola dönmektedir.
* **D** tuşu ile uzay gemimiz sağa dönmektedir
* **P** tuşu ile uzay gemisinin hızı yavaşlamaktadır.
* **Space** tuşu ile uzay gemimiz ateş etmektedir.
* **5** tuşu ile gemimiz kendi ekseni etrafında aşağı dönmektedir
* **2** tuşu ile gemimiz kendi ekseni etrafında yukarı dönmektedir
* **3** tuşu ile gemimiz kendi ekseni etrafında sola dönmektedir
* **1** tuşu ile gemimiz kendi ekseni etrafında sağa dönmektedir
### Challange'lar
Uzay gemisinin manevralarını yapmak, ateş etmek ve blokları en kısa sürede imha etmek oyunun Challange’larıdır.
## Projedeki Göreler
* Uzay gemisinin hareketiyle alakalı olan `Arac` class’ını yazdım. Uzay gemisi rigidbody’sine uygulanan kuvvetler sayesinde hareket ve rotasyon gerçekleştirmektedir.
* Uzaydaki blokların belli merkezler çevresinde rastgele oluşmasını sağlayan `Bina` class’ını yazdım.
* Kurşunların hareketini `rigidbody` ile sağladım. Kurşunlar bloklara çarptıkları zaman patlamaları gerekiyordu. Normalde bunu Unity’nin sağladığı ` OnCollisionEnter` metoduyla gerçekleştiriyordum ancak `WebGL` de bu metodun çalışmadığını farkettim. Bu yüzden `RaycastHit` class’ını kullanarak ışın izledim ve kurşun eğer bloğa 5 metreden yakınsa patlaması talimatını verdim. Patlama ve kurşun nesnelerine ışık ekledim.
* Bloklar gemiden çok uzakta olduklarında görünmüyorlardı. Bu yüzden bloklar uzaktayken onları ekranda temsil edecek Mavi renkli hedef resimi koydum.
* Oyunun gerçekçiliğini arttırmak için Oyuna belli sesler ekledim. Bu sesleri `sfxr` adındaki 8 bit sesler üreten program ile ürettim.
* Giriş ekranı kısmına koyduğum `play` butonuna basıldığında sahneler arası geçiş yapılarak `Menu` sahnesinden `main` sahnesine geçiş yapılıyor ve oyun başlamış oluyor. Bir diğer buton olan `credits` butonuna tıklandığında ise `Canvas` altındaki `CreditsMenu` ekranına geçiş yapılıyor ve ekranda isimlerimizi yazıyor. `Quit` butonuna basıldığında ise konsola uyarı veriyor.
* Oyun sonu ekranı kısmında ise `retry` ve `maın menu` adlı iki adet buton bulunmaktadır. Retry butonuna basıldığında oyun tekrar başlıyor. Main menü butonu ise bizi ilk sahne olan `Menu` sahnesine atıyor 
* Uzay gemisi modellemesini internetten aldığım hazır asset ile modelledim.
* Arayüzler

## Kullanılan Assetler ve linkleri
https://assetstore.unity.com/packages/3d/vehicles/space/spacefighter-87056
