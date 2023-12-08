using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.Windows;

public class GameController : MonoBehaviour
{
    public String csvDosya = "imdb_top_250.csv";
    public String csvSplitBy = ";";

    public TMP_InputField input;

    public GameObject messageBox;

    public int correctAnswer;

    public int count = 1;

    private List<Film> filmListesi;
    private Film secilenFilm;

    void Start()
    {
        filmListesi = FilmleriOku(csvDosya, csvSplitBy);
        secilenFilm = RandomFilmSelect(filmListesi);
    }

    public void CheckButton()
    {
        correctAnswer = 0;

        if (filmListesi == null)
        {
            Debug.LogError("Film list is not initialized.");
            return;
        }

        string userInput = input.text;
        Debug.LogError("Kullanýcý Giriþi: " + userInput);

        Film kullaniciFilm = KullaniciFilmiBul(filmListesi, input.text);
        Debug.LogError("Bilgisayar Seçimi: " + secilenFilm.filmAdi);

        if (kullaniciFilm == null)
        {
            messageBox.SetActive(true);
        }
        else
        {
            // Continue with the logic
            Debug.Log("Kullanýcý Film: " + kullaniciFilm.getFilmAdi());
        }
    }

    private Film RandomFilmSelect(List<Film> filmListesi)
    {
        System.Random random = new System.Random();
        int rastgeleNumara = random.Next(1, filmListesi.Count); // 1 ile filmListesi.Count arasýnda rastgele bir indeks seçiyoruz
        Film rastgeleFilm = filmListesi[rastgeleNumara];
        return rastgeleFilm;
    }


    public static Film KullaniciFilmiBul(List<Film> filmListesi, string kullaniciFilmIsmi)
    {
        foreach (Film film in filmListesi)
        {
            Debug.Log("Checking film: " + film.getFilmAdi());
            if (string.Equals(film.getFilmAdi(), kullaniciFilmIsmi, StringComparison.OrdinalIgnoreCase))
            {
                return film;
            }
        }
        return null;
    }

    private List<Film> FilmleriOku(string csvDosya, string csvSplitBy)
    {
        List<Film> filmListesi = new List<Film>();

        try
        {
            using (StreamReader sr = new StreamReader(csvDosya))
            {
                while (!sr.EndOfStream)
                {
                    string satir = sr.ReadLine();
                    string[] veriler = satir.Split(csvSplitBy);

                    if (veriler.Length >= 6) // Minimum 6 sütun kontrolü
                    {
                        string filmAdi = veriler[1];
                        string yil = veriler[2];
                        string tur = veriler[3];
                        string ulke = veriler[4];
                        string yonetmen = veriler[5];
                        string yildiz = veriler[6];

                        Film film = new Film(filmAdi, yil, tur, ulke, yonetmen, yildiz);
                        filmListesi.Add(film);
                    }
                    else
                    {
                        // Hatalý satýr durumunu iþleyebilirsiniz
                        Debug.LogWarning("Hatalý satýr: " + satir);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Dosya okuma hatasý: " + ex.Message);
        }

        return filmListesi;
    }

    public class Film
    {
        public string filmAdi;
        public string yil;
        public string tur;
        public string ulke;
        public string yonetmen;
        public string yildiz;

        public Film(String filmAdi, String yil, String tur, String ulke, String yonetmen, String yildiz)
        {
            this.filmAdi = filmAdi;
            this.yil = yil;
            this.tur = tur;
            this.ulke = ulke;
            this.yonetmen = yonetmen;
            this.yildiz = yildiz;
        }

        public String getFilmAdi()
        {
            return filmAdi;
        }

        public String getYil()
        {
            return yil;
        }

        public String getTur()
        {
            return tur;
        }

        public String getUlke()
        {
            return ulke;
        }

        public String getYonetmen()
        {
            return yonetmen;
        }

        public String getYildiz()
        {
            return yildiz;
        }
    }
}
