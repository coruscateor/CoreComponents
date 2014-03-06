﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SQL.pgsql
{

    /*
    http://www.postgresql.org/docs/8.4/static/sql-update.html

    ABORT -- abort the current transaction
    ALTER AGGREGATE -- change the definition of an aggregate function
    ALTER CONVERSION -- change the definition of a conversion
    ALTER DATABASE -- change a database
    ALTER DOMAIN --  change the definition of a domain
    ALTER FOREIGN DATA WRAPPER -- change the definition of a foreign-data wrapper
    ALTER FUNCTION -- change the definition of a function
    ALTER GROUP -- change role name or membership
    ALTER INDEX -- change the definition of an index
    ALTER LANGUAGE -- change the definition of a procedural language
    ALTER OPERATOR -- change the definition of an operator
    ALTER OPERATOR CLASS -- change the definition of an operator class
    ALTER OPERATOR FAMILY -- change the definition of an operator family
    ALTER ROLE -- change a database role
    ALTER SCHEMA -- change the definition of a schema
    ALTER SEQUENCE --  change the definition of a sequence generator
    ALTER SERVER -- change the definition of a foreign server
    ALTER TABLE -- change the definition of a table
    ALTER TABLESPACE -- change the definition of a tablespace
    ALTER TEXT SEARCH CONFIGURATION -- change the definition of a text search configuration
    ALTER TEXT SEARCH DICTIONARY -- change the definition of a text search dictionary
    ALTER TEXT SEARCH PARSER -- change the definition of a text search parser
    ALTER TEXT SEARCH TEMPLATE -- change the definition of a text search template
    ALTER TRIGGER -- change the definition of a trigger
    ALTER TYPE --  change the definition of a type
    ALTER USER -- change a database role
    ALTER USER MAPPING -- change the definition of a user mapping
    ALTER VIEW -- change the definition of a view
    ANALYZE -- collect statistics about a database
    BEGIN -- start a transaction block
    CHECKPOINT -- force a transaction log checkpoint
    CLOSE -- close a cursor
    CLUSTER -- cluster a table according to an index
    COMMENT -- define or change the comment of an object
    COMMIT -- commit the current transaction
    COMMIT PREPARED -- commit a transaction that was earlier prepared for two-phase commit
    COPY -- copy data between a file and a table
    CREATE AGGREGATE -- define a new aggregate function
    CREATE CAST -- define a new cast
    CREATE CONSTRAINT TRIGGER -- define a new constraint trigger
    CREATE CONVERSION -- define a new encoding conversion
    CREATE DATABASE -- create a new database
    CREATE DOMAIN -- define a new domain
    CREATE FOREIGN DATA WRAPPER -- define a new foreign-data wrapper
    CREATE FUNCTION -- define a new function
    CREATE GROUP -- define a new database role
    CREATE INDEX -- define a new index
    CREATE LANGUAGE -- define a new procedural language
    CREATE OPERATOR -- define a new operator
    CREATE OPERATOR CLASS -- define a new operator class
    CREATE OPERATOR FAMILY -- define a new operator family
    CREATE ROLE -- define a new database role
    CREATE RULE -- define a new rewrite rule
    CREATE SCHEMA -- define a new schema
    CREATE SEQUENCE -- define a new sequence generator
    CREATE SERVER -- define a new foreign server
    CREATE TABLE -- define a new table
    CREATE TABLE AS -- define a new table from the results of a query
    CREATE TABLESPACE -- define a new tablespace
    CREATE TEXT SEARCH CONFIGURATION -- define a new text search configuration
    CREATE TEXT SEARCH DICTIONARY -- define a new text search dictionary
    CREATE TEXT SEARCH PARSER -- define a new text search parser
    CREATE TEXT SEARCH TEMPLATE -- define a new text search template
    CREATE TRIGGER -- define a new trigger
    CREATE TYPE -- define a new data type
    CREATE USER -- define a new database role
    CREATE USER MAPPING -- define a new mapping of a user to a foreign server
    CREATE VIEW -- define a new view
    DEALLOCATE -- deallocate a prepared statement
    DECLARE -- define a cursor
    DELETE -- delete rows of a table
    DISCARD -- discard session state
    DROP AGGREGATE -- remove an aggregate function
    DROP CAST -- remove a cast
    DROP CONVERSION -- remove a conversion
    DROP DATABASE -- remove a database
    DROP DOMAIN -- remove a domain
    DROP FOREIGN DATA WRAPPER -- remove a foreign-data wrapper
    DROP FUNCTION -- remove a function
    DROP GROUP -- remove a database role
    DROP INDEX -- remove an index
    DROP LANGUAGE -- remove a procedural language
    DROP OPERATOR -- remove an operator
    DROP OPERATOR CLASS -- remove an operator class
    DROP OPERATOR FAMILY -- remove an operator family
    DROP OWNED -- remove database objects owned by a database role
    DROP ROLE -- remove a database role
    DROP RULE -- remove a rewrite rule
    DROP SCHEMA -- remove a schema
    DROP SEQUENCE -- remove a sequence
    DROP SERVER -- remove a foreign server descriptor
    DROP TABLE -- remove a table
    DROP TABLESPACE -- remove a tablespace
    DROP TEXT SEARCH CONFIGURATION -- remove a text search configuration
    DROP TEXT SEARCH DICTIONARY -- remove a text search dictionary
    DROP TEXT SEARCH PARSER -- remove a text search parser
    DROP TEXT SEARCH TEMPLATE -- remove a text search template
    DROP TRIGGER -- remove a trigger
    DROP TYPE -- remove a data type
    DROP USER -- remove a database role
    DROP USER MAPPING -- remove a user mapping for a foreign server
    DROP VIEW -- remove a view
    END -- commit the current transaction
    EXECUTE -- execute a prepared statement
    EXPLAIN -- show the execution plan of a statement
    FETCH -- retrieve rows from a query using a cursor
    GRANT -- define access privileges
    INSERT -- create new rows in a table
    LISTEN -- listen for a notification
    LOAD -- load a shared library file
    LOCK -- lock a table
    MOVE -- position a cursor
    NOTIFY -- generate a notification
    PREPARE -- prepare a statement for execution
    PREPARE TRANSACTION -- prepare the current transaction for two-phase commit
    REASSIGN OWNED -- change the ownership of database objects owned by a database role
    REINDEX -- rebuild indexes
    RELEASE SAVEPOINT -- destroy a previously defined savepoint
    RESET -- restore the value of a run-time parameter to the default value
    REVOKE -- remove access privileges
    ROLLBACK -- abort the current transaction
    ROLLBACK PREPARED -- cancel a transaction that was earlier prepared for two-phase commit
    ROLLBACK TO SAVEPOINT -- roll back to a savepoint
    SAVEPOINT -- define a new savepoint within the current transaction
    SELECT -- retrieve rows from a table or view
    SELECT INTO -- define a new table from the results of a query
    SET -- change a run-time parameter
    SET CONSTRAINTS -- set constraint checking modes for the current transaction
    SET ROLE -- set the current user identifier of the current session
    SET SESSION AUTHORIZATION -- set the session user identifier and the current user identifier of the current session
    SET TRANSACTION -- set the characteristics of the current transaction
    SHOW -- show the value of a run-time parameter
    START TRANSACTION -- start a transaction block
    TRUNCATE -- empty a table or set of tables
    UNLISTEN -- stop listening for a notification
    UPDATE -- update rows of a table
    VACUUM -- garbage-collect and optionally analyze a database
    VALUES -- compute a set of rows
    */

    //Repepresents an standard SQL command.

    public class pgsqlKeywordConstants
    {
    }
}
