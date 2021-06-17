CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS posts(
  id INT NOT NULL AUTO_INCREMENT  PRIMARY KEY COMMENT 'Primary Key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  body VARCHAR (255),
  imgUrl VARCHAR (255) NOT NULL COMMENT 'Post Image',
  likes INT COMMENT 'post likes',
  creatorId VARCHAR(255) COMMENT 'FK: User Account',

  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';


CREATE TABLE IF NOT EXISTS likes(
  id INT AUTO_INCREMENT PRIMARY KEY COMMENT 'Primary Key',
  creatorId VARCHAR(255) NOT NULL COMMENT 'FK: User Account',
  postId INT NOT NULL COMMENT 'FK: Post ID',

  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE,
  FOREIGN KEY (postId) REFERENCES posts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS comments(
  id INT AUTO_INCREMENT PRIMARY KEY COMMENT 'Primary Key',
  postId INT NOT NULL COMMENT 'FK: Post ID',
  body VARCHAR (255) NOT NULL COMMENT 'Comment Body',
  creatorId VARCHAR(255) NOT NULL COMMENT 'FK: User Account',

  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE,
  FOREIGN KEY (postId) REFERENCES posts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';