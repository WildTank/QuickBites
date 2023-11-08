/* JUST RUN ONCE, THIS SETUPS ALL THE NECESSARY TABLES AND THE ADMIN ACCOUNT*/
/* IF YOU WANT TO RUN THIS AGAIN, DROP ALL THE TABLES FIRST (DropInitialTables.sql) */

CREATE TABLE UserAccounts (
	id INT PRIMARY KEY IDENTITY,
	username NVARCHAR(255) UNIQUE,
	pass NVARCHAR(255)
);

CREATE TABLE UserDetails (
	id INT PRIMARY KEY IDENTITY,
	customername NVARCHAR(255),
	gender NVARCHAR(255),
	dateofbirth DATE,
	homeaddress NVARCHAR(255),
	contactnumber NVARCHAR(255),
	email NVARCHAR(255),
	FOREIGN KEY (id) REFERENCES UserAccounts(id)
);

CREATE TABLE Products (
	id NVARCHAR(3) PRIMARY KEY,
	category NVARCHAR(255),
	item NVARCHAR(255) UNIQUE,
	price FLOAT,
);

CREATE TABLE Orders (
	queue_number INT PRIMARY KEY IDENTITY,
	order_date DATE,
	customer_id INT,
	order_item NVARCHAR(255),
	order_quantity INT,
	quantified_price FLOAT,
	FOREIGN KEY (customer_id) REFERENCES UserAccounts(id),
	FOREIGN KEY (order_item) REFERENCES Products(item)
);

/* ADMIN ACCOUNT */
INSERT INTO UserAccounts (username, pass)
VALUES
	('admin', 'quickbites2023');

INSERT INTO UserDetails (customername, gender, dateofbirth,  homeaddress, contactnumber, email)
VALUES
	('Administrator', 'Male', '08-25-2004', 'In Your Walls', '09694206969', 'Macrohard@gmail.com');

/* FOOD PRODUCTS (AT LEAST 6 ITEMS IN EACH CATEGORY TO CORRESPOND WITH PRODUCTS PAGE)*/
INSERT INTO Products (id, category, item, price)
VALUES
	/* Half-ass menu to test the order feature */
	/* Please change menu for the better (Also change the products page images and text labels)*/
	/*A - Course Meals*/
	('A1', 'Course Meal', 'Adobo', '119.00'),
	('A2', 'Course Meal', 'Crispy Pata', '399.00'),
	('A3', 'Course Meal', 'Escabeche', '79.00'),
	('A4', 'Course Meal', 'Liempo', '299.00'),
	('A5', 'Course Meal', 'Sisig', '99.00'),
	('A6', 'Course Meal', 'Tapa', '119.00'),
	/*B - Drinks*/
	('B1', 'Drinks', 'Iced Tea', '29.00'),
	('B2', 'Drinks', 'Lemon Juice', '29.00'),
	('B3', 'Drinks', 'Coca Cola', '24.00'),
	('B4', 'Drinks', 'Sprite', '24.00'),
	('B5', 'Drinks', 'Iced Coffee', '34.00'),
	('B6', 'Drinks', 'Sparkling Water', '24.00'), /* LEL */
	/*C - Specialties*/
	('C1', 'Specialties', 'Batchoy', '79.00'),
	('C2', 'Specialties', 'Bicol Express', '49.00'),
	('C3', 'Specialties', 'Pochero', '79.00'),
	('C4', 'Specialties', 'Humba', '59.00'),
	('C5', 'Specialties', 'Bihon', '39.00'),
	('C6', 'Specialties', 'Lumpia', '29.00');
