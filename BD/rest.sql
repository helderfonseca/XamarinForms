-- phpMyAdmin SQL Dump
-- version 4.8.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: 08-Jun-2018 às 15:46
-- Versão do servidor: 10.1.32-MariaDB
-- PHP Version: 7.2.5

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `rest`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `pessoa`
--

CREATE TABLE `pessoa` (
  `id` int(11) NOT NULL,
  `nome` varchar(80) NOT NULL,
  `morada` varchar(80) DEFAULT NULL,
  `email` varchar(100) NOT NULL,
  `sexo` varchar(20) NOT NULL,
  `dt_nasc` varchar(20) NOT NULL,
  `username` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `pessoa`
--

INSERT INTO `pessoa` (`id`, `nome`, `morada`, `email`, `sexo`, `dt_nasc`, `username`) VALUES
(1, 'Helder Augusto Barbosa Mendes Fonseca', 'Fazenda', 'helder@gmail.com', 'masculino', '21-10-1994', 'hfonseca'),
(2, 'Odair Antunes Barbosa Mendes Fonseca', 'Fazenda', 'odair@gmail.ccom', 'masculino', '15-06-1992', 'ofonseca');

-- --------------------------------------------------------

--
-- Estrutura da tabela `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `nome` varchar(25) CHARACTER SET utf8 NOT NULL,
  `username` varchar(50) CHARACTER SET utf8 NOT NULL,
  `password` varchar(150) CHARACTER SET utf8 NOT NULL,
  `telefone` varchar(25) CHARACTER SET utf8 DEFAULT NULL,
  `estado` tinyint(1) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `users`
--

INSERT INTO `users` (`id`, `nome`, `username`, `password`, `telefone`, `estado`) VALUES
(1, 'Helder Fonseca', 'hfonseca', '$2y$10$0nyLeUrGBqdMcGAZrLrAB.0tKEMYy0ZWgRd3pL1sWhkcn0nxKdRG2', '9523212', 0),
(2, 'Odair Fonseca', 'ofonseca', '$2y$10$0nyLeUrGBqdMcGAZrLrAB.0tKEMYy0ZWgRd3pL1sWhkcn0nxKdRG2', '9415235', 0),
(3, 'Valdir Fonseca', 'vfonseca', '$2y$10$0nyLeUrGBqdMcGAZrLrAB.0tKEMYy0ZWgRd3pL1sWhkcn0nxKdRG2', '9241325', 0);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `pessoa`
--
ALTER TABLE `pessoa`
  ADD PRIMARY KEY (`id`),
  ADD KEY `username` (`username`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD KEY `username` (`username`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `pessoa`
--
ALTER TABLE `pessoa`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Constraints for dumped tables
--

--
-- Limitadores para a tabela `pessoa`
--
ALTER TABLE `pessoa`
  ADD CONSTRAINT `pessoa_ibfk_1` FOREIGN KEY (`username`) REFERENCES `users` (`username`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
