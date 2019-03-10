DROP TABLE project_employee;
DROP TABLE employee;
DROP TABLE department;
DROP TABLE project;


BEGIN TRANSACTION;

CREATE TABLE employee (
	employee_id integer identity NOT NULL,
	department_id integer NOT NULL,
	first_name varchar(20) NOT NULL,
	last_name varchar(30) NOT NULL,
	job_title varchar(50) NOT NULL,
	birth_date date NOT NULL,
	gender char(1) NOT NULL,
	hire_date date NOT NULL,
	CONSTRAINT pk_employee_employee_id PRIMARY KEY (employee_id),
	CONSTRAINT ck_gender CHECK (gender IN ('M', 'F')),
);

CREATE TABLE department (
	department_id integer identity  NOT NULL,
	name varchar(40) UNIQUE NOT NULL,
	CONSTRAINT pk_department_department_id PRIMARY KEY (department_id)
);

CREATE TABLE project (
	project_id integer identity  NOT NULL,
	name varchar(40) UNIQUE NOT NULL,
	from_date date not null,
	CONSTRAINT pk_project_project_id PRIMARY KEY (project_id)
);

CREATE TABLE project_employee (	
	project_id integer NOT NULL,
	employee_id integer NOT NULL,
	CONSTRAINT pk_project_employee PRIMARY KEY (project_id, employee_id)
);

ALTER TABLE employee ADD CONSTRAINT fk_employee_department FOREIGN KEY (department_id) REFERENCES department(department_id);

ALTER TABLE project_employee ADD FOREIGN KEY (project_id) REFERENCES project(project_id);
ALTER TABLE project_employee ADD FOREIGN KEY (employee_id) REFERENCES employee(employee_id);


INSERT INTO department (name) VALUES ('Defenders');
INSERT INTO department (name) VALUES ('Avengers');
INSERT INTO department (name) VALUES ('XMEN');
INSERT INTO department (name) VALUES ('Nova Corps');

INSERT INTO project (name, from_date) VALUES ('Weapon X', '1961-03-01');
INSERT INTO project (name, from_date) VALUES ('Annihilation', '2010-01-01');
INSERT INTO project (name, from_date) VALUES ('Seize the Day', '2015-06-30');
INSERT INTO project (name, from_date) VALUES ('Civil War', '2015-10-15');

INSERT INTO employee (department_id, first_name, last_name, birth_date, gender, hire_date, job_title)
VALUES (4, 'Richard', 'Rider', '1953-07-15', 'M', '2001-04-01', 'Nova Prime');
INSERT INTO employee (department_id, first_name, last_name, birth_date, gender, hire_date, job_title)
VALUES (4, 'Sam', 'Alexander', '1990-12-28', 'M', '2011-08-01', 'Nova');
INSERT INTO employee (department_id, first_name, last_name, birth_date, gender, hire_date, job_title)
VALUES (2, 'Peter', 'Parker', '1980-07-14', 'M', '1998-09-01', 'Spirderman');
INSERT INTO employee (department_id, first_name, last_name, birth_date, gender, hire_date, job_title)
VALUES (2, 'Mark', 'Spectre', '1976-07-04', 'M', '2009-03-01', 'Moon Knight');
INSERT INTO employee (department_id, first_name, last_name, birth_date, gender, hire_date, job_title)
VALUES (1, 'Matt', 'Murdock', '1972-06-04', 'M', '1998-09-01', 'Daredevil');
INSERT INTO employee (department_id, first_name, last_name, birth_date, gender, hire_date, job_title)
VALUES (2, 'Tony', 'Stark', '1983-04-08', 'M', '2012-04-01', 'Iron Man');
INSERT INTO employee (department_id, first_name, last_name, birth_date, gender, hire_date, job_title)
VALUES (2, 'Steve', 'Rogers', '1987-11-11', 'M', '2013-02-16', 'Captain America');
INSERT INTO employee (department_id, first_name, last_name, birth_date, gender, hire_date, job_title)
VALUES (1, 'Danny', 'Rand', '1983-04-04', 'M', '2013-07-01', 'Iron Fist');
INSERT INTO employee (department_id, first_name, last_name, birth_date, gender, hire_date, job_title)
VALUES (2, 'Steven', 'Strange', '1987-05-13', 'M', '2007-11-01', 'Doctor Strange');
INSERT INTO employee (department_id, first_name, last_name, birth_date, gender, hire_date, job_title)
VALUES (1, 'Luke', 'Cage', '1968-04-05', 'M', '2016-02-16', 'Power Man');
INSERT INTO employee (department_id, first_name, last_name, birth_date, gender, hire_date, job_title)
VALUES (1, 'Jessica', 'Jones', '1981-09-25', 'F', '2003-05-01', 'Jewel');
INSERT INTO employee (department_id, first_name, last_name, birth_date, gender, hire_date, job_title)
VALUES (3, 'Scott', 'Summers', '1980-03-17', 'M', '1999-08-01', 'Cyclops');

INSERT INTO project_employee (project_id, employee_id) VALUES (2, 1);
INSERT INTO project_employee (project_id, employee_id) VALUES (4, 3);
INSERT INTO project_employee (project_id, employee_id) VALUES (3, 2);
INSERT INTO project_employee (project_id, employee_id) VALUES (1, 12);
INSERT INTO project_employee (project_id, employee_id) VALUES (4, 7);
INSERT INTO project_employee (project_id, employee_id) VALUES (3, 4);
INSERT INTO project_employee (project_id, employee_id) VALUES (4, 6);
INSERT INTO project_employee (project_id, employee_id) VALUES (3, 8);
INSERT INTO project_employee (project_id, employee_id) VALUES (4, 9);
INSERT INTO project_employee (project_id, employee_id) VALUES (3, 5);
INSERT INTO project_employee (project_id, employee_id) VALUES (3, 10);
INSERT INTO project_employee (project_id, employee_id) VALUES (3, 11);

COMMIT TRANSACTION;