
-- The operations which the customer-controller offers are implemented as routines of the database instead of as
-- statements which are assembled in the sourcecode. The bodies are dollar-quoted, which is what keeps the
-- semicolons inside them from ending the "create function" when the migration is sent to the server.

CREATE FUNCTION "CreateCustomer"(p_Id integer, p_Name varchar(255), p_ContactEmailAddress varchar(255)) RETURNS void AS $$
    INSERT INTO "Customers"("Id", "Name", "ContactEmailAddress") VALUES (p_Id, p_Name, p_ContactEmailAddress);
$$ LANGUAGE sql;

CREATE FUNCTION "UpdateCustomer"(p_Id integer, p_Name varchar(255), p_ContactEmailAddress varchar(255)) RETURNS void AS $$
    UPDATE "Customers" SET "Name" = p_Name, "ContactEmailAddress" = p_ContactEmailAddress WHERE "Id" = p_Id;
$$ LANGUAGE sql;

CREATE FUNCTION "RemoveCustomer"(p_Id integer) RETURNS void AS $$
    DELETE FROM "Customers" WHERE "Id" = p_Id;
$$ LANGUAGE sql;

CREATE FUNCTION "GetCustomer"(p_Id integer) RETURNS TABLE("Id" integer, "Name" varchar(255), "ContactEmailAddress" varchar(255)) AS $$
    SELECT "Customers"."Id", "Customers"."Name", "Customers"."ContactEmailAddress" FROM "Customers" WHERE "Customers"."Id" = p_Id;
$$ LANGUAGE sql;

CREATE FUNCTION "GetAllCustomers"() RETURNS TABLE("Id" integer, "Name" varchar(255), "ContactEmailAddress" varchar(255)) AS $$
    SELECT "Customers"."Id", "Customers"."Name", "Customers"."ContactEmailAddress" FROM "Customers";
$$ LANGUAGE sql;
