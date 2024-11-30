-- Crear la base de datos
CREATE DATABASE PlataformaEvaluacionCursosDev4
GO

-- Usar la base de datos creada
USE PlataformaEvaluacionCursosDev4
GO

-- Creación de tablas principales
CREATE TABLE Usuarios (
    UsuarioID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Contraseña NVARCHAR(256) NOT NULL,
    FechaRegistro DATETIME NOT NULL DEFAULT GETDATE()
); 

CREATE TABLE Roles (
    RolID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE UsuarioRoles (
    UsuarioRolID INT IDENTITY(1,1) PRIMARY KEY,
    UsuarioID INT NOT NULL FOREIGN KEY REFERENCES Usuarios(UsuarioID),
    RolID INT NOT NULL FOREIGN KEY REFERENCES Roles(RolID)
);

CREATE TABLE Cursos (
    CursoID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(MAX) NULL,
    FechaCreacion DATETIME NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Inscripciones (
    InscripcionID INT IDENTITY(1,1) PRIMARY KEY,
    UsuarioID INT NOT NULL FOREIGN KEY REFERENCES Usuarios(UsuarioID),
    CursoID INT NOT NULL FOREIGN KEY REFERENCES Cursos(CursoID),
    FechaInscripcion DATETIME NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Evaluaciones (
    EvaluacionID INT IDENTITY(1,1) PRIMARY KEY,
    CursoID INT NOT NULL FOREIGN KEY REFERENCES Cursos(CursoID),
    Titulo NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(MAX) NULL,
    FechaInicio DATETIME NOT NULL,
    FechaFin DATETIME NOT NULL
);

CREATE TABLE Preguntas (
    PreguntaID INT IDENTITY(1,1) PRIMARY KEY,
    EvaluacionID INT NOT NULL FOREIGN KEY REFERENCES Evaluaciones(EvaluacionID),
    Texto NVARCHAR(MAX) NOT NULL,
    Tipo NVARCHAR(50) NOT NULL
);

CREATE TABLE Respuestas (
    RespuestaID INT IDENTITY(1,1) PRIMARY KEY,
    PreguntaID INT NOT NULL FOREIGN KEY REFERENCES Preguntas(PreguntaID),
    Texto NVARCHAR(MAX) NOT NULL,
    EsCorrecta BIT NOT NULL
);

CREATE TABLE Intentos (
    IntentoID INT IDENTITY(1,1) PRIMARY KEY,
    UsuarioID INT NOT NULL FOREIGN KEY REFERENCES Usuarios(UsuarioID),
    EvaluacionID INT NOT NULL FOREIGN KEY REFERENCES Evaluaciones(EvaluacionID),
    FechaInicio DATETIME NOT NULL,
    FechaFin DATETIME NULL,
    Calificacion FLOAT NULL
);

CREATE TABLE RespuestasUsuario (
    RespuestaUsuarioID INT IDENTITY(1,1) PRIMARY KEY,
    IntentoID INT NOT NULL FOREIGN KEY REFERENCES Intentos(IntentoID),
    PreguntaID INT NOT NULL FOREIGN KEY REFERENCES Preguntas(PreguntaID),
    RespuestaID INT NULL FOREIGN KEY REFERENCES Respuestas(RespuestaID),
    RespuestaAbierta NVARCHAR(MAX) NULL
);

--SEMBRADO DE DATOS

-- Usar la base de datos
USE PlataformaEvaluacionCursosDev4
GO
 
select * from USu arios
-- Insertar datos en la tabla Usuarios
INSERT INTO Usuarios (Nombre, Email, Contraseña)
VALUES 
('Juan Pérez', 'juan.perez@example.com', 'hashed_password1'),
('María Gómez', 'maria.gomez@example.com', 'hashed_password2'),
('Carlos López', 'carlos.lopez@example.com', 'hashed_password3');

-- Insertar datos en la tabla Roles
INSERT INTO Roles (Nombre)
VALUES 
('Administrador'),
('Estudiante'),
('Profesor');


-- Insertar datos en la tabla UsuarioRoles
INSERT INTO UsuarioRoles (UsuarioID, RolID)
VALUES 
(1, 1), -- Juan Pérez como Administrador
(2, 2), -- María Gómez como Estudiante
(3, 3); -- Carlos López como Profesor

-- Insertar datos en la tabla Cursos
INSERT INTO Cursos (Nombre, Descripcion)
VALUES 
('Curso de SQL Server', 'Aprende los fundamentos de SQL Server.'),
('Curso de Programación C#', 'Domina la programación en C#.'),
('Curso de Desarrollo Web', 'Crea aplicaciones web modernas.');

select * from Inscripciones i join Cursos c
on i.CursoID = c.CursoID
-- Insertar datos en la tabla Inscripciones
INSERT INTO Inscripciones (UsuarioID, CursoID)
VALUES 
(2, 1), -- María Gómez inscrita en Curso de SQL Server
(2, 2), -- María Gómez inscrita en Curso de Programación C#
(3, 1); -- Carlos López inscrito en Curso de SQL Server

-- Insertar datos en la tabla Evaluaciones
INSERT INTO Evaluaciones (CursoID, Titulo, Descripcion, FechaInicio, FechaFin)
VALUES 
(1, 'Evaluación SQL Básico', 'Evaluación de fundamentos básicos de SQL.', '2024-11-25', '2024-11-30'),
(2, 'Evaluación C# Intermedio', 'Prueba de conceptos intermedios en C#.', '2024-12-01', '2024-12-10');

-- Insertar datos en la tabla Preguntas
INSERT INTO Preguntas (EvaluacionID, Texto, Tipo)
VALUES 
(1, '¿Qué es una clave primaria?', 'Opción Múltiple'),
(1, 'Escribe una consulta para seleccionar todos los registros de una tabla.', 'Abierta'),
(2, '¿Qué es una clase en C#?', 'Opción Múltiple'),
(2, 'Escribe un ejemplo de herencia en C#.', 'Abierta');

-- Insertar datos en la tabla Respuestas
INSERT INTO Respuestas (PreguntaID, Texto, EsCorrecta)
VALUES 
(1, 'Es un identificador único de un registro.', 1),
(1, 'Es un campo opcional.', 0),
(3, 'Es una plantilla para crear objetos.', 1),
(3, 'Es una función en C#.', 0);

-- Insertar datos en la tabla Intentos
INSERT INTO Intentos (UsuarioID, EvaluacionID, FechaInicio, FechaFin, Calificacion)
VALUES 
(2, 1, '2024-11-26 10:00:00', '2024-11-26 11:00:00', 8.5),
(2, 2, '2024-12-02 14:00:00', NULL, NULL); -- Intento en curso
select * from Intentos;
INSERT INTO Intentos (UsuarioID, EvaluacionID, FechaInicio)
VALUES 
(2, 2, '2024-12-02 14:00:00'); -- Intento en curso
-- Insertar datos en la tabla RespuestasUsuario
INSERT INTO RespuestasUsuario (IntentoID, PreguntaID, RespuestaID, RespuestaAbierta)
VALUES 
(1, 1, 1, NULL), -- María respondió correctamente la pregunta de opción múltiple
(1, 2, NULL, 'SELECT * FROM tabla;'), -- Respuesta abierta proporcionada
(2, 3, 1, NULL); -- Respuesta parcial del intento en curso

select i.FechaInicio,i.FechaFin,i.Calificacion,e.Titulo from Intentos i 
join Evaluaciones e on i.EvaluacionID = e.EvaluacionID
where i.UsuarioID = 2