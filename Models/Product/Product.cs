using System.ComponentModel.DataAnnotations;
namespace IMS.Models;

public class Product
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    [Range(0, double.MaxValue)]
    public decimal Price { get; set; }

    [Required]
    public int CategoryId { get; set; }
    [Required]
    public int SupplierId { get; set; }


    [Range(0, int.MaxValue)]
    public int Quantity { get; set; }
}

/*
SQL table creation:

CREATE TABLE Product (
    Id INT PRIMARY KEY AUTO_INCREMENT, //id primary key r eita auto increment hbe
    Name VARCHAR(150) NOT NULL, //eta kokhnoi null hote parbe na
    Price DECIMAL(10, 2) NOT NULL CHECK (Price >= 0), //condition price 0 er theke choto hote parbe na
    Quantity INT NOT NULL CHECK (Quantity >= 0),
    CategoryId INT NOT NULL,
    SupplierId INT NOT NULL,
    Description TEXT,

    CONSTRAINT fk_product_category   //This is simply the name of the foreign key constraint:CONSTRAINT → keyword used to define a rule/constraint, fk_product_category  → custom name of the foreign key
        FOREIGN KEY (CategoryId)  //CategoryId ta foreign key
        REFERENCES Category(Id)  //category table er id ta holo CategoryId ta ja eikhne foreign key
        ON DELETE RESTRICT  // Do NOT allow delete from parent table if child data exists.
        ON UPDATE CASCADE, //category table e update hole eikhneo hbe

    CONSTRAINT fk_product_supplier 
        FOREIGN KEY (SupplierId) 
        REFERENCES Supplier(Id) 
        ON DELETE RESTRICT 
        ON UPDATE CASCADE
);

CREATE table Category(
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(100) NOT NULL UNIQUE
)

CREATE TABLE Supplier (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(100) NOT NULL UNIQUE,
    Country VARCHAR(100),
    ContactInfo VARCHAR(200)
);

//insert data into category table
INSERT INTO Category (Name)
VALUES ('Electronics');


//insert data into suplier table
INSERT INTO Supplier (Name, Country, ContactInfo)
VALUES ('Supplier 1', 'USA', 'Test contact 1, USA');



*/