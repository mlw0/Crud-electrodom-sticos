-- Base de datos: ElectrodomesticosDB
-- Servidor: localhost | Usuario: sa | Contraseña: 12345678

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'ElectrodomesticosDB')
    CREATE DATABASE ElectrodomesticosDB;
GO

USE ElectrodomesticosDB;
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Productos' AND xtype = 'U')
    CREATE TABLE Productos (
        Id           INT            PRIMARY KEY IDENTITY(1,1),
        Codigo       NVARCHAR(20)   NOT NULL UNIQUE,
        Nombre       NVARCHAR(150)  NOT NULL,
        Categoria    NVARCHAR(100)  NOT NULL,
        Marca        NVARCHAR(100)  NOT NULL,
        Precio       DECIMAL(10,2)  NOT NULL CHECK (Precio >= 0),
        Stock        INT            NOT NULL DEFAULT 0 CHECK (Stock >= 0),
        Descripcion  NVARCHAR(300)  NULL,
        FechaIngreso DATE           NOT NULL DEFAULT GETDATE()
    );
GO

-- Datos de ejemplo (solo si la tabla está vacía)
IF (SELECT COUNT(*) FROM Productos) = 0
BEGIN
    INSERT INTO Productos (Codigo, Nombre, Categoria, Marca, Precio, Stock, Descripcion, FechaIngreso)
    VALUES
        ('REF-001', 'Refrigeradora No Frost 400L',      'Refrigeradoras',             'Samsung',   850.00,  5,  'Refrigeradora de 2 puertas con dispensador de agua',  '2025-01-10'),
        ('REF-002', 'Refrigeradora Side by Side 600L',  'Refrigeradoras',             'LG',       1350.00,  2,  'Refrigeradora Side by Side con pantalla táctil',      '2025-01-15'),
        ('LAV-001', 'Lavadora Automática 18 kg',        'Lavadoras',                  'LG',        620.00,  8,  'Lavadora con función vapor y control Wi-Fi',           '2025-01-20'),
        ('LAV-002', 'Lavadora de Carga Frontal 12 kg',  'Lavadoras',                  'Samsung',   780.00,  4,  'Lavadora con tecnología EcoBubble',                   '2025-02-01'),
        ('TV-001',  'Smart TV 55" 4K OLED',             'Televisores',                'LG',       1200.00,  3,  'Pantalla OLED con resolución 4K y 120 Hz',            '2025-02-10'),
        ('TV-002',  'Smart TV 65" QLED 8K',             'Televisores',                'Samsung',  2100.00,  1,  'Televisor QLED con resolución 8K y Neo Quantum',      '2025-02-15'),
        ('MIC-001', 'Microondas 30L Digital',           'Microondas',                 'Mabe',      180.00, 12,  'Microondas con función grill y convección',            '2025-02-20'),
        ('COC-001', 'Cocina de Inducción 4 hornillas',  'Cocinas',                    'Indurama',  450.00,  6,  'Cocina vitrocerámica con 4 zonas de cocción',         '2025-03-01'),
        ('COC-002', 'Cocina a Gas 6 hornillas',         'Cocinas',                    'Mabe',      320.00,  9,  'Cocina empotrable de acero inoxidable',                '2025-03-05'),
        ('ACO-001', 'Aire Acondicionado 12000 BTU',     'Aires Acondicionados',        'Whirlpool', 550.00,  7,  'Split inverter frío/calor con filtro HEPA',           '2025-03-10'),
        ('LAV-003', 'Lavavajillas 14 puestos',          'Lavavajillas',               'Bosch',     900.00,  3,  'Lavavajillas silencioso con 8 programas de lavado',   '2025-03-15'),
        ('LIC-001', 'Licuadora Industrial 2L',          'Pequeños Electrodomésticos', 'Oster',      95.00, 20,  'Licuadora de alta potencia con vaso de vidrio',        '2025-03-20');
END
GO

SELECT COUNT(*) AS TotalProductos FROM Productos;
GO
