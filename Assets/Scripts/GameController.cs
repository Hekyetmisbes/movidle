using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.Windows;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public class GameController : MonoBehaviour
{
    public GameObject name0, name1, name2, year0, year1, year2, type0, type1, type2, director0, director1, director2, country0, country1, country2, star0, star1, star2;
    public TextMeshProUGUI tname0, tname1, tname2, tyear0, tyear1, tyear2, ttype0, ttype1, ttype2, tdirector0, tdirector1, tdirector2, tcountry0, tcountry1, tcountry2, tstar0, tstar1, tstar2;

    public String csvDosya = "imdb_top_250.csv";
    public String csvSplitBy = ";";

    public TMP_InputField input;

    public GameObject messageBox;

    public int correctAnswer;

    public int count;

    private List<Film> filmListesi;
    private Film secilenFilm;

    void Start()
    {
        filmListesi = FilmleriOku(csvDosya, csvSplitBy);
        secilenFilm = RandomFilmSelect(filmListesi);
        count = 0;
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
        Debug.LogError("Bilgisayar Seçimi: " + secilenFilm.filmAdi + "\n" + secilenFilm.tur + "\n" + secilenFilm.yil + "\n" + secilenFilm.yonetmen + "\n" + secilenFilm.ulke + "\n" + secilenFilm.yildiz);
        
        if (kullaniciFilm == null)
        {
            messageBox.SetActive(true);
        }
        else
        {
            Debug.LogError("Kullanýcý Film Bilgileri" + kullaniciFilm.filmAdi + "\n" + kullaniciFilm.tur + "\n" + kullaniciFilm.yil + "\n" + kullaniciFilm.yonetmen + "\n" + kullaniciFilm.ulke + "\n" + kullaniciFilm.yildiz);
            switch (count)
            {
                case 0:
                    name0.SetActive(true);
                    tname0.text = kullaniciFilm.filmAdi;
                    if (string.Equals(kullaniciFilm.filmAdi, secilenFilm.filmAdi, StringComparison.OrdinalIgnoreCase))
                    {
                        Debug.Log("Girdi.");
                        name0.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f);
                    }
                    year0.SetActive(true);
                    tyear0.text = kullaniciFilm.yil;
                    if (kullaniciFilm.yil == secilenFilm.yil)
                        year0.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0);
                    country0.SetActive(true);
                    tcountry0.text = kullaniciFilm.ulke;
                    if (kullaniciFilm.ulke == secilenFilm.ulke)
                        country0.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0);
                    type0.SetActive(true);
                    ttype0.text = kullaniciFilm.tur;
                    if (kullaniciFilm.tur == secilenFilm.tur)
                        type0.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0);
                    star0.SetActive(true);
                    tstar0.text = kullaniciFilm.yildiz;
                    if (kullaniciFilm.yildiz == secilenFilm.yildiz)
                        star0.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0);
                    director0.SetActive(true);
                    tdirector0.text = kullaniciFilm.yonetmen;
                    if (kullaniciFilm.yonetmen == secilenFilm.yonetmen)
                        director0.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0);
                    count++;
                    break;
                case 1:
                    name1.SetActive(true);
                    tname1.text = kullaniciFilm.filmAdi;
                    if (kullaniciFilm.filmAdi == secilenFilm.filmAdi)
                        name1.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0);
                    year1.SetActive(true);
                    tyear1.text = kullaniciFilm.yil;
                    if (kullaniciFilm.yil == secilenFilm.yil)
                        year1.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0);
                    country1.SetActive(true);
                    tcountry1.text = kullaniciFilm.ulke;
                    if (kullaniciFilm.ulke == secilenFilm.ulke)
                        country1.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0);
                    type1.SetActive(true);
                    if (kullaniciFilm.tur == secilenFilm.tur)
                        type1.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0);
                    star1.SetActive(true);
                    if (kullaniciFilm.yildiz == secilenFilm.yildiz)
                        star1.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0);
                    director1.SetActive(true);
                    if (kullaniciFilm.yonetmen == secilenFilm.yonetmen)
                        director1.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0);
                    count++;
                    break;
                case 2:
                    name2.SetActive(true);
                    tname2.text = kullaniciFilm.filmAdi;
                    if (kullaniciFilm.filmAdi == secilenFilm.filmAdi)
                        name2.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0);
                    year2.SetActive(true);
                    if (kullaniciFilm.yil == secilenFilm.yil)
                        year2.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0);
                    country2.SetActive(true);
                    if (kullaniciFilm.ulke == secilenFilm.ulke)
                        country2.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0);
                    type2.SetActive(true);
                    if (kullaniciFilm.tur == secilenFilm.tur)
                        type2.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0);
                    star2.SetActive(true);
                    if (kullaniciFilm.yildiz == secilenFilm.yildiz)
                        star2.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0);
                    director2.SetActive(true);
                    if (kullaniciFilm.yonetmen == secilenFilm.yonetmen)
                        director2.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0);
                    count++;
                    break;
                default:
                    Debug.Log("Countta Sýkýntý Var.");
                    break;
            }
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
