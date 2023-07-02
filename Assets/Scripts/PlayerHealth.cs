using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Text healthText;
    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    public GameObject playerDestroyFX;
    public GameObject gameOverUI;
    public GameObject explosionObj;
    public GameObject parent;
    public FMODUnity.StudioEventEmitter playerDeathSound;

    bool damaged;
    bool collidedWithParticle;
    private FMOD.Studio.EventInstance healthLowEngine;
    public FMODUnity.StudioEventEmitter healthLowImpact;
    public FMODUnity.StudioEventEmitter healthHeal;
    public bool brokenPlaying;
    public bool firstLevelHealthImpact;
    public bool secondLevelHealthImpact;
    public Engine_Audio engineAudioScript;

    public static bool isDead;

    private void Awake()
    {
        currentHealth = startingHealth;
        isDead = false;
        gameOverUI.SetActive(false);
    }

    // Use this for initialization
    void Start () {
        healthLowEngine = FMODUnity.RuntimeManager.CreateInstance("event:/Health_Low_Loop");
        healthLowEngine.start();
        firstLevelHealthImpact = false;
        secondLevelHealthImpact = false;
    }

    void CheckDamage()
    {

        if (currentHealth <= 70 && currentHealth >= 50 && brokenPlaying == false)
        {
            healthLowEngine.setParameterByName("Health", currentHealth);
            brokenPlaying = true;
        }
        if (currentHealth <= 50 && currentHealth >= 25 && brokenPlaying)
        {
            healthLowEngine.setParameterByName("Health", currentHealth);
        }
        if (currentHealth > 70 && brokenPlaying) {
            healthLowEngine.setParameterByName("Health", currentHealth);
            brokenPlaying = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
        healthLowImpact.SetParameter("Health", currentHealth);
        CheckDamage();
        if (damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;

        // Test damage function
        if (Input.GetKeyDown("k"))
        {
            healthLowImpact.Play();
            TakeDamage(25);
        }
        // Test gain health function
        if (Input.GetKeyDown("j"))
        {
            healthHeal.Play();
            TakeDamage(-25);
        }
    }

    public void TakeDamage (int amount)
    {
        damaged = true;

        currentHealth -= amount;

        healthSlider.value = currentHealth;
        healthText.text = "Shield Health: " + healthSlider.value.ToString() + "%";

        if(currentHealth <= 0 && !isDead)
        {
            brokenPlaying = false;
            healthLowEngine.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            Death();
        }
    }

    void Death()
    {
        // called when player dies
        playerDeathSound.Play();
        parent.GetComponent<CameraSwitching>().Reset();
        isDead = true;

        Instantiate(playerDestroyFX, transform.position, transform.rotation);

        gameObject.SetActive(false);
        gameOverUI.SetActive(true);
        engineAudioScript.StopEngineAudio();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("ColDetected");
        if (collision.gameObject.tag == "Prop")
        {
            //Debug.Log("PropColDetected");
            Death();
        }

        if(collision.gameObject.tag == "Enemy")
        {
            //Debug.Log("EnemyColDetected");
            Death();
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        // called when the player takes damage
        //Debug.Log("Particle Collision");
        TakeDamage(10); 
    }
}
