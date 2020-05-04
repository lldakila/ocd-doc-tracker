-- phpMyAdmin SQL Dump
-- version 4.8.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Mar 18, 2019 at 01:06 PM
-- Server version: 10.1.34-MariaDB
-- PHP Version: 7.2.7

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `ocd`
--

-- --------------------------------------------------------

--
-- Table structure for table `tbl_all_docu`
--

CREATE TABLE `tbl_all_docu` (
  `file_id` int(250) NOT NULL,
  `barcode_id` bigint(13) NOT NULL,
  `col_origin` text NOT NULL,
  `filename` varchar(250) NOT NULL,
  `date_recieve` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `received_by` varchar(250) NOT NULL,
  `subject` varchar(250) NOT NULL,
  `col_to` varchar(250) NOT NULL,
  `col_from` varchar(250) NOT NULL,
  `date_activity` date NOT NULL,
  `remarks` longtext NOT NULL,
  `action_needed` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_all_docu`
--

INSERT INTO `tbl_all_docu` (`file_id`, `barcode_id`, `col_origin`, `filename`, `date_recieve`, `received_by`, `subject`, `col_to`, `col_from`, `date_activity`, `remarks`, `action_needed`) VALUES
(2, 16001660000, 'Central', 'Tuguegarao-Pancit-Finder-Website.docx', '2019-03-18 03:53:50', 'uscba', 'cjibfu', 'safjbnui', 'cnnuwewno', '2019-02-20', 'bcaubq  uchhwn  c ibnf w nk ijnwe nj ; \' \"asfams \' \' buguigiuguigiugiug', 'vnweuicn  uibw viub nwbufnew f  kjnwe kn ivwbii \' \' \' '),
(3, 8002346100, 'RGL/PRVL', 'Luyun-Aguirre-Cosmelyn-Docu.docx', '2019-03-11 06:14:26', 'sanasifbasij', 's fjansiaibibanfa', 'san san san', 'cnwjinivwbebfubib', '2019-02-19', 'sabfuiasbfbawui', 'asnfonofnwoenfowenfeow  vnsv ibwu vibwjiwe  iusbf ijew '),
(4, 16002363500, 'Central', 'Bartolome-Dayag-Lozano.docx', '2019-03-11 06:15:02', 'sdfausbfubsufi', 'sdsfbibaiufbw', 'nfiwbiubfwiubi', 'sdsbfbiuwbfuiwbiu', '2019-02-21', 'ssfbauisbfausbfiuafiuabiufb', 'snofanfnnmsnznxnvbcxvb bksdd aisj niv\"kjlz hiuaji\"ba b ajsb gui;'),
(5, 4801278325071, 'Central', 'johnald john trinidad.docx', '2019-03-11 06:15:11', 'dakila', 'dakila pa', 'dakila tug', 'daki la', '2019-02-13', 'sadahsoidhasoihdoaishdioashdiosah', 'saidoasoidhasoifhasiohfiaosh'),
(7, 4800049720190, 'RGL/PRVL', 'Kuya-Daks-Final-Document (1).docx', '2019-03-11 06:15:20', 'jbjdsbfjksdbiu', 'sdjfbibaib', 'sdjfbwib', 'sdifjbiubf', '2019-02-19', 'yusadsdfbsdiugbisubg', 'sd,lsdkf\';sv;,sd,v;;slmvsw.,smgvlms\'sks;lfmdb.sdbmll'),
(8, 122342151561, 'Central', 'IPO(PansitFinder).docx', '2019-03-11 09:22:35', 'safasnovna aoms', ' so dv o osv ', ' OSD V SJV SJNM ', 'VSDIONVO SD JSD', '2019-03-27', 'S SALJKNCFJAS KJSDNFAS AJNFJASFK AS NASJFNSANFLKSAN SAKJNFASNFNASO', 'SSANFASJNOAS ndsofnasdofns osdnvodns doinifosdn');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_incoming_rgl_prvl`
--

CREATE TABLE `tbl_incoming_rgl_prvl` (
  `file_id` int(250) NOT NULL,
  `filename` varchar(250) NOT NULL,
  `date_receive` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `received_by` varchar(250) NOT NULL,
  `subject` varchar(250) NOT NULL,
  `to` varchar(250) NOT NULL,
  `from` varchar(250) NOT NULL,
  `date_activity` datetime NOT NULL,
  `remarks` varchar(250) NOT NULL,
  `action_needed` varchar(250) NOT NULL,
  `barcode_id` int(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_login`
--

CREATE TABLE `tbl_login` (
  `id` int(250) NOT NULL,
  `username` varchar(250) NOT NULL,
  `password` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_memorandum`
--

CREATE TABLE `tbl_memorandum` (
  `file_id` int(250) NOT NULL,
  `filename` varchar(250) NOT NULL,
  `date_receive` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `received_by` varchar(250) NOT NULL,
  `subject` varchar(250) NOT NULL,
  `to` varchar(250) NOT NULL,
  `from` varchar(250) NOT NULL,
  `date_activity` datetime NOT NULL,
  `remarks` varchar(250) NOT NULL,
  `action_needed` varchar(250) NOT NULL,
  `barcode_id` int(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_memo_cdrrmc`
--

CREATE TABLE `tbl_memo_cdrrmc` (
  `file_id` int(250) NOT NULL,
  `filename` varchar(250) NOT NULL,
  `date_receive` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `received_by` varchar(250) NOT NULL,
  `subject` varchar(250) NOT NULL,
  `to` varchar(250) NOT NULL,
  `from` varchar(250) NOT NULL,
  `date_activity` datetime NOT NULL,
  `remarks` varchar(250) NOT NULL,
  `action_needed` varchar(250) NOT NULL,
  `barcode_id` int(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_memo_rdrrmc`
--

CREATE TABLE `tbl_memo_rdrrmc` (
  `file_id` int(250) NOT NULL,
  `filename` varchar(250) NOT NULL,
  `date_receive` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `received_by` varchar(250) NOT NULL,
  `subject` varchar(250) NOT NULL,
  `to` varchar(250) NOT NULL,
  `from` varchar(250) NOT NULL,
  `date_activity` datetime NOT NULL,
  `remarks` varchar(250) NOT NULL,
  `action_needed` varchar(250) NOT NULL,
  `barcode_id` int(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_outgoing_central`
--

CREATE TABLE `tbl_outgoing_central` (
  `file_id` int(250) NOT NULL,
  `filename` varchar(250) NOT NULL,
  `date_receive` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `received_by` varchar(250) NOT NULL,
  `subject` varchar(250) NOT NULL,
  `to` varchar(250) NOT NULL,
  `from` varchar(250) NOT NULL,
  `date_activity` datetime NOT NULL,
  `remarks` varchar(250) NOT NULL,
  `action_needed` varchar(250) NOT NULL,
  `barcode_id` int(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_outgoing_rgl_prvl`
--

CREATE TABLE `tbl_outgoing_rgl_prvl` (
  `file_id` int(11) NOT NULL,
  `filename` varchar(250) NOT NULL,
  `date_receive` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `received_by` varchar(250) NOT NULL,
  `subject` varchar(250) NOT NULL,
  `to` varchar(250) NOT NULL,
  `from` varchar(250) NOT NULL,
  `date_activity` datetime NOT NULL,
  `remarks` varchar(250) NOT NULL,
  `action_needed` varchar(250) NOT NULL,
  `barcode_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_travel_order`
--

CREATE TABLE `tbl_travel_order` (
  `file_id` int(250) NOT NULL,
  `filename` varchar(250) NOT NULL,
  `date_receive` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `received_by` varchar(250) NOT NULL,
  `subject` varchar(250) NOT NULL,
  `to` varchar(250) NOT NULL,
  `from` varchar(250) NOT NULL,
  `date_activity` datetime NOT NULL,
  `remarks` varchar(250) NOT NULL,
  `action_needed` varchar(250) NOT NULL,
  `barcode_id` int(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_users`
--

CREATE TABLE `tbl_users` (
  `id` int(250) NOT NULL,
  `username` varchar(250) NOT NULL,
  `password` varchar(250) NOT NULL,
  `f_name` varchar(250) NOT NULL,
  `m_name` varchar(250) NOT NULL,
  `l_name` varchar(250) NOT NULL,
  `email` varchar(250) NOT NULL,
  `m_number` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tbl_all_docu`
--
ALTER TABLE `tbl_all_docu`
  ADD PRIMARY KEY (`file_id`),
  ADD UNIQUE KEY `barcode_id` (`barcode_id`),
  ADD UNIQUE KEY `filename` (`filename`);

--
-- Indexes for table `tbl_incoming_rgl_prvl`
--
ALTER TABLE `tbl_incoming_rgl_prvl`
  ADD PRIMARY KEY (`file_id`);

--
-- Indexes for table `tbl_login`
--
ALTER TABLE `tbl_login`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tbl_memorandum`
--
ALTER TABLE `tbl_memorandum`
  ADD PRIMARY KEY (`file_id`);

--
-- Indexes for table `tbl_memo_cdrrmc`
--
ALTER TABLE `tbl_memo_cdrrmc`
  ADD PRIMARY KEY (`file_id`);

--
-- Indexes for table `tbl_memo_rdrrmc`
--
ALTER TABLE `tbl_memo_rdrrmc`
  ADD PRIMARY KEY (`file_id`);

--
-- Indexes for table `tbl_outgoing_central`
--
ALTER TABLE `tbl_outgoing_central`
  ADD PRIMARY KEY (`file_id`);

--
-- Indexes for table `tbl_travel_order`
--
ALTER TABLE `tbl_travel_order`
  ADD PRIMARY KEY (`file_id`);

--
-- Indexes for table `tbl_users`
--
ALTER TABLE `tbl_users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tbl_all_docu`
--
ALTER TABLE `tbl_all_docu`
  MODIFY `file_id` int(250) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `tbl_incoming_rgl_prvl`
--
ALTER TABLE `tbl_incoming_rgl_prvl`
  MODIFY `file_id` int(250) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tbl_login`
--
ALTER TABLE `tbl_login`
  MODIFY `id` int(250) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tbl_memorandum`
--
ALTER TABLE `tbl_memorandum`
  MODIFY `file_id` int(250) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tbl_memo_cdrrmc`
--
ALTER TABLE `tbl_memo_cdrrmc`
  MODIFY `file_id` int(250) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tbl_memo_rdrrmc`
--
ALTER TABLE `tbl_memo_rdrrmc`
  MODIFY `file_id` int(250) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tbl_outgoing_central`
--
ALTER TABLE `tbl_outgoing_central`
  MODIFY `file_id` int(250) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tbl_travel_order`
--
ALTER TABLE `tbl_travel_order`
  MODIFY `file_id` int(250) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tbl_users`
--
ALTER TABLE `tbl_users`
  MODIFY `id` int(250) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
