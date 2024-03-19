using System.Collections.Generic;
using System.Reflection.Metadata;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using MySqlConnector;

namespace ToskanApp.Models;

public class DBCore
{
     public static MySqlConnectionStringBuilder ConnectionString =
        new MySqlConnectionStringBuilder
        {
            Server = "localhost",
            Database = "toskanakurs",
            UserID = "root",
            Password = "root"
        };

     public static List<AccountingForExpense> GetAccountExpense()
     {
         List<AccountingForExpense> data = new List<AccountingForExpense>();
         using (var connection = new MySqlConnection(ConnectionString.ConnectionString))
         {
             connection.Open();
             using (var comand = connection.CreateCommand())
             {
                 comand.CommandText = "SELECT accounting_for_expense.Id, " +
                                      "accounting_for_expense.accouting_for_receipts_id, " +
                                      "accounting_for_expense.type_id, " +
                                      "accounting_for_expense.count, " +
                                      "accounting_for_expense.date, " +
                                      "accounting_for_expense.employee_id, " +
                                      "type_expense.name AS type_expense_name, " +
                                      "employee.lastname AS employee_name " +
                                      "FROM accounting_for_expense " +
                                      "JOIN type_expense ON accounting_for_expense.type_id = type_expense.Id " +
                                      "JOIN employee ON accounting_for_expense.employee_id = employee.Id";

                 using (var reader = comand.ExecuteReader())
                 {
                     while (reader.Read())
                     {   
                         data.Add(
                             new AccountingForExpense(
                                 reader.GetInt32("Id"),
                                 reader.GetInt32("accouting_for_receipts_id"),
                                 reader.GetDateTime("date"),
                                 reader.GetInt32("type_id"),
                                 reader.GetFloat("count"),
                                 reader.GetInt32("employee_id"),
                                 reader.GetString("type_expense_name"),
                                 reader.GetString("employee_name")
                             ));
                     }
                 }
             }

             connection.Close();
         }

         return data;
     }
     
     public static List<AccountingForReceipts> GetAccountReceipts()
     {
         List<AccountingForReceipts> data = new List<AccountingForReceipts>();
         using (var connection = new MySqlConnection(ConnectionString.ConnectionString))
         {
             connection.Open();
             using (var comand = connection.CreateCommand())
             {
                 comand.CommandText = "SELECT accounting_for_receipts.Id, " +
                                      "accounting_for_receipts.product_id, " +
                                      "accounting_for_receipts.date_expiration, " +
                                      "accounting_for_receipts.date_manufacture, " +
                                      "accounting_for_receipts.count, " +
                                      "accounting_for_receipts.employee_id, " +
                                      "product.name AS product_name, " +
                                      "employee.lastname AS employee_name " +
                                      "FROM accounting_for_receipts " +
                                      "JOIN product ON accounting_for_receipts.product_id = product.Id " +
                                      "JOIN employee ON accounting_for_receipts.employee_id = employee.Id";
                 using (var reader = comand.ExecuteReader())
                 {
                     while (reader.Read())
                     {
                         data.Add(
                             new AccountingForReceipts(
                                 reader.GetInt32("Id"),
                                 reader.GetInt32("product_id"),
                                 reader.GetDateTime("date_expiration"),
                                 reader.GetDateTime("date_manufacture"),
                                 reader.GetFloat("count"),
                                 reader.GetString("employee_name"),
                                 reader.GetString("product_name"),
                                 reader.GetInt32("employee_id")
                             ));
                     }
                 }
             }

             connection.Close();
         }

         return data;
     }
    public static List<Employee> GetEmployee()
    {
        List<Employee> data = new List<Employee>();
        using (var connection = new MySqlConnection(ConnectionString.ConnectionString))
        {
            connection.Open();
            using (var comand = connection.CreateCommand())
            {
                comand.CommandText = "SELECT Employee.Id, Employee.firstname, Employee.lastname, " +
                                     "Employee.patronymic, Employee.login, Employee.role_id, " +
                                     "Employee.position_id, Employee.password, role.name AS role_name, " +
                                     "position.name AS position_name " +
                                     "FROM Employee " +
                                     "JOIN role ON Employee.role_id = role.Id " +
                                     "JOIN position ON Employee.position_id = position.Id";
                using (var reader = comand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        data.Add(
                            new Employee(
                                reader.GetInt32("Id"),
                                reader.GetString("firstname"),
                                reader.GetString("lastname"),
                                reader.GetString("patronymic"),
                                reader.GetString("login"),
                                reader.GetString("password"),
                                reader.GetInt32("role_id"),
                                reader.GetInt32("position_id"),
                                reader.GetString("role_name"),
                                reader.GetString("position_name")
                            ));
                    }
                }
            }

            connection.Close();
        }

        return data;
    }
    public static List<Position> GetPosition()
    {
        List<Position> data = new List<Position>();
        using (var connection = new MySqlConnection(ConnectionString.ConnectionString))
        {
            connection.Open();
            using (var comand = connection.CreateCommand())
            {
                comand.CommandText = "SELECT * FROM Position";
                using (var reader = comand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        data.Add(
                            new Position(
                                reader.GetInt32("Id"),
                                reader.GetString("name")
                            )
                        );
                    }
                }
            }

            connection.Close();
        }

        return data;
    }
    public static List<Product> GetProduct()
    {
        List<Product> data = new List<Product>();
        using (var connection = new MySqlConnection(ConnectionString.ConnectionString))
        {
            connection.Open();
            using (var comand = connection.CreateCommand())
            {
                comand.CommandText = "SELECT product.*, unit.name AS unit_name " +
                                 "FROM product " +
                                 "JOIN unit ON product.unit_id = unit.id";

                using (var reader = comand.ExecuteReader())
                {
                while (reader.Read())
                {
                    data.Add(
                        new Product(
                            reader.GetInt32("Id"),
                            reader.GetString("name")  ,      
                            reader.GetInt32("unit_id")   ,    
                            reader.GetDouble("count"), 
                            reader.GetInt32("expiration_day"),
                            reader.GetString("unit_name")
                        )
                    );
                }
                }
            }

            connection.Close();
        }

        return data;
    }
    public static List<TypeExpense> GetTypeExpense()
    {
        List<TypeExpense> data = new List<TypeExpense>();
        using (var connection = new MySqlConnection(ConnectionString.ConnectionString))
        {
            connection.Open();
            using (var comand = connection.CreateCommand())
            {
                comand.CommandText = "SELECT * FROM Type_Expense";
                using (var reader = comand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        data.Add(
                            new TypeExpense(
                                reader.GetInt32("Id"),
                                reader.GetString("name")
                            )
                        );
                    }
                }
            }

            connection.Close();
        }

        return data;
    }
    public static List<Unit> GetUnit()
    {
        List<Unit> data = new List<Unit>();
        using (var connection = new MySqlConnection(ConnectionString.ConnectionString))
        {
            connection.Open();
            using (var comand = connection.CreateCommand())
            {
                comand.CommandText = "SELECT * FROM Unit";
                using (var reader = comand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        data.Add(
                            new Unit(
                                reader.GetInt32("Id"),
                                reader.GetString("name")
                            )
                        );
                    }
                }
            }

            connection.Close();
        }

        return data;
    }

    public static void AddProduct(Product data)
    {
        using (var connection = new MySqlConnection(ConnectionString.ConnectionString))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText =
                    "INSERT INTO product (id, name, unit_id, count, expiration_day) " +
                    "VALUES (@Id, @Name, @UnitId, @Count, @ExpirationDay);";
                command.Parameters.AddWithValue("@Id", data.Id);
                command.Parameters.AddWithValue("@Name", data.Name);
                command.Parameters.AddWithValue("@UnitId", data.UnitId);
                command.Parameters.AddWithValue("@Count", data.Count); 
                command.Parameters.AddWithValue("@ExpirationDay", data.ExpirationDay); 
                var rowsCount = command.ExecuteNonQuery();
                if (rowsCount == 0)
                {
                    MessageBoxManager.GetMessageBoxStandard("Ошибка", "Данные не добавлены", ButtonEnum.Ok).ShowAsync(); ;
                }
            }
            connection.Close();
        }
    }   
    public static void AddAccountingExpense(AccountingForExpense data)
    {
        using (var connection = new MySqlConnection(ConnectionString.ConnectionString))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText =
                    "INSERT INTO accounting_for_expense (id, accouting_for_receipts_id, date, type_id, count, employee_id) " +
                    "VALUES (@Id, @AccoutingForReceiptsId, @Date, @TypeId, @Count, @EmployeeId);";
                command.Parameters.AddWithValue("@Id", data.Id);
                command.Parameters.AddWithValue("@AccoutingForReceiptsId", data.AccoutingForReceiptsId);
                command.Parameters.AddWithValue("@Date", data.Date);     
                command.Parameters.AddWithValue("@TypeId", data.TypeId);             
                command.Parameters.AddWithValue("@Count", data.Count);
                command.Parameters.AddWithValue("@EmployeeId", data.EmployeeId); 
                var rowsCount = command.ExecuteNonQuery();
                if (rowsCount == 0)
                {
                    MessageBoxManager.GetMessageBoxStandard("Ошибка", "Данные не добавлены", ButtonEnum.Ok).ShowAsync(); ;
                }
            }
            connection.Close();
        }
    }
    public static void AddAccountingReceipts(AccountingForReceipts data)
    {
        using (var connection = new MySqlConnection(ConnectionString.ConnectionString))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText =
                    "INSERT INTO accounting_for_receipts (id, product_id, date_expiration, date_manufacture, count, employee_id) " +
                    "VALUES (@Id, @ProductId, @DateExpiration, @DateManufacture, @Count, @EmployeeId);";
                command.Parameters.AddWithValue("@Id", data.Id);
                command.Parameters.AddWithValue("@ProductId", data.ProductId);
                command.Parameters.AddWithValue("@DateExpiration", data.DateExpiration);
                command.Parameters.AddWithValue("@DateManufacture", data.DateManufacture);     
                command.Parameters.AddWithValue("@Count", data.Count);    
                command.Parameters.AddWithValue("@EmployeeId", data.EmployeeId); 
                var rowsCount = command.ExecuteNonQuery();
                if (rowsCount == 0)
                {
                    MessageBoxManager.GetMessageBoxStandard("Ошибка", "Данные не добавлены", ButtonEnum.Ok).ShowAsync(); ;
                }
            }
            connection.Close();
        }
    }   
    public static void UpdateProduct(Product data)
    {
        using (var connection = new MySqlConnection(ConnectionString.ConnectionString))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText =
                    "UPDATE product " +
                    "SET name = @Name," +
                    " unit_id = @UnitId," +
                    " count = @Count, " + 
                    " expiration_day = @ExpirationDay " +
                    " WHERE id = @Id;";
                command.Parameters.AddWithValue("@Id", data.Id);
                command.Parameters.AddWithValue("@Name", data.Name);
                command.Parameters.AddWithValue("@UnitId", data.UnitId);
                command.Parameters.AddWithValue("@Count", data.Count); 
                command.Parameters.AddWithValue("@ExpirationDay", data.ExpirationDay); 
                var rowsCount = command.ExecuteNonQuery();
                if (rowsCount == 0)
                {
                    MessageBoxManager.GetMessageBoxStandard("Ошибка", "Данные не добавлены", ButtonEnum.Ok).ShowAsync(); ;
                }
            }
            connection.Close();
        }
    }   
    public static void UpdateAccountingExpense(AccountingForExpense data)
    {
        using (var connection = new MySqlConnection(ConnectionString.ConnectionString))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText =
                    "UPDATE  accounting_for_expense " +
                    "SET accouting_for_receipts_id = @AccoutingForReceiptsId," +
                    " date = @Date," +
                    " type_id = @TypeId, " +
                    " count = @Count, " +
                    " employee_id = @EmployeeId " +
                    " WHERE id = @Id;";
                command.Parameters.AddWithValue("@Id", data.Id);
                command.Parameters.AddWithValue("@AccoutingForReceiptsId", data.AccoutingForReceiptsId);
                command.Parameters.AddWithValue("@Date", data.Date);     
                command.Parameters.AddWithValue("@TypeId", data.TypeId);             
                command.Parameters.AddWithValue("@Count", data.Count);
                command.Parameters.AddWithValue("@EmployeeId", data.EmployeeId); 
                var rowsCount = command.ExecuteNonQuery();
                if (rowsCount == 0)
                {
                    MessageBoxManager.GetMessageBoxStandard("Ошибка", "Данные не добавлены", ButtonEnum.Ok).ShowAsync(); ;
                }
            }
            connection.Close();
        }
    }
    public static void UpdateAccountingReceipts(AccountingForReceipts data)
    {
        using (var connection = new MySqlConnection(ConnectionString.ConnectionString))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {               
                command.CommandText =
                    "UPDATE accounting_for_receipts " +
                    "SET product_id = @ProductId," +
                    " date_expiration = @DateExpiration," +
                    " date_manufacture = @DateManufacture, " +
                    " count = @Count, " +
                    " employee_id = @EmployeeId " +
                    " WHERE id = @Id;";
                command.Parameters.AddWithValue("@Id", data.Id);
                command.Parameters.AddWithValue("@ProductId", data.ProductId);
                command.Parameters.AddWithValue("@DateExpiration", data.DateExpiration);
                command.Parameters.AddWithValue("@DateManufacture", data.DateManufacture);     
                command.Parameters.AddWithValue("@Count", data.Count);    
                command.Parameters.AddWithValue("@EmployeeId", data.EmployeeId); 
                var rowsCount = command.ExecuteNonQuery();
                if (rowsCount == 0)
                {
                    MessageBoxManager.GetMessageBoxStandard("Ошибка", "Данные не добавлены", ButtonEnum.Ok).ShowAsync(); ;
                }
            }
            connection.Close();
        }
    }
    public static void RemoveAccintingReceipts(AccountingForReceipts data)
    {
        using (var connection = new MySqlConnection(ConnectionString.ConnectionString))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM accounting_for_receipts  WHERE Id = @Id;";
                command.Parameters.AddWithValue("@Id", data.Id);
                var rowsCount = command.ExecuteNonQuery();
                if (rowsCount == 0)
                {
                    MessageBoxManager.GetMessageBoxStandard("Ошибка", "Данные не удалены", ButtonEnum.Ok).ShowAsync();
                    ;
                }
            }

            connection.Close();
        }
    }
    public static void RemoveAccuntingExpense(AccountingForExpense data)
    {
        using (var connection = new MySqlConnection(ConnectionString.ConnectionString))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM accounting_for_expense  WHERE Id = @Id;";
                command.Parameters.AddWithValue("@Id", data.Id);
                var rowsCount = command.ExecuteNonQuery();
                if (rowsCount == 0)
                {
                    MessageBoxManager.GetMessageBoxStandard("Ошибка", "Данные не удалены", ButtonEnum.Ok).ShowAsync();
                    ;
                }
            }

            connection.Close();
        }
    }

}