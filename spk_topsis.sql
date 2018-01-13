-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Jan 13, 2018 at 07:46 AM
-- Server version: 10.1.13-MariaDB
-- PHP Version: 7.0.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `spk_topsis`
--

-- --------------------------------------------------------

--
-- Table structure for table `kriteria`
--

CREATE TABLE `kriteria` (
  `id` int(11) NOT NULL,
  `kriteria` varchar(30) NOT NULL,
  `bobot` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `kriteria`
--

INSERT INTO `kriteria` (`id`, `kriteria`, `bobot`) VALUES
(1, 'kondisi rumah', 5),
(2, 'penghasilan', 4),
(3, 'pekerjaan', 3),
(4, 'jumlah tanggungan', 2),
(5, 'aset pribadi', 1);

-- --------------------------------------------------------

--
-- Table structure for table `nilai`
--

CREATE TABLE `nilai` (
  `id` int(11) NOT NULL,
  `nilai` tinytext NOT NULL,
  `bobot` int(11) NOT NULL,
  `id_kriteria` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `nilai`
--

INSERT INTO `nilai` (`id`, `nilai`, `bobot`, `id_kriteria`) VALUES
(1, 'Bambu', 3, 1),
(2, 'Triplek', 2, 1),
(3, 'Papan', 1, 1),
(4, 'Beton', 0, 1),
(5, 'x  < 500.000', 4, 2),
(6, '500 .000 ? x ? 1.000.000', 3, 2),
(7, '1.000.000 <x? 3.000.000', 2, 2),
(8, '3.000.000 < x ? 5.000.000', 1, 2),
(9, 'x> 5.000.000', 0, 2),
(10, 'Buruh', 4, 3),
(11, 'Petani', 3, 3),
(12, 'PNS', 2, 3),
(13, 'Wirausaha', 1, 3),
(14, 'Pengusaha', 0, 3),
(15, '> 8 orang', 3, 4),
(16, '6-8 orang', 2, 4),
(17, '3-5 orang', 1, 4),
(18, '1-2 orang', 0, 4),
(19, 'y ? 1.000.000', 3, 5),
(20, '1.000.000 <  y < 4.000.000', 2, 5),
(21, '4.000.000 ? y ? 8.000.000', 1, 5),
(22, 'y>8.000.000', 0, 5);

-- --------------------------------------------------------

--
-- Table structure for table `penduduk`
--

CREATE TABLE `penduduk` (
  `id` int(11) NOT NULL,
  `nama` varchar(30) NOT NULL,
  `nik` varchar(30) NOT NULL,
  `alamat` varchar(100) NOT NULL,
  `total_nilai` double NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `penduduk`
--

INSERT INTO `penduduk` (`id`, `nama`, `nik`, `alamat`, `total_nilai`) VALUES
(1, 'Slamet', '0139081973', 'Dusun Jambean RT 02 RW 01 Desa Cekok Kecamatan', 1),
(2, 'Jarwani', '3524232904790001', 'Dusun Jambean RT 02 RW 01 Desa Cekok Kecamatan', 0.5711),
(3, 'Samsul', '3174041512720016', 'Dusun Krajan RtT 03 RW 02 Desa Cekok Kecamatan', 0),
(4, 'Budi Anduk', '1234567543', 'Jl.Senggani Malang', 0.5711);

-- --------------------------------------------------------

--
-- Table structure for table `perhitungan`
--

CREATE TABLE `perhitungan` (
  `id` int(11) NOT NULL,
  `id_penduduk` int(11) NOT NULL,
  `id_kriteria` int(11) NOT NULL,
  `id_nilai` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `perhitungan`
--

INSERT INTO `perhitungan` (`id`, `id_penduduk`, `id_kriteria`, `id_nilai`) VALUES
(1, 1, 1, 1),
(2, 1, 2, 5),
(3, 1, 3, 10),
(4, 1, 4, 17),
(5, 1, 5, 19),
(6, 2, 1, 2),
(7, 2, 2, 5),
(8, 2, 3, 11),
(9, 2, 4, 17),
(10, 2, 5, 19),
(11, 3, 1, 3),
(12, 3, 2, 7),
(13, 3, 3, 12),
(14, 3, 4, 17),
(15, 3, 5, 20),
(52, 4, 5, 19),
(51, 4, 4, 17),
(50, 4, 3, 11),
(49, 4, 2, 5),
(48, 4, 1, 2);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `kriteria`
--
ALTER TABLE `kriteria`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `nilai`
--
ALTER TABLE `nilai`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `penduduk`
--
ALTER TABLE `penduduk`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `perhitungan`
--
ALTER TABLE `perhitungan`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `kriteria`
--
ALTER TABLE `kriteria`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT for table `nilai`
--
ALTER TABLE `nilai`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;
--
-- AUTO_INCREMENT for table `penduduk`
--
ALTER TABLE `penduduk`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT for table `perhitungan`
--
ALTER TABLE `perhitungan`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=53;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
