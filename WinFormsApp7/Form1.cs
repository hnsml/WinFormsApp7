using Dapper;
using Microsoft.Data.Sqlite;

namespace WinFormsApp7
{
    public partial class Form1 : Form
    {
        private string? ConnString = "Data Source=:memory:";
        private List<Buyer> buyers;
        private List<Sector> sectors;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            buyers = new List<Buyer>();

            using (var connection = new SqliteConnection(ConnString))
            {
                connection.Open();
                CreateTable(connection);
                LoadData(connection);
            }
        }
         private void LoadData(SqliteConnection connection)
        {
            buyers = connection.Query<Buyer>("select * from Buyers").ToList();
            sectors = connection.Query<Sector>("select * from Sectors").ToList();
            dataGridView1.DataSource = buyers;
        }
        public void CreateTable(SqliteConnection connection)
        {

            SqliteCommand c = new SqliteCommand("CREATE TABLE Buyers (\r\n    BuyerId INTEGER PRIMARY KEY AUTOINCREMENT,\r\n    PIB TEXT NOT NULL,\r\n    BirthDate TEXT NOT NULL,\r\n    Sex TEXT NOT NULL,\r\n    Email TEXT NOT NULL,\r\n    Country TEXT NOT NULL,\r\n    City TEXT NOT NULL,\r\n   SectionsOfInterest TEXT NOT NULL\r\n);", connection);
            c.ExecuteNonQuery();

            SqliteCommand ce = new SqliteCommand("INSERT INTO Buyers(BuyerId, PIB, BirthDate, Sex, Email, Country, City, SectionsOfInterest) VALUES(NULL, 'Didlo Black', '20/12/1983','Чоловік',  'didlblc429@gmail.com',  'Франція',  'Париж', 'a');", connection);
            ce.ExecuteNonQuery();
            SqliteCommand ce1 = new SqliteCommand("INSERT INTO Buyers(BuyerId, PIB, BirthDate, Sex, Email, Country, City, SectionsOfInterest) VALUES(NULL, 'Liona Brown', '12/11/2001', 'Жінка',  'lionbrwn@gmail.com',  'США',  'Вашингтон', 'b');", connection);
            ce1.ExecuteNonQuery();
            SqliteCommand ce2 = new SqliteCommand("INSERT INTO Buyers(BuyerId, PIB, BirthDate, Sex, Email, Country, City, SectionsOfInterest) VALUES(NULL, 'Aaron Berkz', '30/10/2003', 'Чоловік',  'aronber91@gmail.com',  'Франція',  'Париж', 'c');", connection);
            ce2.ExecuteNonQuery();
            SqliteCommand ce3 = new SqliteCommand("INSERT INTO Buyers(BuyerId, PIB, BirthDate, Sex, Email, Country, City, SectionsOfInterest) VALUES(NULL, 'Баран Степан Лупуляк', '14/01/1992', 'Чоловік',  'baranstep@gmail.com',  'Україна',  'Дніпро', 'd' );", connection);
            ce3.ExecuteNonQuery();
            SqliteCommand ce4 = new SqliteCommand("INSERT INTO Buyers(BuyerId, PIB, BirthDate, Sex, Email, Country, City, SectionsOfInterest) VALUES(NULL, 'Сракодер Роман Парфюмович','16/05/2000',  'Чоловік',  'srakodrom@gmail.com',  'Україна', 'Чернівці', 'e');", connection);
            ce4.ExecuteNonQuery();
            SqliteCommand ce5 = new SqliteCommand("INSERT INTO Buyers(BuyerId, PIB, BirthDate, Sex, Email, Country, City, SectionsOfInterest) VALUES(NULL, 'Завалюк Орися Миколаївна', '13/08/1963/', 'Жінка', 'zavalorysya779@gmail.com', 'Україна', 'Київ', 'f');", connection);
            ce5.ExecuteNonQuery();
            SqliteCommand ce6 = new SqliteCommand("INSERT INTO Buyers(BuyerId, PIB, BirthDate, Sex, Email, Country, City, SectionsOfInterest) VALUES(NULL, 'Гашишев Оксана Валентинівна', '2/09/1995', 'Жінка', 'gashiwoksn228@gmail.com', 'Канада', 'Торонто', 'g');", connection);
            ce6.ExecuteNonQuery();
            SqliteCommand ce7 = new SqliteCommand("INSERT INTO Buyers(BuyerId, PIB, BirthDate, Sex, Email, Country, City, SectionsOfInterest) VALUES(NULL, 'Гамнонюк Олександра Віталіївна', '12/12/1987', 'Жінка', 'gamnoolx33@gmail.com', 'Німеччина', 'Берлін', 'h');", connection);
            ce7.ExecuteNonQuery();
            SqliteCommand ce8 = new SqliteCommand("INSERT INTO Buyers(BuyerId, PIB, BirthDate, Sex, Email, Country, City, SectionsOfInterest) VALUES(NULL, 'Пентагонюк Іван Заразович', '23/07/1991', 'Чоловік', 'pentaiva234@gmail.com', 'Швейцарія', 'Берн', 'i');", connection);
            SqliteCommand c1 = new SqliteCommand("CREATE TABLE Sectors (SectorId INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT NOT NULL);", connection);
            c1.ExecuteNonQuery();

            SqliteCommand c1e = new SqliteCommand("INSERT INTO Sectors(SectorId, Name) VALUES(NULL, 'кухонна техніка')", connection);
            SqliteCommand c2e = new SqliteCommand("INSERT INTO Sectors(SectorId, Name) VALUES(NULL, 'комп`ютери')", connection);
            SqliteCommand c3e = new SqliteCommand("INSERT INTO Sectors(SectorId, Name) VALUES(NULL, 'планшети')", connection);
            SqliteCommand c4e = new SqliteCommand("INSERT INTO Sectors(SectorId, Name) VALUES(NULL, 'ноутбуки')", connection);
            SqliteCommand c5e = new SqliteCommand("INSERT INTO Sectors(SectorId, Name) VALUES(NULL, 'телефони')", connection);
            SqliteCommand c6e = new SqliteCommand("INSERT INTO Sectors(SectorId, Name) VALUES(NULL, 'перефирічні пристрої')", connection);
            c1e.ExecuteNonQuery();
            c2e.ExecuteNonQuery();
            c3e.ExecuteNonQuery();
            c4e.ExecuteNonQuery();
            c5e.ExecuteNonQuery();
            c6e.ExecuteNonQuery();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var connection = new SqliteConnection(ConnString))
            {
                connection.Open();
                CreateTable(connection);
                dataGridView1.DataSource = buyers;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var connection = new SqliteConnection(ConnString))
            {
                connection.Open();
                CreateTable(connection);
                dataGridView1.DataSource = connection.Query<Buyer>("select Email from Buyers").ToList();
            }
            Buyer.StaticId = buyers.Last().Id;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var connection = new SqliteConnection(ConnString))
            {
                connection.Open();
                CreateTable(connection);
                dataGridView1.DataSource = connection.Query<Buyer>("select City from Buyers").ToList();
            }
            Buyer.StaticId = buyers.Last().Id;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (var connection = new SqliteConnection(ConnString))
            {
                connection.Open();
                CreateTable(connection);
                dataGridView1.DataSource = connection.Query<Buyer>("select Country from Buyers").ToList();
            }
            Buyer.StaticId = buyers.Last().Id;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var connection = new SqliteConnection(ConnString))
            {
                connection.Open();
                CreateTable(connection);
                dataGridView1.DataSource = sectors;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (var connection = new SqliteConnection(ConnString))
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Введіть назву міста.", "Ввід даних", "Київ", -1, -1);
                connection.Open();
                CreateTable(connection);
                dataGridView1.DataSource = connection.Query<Buyer>($"select * from Buyers where City == '{input}' ").ToList();
            }
            Buyer.StaticId = buyers.Last().Id;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (var connection = new SqliteConnection(ConnString))
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Введіть назву країни.", "Ввід даних", "Україна", -1, -1);
                connection.Open();
                CreateTable(connection);
                dataGridView1.DataSource = connection.Query<Buyer>($"select * from Buyers where Country == '{input}'").ToList();
            }
            Buyer.StaticId = buyers.Last().Id;

        }
    }
}
