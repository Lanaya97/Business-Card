CREATE DATABASE  IF NOT EXISTS `businesscardschema` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `businesscardschema`;
-- MySQL dump 10.13  Distrib 8.0.38, for Win64 (x86_64)
--
-- Host: localhost    Database: businesscardschema
-- ------------------------------------------------------
-- Server version	8.0.39

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `businesscard`
--

DROP TABLE IF EXISTS `businesscard`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `businesscard` (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Gender` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `DateOfBirth` datetime(6) NOT NULL,
  `Email` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CountryCode` varchar(4) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `PhoneNumber` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Street` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `City` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ZipCode` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Photo` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DateCreated` datetime(6) NOT NULL,
  `DateModified` datetime(6) NOT NULL,
  `DateDeleted` datetime(6) DEFAULT NULL,
  `CreatedById` int DEFAULT NULL,
  `ModifiedById` int DEFAULT NULL,
  `DeletedById` int DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IX_BusinessCard_Email` (`Email`),
  UNIQUE KEY `IX_BusinessCard_PhoneNumber` (`PhoneNumber`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `businesscard`
--

LOCK TABLES `businesscard` WRITE;
/*!40000 ALTER TABLE `businesscard` DISABLE KEYS */;
INSERT INTO `businesscard` VALUES ('01e5adf2-9238-4fac-b780-cd41055b85ea','Edward Elric','Male','1996-04-03 00:00:00.000000','edward@example.com','+81','1231231234','852 Birch St','Tokyo','98765',NULL,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000',NULL,NULL,NULL,NULL,0),('23c46907-7a20-42b8-a84f-b483553e9c13','Charlie Brown','Male','1992-07-22 00:00:00.000000','charlie@example.com','+44','1122334455','789 Maple Ave','London','54321',NULL,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000',NULL,NULL,NULL,NULL,0),('249f91de-1b23-4054-a08b-beaeced1d11f','Ian Curtis','Male','1991-01-05 00:00:00.000000','ian@example.com','+33','9876543210','963 Birch Dr','Paris','12345',NULL,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000',NULL,NULL,NULL,NULL,0),('44bc8b1c-4bf8-4d31-9502-37754ff4559d','Fiona Green','Female','1994-08-30 00:00:00.000000','fiona@example.com','+81','4321432143','963 Cedar St','Tokyo','98765',NULL,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000',NULL,NULL,NULL,NULL,0),('59d8c051-7b9b-4e56-9f44-6348836b0ee0','Bob Johnson','Male','1985-03-15 00:00:00.000000','bob@example.com','+1','0987654321','456 Oak St','Springfield','12345',NULL,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000',NULL,NULL,NULL,NULL,0),('93071d63-e477-44b5-82d0-70e801bf3c73','Julia Roberts','Female','1983-10-10 00:00:00.000000','julia@example.com','+33','6543217890','258 Oak Rd','Paris','12345',NULL,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000',NULL,NULL,NULL,NULL,0),('a0b6eb19-ba3f-42aa-828c-f3c62ddeab9f','Diana Prince','Female','1988-11-11 00:00:00.000000','diana@example.com','+44','5566778899','159 Pine St','London','54321',NULL,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000',NULL,NULL,NULL,NULL,0),('a2ef9c7b-9732-40da-b8b5-b354eee968d2','Alice Smith','Female','1990-05-01 00:00:00.000000','alice@example.com','+1','1234567890','123 Elm St','Springfield','12345',NULL,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000',NULL,NULL,NULL,NULL,0),('c4ad3892-8222-4f4c-ab2d-261cad07f44f','Hannah White','Female','1995-06-18 00:00:00.000000','hannah@example.com','+61','6546546544','852 Cedar Rd','Sydney','54321',NULL,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000',NULL,NULL,NULL,NULL,0),('cd22a992-2c33-418d-b91c-d62916ba6216','George Martin','Male','1980-12-15 00:00:00.000000','george@example.com','+61','3213214321','741 Spruce St','Sydney','54321',NULL,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000',NULL,NULL,NULL,NULL,0);
/*!40000 ALTER TABLE `businesscard` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-10-13 23:19:24
