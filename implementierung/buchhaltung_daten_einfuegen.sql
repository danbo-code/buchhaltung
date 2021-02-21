USE buchhaltung;
GO



INSERT INTO Steuersaetze(Bezeichnung, Steuersatz) VALUES 
  ('Einkauf Food', 0.07),
  ('Einkauf NonFood', 0.19),
  ('Verkauf InHouse', 0.19),
  ('Einkauf ToGo', 0.07)
;

INSERT INTO Einkauf (Betrag_Netto, Datum, ID_Steuersatz) VALUES

(200, '20200717', 1),
(420, '20200717', 2),
(1337, '20200720', 2),
(100, '20200801', 1),
(500, '20200811', 1),
(40.99, '20201004', 1),
(127.45, '20201031', 1),
(345.67, '20201230', 2),
(200, '20210122', 1),
(100, '20210131', 2),
(217.99, GETDATE(), 1),
(19.99, GETDATE(), 1)
;

INSERT INTO Verkauf (Betrag_Netto, Datum, ID_Steuersatz) VALUES

(20.99, '20200722', 3),
(42.75, '20200723', 4),
(13.37, '20200830', 3),
(10, '20200901', 3),
(50.97, '20200911', 3),
(40.99, '20201004', 4),
(12.25, '20201031', 3),
(33.26, '20201230', 3),
(20, '20210122', 3),
(10.97, '20210131', 3),
(21.99, GETDATE(), 3),
(19.99, GETDATE(), 4)
;


INSERT INTO Personal (Nachname, Stundenlohn) VALUES
 ('Mueller', 12.00),
 ('Schmidt', 13.00),
 ('Kroener', 15.00),
 ('Gehring', 22.00),
 ('Bossman', 24.50)
 ;

 INSERT INTO Arbeitszeiten(ID_Personal, Arbeitsstunden,Datum) VALUES
 (1, 8.00, GETDATE()),
 (2, 8.00, GETDATE()),
 (3, 10.00, GETDATE()),
 (4, 10.00, GETDATE()),
 (5, 9.50, GETDATE()),
 (1, 8.00, GETDATE()),
 (2, 8.00, GETDATE()),
 (3, 8.00, GETDATE()),
 (2, 8.00, GETDATE()),
 (4, 10.00, GETDATE()),
 (1, 8.00, GETDATE()),
 (1, 8.00, GETDATE()),
 (3, 8.00, GETDATE()),
 (1, 8.00, GETDATE()),
 (4, 10.00, GETDATE()),
 (2, 8.00, GETDATE()),
 (5, 9.50, GETDATE()),
 (2, 8.00, GETDATE()),
 (3, 8.00, GETDATE()),
 (1, 8.00, GETDATE()),
 (4, 10.00, GETDATE()),
 (1, 8.00, GETDATE()),
 (1, 8.00, GETDATE()),
 (3, 8.00, GETDATE()),
 (2, 8.00, GETDATE()),
 (1, 8.00, GETDATE()),
 (1, 8.00, GETDATE()),
 (5, 9.50, GETDATE()),
 (3, 8.00, GETDATE()),
 (2, 8.00, GETDATE()),
 (3, 8.00, GETDATE())

 ;

 INSERT INTO Fixkosten (Bezeichnung, Betrag, Datum) VALUES
  ('Miete', 3000, '20210201'),
  ('Werbekosten', 1200, GETDATE())