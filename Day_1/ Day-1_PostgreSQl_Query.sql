CREATE DATABASE "firstDemo"
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    LOCALE_PROVIDER = 'libc'
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;
	
-- Create table
CREATE TABLE student (
	s_id BIGINT PRIMARY KEY,
	s_name VARCHAR(100),
	semester INT
);

-- Read table
SELECT * FROM student;

-- add column into table
ALTER TABLE student ADD COLUMN branch VARCHAR(20);

-- delete column from table
ALTER TABLE student DROP COLUMN branch,
					DROP COLUMN semester;

-- Raname Column
ALTER TABLE student RENAME COLUMN s_name TO name;

--Rename Table
ALTER TABLE student RENAME TO gtu_student;

-- Read table
SELECT * FROM gtu_student;

-- add mutiple column
ALTER TABLE gtu_student 
	ADD COLUMN semester INT NOT NULL,
	ADD COLUMN branch VARCHAR(20) NOT NULL;

-- delete table with data
DROP TABLE gtu_student;

-- Create branch table
CREATE TABLE gtu_branch (
	b_id SERIAL PRIMARY KEY,
	b_name VARCHAR(20) UNIQUE NOT NULL
);

	-- insert value into branch table
	INSERT INTO gtu_branch(b_name) VALUES ('CSE'),('IT'),('ICT'),('ME');

	-- read data
	SELECT * FROM gtu_branch;


-- Create student table
CREATE TABLE student (
	s_id SERIAL PRIMARY KEY,
	s_name VARCHAR(100) NOT NULL,
	semester INT NOT NULL,
	branch VARCHAR(20) NOT NULL
);

-- Insert values into table
INSERT INTO student(s_name,semester,branch) VALUES ('Chintan',7,'IT');

-- read data
SELECT * FROM student;

INSERT INTO student(s_name,semester,branch) VALUES ('Kushal',7,'CSE'),
						   ('Nisarg',7,'IT'),
						   ('Dev',7,'IT'),
						   ('Raj',7,'ICT'),
						   ('Neel',7,'IT'),
						   ('Jimit',5,'IT'),
						   ('Tirth',5,'IT'),
						   ('Sager',3,'CIVIL');


-- order by 
SELECT s_name FROM student ORDER BY s_name ASC;
SELECT s_name,branch FROM student ORDER BY s_name ASC, branch DESC; -- data select with asc order of s_name and same s_name can be select with desc order of branch

-- WHERE Clause 
SELECT * FROM student WHERE semester=7;
SELECT * FROM student WHERE semester=7 AND branch='CSE';
SELECT * FROM student WHERE branch IN ('CSE','IT');
SELECT s_name FROM student WHERE s_name LIKE '%h%';
SELECT s_name FROM student WHERE s_name ILIKE '%i%';
SELECT s_name FROM student WHERE s_name ILIKE '_i%';

-- join
SELECT * FROM student AS s INNER JOIN gtu_branch AS b ON s.branch = b.b_name;
SELECT * FROM student AS s LEFT JOIN gtu_branch AS b ON s.branch = b.b_name;
SELECT * FROM student AS s RIGHT JOIN gtu_branch AS b ON s.branch = b.b_name;
SELECT * FROM student AS s FULL JOIN gtu_branch AS b ON s.branch = b.b_name;
SELECT * FROM student AS s LEFT JOIN gtu_branch AS b ON s.branch = b.b_name WHERE b.b_name IS NULL;

-- agregation with group by
SELECT COUNT(semester) FROM student;
SELECT semester,COUNT(semester) FROM student GROUP BY semester;

-- group by with having
SELECT semester,COUNT(semester) FROM student AS s GROUP BY semester HAVING COUNT(s.branch)>1;

-- Subqueries
SELECT * FROM student WHERE branch IN (SELECT b_name FROM gtu_branch);
SELECT * FROM student WHERE EXISTS (SELECT 1 FROM gtu_branch WHERE student.branch=gtu_branch.b_name);
SELECT * FROM student WHERE branch = ANY (SELECT b_name FROM gtu_branch);
SELECT * FROM student WHERE branch LIKE ANY (ARRAY['C%', '___']);

-- update row
UPDATE student SET s_name='Krishna' WHERE s_id=3;

-- delete row
DELETE FROM student WHERE s_id=5;



