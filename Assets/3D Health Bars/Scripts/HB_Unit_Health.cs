using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HB_Unit_Health : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public GameObject healthBarHolder;

    Material m_Material;

    public Slider mSlider;
    public float min;
    public float max;

    public Timer script;

    private float startTime;
    private string minutes;
    private string seconds;
    private bool runonlyOnce;

    [SerializeField] private Image GameOverImage;
    public float delay;

    [SerializeField] private Image AdImage;
    public GameObject gameOverObject;

    private IEnumerator WaitBeforeShowEndScene(Image GameOverImage, float delay)
    {
        yield return new WaitForSeconds(2f);
        GameOverImage.enabled = true;
        Destroy(gameOverObject);
        
        yield return new WaitForSeconds(5f);
        GameOverImage.enabled = false;
        SceneManager.LoadScene("VoxelWorld_Demo01");
    }


    private IEnumerator WaitBeforeShow(Image AdImage, float delay)
    {
        AdImage.enabled = true;
        yield return new WaitForSeconds(delay);
        AdImage.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        mSlider.value = 0.5f;
        
    }


    // Update is called once per frame


    /*
    void Update()
    {
        float t = Time.time - startTime;
        minutes = ((int)t / 60).ToString();
        seconds = (t % 60).ToString("f0");


        int i = (int)t / 60;


        if (i % 2 == 1 && seconds == "0" && i != 0)
        {
            
            runonlyOnce = true;
            if(runonlyOnce == true)
            {
                runonlyOnce = false;
                LoosePoint(1);
                print(currentHealth);
                mSlider.value = currentHealth / (max - min);               
            }
            
            
            //LoosePoint(1);
            currentHealth = currentHealth / 2;
            print(currentHealth);
            mSlider.value = currentHealth / (max - min);
            StartCoroutine(WaitBeforeShow());
        }
    }
    */


    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "cookies")
        {
            //print("item picked up");
            //Destroy(gameObject);
            //AddPoint(1);
            //print(currentHealth);
            //mSlider.value = currentHealth / (max - min);
        }

        if (collider.gameObject.tag == "SurveillanceCamera")
        {
            //print("item picked up");
            //Destroy(gameObject);
            LoosePoint(3);
            print(currentHealth);
            mSlider.value = currentHealth / (max - min);

            if (mSlider.value == 0f)
            {
                print("GameOver");
                //gameOverObject.SetActive(false);
                StartCoroutine(WaitBeforeShowEndScene(GameOverImage, delay));
            }
        }

        if (collider.gameObject.tag == "Like")
        {
            //print("item picked up");
            //Destroy(gameObject);
            AddPoint(3);
            print(currentHealth);
            mSlider.value = currentHealth / (max - min);

            if (mSlider.value >= 1f)
            {
                mSlider.value = 1f;
            }
        }

        if (collider.gameObject.tag == "Board")
        {
            //print("item picked up");
            //Destroy(gameObject);
            AddPoint(3);
            print(currentHealth);
            mSlider.value = currentHealth / (max - min);

            if (mSlider.value >= 1f)
            {
                mSlider.value = 1f;
            }
        }

        if (collider.gameObject.tag == "Subscription")
        {
            //print("item picked up");
            //Destroy(gameObject);
            AddPoint(1);
            print(currentHealth);
            mSlider.value = currentHealth / (max - min);

            if (mSlider.value >= 1f)
            {
                mSlider.value = 1f;
            }
        }


        /*
        if (collider.gameObject.tag == "Timer")
        {
            //print("item picked up");
            //Destroy(gameObject);
            AddPoint(1);
            print(currentHealth);
            mSlider.value = currentHealth / (max - min);
        }
        */

        if (collider.gameObject.tag == "Mute")
        {
            //print("item picked up");
            //Destroy(gameObject);
            LoosePoint(3);
            print(currentHealth);
            mSlider.value = currentHealth / (max - min);

            if (mSlider.value == 0f)
            {
                print("GameOver");
                StartCoroutine(WaitBeforeShowEndScene(GameOverImage, delay));
            }
        }

        if (collider.gameObject.tag == "Mask")
        {
            //print("item picked up");
            //Destroy(gameObject);
            LoosePoint(3);
            print(currentHealth);
            mSlider.value = currentHealth / (max - min);

            if (mSlider.value == 0f)
            {
                print("GameOver");
                StartCoroutine(WaitBeforeShowEndScene(GameOverImage, delay));
            }
        }

        /*
        if (collider.gameObject.tag == "Portal")
        {
            //print("item picked up");
            //Destroy(gameObject);
            //LoosePoint(1);
            currentHealth = currentHealth / 2;
            print(currentHealth);
            mSlider.value = currentHealth / (max - min);

            if (mSlider.value == 0f)
            {
                print("GameOver");
                StartCoroutine(WaitBeforeShowEndScene(GameOverImage, delay));
            }
        }
        */
    }

    

    //Access via OnTriggerEnter and pass whatever damage amount you want


    public void AddPoint(int damageTaken)
    {
        //Minus the damagetaken and also set currenthealth equal to that number
        currentHealth += damageTaken;

        if (GetComponent<HB_Healthbar>().shakeOnHit)
        {
            healthBarHolder.GetComponentInParent<Healthbar_Shake>().trigger = true;
        }

        healthBarHolder.transform.localScale = new Vector3((float)currentHealth / (float)maxHealth, 1, 1);
        ParticleSystem temp;
        temp = GetComponent<HB_Healthbar>().breakFX;
        var main = GetComponent<HB_Healthbar>().breakFX.main;

        main.startSizeX = ((float)damageTaken / (float)maxHealth) * 1.2f * GetComponent<HB_Healthbar>().healthbarWidthScale;
        m_Material = temp.GetComponent<Renderer>().material;
        m_Material.color = (Color)GetComponent<HB_Healthbar>().barColor;
        temp.Play();
    }

    public void LoosePoint(int damageTaken)
    {
        //Minus the damagetaken and also set currenthealth equal to that number
        currentHealth -= damageTaken;

        if (GetComponent<HB_Healthbar>().shakeOnHit)
        {
            healthBarHolder.GetComponentInParent<Healthbar_Shake>().trigger = true;
        }

        healthBarHolder.transform.localScale = new Vector3((float)currentHealth / (float)maxHealth, 1, 1);
        ParticleSystem temp;
        temp = GetComponent<HB_Healthbar>().breakFX;
        var main = GetComponent<HB_Healthbar>().breakFX.main;

        main.startSizeX = ((float)damageTaken / (float)maxHealth) * 1.2f * GetComponent<HB_Healthbar>().healthbarWidthScale;
        m_Material = temp.GetComponent<Renderer>().material;
        m_Material.color = (Color)GetComponent<HB_Healthbar>().barColor;
        temp.Play();
    }
}
