CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;
CREATE TABLE "IssuePriorities" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Name" text NOT NULL,
    "DateCreated" timestamp with time zone,
    "DateModified" timestamp with time zone,
    CONSTRAINT "PK_IssuePriorities" PRIMARY KEY ("Id")
);

CREATE TABLE "IssueStatuses" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Name" text NOT NULL,
    "DateCreated" timestamp with time zone,
    "DateModified" timestamp with time zone,
    CONSTRAINT "PK_IssueStatuses" PRIMARY KEY ("Id")
);

CREATE TABLE "IssueTypes" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Name" text NOT NULL,
    "DateCreated" timestamp with time zone,
    "DateModified" timestamp with time zone,
    CONSTRAINT "PK_IssueTypes" PRIMARY KEY ("Id")
);

CREATE TABLE "Issues" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "IssueTypeId" integer NOT NULL,
    "IssueStatusId" integer NOT NULL,
    "IssuePriorityId" integer NOT NULL,
    "Summary" text NOT NULL,
    "Description" text NOT NULL,
    "ReporterId" text NOT NULL,
    "AssigneeId" text,
    "DateCreated" timestamp with time zone,
    "DateModified" timestamp with time zone,
    CONSTRAINT "PK_Issues" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Issues_IssuePriorities_IssuePriorityId" FOREIGN KEY ("IssuePriorityId") REFERENCES "IssuePriorities" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Issues_IssueStatuses_IssueStatusId" FOREIGN KEY ("IssueStatusId") REFERENCES "IssueStatuses" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Issues_IssueTypes_IssueTypeId" FOREIGN KEY ("IssueTypeId") REFERENCES "IssueTypes" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_Issues_IssuePriorityId" ON "Issues" ("IssuePriorityId");

CREATE INDEX "IX_Issues_IssueStatusId" ON "Issues" ("IssueStatusId");

CREATE INDEX "IX_Issues_IssueTypeId" ON "Issues" ("IssueTypeId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20241202103104_NewInit', '9.0.0');

ALTER TABLE "IssueTypes" ALTER COLUMN "Name" TYPE character varying(20);

ALTER TABLE "IssueStatuses" ALTER COLUMN "Name" TYPE character varying(20);

ALTER TABLE "IssuePriorities" ALTER COLUMN "Name" TYPE character varying(20);

INSERT INTO "IssuePriorities" ("Id", "DateCreated", "DateModified", "Name")
VALUES (1, NULL, NULL, 'Low');
INSERT INTO "IssuePriorities" ("Id", "DateCreated", "DateModified", "Name")
VALUES (2, NULL, NULL, 'Medium');
INSERT INTO "IssuePriorities" ("Id", "DateCreated", "DateModified", "Name")
VALUES (3, NULL, NULL, 'High');
INSERT INTO "IssuePriorities" ("Id", "DateCreated", "DateModified", "Name")
VALUES (4, NULL, NULL, 'Critical');

INSERT INTO "IssueStatuses" ("Id", "DateCreated", "DateModified", "Name")
VALUES (1, NULL, NULL, 'New');
INSERT INTO "IssueStatuses" ("Id", "DateCreated", "DateModified", "Name")
VALUES (2, NULL, NULL, 'Assigned');
INSERT INTO "IssueStatuses" ("Id", "DateCreated", "DateModified", "Name")
VALUES (3, NULL, NULL, 'In progress');
INSERT INTO "IssueStatuses" ("Id", "DateCreated", "DateModified", "Name")
VALUES (4, NULL, NULL, 'Resolved');
INSERT INTO "IssueStatuses" ("Id", "DateCreated", "DateModified", "Name")
VALUES (5, NULL, NULL, 'Closed');

INSERT INTO "IssueTypes" ("Id", "DateCreated", "DateModified", "Name")
VALUES (1, NULL, NULL, 'Bug');
INSERT INTO "IssueTypes" ("Id", "DateCreated", "DateModified", "Name")
VALUES (2, NULL, NULL, 'Defect');
INSERT INTO "IssueTypes" ("Id", "DateCreated", "DateModified", "Name")
VALUES (3, NULL, NULL, 'New feature');
INSERT INTO "IssueTypes" ("Id", "DateCreated", "DateModified", "Name")
VALUES (4, NULL, NULL, 'Task');
INSERT INTO "IssueTypes" ("Id", "DateCreated", "DateModified", "Name")
VALUES (5, NULL, NULL, 'Improvement');

SELECT setval(
    pg_get_serial_sequence('"IssuePriorities"', 'Id'),
    GREATEST(
        (SELECT MAX("Id") FROM "IssuePriorities") + 1,
        nextval(pg_get_serial_sequence('"IssuePriorities"', 'Id'))),
    false);
SELECT setval(
    pg_get_serial_sequence('"IssueStatuses"', 'Id'),
    GREATEST(
        (SELECT MAX("Id") FROM "IssueStatuses") + 1,
        nextval(pg_get_serial_sequence('"IssueStatuses"', 'Id'))),
    false);
SELECT setval(
    pg_get_serial_sequence('"IssueTypes"', 'Id'),
    GREATEST(
        (SELECT MAX("Id") FROM "IssueTypes") + 1,
        nextval(pg_get_serial_sequence('"IssueTypes"', 'Id'))),
    false);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20241202125350_DataSeed', '9.0.0');

COMMIT;