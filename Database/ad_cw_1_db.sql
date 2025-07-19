-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Aug 01, 2025 at 10:33 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `ad_cw_1_new`
--

-- --------------------------------------------------------

--
-- Table structure for table `assistants`
--

CREATE TABLE `assistants` (
  `id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `phone` varchar(20) DEFAULT NULL,
  `address` varchar(500) DEFAULT NULL,
  `status` varchar(255) NOT NULL DEFAULT 'Active',
  `created_at` datetime DEFAULT current_timestamp(),
  `updated_at` datetime NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `assistants`
--

INSERT INTO `assistants` (`id`, `name`, `phone`, `address`, `status`, `created_at`, `updated_at`) VALUES
(1, 'Samantha', '0771000001', 'Galle', 'Inactive', '2025-07-31 17:11:53', '2025-08-01 10:59:53'),
(2, 'Chandrakumara', '0771000002', 'Matara', 'Active', '2025-07-31 17:11:53', '2025-08-01 11:00:07'),
(3, 'Jayanath', '0789451368', 'Enderamulla, Wattala', 'Active', '2025-07-31 20:38:33', '2025-08-01 10:59:32'),
(4, 'Senith', '0745879654', 'No 103/1, D.S.Senanayaka Street, Kandy', 'Active', '2025-08-01 11:01:33', '2025-08-01 11:01:33'),
(5, 'Nishantha', '0769824712', '162/26, Megoda Kolonnawa', 'Active', '2025-08-01 11:02:30', '2025-08-01 11:02:30'),
(6, 'Hasitha', '0783241569', '264 Grandpass Road, 14, Colombo', 'Active', '2025-08-01 11:03:28', '2025-08-01 11:03:28'),
(7, 'Jayasiri', '0781549635', '78 Main Street, Matara', 'Active', '2025-08-01 13:50:19', '2025-08-01 13:50:19');

-- --------------------------------------------------------

--
-- Table structure for table `customers`
--

CREATE TABLE `customers` (
  `id` int(11) NOT NULL,
  `customer_number` varchar(20) NOT NULL,
  `name` varchar(100) NOT NULL,
  `address` text DEFAULT NULL,
  `phone` varchar(15) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `created_at` datetime DEFAULT current_timestamp(),
  `user_id` int(11) DEFAULT NULL,
  `updated_at` datetime NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `customers`
--

INSERT INTO `customers` (`id`, `customer_number`, `name`, `address`, `phone`, `email`, `created_at`, `user_id`, `updated_at`) VALUES
(15, 'CUST202508019082', 'Chamika', '', '0774564544', 'pasindukavinda227+2@gmail.com', '2025-08-01 08:34:20', 14, '2025-08-01 11:13:22'),
(17, 'CUST202508014682', 'Dilshika', '81 Roadrigo Place, 15, Colombo', '0762315479', 'pasindukavinda227+4@gmail.com', '2025-08-01 08:46:31', 16, '2025-08-01 11:13:08'),
(18, 'CUST32514847856', 'Saman', '10/2 Beachside Avenue, Negombo', '0768945621', 'pasindukavinda227@gmail.com', '2025-08-01 13:52:51', 17, '2025-08-01 13:52:51'),
(19, 'CUST202508011578', 'Pasindu', '', '0784562139', 'pasindukavinda227+23@gmail.com', '2025-08-01 13:57:29', 18, '2025-08-01 13:57:29');

-- --------------------------------------------------------

--
-- Table structure for table `drivers`
--

CREATE TABLE `drivers` (
  `id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `license_number` varchar(50) NOT NULL,
  `phone` varchar(20) DEFAULT NULL,
  `address` varchar(500) DEFAULT NULL,
  `status` varchar(255) NOT NULL DEFAULT '1',
  `created_at` datetime DEFAULT current_timestamp(),
  `updated_at` datetime NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `drivers`
--

INSERT INTO `drivers` (`id`, `name`, `license_number`, `phone`, `address`, `status`, `created_at`, `updated_at`) VALUES
(1, 'Sadeepa', 'DR-648712', '0772000001', '100/16 Keyzer Street, 1, Colombo', 'Active', '2025-07-31 17:11:53', '2025-08-01 10:53:14'),
(2, 'Aruna', 'DR-469781', '0772000002', '336, Colombo Road, Peradeniya', 'Inactive', '2025-07-31 17:11:53', '2025-08-01 10:54:41'),
(6, 'Nadun', 'DR-789454', '0778945125', 'No.41, Industrial Estat, Dankotuwa', 'Active', '2025-07-31 19:33:59', '2025-08-01 10:52:20'),
(7, 'Kosala', 'DR-364187', '0778459315', 'Uragasmanhandiya Road, Mahaedanda', 'Active', '2025-08-01 10:55:51', '2025-08-01 10:55:51'),
(8, 'Saranga', 'DR-451368', '0772365418', 'Sri Gunarathana Road, Panadura', 'Active', '2025-08-01 10:57:02', '2025-08-01 10:57:02'),
(9, 'Madawa', 'DR-874165', '0762549831', '436, Kaluaggala, Hanwella', 'Active', '2025-08-01 10:58:10', '2025-08-01 10:58:10'),
(10, 'Nimal Perera', 'DR-54139', '0775421369', 'No. 45, Galle Road, Colombo 03', 'Active', '2025-08-01 13:49:41', '2025-08-01 13:49:41');

-- --------------------------------------------------------

--
-- Table structure for table `jobs`
--

CREATE TABLE `jobs` (
  `id` int(11) NOT NULL,
  `job_number` varchar(50) NOT NULL,
  `customer_id` int(11) NOT NULL,
  `pickup_location` varchar(500) NOT NULL,
  `delivery_location` varchar(500) NOT NULL,
  `request_date` datetime NOT NULL,
  `scheduled_date` datetime DEFAULT NULL,
  `completion_date` datetime DEFAULT NULL,
  `description` varchar(1000) DEFAULT NULL,
  `estimated_cost` decimal(10,2) NOT NULL,
  `actual_cost` decimal(10,2) DEFAULT NULL,
  `status` varchar(255) NOT NULL DEFAULT '1',
  `transport_unit_id` int(11) DEFAULT NULL,
  `created_at` datetime DEFAULT current_timestamp(),
  `notes` varchar(1000) DEFAULT NULL,
  `updated_at` datetime NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `jobs`
--

INSERT INTO `jobs` (`id`, `job_number`, `customer_id`, `pickup_location`, `delivery_location`, `request_date`, `scheduled_date`, `completion_date`, `description`, `estimated_cost`, `actual_cost`, `status`, `transport_unit_id`, `created_at`, `notes`, `updated_at`) VALUES
(16, 'JOB20250801113820', 15, 'No.131/A, Kandy Rd', '11 A 2nd Cross Street', '2025-08-01 11:38:20', NULL, NULL, 'Transfer Request', 0.00, NULL, 'Pending', NULL, '2025-08-01 11:38:20', 'ASAP', '2025-08-01 11:51:27'),
(17, 'JOB20250801115044', 15, '38 Kumaran Ratnam Road, 02', '517/6 Thimbirigasyaya Road', '2025-08-01 11:50:44', NULL, NULL, 'Transfer Request', 0.00, NULL, 'Pending', NULL, '2025-08-01 11:50:44', 'Call me before pickup', '2025-08-01 11:50:44'),
(18, 'JOB20250801115225', 15, '65, 2ND LAND, Ratmalana', '312A Kandy Road ,Kadawatha', '2025-08-01 11:52:25', NULL, NULL, 'Transfer Request', 0.00, NULL, 'Pending', NULL, '2025-08-01 11:52:25', '-', '2025-08-01 11:52:25'),
(19, 'JOB20250801115945', 17, 'B9,Metiyagane,Galle', 'B5,Halloluwa,Galle', '2025-08-01 11:59:45', NULL, NULL, 'Transfer Request', 0.00, NULL, 'Pending', NULL, '2025-08-01 11:59:45', '', '2025-08-01 11:59:45'),
(20, 'JOB20250801120044', 17, 'B22,Lakshauyana,Dambulla', 'B20,Galadivulwewa,Dambulla', '2025-08-01 12:00:44', NULL, '2025-08-01 12:07:08', 'Transfer Request', 200.00, NULL, 'Completed', 5, '2025-08-01 12:00:44', '', '2025-08-01 12:07:08'),
(21, 'JOB20250801135839', 19, '78 Main Street, Matara', '25 Temple Lane, Nuwara Eliya', '2025-08-01 13:58:39', NULL, NULL, 'Transfer Request', 120.00, NULL, 'Confirmed', 1, '2025-08-01 13:58:39', 'asap', '2025-08-01 13:59:50');

-- --------------------------------------------------------

--
-- Table structure for table `job_products`
--

CREATE TABLE `job_products` (
  `id` int(11) NOT NULL,
  `job_id` int(11) DEFAULT NULL,
  `product_id` int(11) DEFAULT NULL,
  `quantity` int(11) DEFAULT NULL,
  `custom_weight` decimal(8,2) DEFAULT NULL,
  `custom_dimensions` varchar(100) DEFAULT NULL,
  `created_at` datetime NOT NULL DEFAULT current_timestamp(),
  `updated_at` datetime NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `job_products`
--

INSERT INTO `job_products` (`id`, `job_id`, `product_id`, `quantity`, `custom_weight`, `custom_dimensions`, `created_at`, `updated_at`) VALUES
(9, 16, 4, 5, NULL, NULL, '2025-08-01 11:38:20', '2025-08-01 11:38:20'),
(10, 16, 7, 10, NULL, NULL, '2025-08-01 11:38:20', '2025-08-01 11:38:20'),
(11, 16, 1, 5, NULL, NULL, '2025-08-01 11:38:20', '2025-08-01 11:38:20'),
(12, 17, 2, 4, NULL, NULL, '2025-08-01 11:50:44', '2025-08-01 11:50:44'),
(13, 17, 6, 2, NULL, NULL, '2025-08-01 11:50:44', '2025-08-01 11:50:44'),
(14, 18, 5, 10, NULL, NULL, '2025-08-01 11:52:25', '2025-08-01 11:52:25'),
(15, 18, 1, 1, NULL, NULL, '2025-08-01 11:52:25', '2025-08-01 11:52:25'),
(16, 19, 7, 4, NULL, NULL, '2025-08-01 11:59:45', '2025-08-01 11:59:45'),
(17, 19, 2, 3, NULL, NULL, '2025-08-01 11:59:45', '2025-08-01 11:59:45'),
(18, 19, 4, 1, NULL, NULL, '2025-08-01 11:59:45', '2025-08-01 11:59:45'),
(19, 20, 6, 4, NULL, NULL, '2025-08-01 12:00:44', '2025-08-01 12:00:44'),
(20, 21, 7, 5, NULL, NULL, '2025-08-01 13:58:39', '2025-08-01 13:58:39'),
(21, 21, 6, 2, NULL, NULL, '2025-08-01 13:58:39', '2025-08-01 13:58:39');

-- --------------------------------------------------------

--
-- Table structure for table `job_status_logs`
--

CREATE TABLE `job_status_logs` (
  `id` int(11) NOT NULL,
  `job_id` int(11) NOT NULL,
  `status` varchar(50) NOT NULL,
  `updated_by` int(11) DEFAULT NULL,
  `note` text DEFAULT NULL,
  `created_at` datetime DEFAULT current_timestamp(),
  `updated_at` datetime NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `loads`
--

CREATE TABLE `loads` (
  `id` int(11) NOT NULL,
  `load_number` varchar(50) NOT NULL,
  `job_id` int(11) NOT NULL,
  `description` varchar(500) NOT NULL,
  `weight` decimal(10,2) NOT NULL,
  `volume` decimal(10,2) NOT NULL,
  `instructions` varchar(500) DEFAULT NULL,
  `created_at` datetime DEFAULT current_timestamp(),
  `updated_at` datetime NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `loads`
--

INSERT INTO `loads` (`id`, `load_number`, `job_id`, `description`, `weight`, `volume`, `instructions`, `created_at`, `updated_at`) VALUES
(5, 'LDJOB2025080112004420250801120144', 20, 'Manual Load Entry', 20.00, 5.00, 'Added via Manage Job Modal', '2025-08-01 12:01:44', '2025-08-01 12:01:44'),
(6, 'LDJOB2025080113583920250801135931', 21, 'Manual Load Entry', 10.00, 5.00, 'Added via Manage Job Modal', '2025-08-01 13:59:31', '2025-08-01 13:59:31'),
(7, 'LDJOB2025080113583920250801135938', 21, 'Manual Load Entry', 2.00, 3.00, 'Added via Manage Job Modal', '2025-08-01 13:59:38', '2025-08-01 13:59:38');

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE `products` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `weight` decimal(10,2) DEFAULT NULL,
  `dimensions` varchar(255) DEFAULT NULL,
  `created_at` datetime NOT NULL DEFAULT current_timestamp(),
  `updated_at` datetime NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`id`, `name`, `weight`, `dimensions`, `created_at`, `updated_at`) VALUES
(1, 'Sofa Set', 150.00, '8x3', '2025-07-31 17:11:53', '2025-08-01 12:19:51'),
(2, 'Washing Machine', 70.00, '2x3', '2025-07-31 17:11:53', '2025-08-01 12:20:02'),
(4, 'Television', 2.00, '32x20', '2025-08-01 05:08:06', '2025-08-01 12:19:39'),
(5, 'Refrigerator', 100.00, '2x4', '2025-08-01 11:29:44', '2025-08-01 12:19:30'),
(6, 'Single bed', 60.00, '5x3', '2025-08-01 11:30:16', '2025-08-01 12:19:19'),
(7, 'Chair', 10.00, '2x2', '2025-08-01 11:31:13', '2025-08-01 12:19:04');

-- --------------------------------------------------------

--
-- Table structure for table `transport_units`
--

CREATE TABLE `transport_units` (
  `id` int(11) NOT NULL,
  `unit_number` varchar(50) NOT NULL,
  `truck_id` int(11) NOT NULL,
  `driver_id` int(11) NOT NULL,
  `assistant_id` int(11) DEFAULT NULL,
  `status` varchar(255) NOT NULL DEFAULT '1',
  `created_at` datetime DEFAULT current_timestamp(),
  `updated_at` datetime NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `transport_units`
--

INSERT INTO `transport_units` (`id`, `unit_number`, `truck_id`, `driver_id`, `assistant_id`, `status`, `created_at`, `updated_at`) VALUES
(1, 'TU-0017', 7, 1, 1, 'Active', '2025-07-31 17:11:53', '2025-08-01 11:06:05'),
(2, 'TU-0802', 2, 2, 2, 'Active', '2025-07-31 17:11:53', '2025-08-01 11:06:31'),
(3, 'TU-2276', 9, 7, 3, 'Active', '2025-07-31 21:51:42', '2025-08-01 11:05:55'),
(4, 'TU-8457', 10, 6, 6, 'Active', '2025-08-01 11:04:32', '2025-08-01 11:04:32'),
(5, 'TU-1487', 8, 9, 5, 'Active', '2025-08-01 11:05:39', '2025-08-01 11:05:39'),
(6, 'TU-2223', 7, 10, 7, 'Active', '2025-08-01 13:50:55', '2025-08-01 13:50:55');

-- --------------------------------------------------------

--
-- Table structure for table `trucks`
--

CREATE TABLE `trucks` (
  `id` int(11) NOT NULL,
  `truck_number` varchar(50) NOT NULL,
  `model` varchar(100) NOT NULL,
  `license_plate` varchar(20) NOT NULL,
  `status` varchar(255) NOT NULL DEFAULT 'Active',
  `capacity` int(11) NOT NULL CHECK (`capacity` > 0),
  `created_at` datetime NOT NULL DEFAULT current_timestamp(),
  `updated_at` datetime DEFAULT NULL ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `trucks`
--

INSERT INTO `trucks` (`id`, `truck_number`, `model`, `license_plate`, `status`, `capacity`, `created_at`, `updated_at`) VALUES
(1, 'TR-4545', 'Dyna 150 / 200', 'NA-1514', 'Active', 56, '2025-07-29 02:18:37', '2025-08-01 13:48:30'),
(2, 'TR-6953', 'Canter FE71 / FE8', 'NH-9867', 'Active', 100, '2025-07-31 20:10:20', '2025-08-01 05:15:14'),
(5, 'TR-6954', 'Jayo / Loadking', 'NH-4512', 'Inactive', 50, '2025-08-01 05:15:48', '2025-08-01 13:48:37'),
(6, 'TR-7457', 'NHR / NPR / NQR', 'PH-1245', 'Active', 75, '2025-08-01 05:16:45', NULL),
(7, 'TR-1297', 'Dyna 150 / 200', 'ND-7845', 'Active', 60, '2025-08-01 05:17:39', NULL),
(8, 'TR-8745', 'Canter FE71 / FE8', 'NH-4419', 'Active', 50, '2025-08-01 10:48:43', NULL),
(9, 'TR-6745', 'D-MAX', 'ND-4578', 'Active', 45, '2025-08-01 10:49:26', NULL),
(10, 'TR-6324', 'Xenon / Yodha', 'NA-4482', 'Active', 60, '2025-08-01 10:50:05', NULL),
(11, 'TR-6398', 'D-MAX', 'ND-1148', 'Active', 50, '2025-08-01 13:48:08', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `username` varchar(100) NOT NULL,
  `password` varchar(255) DEFAULT NULL,
  `role` enum('admin','customer') NOT NULL,
  `created_at` datetime DEFAULT current_timestamp(),
  `updated_at` datetime NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `username`, `password`, `role`, `created_at`, `updated_at`) VALUES
(5, 'admin', 'XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=', 'admin', '2025-07-20 12:10:30', '2025-07-31 14:42:51'),
(14, 'CUST202508019082', 'XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=', 'customer', '2025-08-01 08:34:20', '2025-08-01 08:34:20'),
(16, 'CUST202508014682', 'XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=', 'customer', '2025-08-01 08:46:31', '2025-08-01 08:46:31'),
(17, 'CUST32514847856', 'IlWbQaxwd8GF5GC3OPM9lpylVjCM+oUXOAYxoAAAD/4=', 'customer', '2025-08-01 13:52:51', '2025-08-01 13:52:51'),
(18, 'CUST202508011578', 'C+ZK6J3dJOIlQ03pXVAXETObru4Y8Am6m0NpryfTDWA=', 'customer', '2025-08-01 13:57:29', '2025-08-01 13:57:29');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `assistants`
--
ALTER TABLE `assistants`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `customers`
--
ALTER TABLE `customers`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `customer_number` (`customer_number`),
  ADD KEY `FK_customers_user_id` (`user_id`);

--
-- Indexes for table `drivers`
--
ALTER TABLE `drivers`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `license_number` (`license_number`);

--
-- Indexes for table `jobs`
--
ALTER TABLE `jobs`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `job_number` (`job_number`),
  ADD KEY `customer_id` (`customer_id`),
  ADD KEY `transport_unit_id` (`transport_unit_id`);

--
-- Indexes for table `job_products`
--
ALTER TABLE `job_products`
  ADD PRIMARY KEY (`id`),
  ADD KEY `job_id` (`job_id`),
  ADD KEY `product_id` (`product_id`);

--
-- Indexes for table `job_status_logs`
--
ALTER TABLE `job_status_logs`
  ADD PRIMARY KEY (`id`),
  ADD KEY `job_id` (`job_id`),
  ADD KEY `updated_by` (`updated_by`);

--
-- Indexes for table `loads`
--
ALTER TABLE `loads`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `load_number` (`load_number`),
  ADD KEY `job_id` (`job_id`);

--
-- Indexes for table `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`id`),
  ADD KEY `IX_Product_Name` (`name`);

--
-- Indexes for table `transport_units`
--
ALTER TABLE `transport_units`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `unit_number` (`unit_number`),
  ADD KEY `truck_id` (`truck_id`),
  ADD KEY `driver_id` (`driver_id`),
  ADD KEY `assistant_id` (`assistant_id`);

--
-- Indexes for table `trucks`
--
ALTER TABLE `trucks`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `truck_number` (`truck_number`),
  ADD UNIQUE KEY `license_plate` (`license_plate`),
  ADD KEY `idx_truck_number` (`truck_number`),
  ADD KEY `idx_license_plate` (`license_plate`),
  ADD KEY `idx_status` (`status`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `username` (`username`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `assistants`
--
ALTER TABLE `assistants`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `customers`
--
ALTER TABLE `customers`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT for table `drivers`
--
ALTER TABLE `drivers`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `jobs`
--
ALTER TABLE `jobs`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT for table `job_products`
--
ALTER TABLE `job_products`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT for table `job_status_logs`
--
ALTER TABLE `job_status_logs`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `loads`
--
ALTER TABLE `loads`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `products`
--
ALTER TABLE `products`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `transport_units`
--
ALTER TABLE `transport_units`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `trucks`
--
ALTER TABLE `trucks`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `customers`
--
ALTER TABLE `customers`
  ADD CONSTRAINT `FK_customers_user_id` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `jobs`
--
ALTER TABLE `jobs`
  ADD CONSTRAINT `fk_jobs_customer_id` FOREIGN KEY (`customer_id`) REFERENCES `customers` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `jobs_ibfk_2` FOREIGN KEY (`transport_unit_id`) REFERENCES `transport_units` (`id`);

--
-- Constraints for table `job_products`
--
ALTER TABLE `job_products`
  ADD CONSTRAINT `job_products_ibfk_1` FOREIGN KEY (`job_id`) REFERENCES `jobs` (`id`),
  ADD CONSTRAINT `job_products_ibfk_2` FOREIGN KEY (`product_id`) REFERENCES `products` (`ID`);

--
-- Constraints for table `job_status_logs`
--
ALTER TABLE `job_status_logs`
  ADD CONSTRAINT `job_status_logs_ibfk_1` FOREIGN KEY (`job_id`) REFERENCES `jobs` (`id`),
  ADD CONSTRAINT `job_status_logs_ibfk_2` FOREIGN KEY (`updated_by`) REFERENCES `users` (`id`);

--
-- Constraints for table `loads`
--
ALTER TABLE `loads`
  ADD CONSTRAINT `loads_ibfk_1` FOREIGN KEY (`job_id`) REFERENCES `jobs` (`id`);

--
-- Constraints for table `transport_units`
--
ALTER TABLE `transport_units`
  ADD CONSTRAINT `transport_units_ibfk_1` FOREIGN KEY (`truck_id`) REFERENCES `trucks` (`id`),
  ADD CONSTRAINT `transport_units_ibfk_2` FOREIGN KEY (`driver_id`) REFERENCES `drivers` (`id`),
  ADD CONSTRAINT `transport_units_ibfk_3` FOREIGN KEY (`assistant_id`) REFERENCES `assistants` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
