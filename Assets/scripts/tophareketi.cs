using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class tophareketi : MonoBehaviour
{
    public Rigidbody2D top;
    public float ziplamagücü;

    public Color turkuazrenk, sarirenk, morrenk, pemberenk;
    public string mevcutrenk;
    public SpriteRenderer ressam;

    public Transform renkdegistirici, kare, cember, doublecember, rastgeleengel1, engelolusrucu;

    int skor;
    public TextMeshProUGUI skoryazýsý, bitisyazýsý;

    public AudioSource ziplamasesi;

    public GameObject bitispaneli;

    private void Start()
    {
        cemberidöndürme.cemberdönüshizi = 1f;
        rastgelerenk();
    }
    private void Update()
    {
        skoryazýsý.text = "Skor: " + skor.ToString();
        bitisyazýsý.text = "Oyun Bitti!\n Skorunuz: " + skor.ToString();
        if (Input.GetMouseButtonDown(0))
        {
            top.velocity = Vector2.up * ziplamagücü;
            ziplamasesi.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D temas)
    {
        if (temas.CompareTag("zemin"))
        {
            var speed = GetComponent<Rigidbody2D>().velocity;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 7);
        }
        if (temas.gameObject.tag != mevcutrenk && temas.gameObject.tag != "renkdegistirici" && temas.gameObject.tag != "engel"&& temas.gameObject.tag !="zemin")
        {
            bitispaneli.SetActive(true);
            Time.timeScale = 0;
            
        }
        if (temas.gameObject.tag == "renkdegistirici")
        {
            renkdegistirici.position = new Vector3(renkdegistirici.position.x, renkdegistirici.position.y + 9f, renkdegistirici.position.z);
            rastgelerenk();
            skor++;
            cemberidöndürme.cemberdönüshizi += 0.05f;
        }
        if (temas.gameObject.tag == "engel")
        {
            rastgeleengelolustur();
        }
    }

    void rastgelerenk()
    {
        int rastgele = Random.Range(0, 4);
        switch (rastgele)
        {
            case 0: mevcutrenk = "turkuaz";
                ressam.color = turkuazrenk;
                break;
            case 1: mevcutrenk = "sari";
                ressam.color = sarirenk;
                break;
            case 2: mevcutrenk = "mor";
                ressam.color = morrenk;
                break;
            case 3: mevcutrenk = "pembe";
                ressam.color = pemberenk;
                break;
        }
    }
    void rastgeleengelolustur()
    {
        int engelrastgele = Random.Range(0,2);
        switch (engelrastgele)
        {
            case 0: rastgeleengel1 = kare;
                break;
            case 1: rastgeleengel1 = doublecember;
                break;
            case 2: rastgeleengel1 = cember;
                break;
        }
        rastgeleengel1.position = new Vector3(rastgeleengel1.position.x, engelolusrucu.position.y + 6f, rastgeleengel1.position.z);
        engelolusrucu.position = new Vector3(engelolusrucu.position.x, engelolusrucu.position.y + 9f, engelolusrucu.position.z);
    }
}
