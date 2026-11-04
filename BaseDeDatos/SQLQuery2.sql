SELECT name
FROM sys.databases
WHERE name = 'BD_Proyecto';

SELECT name
FROM master.sys.tables
WHERE name IN ('Equipos', 'Jugadores', 'Usuarios');
