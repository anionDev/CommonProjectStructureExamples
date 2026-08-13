
CREATE TABLE `Customers` (
    `Id` int not null,
    `Name` varchar(255) not null,
    `ContactEmailAddress` varchar(255) not null,
    CONSTRAINT `PK_Customers` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;
