SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';


-- -----------------------------------------------------
-- Table `posdb`.`postcode`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `posdb`.`postcode` ;

CREATE  TABLE IF NOT EXISTS `posdb`.`postcode` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `code` VARCHAR(45) NULL ,
  PRIMARY KEY (`id`) ,
  UNIQUE INDEX `code_UNIQUE` (`code` ASC) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `posdb`.`address`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `posdb`.`address` ;

CREATE  TABLE IF NOT EXISTS `posdb`.`address` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `buildingname` VARCHAR(100) NULL ,
  `houseno` VARCHAR(10) NULL ,
  `street` VARCHAR(50) NULL ,
  `locality` VARCHAR(100) NULL ,
  `postaltown` VARCHAR(100) NULL ,
  `country` VARCHAR(100) NULL ,
  `postcode_id` INT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_address_postcode1_idx` (`postcode_id` ASC) ,
  CONSTRAINT `fk_address_postcode1`
    FOREIGN KEY (`postcode_id` )
    REFERENCES `posdb`.`postcode` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `posdb`.`companyinfo`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `posdb`.`companyinfo` ;

CREATE  TABLE IF NOT EXISTS `posdb`.`companyinfo` (
  `id` INT NOT NULL ,
  `name` VARCHAR(255) NULL ,
  `phone` VARCHAR(15) NULL ,
  `fax` VARCHAR(15) NULL ,
  `servicephone` VARCHAR(15) NULL ,
  `email` VARCHAR(50) NULL ,
  `website` VARCHAR(50) NULL ,
  `vatregistrationnumber` VARCHAR(20) NULL ,
  `address_id` INT NOT NULL ,
  PRIMARY KEY (`id`) ,
  UNIQUE INDEX `id_UNIQUE` (`id` ASC) ,
  INDEX `fk_companyinfo_address1_idx` (`address_id` ASC) ,
  CONSTRAINT `fk_companyinfo_address1`
    FOREIGN KEY (`address_id` )
    REFERENCES `posdb`.`address` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `posdb`.`productcategory`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `posdb`.`productcategory` ;

CREATE  TABLE IF NOT EXISTS `posdb`.`productcategory` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `categorytype` VARCHAR(50) NULL ,
  `description` VARCHAR(255) NULL ,
  PRIMARY KEY (`id`) ,
  UNIQUE INDEX `categorytype_UNIQUE` (`categorytype` ASC) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `posdb`.`menu`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `posdb`.`menu` ;

CREATE  TABLE IF NOT EXISTS `posdb`.`menu` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(100) NULL ,
  `description` VARCHAR(255) NULL ,
  `position` INT NULL ,
  `buttoncolor` VARCHAR(15) NULL ,
  `buttontextcolor` VARCHAR(15) NULL ,
  PRIMARY KEY (`id`) ,
  UNIQUE INDEX `name_UNIQUE` (`name` ASC) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `posdb`.`product`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `posdb`.`product` ;

CREATE  TABLE IF NOT EXISTS `posdb`.`product` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `code` VARCHAR(20) NOT NULL ,
  `name` VARCHAR(100) NULL ,
  `receiptdescription` VARCHAR(100) NULL ,
  `status` VARCHAR(45) NULL ,
  `prepproduct` VARCHAR(45) NULL ,
  `preplocation` VARCHAR(50) NULL ,
  `buyingprice` DECIMAL(15,2) NULL ,
  `dineinprice` DECIMAL(15,2) NULL ,
  `collectionprice` DECIMAL(15,2) NULL ,
  `waitingprice` DECIMAL(15,2) NULL ,
  `deliveryprice` DECIMAL(15,2) NULL ,
  `allprice` DECIMAL(15,2) NULL ,
  `stockproduct` VARCHAR(10) NULL ,
  `stockquantity` INT NULL ,
  `discountable` VARCHAR(10) NULL ,
  `popupmessage` VARCHAR(255) NULL ,
  `lookupcode` VARCHAR(15) NULL ,
  `receiptcopies` INT NULL ,
  `image` LONGBLOB NULL ,
  `productcategory_id` INT NOT NULL ,
  `menu_id` INT NOT NULL ,
  PRIMARY KEY (`id`) ,
  UNIQUE INDEX `productcode_UNIQUE` (`code` ASC) ,
  INDEX `fk_product_productcategory1_idx` (`productcategory_id` ASC) ,
  INDEX `fk_product_menu1_idx` (`menu_id` ASC) ,
  CONSTRAINT `fk_product_productcategory1`
    FOREIGN KEY (`productcategory_id` )
    REFERENCES `posdb`.`productcategory` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_product_menu1`
    FOREIGN KEY (`menu_id` )
    REFERENCES `posdb`.`menu` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `posdb`.`productingredients`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `posdb`.`productingredients` ;

CREATE  TABLE IF NOT EXISTS `posdb`.`productingredients` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `ingredient` VARCHAR(100) NULL ,
  `chargeable` TINYINT(1) NULL ,
  `amount` DECIMAL(15,2) NULL ,
  `product_id` INT NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_productingredients_product_idx` (`product_id` ASC) ,
  CONSTRAINT `fk_productingredients_product`
    FOREIGN KEY (`product_id` )
    REFERENCES `posdb`.`product` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `posdb`.`securitygroup`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `posdb`.`securitygroup` ;

CREATE  TABLE IF NOT EXISTS `posdb`.`securitygroup` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(100) NULL ,
  `description` VARCHAR(255) NULL ,
  PRIMARY KEY (`id`) ,
  UNIQUE INDEX `name_UNIQUE` (`name` ASC) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `posdb`.`department`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `posdb`.`department` ;

CREATE  TABLE IF NOT EXISTS `posdb`.`department` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(100) NULL ,
  `description` VARCHAR(255) NULL ,
  PRIMARY KEY (`id`) ,
  UNIQUE INDEX `name_UNIQUE` (`name` ASC) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `posdb`.`staff`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `posdb`.`staff` ;

CREATE  TABLE IF NOT EXISTS `posdb`.`staff` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `code` VARCHAR(20) NULL ,
  `lastname` VARCHAR(100) NULL ,
  `firstname` VARCHAR(100) NULL ,
  `dateofbirth` DATE NULL ,
  `designation` VARCHAR(50) NULL ,
  `phone` VARCHAR(20) NULL ,
  `mobile` VARCHAR(20) NULL ,
  `email` VARCHAR(100) NULL ,
  `hiredate` DATE NULL ,
  `status` VARCHAR(10) NULL ,
  `image` LONGBLOB NULL ,
  `department_id` INT NOT NULL ,
  `address_id` INT NOT NULL ,
  PRIMARY KEY (`id`) ,
  UNIQUE INDEX `code_UNIQUE` (`code` ASC) ,
  INDEX `fk_staff_depertment1_idx` (`department_id` ASC) ,
  INDEX `fk_staff_address1_idx` (`address_id` ASC) ,
  CONSTRAINT `fk_staff_depertment1`
    FOREIGN KEY (`department_id` )
    REFERENCES `posdb`.`department` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_staff_address1`
    FOREIGN KEY (`address_id` )
    REFERENCES `posdb`.`address` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `posdb`.`user`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `posdb`.`user` ;

CREATE  TABLE IF NOT EXISTS `posdb`.`user` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `userid` VARCHAR(50) NULL ,
  `password` VARCHAR(50) NULL ,
  `status` VARCHAR(15) NULL ,
  `securitygroup_id` INT NOT NULL ,
  `staff_id` INT NOT NULL ,
  PRIMARY KEY (`id`) ,
  UNIQUE INDEX `userid_UNIQUE` (`userid` ASC) ,
  INDEX `fk_user_securitygroup1_idx` (`securitygroup_id` ASC) ,
  INDEX `fk_user_staff1_idx` (`staff_id` ASC) ,
  CONSTRAINT `fk_user_securitygroup1`
    FOREIGN KEY (`securitygroup_id` )
    REFERENCES `posdb`.`securitygroup` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_user_staff1`
    FOREIGN KEY (`staff_id` )
    REFERENCES `posdb`.`staff` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `posdb`.`permissions`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `posdb`.`permissions` ;

CREATE  TABLE IF NOT EXISTS `posdb`.`permissions` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `code` VARCHAR(50) NULL ,
  `name` VARCHAR(50) NULL ,
  PRIMARY KEY (`id`) ,
  UNIQUE INDEX `code_UNIQUE` (`code` ASC) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `posdb`.`securitygrouppermission`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `posdb`.`securitygrouppermission` ;

CREATE  TABLE IF NOT EXISTS `posdb`.`securitygrouppermission` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `permissions_id` INT NOT NULL ,
  `securitygroup_id` INT NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_securitygrouppermission_permissions1_idx` (`permissions_id` ASC) ,
  INDEX `fk_securitygrouppermission_securitygroup1_idx` (`securitygroup_id` ASC) ,
  CONSTRAINT `fk_securitygrouppermission_permissions1`
    FOREIGN KEY (`permissions_id` )
    REFERENCES `posdb`.`permissions` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_securitygrouppermission_securitygroup1`
    FOREIGN KEY (`securitygroup_id` )
    REFERENCES `posdb`.`securitygroup` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `posdb`.`rawstockproduct`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `posdb`.`rawstockproduct` ;

CREATE  TABLE IF NOT EXISTS `posdb`.`rawstockproduct` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `code` VARCHAR(20) NULL ,
  `name` VARCHAR(100) NULL ,
  `buyingprice` DECIMAL(15,2) NULL ,
  `quantity` INT NULL ,
  PRIMARY KEY (`id`) ,
  UNIQUE INDEX `code_UNIQUE` (`code` ASC) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `posdb`.`customer`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `posdb`.`customer` ;

CREATE  TABLE IF NOT EXISTS `posdb`.`customer` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `code` VARCHAR(15) NULL ,
  `type` VARCHAR(10) NULL ,
  `lastname` VARCHAR(100) NULL ,
  `firstname` VARCHAR(100) NULL ,
  `phone` VARCHAR(20) NULL ,
  `mobile` VARCHAR(20) NULL ,
  `email` VARCHAR(100) NULL ,
  `status` VARCHAR(45) NULL ,
  `creditlimit` VARCHAR(45) NULL ,
  `image` LONGBLOB NULL ,
  `address_id` INT NOT NULL ,
  PRIMARY KEY (`id`) ,
  UNIQUE INDEX `code_UNIQUE` (`code` ASC) ,
  INDEX `fk_customer_address1_idx` (`address_id` ASC) ,
  CONSTRAINT `fk_customer_address1`
    FOREIGN KEY (`address_id` )
    REFERENCES `posdb`.`address` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `posdb`.`servicetype`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `posdb`.`servicetype` ;

CREATE  TABLE IF NOT EXISTS `posdb`.`servicetype` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `servicetype` VARCHAR(50) NULL ,
  `description` VARCHAR(255) NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `posdb`.`ordermaster`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `posdb`.`ordermaster` ;

CREATE  TABLE IF NOT EXISTS `posdb`.`ordermaster` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `ticketno` VARCHAR(50) NULL ,
  `orderdate` DATETIME NULL ,
  `customercode` VARCHAR(50) NULL ,
  `paymentstatus` VARCHAR(20) NULL ,
  `subtotal` DECIMAL(15,2) NULL ,
  `discountamount` DECIMAL(15,2) NULL ,
  `deliverycharge` DECIMAL(15,2) NULL ,
  `grandtotal` DECIMAL(15,2) NULL ,
  `server` VARCHAR(45) NULL ,
  `paidamount` DECIMAL(15,2) NULL ,
  `paytype` VARCHAR(20) NULL ,
  `printreceiptcopies` INT NULL ,
  `servicetype_id` INT NOT NULL ,
  PRIMARY KEY (`id`) ,
  UNIQUE INDEX `ticketno_UNIQUE` (`ticketno` ASC) ,
  INDEX `fk_ordermaster_servicetype1_idx` (`servicetype_id` ASC) ,
  CONSTRAINT `fk_ordermaster_servicetype1`
    FOREIGN KEY (`servicetype_id` )
    REFERENCES `posdb`.`servicetype` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `posdb`.`orderchild`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `posdb`.`orderchild` ;

CREATE  TABLE IF NOT EXISTS `posdb`.`orderchild` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `quantity` INT NULL ,
  `amount` DECIMAL(15,2) NULL ,
  `producttype` VARCHAR(20) NULL ,
  `ordermaster_id` INT NOT NULL ,
  `product_id` INT NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_orderchild_ordermaster1_idx` (`ordermaster_id` ASC) ,
  INDEX `fk_orderchild_product1_idx` (`product_id` ASC) ,
  CONSTRAINT `fk_orderchild_ordermaster1`
    FOREIGN KEY (`ordermaster_id` )
    REFERENCES `posdb`.`ordermaster` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_orderchild_product1`
    FOREIGN KEY (`product_id` )
    REFERENCES `posdb`.`product` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `posdb`.`rawstocklistmaster`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `posdb`.`rawstocklistmaster` ;

CREATE  TABLE IF NOT EXISTS `posdb`.`rawstocklistmaster` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `date` DATETIME NULL ,
  `total` DECIMAL(15,2) NULL ,
  `comment` VARCHAR(255) NULL ,
  `server` VARCHAR(50) NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `posdb`.`rawstocklistchild`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `posdb`.`rawstocklistchild` ;

CREATE  TABLE IF NOT EXISTS `posdb`.`rawstocklistchild` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `quantity` INT NULL ,
  `amount` DECIMAL(15,2) NULL ,
  `rawstocklistmaster_id` INT NOT NULL ,
  `rawstockproduct_id` INT NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_rawstocklistchild_rawstocklistmaster1_idx` (`rawstocklistmaster_id` ASC) ,
  INDEX `fk_rawstocklistchild_rawstockproduct1_idx` (`rawstockproduct_id` ASC) ,
  CONSTRAINT `fk_rawstocklistchild_rawstocklistmaster1`
    FOREIGN KEY (`rawstocklistmaster_id` )
    REFERENCES `posdb`.`rawstocklistmaster` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_rawstocklistchild_rawstockproduct1`
    FOREIGN KEY (`rawstockproduct_id` )
    REFERENCES `posdb`.`rawstockproduct` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `posdb`.`productbutton`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `posdb`.`productbutton` ;

CREATE  TABLE IF NOT EXISTS `posdb`.`productbutton` (
  `product_id` INT NOT NULL ,
  `color` VARCHAR(20) NULL ,
  `textcolor` VARCHAR(20) NULL ,
  `fontsize` INT NULL ,
  `textbold` TINYINT(1) NULL ,
  PRIMARY KEY (`product_id`) ,
  CONSTRAINT `fk_productbutton_product1`
    FOREIGN KEY (`product_id` )
    REFERENCES `posdb`.`product` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;



SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
