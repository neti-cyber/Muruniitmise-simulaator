using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreUI;

    //private Rigidbody rb;
    public Light lt;
    AudioSource audio;

    private bool collisionOccured = false;


    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        lt = GameObject.Find("Directional Light").GetComponent<Light>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        scoreUI.text = (score).ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (collisionOccured)
        {
            StartCoroutine(Wait());
            return;
        }
        if (other.gameObject.layer == 6) //grass layer = 6
        {
            score++;
            lt.intensity -= 0.003F;
            audio.volume += 0.001F;
            RenderSettings.fogDensity += 0.00005F;
            RenderSettings.ambientIntensity -= 0.002F;
            collisionOccured = true;
            //Destroy(other.gameObject);
        }
    }

    IEnumerator Wait()
    {  
        yield return new WaitForSeconds(0.1f);
        collisionOccured = false;
    }

    public void Reload()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        Time.timeScale = 1;
    }
}
