using System;
using System.Data.SQLite;
using Microsoft.AspNetCore.Mvc;

namespace TestWork.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CreateSqlController : Controller
    {
        static string connectionString = "Data Source=:memory:";
        public SQLiteConnection connection = new SQLiteConnection(connectionString);

        public void CreateSql(SQLiteCommand command) // Создание таблиц Sql
        {
            command.CommandText = "DROP TABLE IF EXISTS Prog_TestPeople";
            command.ExecuteNonQuery();
            command.CommandText = @"CREATE TABLE Prog_TestPeople(PPL_CODE INTEGER
                        PRIMARY KEY, PPL_NAME VARCHAR(2000), PPL_PPL_CODE INTEGER)";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO Prog_TestPeople(PPL_NAME, PPL_PPL_CODE) VALUES('Alex', 78)";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO Prog_TestPeople(PPL_NAME, PPL_PPL_CODE) VALUES('Tolia', 23)";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO Prog_TestPeople(PPL_NAME, PPL_PPL_CODE) VALUES('Tolia', 12)";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO Prog_TestPeople(PPL_NAME, PPL_PPL_CODE) VALUES('Sveta', 32)";
            command.ExecuteNonQuery();

            command.CommandText = "DROP TABLE IF EXISTS Prog_TestDocs";
            command.ExecuteNonQuery();
            command.CommandText = @"CREATE TABLE Prog_TestDocs(DOC_PPL_CODE INTEGER, DOC_NUM VARCHAR(30), DOC_SERIES VARCHAR(30), DOC_TYPE VARCHAR(30), DOC_DATE VARCHAR(300), FOREIGN KEY (DOC_PPL_CODE)  REFERENCES Prog_TestPeople (PPL_CODE))";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO Prog_TestDocs(DOC_NUM, DOC_SERIES, DOC_TYPE, DOC_DATE, DOC_PPL_CODE) VALUES('777666', '100','Паспорт', '2021', 1)";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO Prog_TestDocs(DOC_NUM, DOC_SERIES, DOC_TYPE, DOC_DATE, DOC_PPL_CODE) VALUES('345679', '200','Водительское', '2021', 1)";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO Prog_TestDocs(DOC_NUM, DOC_SERIES, DOC_TYPE, DOC_DATE, DOC_PPL_CODE) VALUES('567650', '300','Паспорт', '2021', 2)";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO Prog_TestDocs(DOC_NUM, DOC_SERIES, DOC_TYPE, DOC_DATE, DOC_PPL_CODE) VALUES('998756', '400','Военник', '2021', 3)";
            command.ExecuteNonQuery();

            command.CommandText = "DROP TABLE IF EXISTS Prog_TestAddres";
            command.ExecuteNonQuery();
            command.CommandText = @"CREATE TABLE Prog_TestAddres(ADDR_PPL_CODE INTEGER
                        PRIMARY KEY, ADDR_CITY VARCHAR(200), ADDR_STREET VARCHAR(200), ADDR_HOUSE VARCHAR(200), ADDR_FLAT VARCHAR(20), FOREIGN KEY (ADDR_PPL_CODE)  REFERENCES Prog_TestPeople (PPL_CODE))";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO Prog_TestAddres(ADDR_CITY, ADDR_STREET, ADDR_HOUSE, ADDR_FLAT) VALUES('Сургут', 'Пушкина','10', '35')";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO Prog_TestAddres(ADDR_CITY, ADDR_STREET, ADDR_HOUSE, ADDR_FLAT) VALUES('Москва', 'Лермонтова','35', '101')";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO Prog_TestAddres(ADDR_CITY, ADDR_STREET, ADDR_HOUSE, ADDR_FLAT) VALUES('Екатеринбург', 'Островского','14', '55')";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO Prog_TestAddres(ADDR_CITY, ADDR_STREET, ADDR_HOUSE, ADDR_FLAT) VALUES('Омск', 'Карская','4', '178')";
            command.ExecuteNonQuery();
            command.CommandText = "DROP TABLE IF EXISTS Prog_TestAccnt";
            command.ExecuteNonQuery();
            command.CommandText = @"CREATE TABLE Prog_TestAccnt(ACCNT_CODE INTEGER
                        PRIMARY KEY, ACCNT_ACNT VARCHAR(30), ACCNT_PPL_CODE INTEGER, ACCNT_CRNC VARCHAR(3), ACCNT_NAME VARCHAR(2000), FOREIGN KEY (ACCNT_PPL_CODE)  REFERENCES Prog_TestPeople (PPL_CODE))";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO Prog_TestAccnt(ACCNT_ACNT, ACCNT_PPL_CODE, ACCNT_CRNC, ACCNT_NAME) VALUES('1', 2,'Rub','acc1')";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO Prog_TestAccnt(ACCNT_ACNT, ACCNT_PPL_CODE, ACCNT_CRNC, ACCNT_NAME) VALUES('2', 1,'Evr','acc2')";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO Prog_TestAccnt(ACCNT_ACNT, ACCNT_PPL_CODE, ACCNT_CRNC, ACCNT_NAME) VALUES('3', 3,'Doll','acc3')";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO Prog_TestAccnt(ACCNT_ACNT, ACCNT_PPL_CODE, ACCNT_CRNC, ACCNT_NAME) VALUES('4', 4,'Rub','acc4')";
            command.ExecuteNonQuery();

            command.CommandText = "DROP TABLE IF EXISTS Prog_TestBlnc";
            command.ExecuteNonQuery();
            command.CommandText = @"CREATE TABLE Prog_TestBlnc(BLNC_ACCNT_CODE INTEGER
                        PRIMARY KEY, BLNC_OSTATOK INTEGER, FOREIGN KEY (BLNC_ACCNT_CODE)  REFERENCES Prog_TestAccnt (ACCNT_CODE))";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO Prog_TestBlnc(BLNC_OSTATOK) VALUES(1000)";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO Prog_TestBlnc(BLNC_OSTATOK) VALUES(2000)";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO Prog_TestBlnc(BLNC_OSTATOK) VALUES(3000)";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO Prog_TestBlnc(BLNC_OSTATOK) VALUES(4000)";
            command.ExecuteNonQuery();
        }

        [HttpGet("Return_Prog_TestAddres")]// Возвращает таблицу Prog_TestAddres
        public IActionResult ReturnSqlLiteProg_TestAddres()
        {
            using (connection)
            {
                connection.Open();
                using (var command = new SQLiteCommand(connection))
                {
                    CreateSql(command);
                    string readQuery = "SELECT * FROM Prog_TestAddres ";
                    var returnArray = new ProgTestAddress[4];
                    command.CommandText = readQuery;
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        var counter = 0;
                        while (reader.Read())
                        {
                            returnArray[counter] = new ProgTestAddress
                            {
                                ADDR_PPL_CODE = reader.GetInt32(0),
                                ADDR_CITY = (reader.GetValue(1)).ToString(),
                                ADDR_STREET = reader.GetValue(2).ToString(),
                                ADDR_HOUSE = reader.GetValue(3).ToString(),
                                ADDR_FLAT = reader.GetValue(4).ToString()
                            };
                            counter++;
                        }
                    }
                    return Ok(returnArray);
                }
            }
        }

        [HttpGet("Return_Prog_TestAccnt")]// Возвращает таблицу Prog_TestAccnt
        public IActionResult ReturnSqlLiteProg_TestAccnt()
        {
            using (connection)
            {
                connection.Open();
                using (var command = new SQLiteCommand(connection))
                {
                    CreateSql(command);
                    string readQuery = "SELECT * FROM Prog_TestAccnt ";
                    var returnArray = new Prog_TestAccnt[4];
                    command.CommandText = readQuery;
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        var counter = 0;
                        while (reader.Read())
                        {
                            returnArray[counter] = new Prog_TestAccnt
                            {
                                ACCNT_ACNT = reader.GetValue(0).ToString(),
                                ACCNT_CRNC = reader.GetValue(1).ToString(),
                                ACCNT_NAME = reader.GetValue(2).ToString()
                            };
                            counter++;
                        }
                    }
                    return Ok(returnArray);
                }
            }
        }

        [HttpGet("Return_Prog_TestBlnc")]// Возвращает таблицу Prog_TestBlnc
        public IActionResult ReturnSqlLiteProg_TestBlnc()
        {
            using (connection)
            {
                connection.Open();
                using (var command = new SQLiteCommand(connection))
                {
                    CreateSql(command);
                    string readQuery = "SELECT * FROM Prog_TestBlnc ";
                    var returnArray = new Prog_TestBlnc[4];
                    command.CommandText = readQuery;
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        var counter = 0;
                        while (reader.Read())
                        {
                            returnArray[counter] = new Prog_TestBlnc
                            {
                                BLNC_ACCNT_CODE = reader.GetInt32(0),
                                BLNC_OSTATOK = reader.GetInt32(1)
                            };
                            counter++;
                        }
                    }
                    return Ok(returnArray);
                }
            }
        }

        [HttpGet("Return_Prog_TestPeople")]// Возвращает таблицу Prog_TestPeople
        public IActionResult ReturnSqlLiteProg_TestPeople()
        {
            using (connection)
            {
                connection.Open();
                using (var command = new SQLiteCommand(connection))
                {
                    CreateSql(command);
                    string readQuery = "SELECT * FROM Prog_TestPeople ";
                    var returnArray = new Prog_TestPeople[4];
                    command.CommandText = readQuery;
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        var counter = 0;
                        while (reader.Read())
                        {
                            // создаем объект и записываем его в массив
                            returnArray[counter] = new Prog_TestPeople
                            {
                                PPL_CODE = reader.GetInt32(0),
                                PPL_NAME = (reader.GetValue(1)).ToString(),
                                PPL_PPL_CODE = reader.GetInt32(2)
                            };
                            counter++;
                        }
                    }
                    return Ok(returnArray);
                }
            }
        }

        [HttpGet("Return_Prog_TestDocs")]// Возвращает таблицу Prog_TestDocs
        public IActionResult ReturnSqlLiteProg_TestDocs()
        {
            using (connection)
            {
                connection.Open();
                using (var command = new SQLiteCommand(connection))
                {
                    CreateSql(command);
                    string readQuery = "SELECT * FROM Prog_TestDocs ";
                    var returnArray = new ProgTestDocs[4];
                    command.CommandText = readQuery;
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        var counter = 0;
                        while (reader.Read())
                        {
                            returnArray[counter] = new ProgTestDocs
                            {
                                DOC_PPL_CODE = reader.GetInt32(0),
                                DOC_NUM = (reader.GetValue(1)).ToString(),
                                DOC_SERIES = reader.GetValue(2).ToString(),
                                DOC_TYPE = reader.GetValue(3).ToString(),
                                //DOC_DATE = reader.GetDateTime(4)
                            };
                            counter++;
                        }
                    }
                    return Ok(returnArray);
                }
            }
        }


        [HttpGet("Return_Task1")]// Задание № 1 - Сколько денег у каждого клиента. Отсортировать по иментам клиента по алфавиту.
        public IActionResult ReturnSqlLiteTask1()
        {
            using (connection)
            {
                connection.Open();
                using (var command = new SQLiteCommand(connection))
                {
                    CreateSql(command);
                    string readQuery = "SELECT Prog_TestPeople.PPL_NAME AS name, Prog_TestPeople.PPL_PPL_CODE AS code, Prog_TestBlnc.BLNC_OSTATOK AS ostatok, Prog_TestBlnc.BLNC_ACCNT_CODE AS accnt_code FROM Prog_TestPeople INNER JOIN Prog_TestBlnc, Prog_TestAccnt ON Prog_TestPeople.PPL_CODE = Prog_TestAccnt.ACCNT_PPL_CODE AND Prog_TestAccnt.ACCNT_CODE  =  Prog_TestBlnc.BLNC_ACCNT_CODE ORDER BY Prog_TestPeople.PPL_NAME, Prog_TestPeople.PPL_PPL_CODE";
                    var returnArray = new Task1[4];
                    command.CommandText = readQuery;
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        var counter = 0;
                        while (reader.Read())
                        {
                            returnArray[counter] = new Task1
                            {
                                PPL_NAME = reader.GetValue(0).ToString(),
                                PPL_PPL_CODE = reader.GetInt32(1),
                                BLNC_OSTATOK = reader.GetInt32(2),
                                BLNC_ACCNT_CODE = reader.GetInt32(3)

                            };
                            counter++;
                        }
                    }
                    return Ok(returnArray);
                }
            }
        }

        [HttpGet("Return_Task2")]//Задание №2 - Список клиентов без паспорта.
        public IActionResult ReturnSqlLiteTask2()
        {
            using (connection)
            {
                connection.Open();
                using (var command = new SQLiteCommand(connection))
                {
                    CreateSql(command);
                    string readQuery = "SELECT Prog_TestPeople.PPL_NAME AS name, Prog_TestPeople.PPL_PPL_CODE AS code FROM Prog_TestPeople LEFT JOIN Prog_TestDocs ON Prog_TestPeople.PPL_CODE = Prog_TestDocs.DOC_PPL_CODE AND Prog_TestDocs.DOC_TYPE  =  'Паспорт' WHERE Prog_TestDocs.DOC_PPL_CODE IS NULL ORDER BY Prog_TestPeople.PPL_NAME, Prog_TestPeople.PPL_PPL_CODE ";
                    var returnArray = new Task2[4];
                    command.CommandText = readQuery;
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        var counter = 0;
                        while (reader.Read())
                        {
                            returnArray[counter] = new Task2
                            {
                                PPL_NAME = reader.GetValue(0).ToString(),
                                PPL_PPL_CODE = reader.GetInt32(1)
                            };
                            counter++;
                        }
                    }
                    return Ok(returnArray);
                }
            }
        }

        [HttpGet("Return_Task3")]//Задание №3 - Сколько денег у поручителя человека с паспортом номер 567650
        public IActionResult ReturnSqlLiteTask3()
        {
            using (connection)
            {
                connection.Open();
                using (var command = new SQLiteCommand(connection))
                {
                    CreateSql(command);
                    string readQuery = "SELECT Prog_TestPeople.PPL_NAME AS name, Prog_TestPeople.PPL_PPL_CODE AS code, Prog_TestBlnc.BLNC_OSTATOK AS ostatok, Prog_TestBlnc.BLNC_ACCNT_CODE AS accnt_code FROM Prog_TestPeople INNER JOIN Prog_TestDocs, Prog_TestBlnc, Prog_TestAccnt ON Prog_TestPeople.PPL_CODE = Prog_TestDocs.DOC_PPL_CODE AND Prog_TestDocs.DOC_TYPE  =  'Паспорт' AND Prog_TestDocs.DOC_NUM  =  '567650' AND Prog_TestPeople.PPL_CODE = Prog_TestAccnt.ACCNT_PPL_CODE AND Prog_TestAccnt.ACCNT_CODE  =  Prog_TestBlnc.BLNC_ACCNT_CODE ORDER BY Prog_TestPeople.PPL_NAME, Prog_TestPeople.PPL_PPL_CODE";
                    var returnArray = new Task1[4];
                    command.CommandText = readQuery;
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        var counter = 0;
                        while (reader.Read())
                        {
                            returnArray[counter] = new Task1
                            {
                                PPL_NAME = reader.GetValue(0).ToString(),
                                PPL_PPL_CODE = reader.GetInt32(1),
                                BLNC_OSTATOK = reader.GetInt32(2),
                                BLNC_ACCNT_CODE = reader.GetInt32(3)
                            };
                            counter++;
                        }
                    }
                    return Ok(returnArray);
                }
            }
        }

        [HttpGet("Return_Task4")]//Задание №4 - Где живет самый богатый человек
        public IActionResult ReturnSqlLiteTask4()
        {
            using (connection)
            {
                connection.Open();
                using (var command = new SQLiteCommand(connection))
                {
                    CreateSql(command);
                    string readQuery = "SELECT Prog_TestPeople.PPL_NAME AS name, Prog_TestPeople.PPL_PPL_CODE AS code, max(Prog_TestBlnc.BLNC_OSTATOK) AS ostatok, Prog_TestAddres.ADDR_CITY, Prog_TestAddres.ADDR_STREET, Prog_TestAddres.ADDR_HOUSE, Prog_TestAddres.ADDR_FLAT, Prog_TestBlnc.BLNC_ACCNT_CODE AS accnt_code FROM Prog_TestPeople INNER JOIN Prog_TestBlnc, Prog_TestAccnt, Prog_TestAddres ON Prog_TestPeople.PPL_CODE = Prog_TestAccnt.ACCNT_PPL_CODE AND Prog_TestAccnt.ACCNT_CODE  =  Prog_TestBlnc.BLNC_ACCNT_CODE AND Prog_TestPeople.PPL_CODE = Prog_TestAddres.ADDR_PPL_CODE ORDER BY Prog_TestPeople.PPL_NAME, Prog_TestPeople.PPL_PPL_CODE";
                    var returnArray = new Task3[4];
                    command.CommandText = readQuery;
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        var counter = 0;
                        while (reader.Read())
                        {
                            returnArray[counter] = new Task3
                            {
                                PPL_NAME = reader.GetValue(0).ToString(),
                                PPL_PPL_CODE = reader.GetInt32(1),
                                BLNC_OSTATOK = reader.GetInt32(2),
                                ADDR_CITY = reader.GetValue(3).ToString(),
                                ADDR_STREET = reader.GetValue(4).ToString(),
                                ADDR_HOUSE = reader.GetValue(5).ToString(),
                                ADDR_FLAT = reader.GetValue(6).ToString(),
                                BLNC_ACCNT_CODE = reader.GetInt32(7)
                            };
                            counter++;
                        }
                    }
                    return Ok(returnArray);
                }
            }
        }
    }
}


