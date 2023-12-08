using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class Deneme : MonoBehaviour
{
    public TMP_InputField input;

    public GameObject messageBox;

    public GameObject name1, name2, name3, year1, year2, year3, type1, type2, type3, country1, country2, country3, director1, director2, director3, star1, star2, star3;

    public String csvDosya = "imdb_top_250.csv";
    public String csvSplitBy = ";";


    private bool gameFinished = false;

    public int correctAnswer;

    public int count = 1;
    private List<Film> filmListesi;
    private Film rastgeleFilm;


    // Start is called before the first frame update
    void Start()
    {
        filmListesi = FilmleriOku(csvDosya, csvSplitBy);
        rastgeleFilm = RandomFilmSelect(filmListesi);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameFinished && Input.GetKeyDown(KeyCode.Return))
        {
            CheckButton();
        }
    }

    public void CheckButton()
    {

        correctAnswer = 0;

        Film kullaniciFilm = KullaniciFilmiBul(filmListesi, input.text);

        if (kullaniciFilm == null)
        {
            messageBox.SetActive(true);
        }

        else
        {


        }
    }

    private Film RandomFilmSelect(List<Film> filmListesi)
    {
        System.Random random = new();
        int rastgeleNumara = random.Next(1, 250) + 1;
        Film rastgeleFilm = filmListesi[rastgeleNumara];
        return rastgeleFilm;
    }

    public static Film KullaniciFilmiBul(List<Film> filmListesi, string kullaniciFilmIsmi)
    {
        foreach (Film film in filmListesi)
        {
            if (film.getFilmAdi().Equals(kullaniciFilmIsmi))
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
