using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;

namespace Dziennik
{
    public partial class PrincipalWindow : Window
    {
        private string connectionString;
        private int pesel;  // Dodajemy pole do przechowywania PESEL dyrektora
        private int teacherPesel;

        // Konstruktor z dwoma parametrami: connectionString i pesel
        public PrincipalWindow(string connectionString, int pesel)
        {
            InitializeComponent();
            this.connectionString = connectionString;
            this.pesel = pesel;  // Inicjalizujemy pesel
            this.teacherPesel = pesel;

            LoadStudentsForTeacher();
            LoadAllStudents();
            LoadSubjects();
        }

        // Załaduj uczniów przypisanych do nauczyciela (z TeacherWindow)
        private void LoadStudentsForTeacher()
        {
            var students = new List<Uczen>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
                    SELECT u.PESEL, u.imie, u.nazwisko, u.punkty
                    FROM uczen u
                    INNER JOIN klasa k ON u.klasa_id = k.Id
                    WHERE k.wychowawca_id = @PeselWychowawcy";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PeselWychowawcy", pesel); // Używamy pesel dyrektora

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        students.Add(new Uczen
                        {
                            Pesel = reader["PESEL"].ToString(),
                            Imie = reader["Imie"].ToString(),
                            Nazwisko = reader["Nazwisko"].ToString(),
                            Punkty = Convert.ToInt32(reader["Punkty"])
                        });
                    }
                }
            }

            StudentsListBox.ItemsSource = students;
        }

        // Załaduj wszystkich uczniów
        private void LoadAllStudents()
        {
            var students = new List<Uczen>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT PESEL, imie, nazwisko, punkty FROM uczen";

                using (var command = new SqlCommand(query, connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        students.Add(new Uczen
                        {
                            Pesel = reader["PESEL"].ToString(),
                            Imie = reader["Imie"].ToString(),
                            Nazwisko = reader["Nazwisko"].ToString(),
                            Punkty = Convert.ToInt32(reader["Punkty"])
                        });
                    }
                }
            }

            AllStudentsListBox.ItemsSource = students;
        }

        // Załaduj przedmioty
        private void LoadSubjects()
        {
            var subjects = new List<Przedmiot>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT id, nazwa FROM przedmiot";

                using (var command = new SqlCommand(query, connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        subjects.Add(new Przedmiot
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nazwa = reader["Nazwa"].ToString()
                        });
                    }
                }
            }

            SubjectsComboBox.ItemsSource = subjects;
        }


        private void LoadStudents()
        {
            // Załaduj listę uczniów przypisanych do wychowawcy
            var students = new List<Uczen>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
                    SELECT u.PESEL, u.imie, u.nazwisko, u.punkty
                    FROM uczen u
                    INNER JOIN klasa k ON u.klasa_id = k.Id
                    WHERE k.wychowawca_id = @PeselWychowawcy";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PeselWychowawcy", teacherPesel);

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        students.Add(new Uczen
                        {
                            Pesel = reader["PESEL"].ToString(),
                            Imie = reader["Imie"].ToString(),
                            Nazwisko = reader["Nazwisko"].ToString(),
                            Punkty = Convert.ToInt32(reader["Punkty"])
                        });
                    }
                }
            }

            StudentsListBox.ItemsSource = students;
        }

        private void StudentsListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (StudentsListBox.SelectedItem is Uczen selectedStudent)
            {
                // Wyświetl dane ucznia w polach, jeśli zostanie wybrany
                SelectedStudentName.Text = $"{selectedStudent.Imie} {selectedStudent.Nazwisko}";
                SelectedStudentPoints.Text = selectedStudent.Punkty.ToString();
            }
        }

        private void UpdatePoints_Click(object sender, RoutedEventArgs e)
        {
            if (StudentsListBox.SelectedItem is Uczen selectedStudent &&
                int.TryParse(NewPointsTextBox.Text, out int newPoints))
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand("UPDATE uczen SET Punkty = @Punkty WHERE PESEL = @Pesel", connection);
                    command.Parameters.AddWithValue("@Punkty", newPoints);
                    command.Parameters.AddWithValue("@Pesel", selectedStudent.Pesel);
                    command.ExecuteNonQuery();
                }

                MessageBox.Show($"Zaktualizowano punkty dla ucznia: {selectedStudent.FullName}");
                LoadStudents(); // Odśwież listę uczniów
            }
            else
            {
                MessageBox.Show("Wybierz ucznia i podaj poprawną liczbę punktów.");
            }
        }

        private void AddGrade_Click(object sender, RoutedEventArgs e)
        {
            if (StudentsListBox.SelectedItem is Uczen selectedStudent &&
                SubjectsComboBox.SelectedValue is int subjectId &&
                int.TryParse(NewGradeTextBox.Text, out int gradeValue))
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand("INSERT INTO ocena (ocena, id_ucznia, id_przedmiotu) VALUES (@Wartosc, @Pesel, @PrzedmiotId)", connection);
                    command.Parameters.AddWithValue("@Wartosc", gradeValue);
                    command.Parameters.AddWithValue("@Pesel", selectedStudent.Pesel);
                    command.Parameters.AddWithValue("@PrzedmiotId", subjectId);
                    command.ExecuteNonQuery();
                }

                MessageBox.Show($"Dodano ocenę dla ucznia: {selectedStudent.FullName}");
            }
            else
            {
                MessageBox.Show("Wybierz ucznia, przedmiot i podaj poprawną ocenę.");
            }
        }

        private void DeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            if (AllStudentsListBox.SelectedItem is Uczen selectedStudent)
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM uczen WHERE PESEL = @Pesel";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Pesel", selectedStudent.Pesel);
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Uczeń został usunięty.");
                LoadAllStudents(); // Odśwież listę uczniów
            }
            else
            {
                MessageBox.Show("Wybierz ucznia do usunięcia.");
            }
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            string pesel = PeselTextBox.Text;
            string firstName = FirstNameTextBox.Text;
            string lastName = LastNameTextBox.Text;
            if (int.TryParse(ClassIdTextBox.Text, out int classId))
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO uczen (PESEL, imie, nazwisko, klasa_id) VALUES (@Pesel, @FirstName, @LastName, @ClassId)";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Pesel", pesel);
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);
                        command.Parameters.AddWithValue("@ClassId", classId);
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Uczeń został dodany.");
                LoadAllStudents(); // Odśwież listę uczniów
            }
            else
            {
                MessageBox.Show("Podaj poprawne ID klasy.");
            }
        }
    }
}
