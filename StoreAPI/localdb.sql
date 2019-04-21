-- phpMyAdmin SQL Dump
-- version 4.6.6
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:55132
-- Generation Time: Apr 16, 2019 at 12:42 PM
-- Server version: 5.7.9
-- PHP Version: 5.6.39

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `localdb`
--

-- --------------------------------------------------------

--
-- Table structure for table `address`
--

CREATE TABLE `address` (
  `AddressId` int(11) NOT NULL,
  `FirstName` varchar(45) COLLATE utf8_bin NOT NULL,
  `LastName` varchar(45) COLLATE utf8_bin NOT NULL,
  `Address1` varchar(255) COLLATE utf8_bin NOT NULL,
  `Address2` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `City` varchar(45) COLLATE utf8_bin NOT NULL,
  `State` varchar(45) COLLATE utf8_bin NOT NULL,
  `Zip` varchar(5) COLLATE utf8_bin NOT NULL,
  `Phone` varchar(10) COLLATE utf8_bin DEFAULT NULL,
  `DefaultAddress` tinyint(1) NOT NULL,
  `UserId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- --------------------------------------------------------

--
-- Table structure for table `item`
--

CREATE TABLE `item` (
  `ItemId` int(11) NOT NULL,
  `Category` varchar(255) COLLATE utf8_bin NOT NULL,
  `Type` varchar(255) COLLATE utf8_bin NOT NULL,
  `Name` varchar(255) COLLATE utf8_bin NOT NULL,
  `Price` double(10,2) NOT NULL,
  `Original` double(10,2) NOT NULL,
  `Stock` int(11) NOT NULL,
  `Image` varchar(255) COLLATE utf8_bin NOT NULL,
  `Seller` varchar(255) COLLATE utf8_bin NOT NULL,
  `NewTag` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Dumping data for table `item`
--

INSERT INTO `item` (`ItemId`, `Category`, `Type`, `Name`, `Price`, `Original`, `Stock`, `Image`, `Seller`, `NewTag`) VALUES
(1, 'Accessories', 'Accessories', 'Wool Slipper', 20.95, 40.00, 95, '39.jpg', 'COS', 1),
(2, 'Accessories', 'Accessories', 'Cashmere Socks', 18.95, 60.00, 88, '42.jpg', 'COS', 1),
(3, 'Accessories', 'Accessories', 'Rubber Beach Sandals', 14.95, 20.00, 130, '94.png', 'Amazon', 0),
(4, 'Accessories', 'Accessories', 'Lether Backpack', 135.99, 240.00, 29, '99.png', 'Amazon', 1),
(5, 'Accessories', 'Accessories', 'Nylon Backpack', 47.99, 70.00, 140, '45.jpg', 'Amazon', 0),
(6, 'Accessories', 'Accessories', 'Checked Luggage', 126.99, 335.00, 110, '97.png', 'Samsonite', 1),
(7, 'Accessories', 'Accessories', 'Luggage 4 Set', 210.95, 415.00, 210, '47.jpg', 'Samsonite', 1),
(8, 'Furniture', 'Furniture', 'Bedding Set', 139.97, 312.00, 110, '40.png', 'IKEA', 0),
(9, 'Furniture', 'Furniture', 'Pillow', 23.98, 40.00, 90, '41.jpg', 'IKEA', 0),
(10, 'Furniture', 'Furniture', 'Mattress', 127.99, 234.00, 210, '92.png', 'IKEA', 0),
(11, 'Furniture', 'Furniture', 'Cushion', 12.99, 15.00, 95, '107.png', 'IKEA', 1),
(12, 'Furniture', 'Furniture', 'Towel', 9.95, 12.00, 95, '106.png', 'IKEA', 1),
(13, 'Furniture', 'Furniture', 'Patch Board', 19.95, 24.00, 95, '86.png', 'Amazon', 0),
(14, 'Kitchen', 'Kitchen', 'Towel', 9.99, 15.00, 95, '36.jpg', 'IKEA', 0),
(15, 'Kitchen', 'Kitchen', 'Rice Cooker', 89.99, 100.00, 95, '87.png', 'Amazon', 0),
(16, 'Kitchen', 'Kitchen', 'Glass Container', 19.99, 30.00, 105, '90.png', 'IKEA', 0),
(17, 'Kitchen', 'Kitchen', 'Scissors', 9.99, 12.00, 85, '93.png', 'Staples', 0),
(18, 'Kitchen', 'Kitchen', 'Mug', 7.5, 10.00, 195, '105.png', 'Amazon', 0),
(19, 'Kitchen', 'Kitchen', 'Porcelain Bowl', 19.99, 30.00, 205, '95.png', 'IKEA', 0);

-- --------------------------------------------------------

--
-- Table structure for table `orderdetail`
--

CREATE TABLE `orderdetail` (
  `OrderId` varchar(45) COLLATE utf8_bin NOT NULL,
  `Staus` varchar(255) COLLATE utf8_bin NOT NULL,
  `PlacedTime` datetime NOT NULL,
  `Total` double(10,2) NOT NULL,
  `ShippingAddressId` int(11) DEFAULT NULL,
  `PaymentId` int(11) DEFAULT NULL,
  `UserId` int(11) DEFAULT NULL,
  `Code` varchar(45) COLLATE utf8_bin DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- --------------------------------------------------------

--
-- Table structure for table `orderitem`
--

CREATE TABLE `orderitem` (
  `OrderId` varchar(45) COLLATE utf8_bin NOT NULL,
  `ItemId` int(11) NOT NULL,
  `Number` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- --------------------------------------------------------

--
-- Table structure for table `payment`
--

CREATE TABLE `payment` (
  `PaymentId` int(11) NOT NULL,
  `NameOnCard` varchar(45) COLLATE utf8_bin NOT NULL,
  `CardType` varchar(45) COLLATE utf8_bin NOT NULL,
  `Issuer` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `CardNumber` varchar(16) COLLATE utf8_bin NOT NULL,
  `Expiration` varchar(4) COLLATE utf8_bin NOT NULL,
  `CVV` varchar(3) COLLATE utf8_bin NOT NULL,
  `DefaultPayment` tinyint(1) NOT NULL,
  `BillingAddressId` int(11) DEFAULT NULL,
  `UserId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- --------------------------------------------------------

--
-- Table structure for table `promocode`
--

CREATE TABLE `promocode` (
  `Code` varchar(45) COLLATE utf8_bin NOT NULL,
  `Discount` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Dumping data for table `promocode`
--

INSERT INTO `promocode` (`Code`, `Discount`) VALUES
('SAVE10', '0.90'),
('SAVE20', '0.80'),
('SAVE30', '0.70'),
('SAVE5', '0.95'),
('SAVE50', '0.50');

-- --------------------------------------------------------

--
-- Table structure for table `shoppingcart`
--

CREATE TABLE `shoppingcart` (
  `UserId` int(11) NOT NULL,
  `ItemId` int(11) NOT NULL,
  `Number` int(11) NOT NULL,
  `AddTime` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- --------------------------------------------------------

--
-- Table structure for table `tracking`
--

CREATE TABLE `tracking` (
  `TrackingId` int(11) NOT NULL,
  `Status` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `OrderId` varchar(45) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `UserId` int(11) NOT NULL,
  `Username` varchar(45) COLLATE utf8_bin NOT NULL,
  `Password` varchar(255) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `address`
--
ALTER TABLE `address`
  ADD PRIMARY KEY (`AddressId`),
  ADD KEY `fk_address_user_idx` (`UserId`);

--
-- Indexes for table `item`
--
ALTER TABLE `item`
  ADD PRIMARY KEY (`ItemId`) USING BTREE;

--
-- Indexes for table `orderdetail`
--
ALTER TABLE `orderdetail`
  ADD PRIMARY KEY (`OrderId`),
  ADD KEY `fk_order_user_idx` (`UserId`),
  ADD KEY `fk_order_address_idx` (`ShippingAddressId`),
  ADD KEY `fk_order_payment_idx` (`PaymentId`),
  ADD KEY `fk_order_code_idx` (`Code`) USING BTREE;

--
-- Indexes for table `orderitem`
--
ALTER TABLE `orderitem`
  ADD PRIMARY KEY (`OrderId`,`ItemId`),
  ADD KEY `fk_orderitem_order_idx` (`OrderId`),
  ADD KEY `fk_orderitem_item_idx` (`ItemId`);

--
-- Indexes for table `payment`
--
ALTER TABLE `payment`
  ADD PRIMARY KEY (`PaymentId`),
  ADD KEY `fk_payment_address_idx` (`BillingAddressId`),
  ADD KEY `fk_payment_user_idx` (`UserId`);

--
-- Indexes for table `promocode`
--
ALTER TABLE `promocode`
  ADD PRIMARY KEY (`Code`);

--
-- Indexes for table `shoppingcart`
--
ALTER TABLE `shoppingcart`
  ADD PRIMARY KEY (`UserId`,`ItemId`),
  ADD KEY `fk_shoppintcart_user_idx` (`UserId`),
  ADD KEY `fk_shoppintcart_item_idx` (`ItemId`);

--
-- Indexes for table `tracking`
--
ALTER TABLE `tracking`
  ADD PRIMARY KEY (`TrackingId`),
  ADD KEY `fk_tracking_order_idx` (`OrderId`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`UserId`),
  ADD UNIQUE KEY `index_username` (`Username`),
  ADD KEY `UserId` (`UserId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `address`
--
ALTER TABLE `address`
  MODIFY `AddressId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;
--
-- AUTO_INCREMENT for table `item`
--
ALTER TABLE `item`
  MODIFY `ItemId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;
--
-- AUTO_INCREMENT for table `payment`
--
ALTER TABLE `payment`
  MODIFY `PaymentId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;
--
-- AUTO_INCREMENT for table `tracking`
--
ALTER TABLE `tracking`
  MODIFY `TrackingId` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `UserId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;
--
-- Constraints for dumped tables
--

--
-- Constraints for table `address`
--
ALTER TABLE `address`
  ADD CONSTRAINT `fk_address_user` FOREIGN KEY (`UserId`) REFERENCES `user` (`UserId`);

--
-- Constraints for table `orderdetail`
--
ALTER TABLE `orderdetail`
  ADD CONSTRAINT `fk_order_address` FOREIGN KEY (`ShippingAddressId`) REFERENCES `address` (`AddressId`),
  ADD CONSTRAINT `fk_order_code` FOREIGN KEY (`Code`) REFERENCES `promocode` (`Code`),
  ADD CONSTRAINT `fk_order_payment` FOREIGN KEY (`PaymentId`) REFERENCES `payment` (`PaymentId`),
  ADD CONSTRAINT `fk_order_user` FOREIGN KEY (`UserId`) REFERENCES `user` (`UserId`);

--
-- Constraints for table `orderitem`
--
ALTER TABLE `orderitem`
  ADD CONSTRAINT `fk_orderitem_item` FOREIGN KEY (`ItemId`) REFERENCES `item` (`ItemId`),
  ADD CONSTRAINT `fk_orderitem_order` FOREIGN KEY (`OrderId`) REFERENCES `orderdetail` (`OrderId`);

--
-- Constraints for table `payment`
--
ALTER TABLE `payment`
  ADD CONSTRAINT `fk_payment_address` FOREIGN KEY (`BillingAddressId`) REFERENCES `address` (`AddressId`),
  ADD CONSTRAINT `fk_payment_user` FOREIGN KEY (`UserId`) REFERENCES `user` (`UserId`);

--
-- Constraints for table `shoppingcart`
--
ALTER TABLE `shoppingcart`
  ADD CONSTRAINT `fk_shoppintcart_item` FOREIGN KEY (`ItemId`) REFERENCES `item` (`ItemId`),
  ADD CONSTRAINT `fk_shoppintcart_user` FOREIGN KEY (`UserId`) REFERENCES `user` (`UserId`);

--
-- Constraints for table `tracking`
--
ALTER TABLE `tracking`
  ADD CONSTRAINT `fk_tracking_order` FOREIGN KEY (`OrderId`) REFERENCES `orderdetail` (`OrderId`);
