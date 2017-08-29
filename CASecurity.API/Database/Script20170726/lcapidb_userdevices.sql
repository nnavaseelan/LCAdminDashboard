-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: lcapidb
-- ------------------------------------------------------
-- Server version	5.7.18-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `userdevices`
--

DROP TABLE IF EXISTS `userdevices`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `userdevices` (
  `Id` char(36) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `DeviceId` longtext NOT NULL,
  `BankId` longtext NOT NULL,
  `MerchantId` longtext NOT NULL,
  `Platform` longtext NOT NULL,
  `UserName` longtext NOT NULL,
  `AppId` longtext,
  `UserNic` longtext NOT NULL,
  `UserPassport` longtext NOT NULL,
  `JustPayCode` longtext NOT NULL,
  `EmailId` longtext NOT NULL,
  `MobileNo` longtext NOT NULL,
  `CertificateChallenge` longtext,
  `Status` longtext,
  `IssuedDateTime` datetime DEFAULT NULL,
  `VaidityPriod` datetime NOT NULL,
  `ValidatedDateTime` datetime DEFAULT NULL,
  `IsActive` tinyint(1) NOT NULL,
  `NoOfAttempt` int(11) NOT NULL,
  `CreatedDate` datetime NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userdevices`
--

LOCK TABLES `userdevices` WRITE;
/*!40000 ALTER TABLE `userdevices` DISABLE KEYS */;
INSERT INTO `userdevices` VALUES ('2cccf240-ee1a-4096-a3bf-93a9562106a7','1090','1102','1234','Android','navaseelan4u@gmail.com','1090','8594660257V','N121412','1102-1234-1090','navaseelan4u@gmail.com','0774475168','6-1gOqJStChdQ1k0uP02oZ4HRu_WVxUXCn9qGv3K1Tg1','B',NULL,'2017-07-26 13:10:41','2017-07-26 12:11:40',1,1,'2017-07-26 12:10:41');
/*!40000 ALTER TABLE `userdevices` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-07-26 12:13:31
