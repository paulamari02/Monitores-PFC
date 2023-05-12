CREATE DATABASE  IF NOT EXISTS `monitores` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `monitores`;
-- MySQL dump 10.13  Distrib 8.0.33, for Win64 (x86_64)
--
-- Host: localhost    Database: monitores
-- ------------------------------------------------------
-- Server version	8.0.33

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
-- Table structure for table `listadoarticulos`
--

DROP TABLE IF EXISTS `listadoarticulos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `listadoarticulos` (
  `id_articulo` int NOT NULL AUTO_INCREMENT,
  `articulo` varchar(50) NOT NULL DEFAULT '',
  `cod_articulo` varchar(50) NOT NULL DEFAULT '',
  `id_proveedor` int NOT NULL DEFAULT '0',
  `status` varchar(50) NOT NULL DEFAULT '',
  `observaciones` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT '*',
  PRIMARY KEY (`id_articulo`)
) ENGINE=InnoDB AUTO_INCREMENT=56 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `listadoarticulos`
--

LOCK TABLES `listadoarticulos` WRITE;
/*!40000 ALTER TABLE `listadoarticulos` DISABLE KEYS */;
INSERT INTO `listadoarticulos` VALUES (1,'Acoplamiento plastico motor SW80/SW80','42/1001',1,'Disponible','*'),(2,'Barreras de seguridad SMARTSCAN (Emisor+Receptor)','42/1002',3,'Disponible','*'),(3,'Proteccion plastico motorizacion cadena LH','42/1003',2,'Disponible','*'),(4,'Relé 24VDC Schneider CAD32BD','42/1004',1,'Disponible','*'),(5,'Modulo Salidas (Conveyor)','42/1005',2,'Disponible','*'),(6,'Modulo Entradas (Conveyor)','42/1006',3,'Disponible','*'),(7,'Fuente Alimentacion PLC (Conveyor)','42/1007',4,'Agotado','*'),(8,'Acoplamiento cristal motor SW80/SW80','42/1008',1,'Disponible','*'),(9,'Tarjeta Memoria Panel-View (Conveyor)','42/1009',6,'Agotado','*'),(10,'Pila Tarjeta Comunicaciones (Conveyor)','42/1010',7,'Agotado','*'),(11,'Contacto Lateral Schneider GVAN11 034348','42/1011',8,'Agotado','*'),(12,'Rele (Conveyor) Phoenix Contact 24v. 6A/250v.','42/1012',9,'Descatalogado','*'),(13,'Controlador PLC-5 (Conveyor)','42/1013',10,'Descatalogado','*'),(14,'Deslizante plastico tensor traccion','42/1014',12,'Descatalogado','*'),(15,'LATIGUILLO M12-5m A CABLEAR','42/1015',4,'Descatalogado','*'),(16,'Fuente de alimentacion modulos 1500 (SIEMENS)','42/1016',7,'Agotado','*'),(17,'Encauzador plastico triangular guiado curvas LH','42/1017',5,'Agotado','*'),(18,'Rele de seguridad (WIELAND)','42/1018',5,'Disponible','*'),(19,'Muelle Traccion Tensores cadena','42/1019',6,'Disponible','*'),(20,'Base de enchufes doble','42/1020',11,'Disponible','*'),(21,'SENSOR INDUCTIVO M12/4mm','42/1021',12,'Disponible','*'),(22,'CPU 1500 SIEMENS (1515-2PN)','42/1022',10,'Disponible','*'),(23,'Contacto Auxiliar para Guardamotores(SCHNEIDER)','42/1023',8,'Disponible','*'),(24,'Base de enchufe 220v','42/1024',13,'Disponible','*'),(25,'MODULO SEGURIDAD PILZ','42/1025',13,'Disponible','*');
/*!40000 ALTER TABLE `listadoarticulos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `listadoclientes`
--

DROP TABLE IF EXISTS `listadoclientes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `listadoclientes` (
  `id_cliente` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `apellidos` varchar(50) NOT NULL,
  `email` varchar(50) NOT NULL,
  `telefono` varchar(50) NOT NULL,
  `direccion` varchar(50) NOT NULL,
  `codigo_postal` varchar(50) NOT NULL,
  `fechaalta` date NOT NULL,
  `observaciones` varchar(50) DEFAULT '*',
  PRIMARY KEY (`id_cliente`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `listadoclientes`
--

LOCK TABLES `listadoclientes` WRITE;
/*!40000 ALTER TABLE `listadoclientes` DISABLE KEYS */;
INSERT INTO `listadoclientes` VALUES (1,'VOLKSWAGEN','*','inf@volsk.es','655625498','Zufafa A366','45546','2023-02-21','*'),(2,'SEAT S.A.','*','info@seatk.es','654789321','Autovia A-2','42456','2023-02-24','*'),(3,'ContiTech Tooling','*','contitech@tooling.com','654789321','Autopista Mexico','32168','2023-03-01','*'),(4,'AUDI TOOLING BARCELONA. S.L.','*','administr@audi.es','961785465','Poligono Picassent 2','46115','2023-03-03','*'),(5,'SKODA AUTO S.A','*','skoda@auto.es','961787890','PI Alcalde 2-9D','45813','2023-03-05','*'),(6,'Integrale','*','info@integrale.es','624359812','C/ Granja, 10','45548','2023-03-09','*'),(7,'TRASFESA','*','info@trasfera.es','621259812','Auntigua Faurecia','45450','2023-03-13','*'),(8,'VALMO','*','info@valmo.es','621257896','Poligono Juan Carlos I','46440','2023-03-18','*'),(9,'MB Levante','*','mb@levante.es','678527896','Plastal, 129','46440','2023-03-21','*'),(10,'KH','*','kh@info.es','916527896','Yan Feng, 45','46501','2023-03-30','*'),(11,'ESPACK','*','espak@info.es','916524996','Poligono Norte','42772','2023-04-05','*'),(12,'Zender','*','info@zender.es','662324996','Calle Foia, 21','46440','2023-04-17','*'),(13,'Faurecia','*','info@faurecia.es','632584658','Planta V4 L8','45236','2023-04-21','*'),(14,'Forvia','*','admin@forvia.com','651945287','Paralelo Mayor, 34','46460','2023-04-24','*'),(15,'VOLKSWAGEN','*','inf@volsk.es','655625498','Zufafa A366','45546','2023-02-21','*'),(16,'ContiTech Tooling','*','contitech@tooling.com','654789321','Autopista Mexico','32168','2023-03-01','*'),(17,'ABC Corporation','Jones','abc@corporation.com','5551234567','123 Main St','12345','2023-04-15','Cliente corporativo'),(18,'Smith and Sons','Johnson','smith@sons.com','5559876543','456 Elm St','54321','2023-02-20','Cliente familiar'),(19,'XYZ Manufacturing','Brown','xyz@manufacturing.com','5554567890','789 Oak St','67890','2023-05-05','Cliente industrial'),(20,'Johnson Enterprises','Miller','johnson@enterprises.com','5552345678','012 Pine St','09876','2023-01-10','Cliente de servicios'),(21,'Robinson Co.','Davis','robinson@co.com','5556789012','345 Cedar St','76543','2023-03-25','Cliente minorista'),(22,'Garcia and Partners','Martinez','garcia@partners.com','5558901234','567 Maple St','56789','2023-04-02','Cliente de consultoría'),(23,'Williams Group','Taylor','williams@group.com','5550123456','890 Walnut St','45678','2023-02-05','Cliente corporativo'),(24,'Rodriguez Company','Lopez','rodriguez@company.com','5555432109','901 Walnut St','34567','2023-03-10','Cliente minorista'),(25,'Hernandez Solutions','Gonzalez','hernandez@solutions.com','5556543210','234 Maple Ave','45678','2023-04-20','Cliente de servicios');
/*!40000 ALTER TABLE `listadoclientes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `listadoentradaalmacen`
--

DROP TABLE IF EXISTS `listadoentradaalmacen`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `listadoentradaalmacen` (
  `id_entrada` int NOT NULL AUTO_INCREMENT,
  `albaran` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT '',
  `fecha_entrada` date NOT NULL,
  `fecha_transito` date NOT NULL,
  `id_proveedor` int NOT NULL DEFAULT '0',
  `estado` varchar(50) NOT NULL,
  `cantidad` varchar(50) NOT NULL,
  `bultos` varchar(50) NOT NULL,
  PRIMARY KEY (`id_entrada`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `listadoentradaalmacen`
--

LOCK TABLES `listadoentradaalmacen` WRITE;
/*!40000 ALTER TABLE `listadoentradaalmacen` DISABLE KEYS */;
INSERT INTO `listadoentradaalmacen` VALUES (1,'ENT/006846','2023-05-03','2023-04-18',1,'Tránsito','3000','30'),(2,'ENT/006851','2023-05-03','2023-04-24',2,'Almacenado','2100','20'),(3,'ENT/006852','2023-05-03','2023-04-22',3,'Almacenado','2300','25'),(4,'ENT/006859','2023-05-03','2023-04-22',4,'Almacenado','3000','25'),(5,'ENT/006860','2023-05-06','2023-04-29',5,'Almacenado','2500','21'),(6,'ENT/006861','2023-05-07','2023-04-30',6,'Almacenado','1200','20'),(7,'ENT/006862','2023-05-08','2023-05-01',7,'Almacenado','1220','26'),(8,'ENT/006863','2023-05-08','2023-05-03',8,'Almacenado','1440','19'),(9,'ENT/006864','2023-05-08','2023-05-05',9,'Almacenado','1440','28'),(10,'ENT/006865','2023-05-10','2023-05-07',10,'Pendiente','1122','19'),(11,'ENT/006867','2023-05-12','2023-05-09',11,'Pendiente','2000','20'),(12,'ENT/006868','2023-05-13','2023-05-09',12,'Pendiente','1880','29'),(13,'ENT/006869','2023-05-14','2023-05-10',12,'Pendiente','2140','30'),(15,'ENT/006870','2023-05-14','2023-05-07',13,'Almacenado','2500','23'),(16,'ENT/006871','2023-05-15','2023-05-07',14,'Tránsito','2011','24'),(17,'ENT/006872','2023-05-15','2023-05-08',14,'Tránsito','2344','31'),(18,'ENT/006873','2023-05-16','2023-05-09',15,'Tránsito','2001','25'),(19,'ENT/006874','2023-05-16','2023-05-09',16,'Pendiente','1212','18'),(20,'ENT/006875','2023-05-17','2023-05-03',17,'Pendiente','2440','27'),(21,'ENT/006876','2023-05-17','2023-05-08',18,'Pendiente','2340','30'),(22,'ENT/006878','2023-05-17','2023-05-04',19,'Tránsito','2222','26'),(23,'ENT/006879','2023-05-18','2023-05-04',20,'Tránsito','2010','26'),(24,'ENT/006880','2023-05-18','2023-05-04',21,'Tránsito','1224','24'),(25,'ENT/006881','2023-05-18','2023-05-04',22,'Tránsito','2580','25');
/*!40000 ALTER TABLE `listadoentradaalmacen` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `listadopedidos`
--

DROP TABLE IF EXISTS `listadopedidos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `listadopedidos` (
  `id_pedido` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  `id_cliente` int NOT NULL,
  `status_pedido` varchar(50) NOT NULL,
  `fecha_pedido` date NOT NULL,
  `descripcion` varchar(50) DEFAULT '*',
  PRIMARY KEY (`id_pedido`),
  KEY `id_cliente` (`id_cliente`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `listadopedidos`
--

LOCK TABLES `listadopedidos` WRITE;
/*!40000 ALTER TABLE `listadopedidos` DISABLE KEYS */;
INSERT INTO `listadopedidos` VALUES (2,'EDFR 4698',1,'Terminado','1000-10-01','*'),(3,'FTGR 3568',2,'Terminado','2022-10-07','*'),(4,'GTDE 4785',2,'Terminado','2022-10-10','*'),(5,'PLID 9667',2,'Terminado','2022-10-12','*'),(6,'QDVU 2651',3,'Terminado','2022-10-16','*'),(7,'MEOV 8856',3,'Terminado','2022-10-18','*'),(8,'ADFE 4455',4,'Terminado','2022-10-21','*'),(9,'LDAS 4269',4,'En proceso','2022-10-31','*'),(10,'EDPL 6355',4,'Cancelado','2022-11-08','*'),(11,'DUDF 4572',4,'Cancelado','2022-11-13','*'),(12,'PLED 2426',5,'En proceso','2022-11-22','*'),(13,'BURZ 5525',5,'En proceso','2022-12-01','*'),(14,'AEDA 3624',8,'Terminado','2023-05-09','*'),(15,'PEVC 3566',10,'Terminado','2023-05-09','*'),(16,'SLNB 2651',3,'Terminado','2022-10-16','*'),(17,'DRES 2651',6,'En proceso','2022-10-18','*'),(18,'PLRE 3269',10,'En proceso','2022-10-19','*'),(19,'ERCS 3699',7,'En proceso','2022-10-19','*'),(20,'RREX 8831',7,'Cancelado','2022-10-19','*'),(21,'JIRS 3361',11,'Cancelado','2022-10-20','*'),(22,'ZAED 8846',9,'En proceso','2022-10-20','*'),(23,'GRSS 1234',11,'En proceso','2022-10-20','*'),(24,'SASA 4582',6,'Cancelado','2022-10-21','*'),(25,'WDRA 6399',10,'Terminado','2022-10-22','*');
/*!40000 ALTER TABLE `listadopedidos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `listadoproveedores`
--

DROP TABLE IF EXISTS `listadoproveedores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `listadoproveedores` (
  `id_proveedor` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  `num_fiscal` varchar(50) NOT NULL,
  `email` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `telefono` varchar(50) NOT NULL DEFAULT '',
  `direccion` varchar(50) NOT NULL,
  `codigo_postal` varchar(50) NOT NULL,
  `observaciones` varchar(50) DEFAULT '*',
  PRIMARY KEY (`id_proveedor`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `listadoproveedores`
--

LOCK TABLES `listadoproveedores` WRITE;
/*!40000 ALTER TABLE `listadoproveedores` DISABLE KEYS */;
INSERT INTO `listadoproveedores` VALUES (1,'Audi AG','4568521379','audi@prov.es','917852368','Poligono Cuenca 87','14896','*'),(2,'CEBI','2589631478','info@cebi.com','789654321','Pista Silla, 12','52879','*'),(3,'Coroplast','1597532486','info@cloropast.es','654789321','Av.Xativa, 123','85236','*'),(4,'Voss','5896321475','voss@prov.com','951753486','Ind. Zona Yun','58246','*'),(5,'TI Automotive','2546986317','ti@automotive.es','654544563','C\\Juan Herrnandez, 90','46458','*'),(6,'PIMA','4525953568','pima@prov.es','691785236','Poligono Mariano II','46159','*'),(7,'Ferreteria Olmo','5246953584','info@olmo.com','961785236','C\\ Lorenzos, 11','46444','*'),(8,'MidaTec','6464523159','info@midatec.com','961784567','Pista Silla, 67','52879','*'),(9,'AAMEC','5245698532','aamec@auto.com','664523897','Ronda Almudena, 87','46528','*'),(10,'ASAI','6328745579','asai@auto.com','612589985','Av. Angel Juan, 33B','46457','*'),(11,'Rodamientos Castalia','4569963258','castalia@auto.com','961784522','Poligono Almudena, 356','51289','*'),(12,'Zimmer group','5256585422','infor@zimmer.es','964582437','Ronda Francisco, 12','46444','*'),(13,'Electronics','5358546589','infor@electronics.es','662359874','Ronda Francisco, 23','46444','*'),(14,'Furniture Co.','9876543210','info@furnitureco.com','5551234567','Calle Principal, 123','12345','Proveedor de muebles'),(15,'Fashion Store','8765432109','info@fashionstore.com','5559876543','Avenida Moda, 456','67890','Proveedor de moda'),(16,'Gourmet Foods','7654321098','info@gourmetfoods.com','5556789012','Calle Delicias, 789','09876','Proveedor de alimentos gourmet'),(17,'Sports Equipment','6543210987','info@sportsequipment.com','5558901234','Avenida Deportes, 890','76543','Proveedor de equipos deportivos'),(18,'Home Decor','5432109876','info@homedecor.com','5550123456','Calle Decoración, 901','65432','Proveedor de artículos para el hogar'),(19,'Beauty Supplies','4321098765','info@beautysupplies.com','5552345678','Avenida Belleza, 012','54321','Proveedor de suministros de belleza'),(20,'Toys World','3210987654','info@toysworld.com','5554567890','Calle Juguetes, 345','43210','Proveedor de juguetes'),(21,'Stationery Supplies','2109876543','info@stationerysupplies.com','5556789054','Avenida Papelería, 567','32109','Proveedor de suministros de papelería'),(22,'Automotive Parts','1098765432','info@autoparts.com','5559054678','Calle Automóviles, 890','21098','Proveedor de piezas de automóviles'),(23,'Pet Supplies','0987654321','info@petsupplies.com','5555478960','Avenida Mascotas, 901','10987','Proveedor de suministros para mascotas'),(24,'Books Unlimited','9876543210','info@booksunlimited.com','5559087645','Calle Libros, 234','09876','Proveedor de libros'),(25,'Furniture Co.','9876543210','info@furnitureco.com','5551234567','Calle Principal, 123','12345','Proveedor de muebles');
/*!40000 ALTER TABLE `listadoproveedores` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `listadosalidasalmacen`
--

DROP TABLE IF EXISTS `listadosalidasalmacen`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `listadosalidasalmacen` (
  `id_salidas` int NOT NULL AUTO_INCREMENT,
  `albaran` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `id_proveedor` int NOT NULL DEFAULT '0',
  `fecha_salida` date NOT NULL,
  `estado` varchar(50) NOT NULL,
  `id_articulo` int NOT NULL DEFAULT '0',
  `cantidad` varchar(50) NOT NULL,
  `bultos` varchar(50) NOT NULL,
  PRIMARY KEY (`id_salidas`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `listadosalidasalmacen`
--

LOCK TABLES `listadosalidasalmacen` WRITE;
/*!40000 ALTER TABLE `listadosalidasalmacen` DISABLE KEYS */;
INSERT INTO `listadosalidasalmacen` VALUES (1,'EMB/005259',1,'2023-04-15','Almacenado',4,'1652','1652'),(2,'EMB/005260',2,'2023-04-18','Tránsito',5,'1000','1100'),(3,'EMB/005261',3,'2023-04-20','Tránsito',6,'1550','1750'),(4,'EMB/005262',4,'2023-04-22','Tránsito',7,'1400','1440'),(5,'EMB/005263',5,'2023-04-24','Tránsito',8,'2000','1990'),(6,'EMB/005265',6,'2023-04-26','Almacenado',6,'1458','1657'),(7,'EMB/005266',7,'2023-04-28','Almacenado',7,'1357','1357'),(8,'EMB/005267',8,'2023-04-29','Pendiente',8,'1000','1100'),(9,'EMB/005268',9,'2023-05-01','Almacenado',9,'1400','1366'),(10,'EMB/005269',10,'2023-05-02','Pendiente',10,'1988','1985'),(11,'EMB/005270',11,'2023-05-04','Almacenado',11,'2000','2000'),(12,'EMB/005271',12,'2023-05-06','Almacenado',12,'1500','1550'),(13,'EMB/005272',13,'2023-05-08','Almacenado',13,'1670','1600'),(14,'EMB/005273',14,'2023-05-08','Pendiente',15,'1202','1330'),(15,'EMB/005274',15,'2023-05-09','Pendiente',1,'1400','1322'),(16,'EMB/005275',16,'2023-05-10','Pendiente',2,'1111','1112'),(17,'EMB/005276',1,'2023-05-10','Pendiente',3,'1251','1001'),(18,'EMB/005277',2,'2023-05-11','Tránsito',4,'1999','1111'),(19,'EMB/005278',3,'2023-05-11','Tránsito',5,'2000','1355'),(20,'EMB/005279',4,'2023-05-12','Tránsito',6,'1989','1344'),(21,'EMB/005280',17,'2023-05-12','Almacenado',16,'1987','1322'),(22,'EMB/005281',18,'2023-05-13','Almacenado',17,'1452','1246'),(23,'EMB/005282',19,'2023-05-13','Almacenado',18,'1522','1384'),(24,'EMB/005283',20,'2023-05-14','Tránsito',19,'1555','1333'),(25,'EMB/005284',21,'2023-05-14','Tránsito',20,'1557','1337');
/*!40000 ALTER TABLE `listadosalidasalmacen` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-05-12 10:33:22
