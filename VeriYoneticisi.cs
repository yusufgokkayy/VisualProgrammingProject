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

        public static string VeriTabaniYolu
        {
            get { return Path.GetFullPath(dbPath); }
        }

        static VeriYoneticisi()
        {
            VeriTabaniOlustur();
            BaslangicVerileriEkle();
        }

        public static void VeriTabaniniBaslat()
        {
            System.Diagnostics.Debug.WriteLine($"Veritabaný yolu: {VeriTabaniYolu}");
        }

        private static void VeriTabaniOlustur()
        {
            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
                System.Diagnostics.Debug.WriteLine($"Veritabaný oluþturuldu: {VeriTabaniYolu}");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine($"Mevcut veritabaný kullanýlýyor: {VeriTabaniYolu}");
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

                string createKullaniciTable = @"CREATE TABLE IF NOT EXISTS Kullanicilar (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    KullaniciAdi TEXT UNIQUE NOT NULL,
                    Sifre TEXT NOT NULL,
                    Ad TEXT NOT NULL,
                    Soyad TEXT NOT NULL,
                    Email TEXT,
                    Telefon TEXT,
                    TC TEXT,
                    KayitTarihi TEXT,
                    IsAdmin INTEGER DEFAULT 0
                )";

                using (SQLiteCommand cmd = new SQLiteCommand(createTrenTable, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                using (SQLiteCommand cmd = new SQLiteCommand(createBiletTable, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                using (SQLiteCommand cmd = new SQLiteCommand(createKullaniciTable, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                BaslangicKullanicilariEkle(conn);
            }
        }

        private static void BaslangicKullanicilariEkle(SQLiteConnection conn)
        {
            string countQuery = "SELECT COUNT(*) FROM Kullanicilar";
            using (SQLiteCommand cmd = new SQLiteCommand(countQuery, conn))
            {
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0) return;
            }

            string insertAdmin = @"INSERT INTO Kullanicilar (KullaniciAdi, Sifre, Ad, Soyad, Email, Telefon, TC, KayitTarihi, IsAdmin) 
                                 VALUES ('admin', 'admin123', 'Admin', 'User', 'admin@trenbilet.com', '0500000000', '11111111111', @tarih, 1)";
            
            string insertUser = @"INSERT INTO Kullanicilar (KullaniciAdi, Sifre, Ad, Soyad, Email, Telefon, TC, KayitTarihi, IsAdmin) 
                                VALUES ('kullanici', '123', 'Test', 'Kullanýcý', 'kullanici@trenbilet.com', '0500000001', '22222222222', @tarih, 0)";

            using (SQLiteCommand cmd = new SQLiteCommand(insertAdmin, conn))
            {
                cmd.Parameters.AddWithValue("@tarih", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.ExecuteNonQuery();
            }

            using (SQLiteCommand cmd = new SQLiteCommand(insertUser, conn))
            {
                cmd.Parameters.AddWithValue("@tarih", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.ExecuteNonQuery();
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
                    // Ýstanbul - Ankara Hattý
                    new Tren("T101", "Ýstanbul", "Ankara", DateTime.Today.AddDays(1), "09:00", 150, 200),
                    new Tren("T102", "Ankara", "Ýstanbul", DateTime.Today.AddDays(1), "10:30", 150, 200),
                    new Tren("T103", "Ýstanbul", "Ankara", DateTime.Today.AddDays(1), "14:00", 160, 180),
                    new Tren("T104", "Ankara", "Ýstanbul", DateTime.Today.AddDays(1), "18:00", 160, 180),
                    
                    // Ýstanbul - Ýzmir Hattý
                    new Tren("T201", "Ýstanbul", "Ýzmir", DateTime.Today.AddDays(1), "08:00", 120, 180),
                    new Tren("T202", "Ýzmir", "Ýstanbul", DateTime.Today.AddDays(1), "14:00", 120, 180),
                    new Tren("T203", "Ýstanbul", "Ýzmir", DateTime.Today.AddDays(2), "10:00", 125, 170),
                    new Tren("T204", "Ýzmir", "Ýstanbul", DateTime.Today.AddDays(2), "16:00", 125, 170),
                    
                    // Ankara - Ýzmir Hattý
                    new Tren("T301", "Ankara", "Ýzmir", DateTime.Today.AddDays(2), "11:00", 100, 150),
                    new Tren("T302", "Ýzmir", "Ankara", DateTime.Today.AddDays(2), "16:00", 100, 150),
                    new Tren("T303", "Ankara", "Ýzmir", DateTime.Today.AddDays(3), "09:00", 105, 140),
                    
                    // Ýstanbul - Konya Hattý
                    new Tren("T401", "Ýstanbul", "Konya", DateTime.Today.AddDays(2), "07:30", 130, 160),
                    new Tren("T402", "Konya", "Ýstanbul", DateTime.Today.AddDays(2), "15:00", 130, 160),
                    new Tren("T403", "Ýstanbul", "Konya", DateTime.Today.AddDays(3), "08:30", 135, 155),
                    
                    // Ankara - Konya Hattý
                    new Tren("T501", "Ankara", "Konya", DateTime.Today.AddDays(3), "12:00", 90, 140),
                    new Tren("T502", "Konya", "Ankara", DateTime.Today.AddDays(3), "18:00", 90, 140),
                    
                    // Ýstanbul - Eskiþehir Hattý
                    new Tren("T601", "Ýstanbul", "Eskiþehir", DateTime.Today.AddDays(1), "11:00", 85, 120),
                    new Tren("T602", "Eskiþehir", "Ýstanbul", DateTime.Today.AddDays(1), "17:00", 85, 120),
                    
                    // Ankara - Eskiþehir Hattý
                    new Tren("T701", "Ankara", "Eskiþehir", DateTime.Today.AddDays(2), "13:00", 60, 100),
                    new Tren("T702", "Eskiþehir", "Ankara", DateTime.Today.AddDays(2), "19:00", 60, 100)
                };

                foreach (var tren in trenler)
                {
                    TrenEkle(tren);
                }
                
                // Baþlangýç biletleri ekle
                BaslangicBiletleriEkle(conn);
            }
        }
        
        private static void BaslangicBiletleriEkle(SQLiteConnection conn)
        {
            string countQuery = "SELECT COUNT(*) FROM Biletler";
            using (SQLiteCommand cmd = new SQLiteCommand(countQuery, conn))
            {
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0) return;
            }

            // Örnek biletler oluþtur
            List<(string biletNo, string trenNo, string nereden, string nereye, DateTime tarih, string saat, string ad, string soyad, string tc, decimal fiyat, string koltuk)> biletler = new List<(string, string, string, string, DateTime, string, string, string, string, decimal, string)>
            {
                ("B001", "T101", "Ýstanbul", "Ankara", DateTime.Today.AddDays(1), "09:00", "Ahmet", "Yýlmaz", "12345678901", 150, "1"),
                ("B002", "T101", "Ýstanbul", "Ankara", DateTime.Today.AddDays(1), "09:00", "Mehmet", "Demir", "12345678902", 150, "2"),
                ("B003", "T201", "Ýstanbul", "Ýzmir", DateTime.Today.AddDays(1), "08:00", "Ayþe", "Kaya", "12345678903", 120, "1"),
                ("B004", "T301", "Ankara", "Ýzmir", DateTime.Today.AddDays(2), "11:00", "Fatma", "Þahin", "12345678904", 100, "1"),
                ("B005", "T102", "Ankara", "Ýstanbul", DateTime.Today.AddDays(1), "10:30", "Ali", "Çelik", "12345678905", 150, "1"),
                ("B006", "T401", "Ýstanbul", "Konya", DateTime.Today.AddDays(2), "07:30", "Zeynep", "Arslan", "22222222222", 130, "1")
            };

            foreach (var bilet in biletler)
            {
                string insertBilet = @"INSERT INTO Biletler (BiletNo, TrenNo, Nereden, Nereye, Tarih, Saat, 
                                     YolcuAd, YolcuSoyad, TC, Fiyat, KoltukNo) 
                                     VALUES (@biletNo, @trenNo, @nereden, @nereye, @tarih, @saat, 
                                     @ad, @soyad, @tc, @fiyat, @koltukNo)";

                using (SQLiteCommand cmd = new SQLiteCommand(insertBilet, conn))
                {
                    cmd.Parameters.AddWithValue("@biletNo", bilet.biletNo);
                    cmd.Parameters.AddWithValue("@trenNo", bilet.trenNo);
                    cmd.Parameters.AddWithValue("@nereden", bilet.nereden);
                    cmd.Parameters.AddWithValue("@nereye", bilet.nereye);
                    cmd.Parameters.AddWithValue("@tarih", bilet.tarih.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@saat", bilet.saat);
                    cmd.Parameters.AddWithValue("@ad", bilet.ad);
                    cmd.Parameters.AddWithValue("@soyad", bilet.soyad);
                    cmd.Parameters.AddWithValue("@tc", bilet.tc);
                    cmd.Parameters.AddWithValue("@fiyat", bilet.fiyat);
                    cmd.Parameters.AddWithValue("@koltukNo", bilet.koltuk);

                    cmd.ExecuteNonQuery();
                }

                // Trendeki boþ koltuk sayýsýný azalt
                string updateTren = "UPDATE Trenler SET BosKoltuk = BosKoltuk - 1 WHERE TrenNo = @trenNo";
                using (SQLiteCommand cmd = new SQLiteCommand(updateTren, conn))
                {
                    cmd.Parameters.AddWithValue("@trenNo", bilet.trenNo);
                    cmd.ExecuteNonQuery();
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
                    query += " AND LOWER(REPLACE(REPLACE(REPLACE(Nereden, 'Ý', 'i'), 'I', 'ý'), 'Ð', 'ð')) LIKE LOWER(REPLACE(REPLACE(REPLACE(@nereden, 'Ý', 'i'), 'I', 'ý'), 'Ð', 'ð'))";
                }
                if (!string.IsNullOrEmpty(nereye))
                {
                    query += " AND LOWER(REPLACE(REPLACE(REPLACE(Nereye, 'Ý', 'i'), 'I', 'ý'), 'Ð', 'ð')) LIKE LOWER(REPLACE(REPLACE(REPLACE(@nereye, 'Ý', 'i'), 'I', 'ý'), 'Ð', 'ð'))";
                }
                if (tarih.HasValue)
                {
                    query += " AND Tarih = @tarih";
                }

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(nereden))
                        cmd.Parameters.AddWithValue("@nereden", "%" + nereden + "%");
                    if (!string.IsNullOrEmpty(nereye))
                        cmd.Parameters.AddWithValue("@nereye", "%" + nereye + "%");
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

        public static List<Bilet> KullaniciBiletleriGetir(string tc)
        {
            List<Bilet> biletler = new List<Bilet>();

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Biletler WHERE TC = @tc";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tc", tc);
                    
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

        public static bool KullaniciKaydet(string kullaniciAdi, string sifre, string ad, string soyad, string email, string telefon, string tc)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string checkQuery = "SELECT COUNT(*) FROM Kullanicilar WHERE LOWER(KullaniciAdi) = LOWER(@kullaniciAdi)";
                using (SQLiteCommand cmd = new SQLiteCommand(checkQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count > 0)
                    {
                        return false;
                    }
                }

                string insertQuery = @"INSERT INTO Kullanicilar (KullaniciAdi, Sifre, Ad, Soyad, Email, Telefon, TC, KayitTarihi, IsAdmin) 
                                     VALUES (@kullaniciAdi, @sifre, @ad, @soyad, @email, @telefon, @tc, @kayitTarihi, 0)";

                using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                    cmd.Parameters.AddWithValue("@sifre", sifre);
                    cmd.Parameters.AddWithValue("@ad", ad);
                    cmd.Parameters.AddWithValue("@soyad", soyad);
                    cmd.Parameters.AddWithValue("@email", email ?? "");
                    cmd.Parameters.AddWithValue("@telefon", telefon ?? "");
                    cmd.Parameters.AddWithValue("@tc", tc ?? "");
                    cmd.Parameters.AddWithValue("@kayitTarihi", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.ExecuteNonQuery();
                }

                return true;
            }
        }

        public static Kullanici KullaniciGiris(string kullaniciAdi, string sifre)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Kullanicilar WHERE KullaniciAdi = @kullaniciAdi AND Sifre = @sifre";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                    cmd.Parameters.AddWithValue("@sifre", sifre);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Kullanici(
                                Convert.ToInt32(reader["Id"]),
                                reader["KullaniciAdi"].ToString(),
                                reader["Sifre"].ToString(),
                                reader["Ad"].ToString(),
                                reader["Soyad"].ToString(),
                                reader["Email"].ToString(),
                                reader["Telefon"].ToString(),
                                reader["TC"]?.ToString() ?? "",
                                DateTime.Parse(reader["KayitTarihi"].ToString()),
                                Convert.ToInt32(reader["IsAdmin"]) == 1
                            );
                        }
                    }
                }
            }

            return null;
        }

        public static bool KullaniciVarMi(string kullaniciAdi)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Kullanicilar WHERE LOWER(KullaniciAdi) = LOWER(@kullaniciAdi)";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }
    }
}