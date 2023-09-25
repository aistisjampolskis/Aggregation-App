CREATE TABLE IF NOT EXISTS Apartments (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    TINKLAS VARCHAR(255) NOT NULL,
    OBT_PAVADINIMAS ENUM('Namas', 'Butas') NOT NULL,
    OBJ_GV_TIPAS ENUM('G', 'N', 'Ne GV') NOT NULL,
    OBJ_NUMERIS VARCHAR(255) NOT NULL,
    P_plus DECIMAL(10, 4),
    PL_T DATETIME NOT NULL,
    P_minus DECIMAL(10, 4)
);

-- Seed some initial data
INSERT INTO Apartments (TINKLAS, OBT_PAVADINIMAS, OBJ_GV_TIPAS, OBJ_NUMERIS, P_plus, PL_T, P_minus) VALUES
    ('Klaipėdos regiono tinklas', 'Butas', 'N', '4873840', 1.3193, '2022-05-31 00:00:00', 0.0),
    ('Klaipėdos regiono tinklas', 'Butas', 'N', '5824708', 0.0563, '2022-05-31 00:00:00', 0.0),
    ('Klaipėdos regiono tinklas', 'Butas', 'Ne GV', '27654782', NULL, '2022-05-31 00:00:00', NULL);
