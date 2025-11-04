using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using StudentManagementSystem.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Data
{
    public class StudentRepository : IStudentRepository
    {

        public  void AddStudent(Student student)
        {
            const string query = @"
        INSERT INTO Students (Name, Email, Gender, DateOfBirth, Department)
        VALUES (@Name, @Email, @Gender, @DateOfBirth, @Department)";


            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", student.Name);
                    command.Parameters.AddWithValue("@Email", student.Email);
                    command.Parameters.AddWithValue("@Gender", student.Gender);
                    command.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);
                    command.Parameters.AddWithValue("@Department", student.Department);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    
                }

            }
            catch (SqlException sqlEx)
            {
                // Log SQL-specific errors
                Console.Error.WriteLine($"SQL Error: {sqlEx.Message}");
               
            }
            catch (Exception ex)
            {
                // Log general errors
                Console.Error.WriteLine($"Unexpected Error: {ex.Message}");
                
            }


        }
        public  void Update(Student student)
        {
            const string query = @"UPDATE Students 
                                   SET Name=@Name, Email=@Email, Gender=@Gender,
                                       DateOfBirth=@DateOfBirth, Department=@Department
                                   WHERE StudentID=@ID";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", student.StudentID);
                    command.Parameters.AddWithValue("@Name", student.Name);
                    command.Parameters.AddWithValue("@Email", student.Email);
                    command.Parameters.AddWithValue("@Gender", student.Gender);
                    command.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);
                    command.Parameters.AddWithValue("@Department", student.Department);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    

                }
            }
            catch (SqlException sqlEx)
            {
                // Log SQL-specific errors
                Console.Error.WriteLine($"SQL Error: {sqlEx.Message}");
                
            }
            catch (Exception ex)
            {
                // Log general errors
                Console.Error.WriteLine($"Unexpected Error: {ex.Message}");
                
            }
        }

        public  void Delete(int id)
        {
            const string query = "DELETE FROM Students WHERE StudentID=@ID";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                   
                }
            }
            catch (SqlException sqlEx)
            {
                // Log SQL-specific errors
                Console.Error.WriteLine($"SQL Error: {sqlEx.Message}");
                
            }
            catch (Exception ex)
            {
                // Log general errors
                Console.Error.WriteLine($"Unexpected Error: {ex.Message}");
                
            }

        }

        public  Student GetById(int id)
        {
            const string query = "SELECT * FROM Students WHERE StudentID=@ID";
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    if (reader.Read())
                    {
                        return new Student
                        {
                            StudentID = (int)reader["StudentID"],
                            Name = reader["Name"].ToString(),
                            Email = reader["Email"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            DateOfBirth = (DateTime)reader["DateOfBirth"],
                            Department = reader["Department"].ToString()
                        };
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Log general errors
                Console.Error.WriteLine($"Unexpected Error: {ex.Message}");
                return null;
            }

        }
        public  List<Student> GetAll()
        {
            const string query = "SELECT * FROM Students";
            var list = new List<Student>();
            try
            {
                using SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
                using SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Student
                    {
                        StudentID = (int)reader["StudentID"],
                        Name = reader["Name"].ToString(),
                        Email = reader["Email"].ToString(),
                        Gender = reader["Gender"].ToString(),
                        DateOfBirth = (DateTime)reader["DateOfBirth"],
                        Department = reader["Department"].ToString()
                    });
                }
                return list;
            }
            catch (Exception ex)
            {
                // Log general errors
                Console.Error.WriteLine($"Unexpected Error: {ex.Message}");
                return list;

            }

        }


    }
}



