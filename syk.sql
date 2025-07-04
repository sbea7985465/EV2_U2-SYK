-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 04-07-2025 a las 03:42:07
-- Versión del servidor: 10.4.32-MariaDB
-- Versión de PHP: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `syk`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cliente`
--

CREATE TABLE `cliente` (
  `id` int(11) NOT NULL,
  `Nombre` varchar(45) DEFAULT NULL,
  `Apellido` varchar(45) DEFAULT NULL,
  `Correo` varchar(45) DEFAULT NULL,
  `Telefono` varchar(45) DEFAULT NULL,
  `Dirrecion` varchar(30) DEFAULT NULL,
  `Estado` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `descripcionservicio`
--

CREATE TABLE `descripcionservicio` (
  `id` int(11) NOT NULL,
  `Nombre` varchar(45) DEFAULT NULL,
  `Servicio_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `recepcionequipo`
--

CREATE TABLE `recepcionequipo` (
  `id` int(11) NOT NULL,
  `Fecha` datetime DEFAULT NULL,
  `TipoPc` int(11) DEFAULT NULL,
  `Accesorio` varchar(400) DEFAULT NULL,
  `MarcaPc` varchar(60) DEFAULT NULL,
  `ModeloPc` varchar(60) DEFAULT NULL,
  `NSerie` varchar(100) DEFAULT NULL,
  `CapacidadRam` int(11) DEFAULT NULL,
  `TipoAlmacenamiento` int(11) DEFAULT NULL,
  `CapacidadAlmacenamiento` varchar(60) DEFAULT NULL,
  `TipoGpu` int(11) DEFAULT NULL,
  `Grafico` varchar(60) DEFAULT NULL,
  `Cliente_id` int(11) NOT NULL,
  `Servicio_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `servicio`
--

CREATE TABLE `servicio` (
  `id` int(11) NOT NULL,
  `Nombre` varchar(60) DEFAULT NULL,
  `Precio` int(11) DEFAULT NULL,
  `Sku` varchar(50) DEFAULT NULL,
  `Estado` int(11) DEFAULT NULL,
  `Usuario_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuario`
--

CREATE TABLE `usuario` (
  `id` int(11) NOT NULL,
  `Nombre` varchar(45) DEFAULT NULL,
  `Apellido` varchar(45) DEFAULT NULL,
  `Correo` varchar(45) DEFAULT NULL,
  `Password` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `cliente`
--
ALTER TABLE `cliente`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `descripcionservicio`
--
ALTER TABLE `descripcionservicio`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_DescripcionServicio_Servicio1_idx` (`Servicio_id`);

--
-- Indices de la tabla `recepcionequipo`
--
ALTER TABLE `recepcionequipo`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_RecepcionEquipo_Cliente_idx` (`Cliente_id`),
  ADD KEY `fk_RecepcionEquipo_Servicio1_idx` (`Servicio_id`);

--
-- Indices de la tabla `servicio`
--
ALTER TABLE `servicio`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_Servicio_Usuario1_idx` (`Usuario_id`);

--
-- Indices de la tabla `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `cliente`
--
ALTER TABLE `cliente`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `descripcionservicio`
--
ALTER TABLE `descripcionservicio`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `recepcionequipo`
--
ALTER TABLE `recepcionequipo`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `servicio`
--
ALTER TABLE `servicio`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `usuario`
--
ALTER TABLE `usuario`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `descripcionservicio`
--
ALTER TABLE `descripcionservicio`
  ADD CONSTRAINT `fk_DescripcionServicio_Servicio1` FOREIGN KEY (`Servicio_id`) REFERENCES `servicio` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `recepcionequipo`
--
ALTER TABLE `recepcionequipo`
  ADD CONSTRAINT `fk_RecepcionEquipo_Cliente` FOREIGN KEY (`Cliente_id`) REFERENCES `cliente` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_RecepcionEquipo_Servicio1` FOREIGN KEY (`Servicio_id`) REFERENCES `servicio` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `servicio`
--
ALTER TABLE `servicio`
  ADD CONSTRAINT `fk_Servicio_Usuario1` FOREIGN KEY (`Usuario_id`) REFERENCES `usuario` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
