/* JUST RUN ONCE, THIS SETUPS ALL THE NECESSARY TABLES AND THE ADMIN ACCOUNT*/

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

CREATE TABLE Orders (
	id INT PRIMARY KEY IDENTITY,
	customer_id INT,
	order_item NVARCHAR(255),
	total_price FLOAT,
	FOREIGN KEY (customer_id) REFERENCES UserAccounts(id)
);

/* ADMIN ACCOUNT */
INSERT INTO UserAccounts (username, pass)
VALUES
	('admin', 'quickbites2023');

INSERT INTO UserDetails (customername, gender, dateofbirth, contactnumber, homeaddress, email)
VALUES
	('Administrator', 'Male', '2004-08-25', 'In Your Walls', '09694206969', 'Macrohard@gmail.com');
