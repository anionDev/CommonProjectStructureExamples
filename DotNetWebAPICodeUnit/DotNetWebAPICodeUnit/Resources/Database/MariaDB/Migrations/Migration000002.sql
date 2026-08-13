
-- The operations which the customer-controller offers are implemented as routines of the database instead of as
-- statements which are assembled in the sourcecode. The bodies are single statements on purpose: a body with
-- "begin"/"end" contains semicolons, and the migration is sent to the server as one command, so the server would
-- end the "create procedure" at the first of those semicolons.

CREATE PROCEDURE `CreateCustomer`(IN `p_Id` int, IN `p_Name` varchar(255), IN `p_ContactEmailAddress` varchar(255))
    INSERT INTO `Customers`(`Id`, `Name`, `ContactEmailAddress`) VALUES (`p_Id`, `p_Name`, `p_ContactEmailAddress`);

CREATE PROCEDURE `UpdateCustomer`(IN `p_Id` int, IN `p_Name` varchar(255), IN `p_ContactEmailAddress` varchar(255))
    UPDATE `Customers` SET `Name` = `p_Name`, `ContactEmailAddress` = `p_ContactEmailAddress` WHERE `Id` = `p_Id`;

CREATE PROCEDURE `RemoveCustomer`(IN `p_Id` int)
    DELETE FROM `Customers` WHERE `Id` = `p_Id`;

CREATE PROCEDURE `GetCustomer`(IN `p_Id` int)
    SELECT `Id`, `Name`, `ContactEmailAddress` FROM `Customers` WHERE `Id` = `p_Id`;

CREATE PROCEDURE `GetAllCustomers`()
    SELECT `Id`, `Name`, `ContactEmailAddress` FROM `Customers`;
