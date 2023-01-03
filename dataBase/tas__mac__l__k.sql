-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1:3306
-- Üretim Zamanı: 03 Oca 2023, 13:50:02
-- Sunucu sürümü: 5.7.40
-- PHP Sürümü: 8.0.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `tasımacılık`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `admin`
--

DROP TABLE IF EXISTS `admin`;
CREATE TABLE IF NOT EXISTS `admin` (
  `admin_sifre` varchar(100) COLLATE utf8mb4_turkish_ci NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

--
-- Tablo döküm verisi `admin`
--

INSERT INTO `admin` (`admin_sifre`) VALUES
('12345');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `araclar`
--

DROP TABLE IF EXISTS `araclar`;
CREATE TABLE IF NOT EXISTS `araclar` (
  `arac_plaka` varchar(50) COLLATE utf8mb4_turkish_ci NOT NULL,
  `arac_marka` varchar(50) COLLATE utf8mb4_turkish_ci NOT NULL,
  `arac_model` varchar(50) COLLATE utf8mb4_turkish_ci NOT NULL,
  `uretim_yılı` varchar(50) COLLATE utf8mb4_turkish_ci NOT NULL,
  `yakit_tipi` varchar(50) COLLATE utf8mb4_turkish_ci NOT NULL,
  `arac_renk` varchar(50) COLLATE utf8mb4_turkish_ci NOT NULL,
  `arac_kilometre` int(11) NOT NULL,
  `arac_turu` varchar(50) COLLATE utf8mb4_turkish_ci NOT NULL,
  `rezerve` varchar(5) COLLATE utf8mb4_turkish_ci NOT NULL,
  `surucu` varchar(50) COLLATE utf8mb4_turkish_ci NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

--
-- Tablo döküm verisi `araclar`
--

INSERT INTO `araclar` (`arac_plaka`, `arac_marka`, `arac_model`, `uretim_yılı`, `yakit_tipi`, `arac_renk`, `arac_kilometre`, `arac_turu`, `rezerve`, `surucu`) VALUES
('55SMS5512', 'Ford', 'asd', '2011', 'LPG', 'Siyah', 123455, 'Kamyon', 'Evet', 'muharrem'),
('34PH768', 'Iveco', 'C3', '2019', 'Dizel', 'MOR', 800000, 'Tır', 'Evet', 'ahmet'),
('10AFH740', 'Volvo', 'Astra', '2020', 'Benzin', '100', 100, 'Kamyonet ', 'Evet', 'Cem'),
('43AF2010', 'Ford', 'x', '2015', 'Benzin', 'Mavi', 1111, 'Kamyon', 'Hayır', 'Cem'),
('10MS1010', 'Mercedes', 'AMG', '2021', 'Benzin', 'Sarı', 10, 'Tır', 'Evet', 'utku');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kullanıcı`
--

DROP TABLE IF EXISTS `kullanıcı`;
CREATE TABLE IF NOT EXISTS `kullanıcı` (
  `kullanici_id` int(11) NOT NULL AUTO_INCREMENT,
  `kullanici_adi` varchar(50) COLLATE utf8mb4_turkish_ci NOT NULL,
  `kullanici_telno` varchar(11) COLLATE utf8mb4_turkish_ci NOT NULL,
  `sifre` varchar(50) COLLATE utf8mb4_turkish_ci NOT NULL,
  PRIMARY KEY (`kullanici_id`)
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

--
-- Tablo döküm verisi `kullanıcı`
--

INSERT INTO `kullanıcı` (`kullanici_id`, `kullanici_adi`, `kullanici_telno`, `sifre`) VALUES
(2, 'cmkusku', '5425439319', '12345'),
(3, 'AlpKağan', '05454568696', '123'),
(4, 'cem', '11111111111', '1111'),
(5, 'alihan', '1', '1'),
(6, 'asd', '111111', '1234');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `musteri`
--

DROP TABLE IF EXISTS `musteri`;
CREATE TABLE IF NOT EXISTS `musteri` (
  `musteri_id` int(11) NOT NULL AUTO_INCREMENT,
  `musteri_adi` varchar(50) COLLATE utf8mb4_turkish_ci NOT NULL,
  `musteri_adres` varchar(100) COLLATE utf8mb4_turkish_ci NOT NULL,
  `musteri_telno` varchar(11) COLLATE utf8mb4_turkish_ci NOT NULL,
  `musteri_cinsiyet` varchar(10) COLLATE utf8mb4_turkish_ci NOT NULL,
  PRIMARY KEY (`musteri_id`)
) ENGINE=MyISAM AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

--
-- Tablo döküm verisi `musteri`
--

INSERT INTO `musteri` (`musteri_id`, `musteri_adi`, `musteri_adres`, `musteri_telno`, `musteri_cinsiyet`) VALUES
(3, 'Cem', 'adsfsdgdssdgsdgfdhdf', '12311111', 'Erkek'),
(9, 'utku u', 'xc', '11111111122', 'Erkek'),
(5, 'xxxx', 'asdasdasdasdasdasdasfasfasfzxcvzxvzxvxzvzxvxzvzx', '124', 'Kadın'),
(8, 'asdaf', 'aaaaaaa', '111111', 'Kadın'),
(10, 'pdfgd', 'fkghofdg', 'dflgpdfp', 'Kadın'),
(11, 'pxvckfgv', 'dflgfd', 'dfmg', 'Erkek'),
(12, 'Alp Kağan', 'xxxxxxxxx', '05425658575', 'Erkek'),
(13, 'cem', 'asd', '1222222', 'Erkek'),
(14, 'murat', 'asd', '2222222', 'Erkek'),
(15, 'asss', 'x', '(1  )    -', 'Erkek'),
(16, 'Erdem', 'xxx', '05425497896', 'Erkek');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `rezervasyon`
--

DROP TABLE IF EXISTS `rezervasyon`;
CREATE TABLE IF NOT EXISTS `rezervasyon` (
  `rezervasyon_id` int(11) NOT NULL AUTO_INCREMENT,
  `musteri_adi` varchar(50) COLLATE utf8mb4_turkish_ci NOT NULL,
  `arac` varchar(50) COLLATE utf8mb4_turkish_ci NOT NULL,
  `surucu` varchar(50) COLLATE utf8mb4_turkish_ci NOT NULL,
  `gidis_tarihi` date NOT NULL,
  `donus_tarihi` date NOT NULL,
  `ucret` int(11) NOT NULL,
  `rezervasyon_kullanici` varchar(50) COLLATE utf8mb4_turkish_ci NOT NULL,
  PRIMARY KEY (`rezervasyon_id`)
) ENGINE=MyISAM AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

--
-- Tablo döküm verisi `rezervasyon`
--

INSERT INTO `rezervasyon` (`rezervasyon_id`, `musteri_adi`, `arac`, `surucu`, `gidis_tarihi`, `donus_tarihi`, `ucret`, `rezervasyon_kullanici`) VALUES
(8, 'asdaf', '10MS1010', 'emirhan', '2023-01-01', '2023-01-18', 344, 'cmkusku'),
(6, 'Cem', '43UTK4343', 'utku', '2022-12-07', '2022-12-29', 1233, 'cmkusku'),
(7, 'Alp Kağan', '43UTK4343', 'utku', '2022-12-07', '2022-12-21', 100, 'AlpKağan');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `suruculer`
--

DROP TABLE IF EXISTS `suruculer`;
CREATE TABLE IF NOT EXISTS `suruculer` (
  `surucu_id` int(11) NOT NULL AUTO_INCREMENT,
  `isim` varchar(100) COLLATE utf8mb4_turkish_ci NOT NULL,
  `telefon_num` varchar(11) COLLATE utf8mb4_turkish_ci NOT NULL,
  `adres` varchar(500) COLLATE utf8mb4_turkish_ci NOT NULL,
  `dogmgunu` date NOT NULL,
  `ise_gir_tar` date NOT NULL,
  `cinsiyeti` varchar(500) COLLATE utf8mb4_turkish_ci NOT NULL,
  `degerlendirme` int(11) NOT NULL,
  PRIMARY KEY (`surucu_id`)
) ENGINE=MyISAM AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

--
-- Tablo döküm verisi `suruculer`
--

INSERT INTO `suruculer` (`surucu_id`, `isim`, `telefon_num`, `adres`, `dogmgunu`, `ise_gir_tar`, `cinsiyeti`, `degerlendirme`) VALUES
(11, 'asf', '12324', 'qwqwe', '2021-10-21', '2022-11-30', 'Erkek', 3),
(12, 'asd', '542545245', 'asd', '2009-06-10', '2011-06-17', 'Erkek', 3),
(13, 'Cem', '123', 'asd', '2002-09-04', '2022-12-14', 'Erkek', 5),
(14, 'ahmet', '123', 'as', '2022-11-29', '2022-12-27', 'Erkek', 4),
(15, 'utku', '22222', 'adsfasdf', '2022-12-01', '2022-12-21', 'Erkek', 5),
(16, 'muharrem', '1234532', 'xxxxxxxxxxxxxxx', '2001-12-01', '2022-12-15', 'Erkek', 1),
(17, 'Erdem', '05356454545', 'xxx', '1995-07-14', '2022-06-16', 'Erkek', 5);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
