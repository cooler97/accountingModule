CREATE TABLE accounting (
	idaccounting INT PRIMARY KEY NOT NULL,
	idorder INT REFERENCES orders(idorder) NULL,
	idcustomer INT REFERENCES customer(idcustomer) NULL,
	dtdoc DATETIME NOT NULL,
	typedoc INT NOT NULL,
	namedoc varchar(256) NULL,
	quconstr int NULL,
	idsign INT REFERENCES sign(idsign) NULL,
	smdoc numeric(15,4) NULL,
	deleted DATETIME NULL,
	comment varchar(256) NULL	
)



INSERT INTO generator(idgen, name, num, updatelevel, replicatetype, isdiler, isremoteoffice, shift)
VALUES(327, 'gen_accounting', 1, 0, 0, 0, 0, 0);
