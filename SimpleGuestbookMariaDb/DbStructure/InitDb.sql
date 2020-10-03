CREATE OR REPLACE TABLE posts (
	id int not null AUTO_INCREMENT,
	username varchar(1000),
	posttext text,
	createdon DATETIME,
	primary key (id)
);