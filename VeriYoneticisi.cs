using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;

namespace VisualProgrammingProject
{
    public static class VeriYoneticisi
    {
        private static string dbPath = "TrenBileti.db";
        private static string connectionString = $"Data Source={dbPath};Version=3;";

        static VeriYoneticisi()
        {
            VeriTabaniOlustur();
            BaslangicVerileriEkle();
        }

        private static void VeriTabaniOlustur()
        {
            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
            }

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string createTrenTable = @"CREATE TABLE IF NOT EXISTS Trenler (
                    TrenNo TEXT PRIMARY KEY,
                    Nereden TEXT,
                    Nereye TEXT,
                    Tarih TEXT,
                    Saat TEXT,
                    Fiyat REAL,
                    BosKoltuk INTEGER
                )";

                string createBiletTable = @"CREATE TABLE IF NOT EXISTS Biletler (
                    BiletNo TEXT PRIMARY KEY,
                    TrenNo TEXT,
                    Nereden TEXT,
                    Nereye TEXT,
                    Tarih TEXT,
                    Saat TEXT,
                    YolcuAd TEXT,
                    YolcuSoyad TEXT,
                    TC TEXT,
                    Fiyat REAL,
                    KoltukNo TEXT
                )";

                using (SQLiteCommand cmd = new SQLiteCommand(createTrenTable, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                using (SQLiteCommand cmd = new SQLiteCommand(createBiletTable, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static void BaslangicVerileriEkle()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string countQuery = "SELECT COUNT(*) FROM Trenler";
                using (SQLiteCommand cmd = new SQLiteCommand(countQuery, conn))
                {
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count > 0) return;
                }

                List<Tren> trenler = new List<Tren>
                {
                    new Tren("T101", "Ýstanbul", "Ankara", DateTime.Today.AddDays(1), "09:00", 150, 200),
                    new Tren("T102", "Ankara", "Ýstanbul", DateTime.Today.AddDays(1), "10:30", 150, 200),
                    new Tren("T201", "Ýstanbul", "Ýzmir", DateTime.Today.AddDays(1), "08:00", 120, 180),
                    new Tren("T202", "Ýzmir", "Ýstanbul", DateTime.Today.AddDays(1), "14:00", 120, 180),
                    new Tren("T301", "Ankara", "Ýzmir", DateTime.Today.AddDays(2), "11:00", 100, 150),
                    new Tren("T302", "Ýzmir", "Ankara", DateTime.Today.AddDays(2), "16:00", 100, 150),
                    new Tren("T401", "Ýstanbul", "Konya", DateTime.Today.AddDays(2), "07:30", 130, 160),
                    new Tren("T501", "Ankara", "Konya", DateTime.Today.AddDays(3), "12:00", 90, 140)
                };

                foreach (var tren in trenler)
                {
                    TrenEkle(tren);
                }
            }
        }

        public static List<Tren> TrenleriGetir()
        {
            List<Tren> trenler = new List<Tren>();

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Trenler";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Tren tren = new Tren(
                            reader["TrenNo"].ToString(),
                            reader["Nereden"].ToString(),
                            reader["Nereye"].ToString(),
                            DateTime.Parse(reader["Tarih"].ToString()),
                            reader["Saat"].ToString(),
                            Convert.ToDecimal(reader["Fiyat"]),
                            Convert.ToInt32(reader["BosKoltuk"])
                        );
                        trenler.Add(tren);
                    }
                }
            }

            return trenler;
        }

        public static List<Tren> TrenAra(string nereden, string nereye, DateTime? tarih)
        {
            List<Tren> trenler = new List<Tren>();

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Trenler WHERE 1=1";

                if (!string.IsNullOrEmpty(nereden))
                {
                    query += " AND LOWER(Nereden) LIKE @nereden";
                }
                if (!string.IsNullOrEmpty(nereye))
                {
                    query += " AND LOWER(Nereye) LIKE @nereye";
                }
                if (tarih.HasValue)
                {
                    query += " AND Tarih = @tarih";
                }

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(nereden))
                        cmd.Parameters.AddWithValue("@nereden", "%" + nereden.ToLower() + "%");
                    if (!string.IsNullOrEmpty(nereye))
                        cmd.Parameters.AddWithValue("@nereye", "%" + nereye.ToLower() + "%");
                    if (tarih.HasValue)
                        cmd.Parameters.AddWithValue("@tarih", tarih.Value.ToString("yyyy-MM-dd"));

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Tren tren = new Tren(
                                reader["TrenNo"].ToString(),
                                reader["Nereden"].ToString(),
                                reader["Nereye"].ToString(),
                                DateTime.Parse(reader["Tarih"].ToString()),
                                reader["Saat"].ToString(),
                                Convert.ToDecimal(reader["Fiyat"]),
                                Convert.ToInt32(reader["BosKoltuk"])
                            );
                            trenler.Add(tren);
                        }
                    }
                }
            }

            return trenler;
        }

        public static string BiletOlustur(Tren tren, string ad, string soyad, string tc)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT BosKoltuk FROM Trenler WHERE TrenNo = @trenNo";
                int bosKoltuk = 0;
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@trenNo", tren.TrenNo);
                    bosKoltuk = Convert.ToInt32(cmd.ExecuteScalar());

                    if (bosKoltuk <= 0)
                    {
                        return null;
                    }
                }

                Random rnd = new Random();
                string biletNo = "B" + DateTime.Now.ToString("yyyyMMddHHmmss") + rnd.Next(100, 999);
                int koltukNo = 201 - bosKoltuk + 1;

                string insertBilet = @"INSERT INTO Biletler (BiletNo, TrenNo, Nereden, Nereye, Tarih, Saat, 
                                     YolcuAd, YolcuSoyad, TC, Fiyat, KoltukNo) 
                                     VALUES (@biletNo, @trenNo, @nereden, @nereye, @tarih, @saat, 
                                     @ad, @soyad, @tc, @fiyat, @koltukNo)";

                using (SQLiteCommand cmd = new SQLiteCommand(insertBilet, conn))
                {
                    cmd.Parameters.AddWithValue("@biletNo", biletNo);
                    cmd.Parameters.AddWithValue("@trenNo", tren.TrenNo);
                    cmd.Parameters.AddWithValue("@nereden", tren.Nereden);
                    cmd.Parameters.AddWithValue("@nereye", tren.Nereye);
                    cmd.Parameters.AddWithValue("@tarih", tren.Tarih.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@saat", tren.Saat);
                    cmd.Parameters.AddWithValue("@ad", ad);
                    cmd.Parameters.AddWithValue("@soyad", soyad);
                    cmd.Parameters.AddWithValue("@tc", tc);
                    cmd.Parameters.AddWithValue("@fiyat", tren.Fiyat);
                    cmd.Parameters.AddWithValue("@koltukNo", koltukNo.ToString());

                    cmd.ExecuteNonQuery();
                }

                string updateTren = "UPDATE Trenler SET BosKoltuk = BosKoltuk - 1 WHERE TrenNo = @trenNo";
                using (SQLiteCommand cmd = new SQLiteCommand(updateTren, conn))
                {
                    cmd.Parameters.AddWithValue("@trenNo", tren.TrenNo);
                    cmd.ExecuteNonQuery();
                }

                return biletNo;
            }
        }

        public static bool BiletIptal(string biletNo)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string selectBilet = "SELECT TrenNo FROM Biletler WHERE BiletNo = @biletNo";
                string trenNo = "";

                using (SQLiteCommand cmd = new SQLiteCommand(selectBilet, conn))
                {
                    cmd.Parameters.AddWithValue("@biletNo", biletNo);
                    var result = cmd.ExecuteScalar();
                    if (result == null) return false;
                    trenNo = result.ToString();
                }

                string deleteBilet = "DELETE FROM Biletler WHERE BiletNo = @biletNo";
                using (SQLiteCommand cmd = new SQLiteCommand(deleteBilet, conn))
                {
                    cmd.Parameters.AddWithValue("@biletNo", biletNo);
                    cmd.ExecuteNonQuery();
                }

                string updateTren = "UPDATE Trenler SET BosKoltuk = BosKoltuk + 1 WHERE TrenNo = @trenNo";
                using (SQLiteCommand cmd = new SQLiteCommand(updateTren, conn))
                {
                    cmd.Parameters.AddWithValue("@trenNo", trenNo);
                    cmd.ExecuteNonQuery();
                }

                return true;
            }
        }

        public static Bilet BiletBul(string biletNo)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Biletler WHERE BiletNo = @biletNo";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@biletNo", biletNo);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Bilet(
                                reader["BiletNo"].ToString(),
                                reader["TrenNo"].ToString(),
                                reader["Nereden"].ToString(),
                                reader["Nereye"].ToString(),
                                DateTime.Parse(reader["Tarih"].ToString()),
                                reader["Saat"].ToString(),
                                reader["YolcuAd"].ToString(),
                                reader["YolcuSoyad"].ToString(),
                                reader["TC"].ToString(),
                                Convert.ToDecimal(reader["Fiyat"]),
                                reader["KoltukNo"].ToString()
                            );
                        }
                    }
                }
            }

            return null;
        }

        public static List<Bilet> BiletleriGetir()
        {
            List<Bilet> biletler = new List<Bilet>();

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Biletler";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Bilet bilet = new Bilet(
                            reader["BiletNo"].ToString(),
                            reader["TrenNo"].ToString(),
                            reader["Nereden"].ToString(),
                            reader["Nereye"].ToString(),
                            DateTime.Parse(reader["Tarih"].ToString()),
                            reader["Saat"].ToString(),
                            reader["YolcuAd"].ToString(),
                            reader["YolcuSoyad"].ToString(),
                            reader["TC"].ToString(),
                            Convert.ToDecimal(reader["Fiyat"]),
                            reader["KoltukNo"].ToString()
                        );
                        biletler.Add(bilet);
                    }
                }
            }

            return biletler;
        }

        public static void TrenEkle(Tren tren)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = @"INSERT INTO Trenler (TrenNo, Nereden, Nereye, Tarih, Saat, Fiyat, BosKoltuk) 
                               VALUES (@trenNo, @nereden, @nereye, @tarih, @saat, @fiyat, @bosKoltuk)";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@trenNo", tren.TrenNo);
                    cmd.Parameters.AddWithValue("@nereden", tren.Nereden);
                    cmd.Parameters.AddWithValue("@nereye", tren.Nereye);
                    cmd.Parameters.AddWithValue("@tarih", tren.Tarih.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@saat", tren.Saat);
                    cmd.Parameters.AddWithValue("@fiyat", tren.Fiyat);
                    cmd.Parameters.AddWithValue("@bosKoltuk", tren.BosKoltuk);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static bool TrenVarMi(string trenNo)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Trenler WHERE TrenNo = @trenNo";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@trenNo", trenNo);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }
    }
}
