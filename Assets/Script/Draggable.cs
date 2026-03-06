using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Draggable : MonoBehaviour
{
    Vector2 difference = Vector2.zero;
    Vector3 offset;
    private Vector2 initialPosition;
    [SerializeField]private GameObject destination;
    [SerializeField] private GameObject greenSlider;
    [SerializeField] private GameObject redSlider;
    public Color green, red;
    [SerializeField] int PlayerHealth;
    [SerializeField] int EnemyHealth;
    [SerializeField] GameObject PlayerHP;
    [SerializeField] GameObject EnemyHP;
    [SerializeField] GameObject Player;
    [SerializeField] Vector3 PlayerDestination;

    [SerializeField] public static int combo = 1;
    public static int comboCount = combo;
    public static int firstSlash = 0;
    public static int freeze = 5;
    public static int playOnce = 0;

    

    Collider2D collider2D;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    [SerializeField] float delayTime;
    [SerializeField] float subDelayTime;
    [SerializeField] Transform playerUlt;
    [SerializeField] Vector3 playerUltDestination;
    [SerializeField] Transform enemyUlt;
    [SerializeField] Vector3 enemyUltDestination;

    [Header("-----------------Audio source---------------")]
    [SerializeField] AudioSource BGM;
    [SerializeField] AudioSource SFX;

    [SerializeField] AudioClip BGMClip;
    [SerializeField] AudioClip PlayerUltSound;
    [SerializeField] AudioClip EnemyUltSound;
    [SerializeField] AudioClip HitSound;

    // Update is called once per frame
    void timer()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime <= 0)
        {
            
            if (playOnce == 0)
            {
                SFX.clip = EnemyUltSound;
                SFX.Play();
                playOnce = 1;
            }
            if (delayTime > 0)
            {
                if (enemyUlt.position.x > enemyUltDestination.x)
                {
                    enemyUlt.position -= new Vector3(0.9f, 0, 0);
                }
                else
                {
                    enemyUlt.position = enemyUltDestination;
                }
                delayTime -= Time.deltaTime;
            }
            else if (delayTime <= 0)
            {
                delayTime = 0;

                if (enemyUlt.position.x < new Vector3(18.21f, -0.4f, -5f).x)
                {
                    enemyUlt.position += new Vector3(0.9f, 0, 0);
                }
                else
                {
                    enemyUlt.position = new Vector3(18.21f, -0.4f, -5f);
                    remainingTime = 21;
                    PlayerHealth--;
                    UpdateHealth();
                    comboCount = 1;
                    combo = 1;
                }
            }
        }
        int seconds = Mathf.FloorToInt(remainingTime);
        timerText.text = (seconds.ToString());
    }

    private void Start()
    {
        initialPosition = transform.position;
        BGM.clip = BGMClip;
        BGM.Play();
        combo = 1;
    }
    private void Awake()
    {
        collider2D = GetComponent<Collider2D>();
    }
    private void OnMouseDown()
    {
        if(freeze == 0)
        {
            offset = transform.position - MouseWorldPosition();
            difference = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
        }
    }

    private void OnMouseDrag()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
    }

    //drop
    private void OnMouseUp()
    {
        if(Mathf.Abs(transform.position.x-destination.transform.position.x)<=0.5f&&
           Mathf.Abs(transform.position.y - destination.transform.position.y) <= 0.5f )
        {
            transform.position = destination.transform.position + new Vector3(0, 0, -0.01f);
            if(comboCount>=3)
            {
                if(firstSlash==0) 
                {
                    firstSlash = 1;
                    combo = comboCount;
                    SFX.clip = HitSound;
                    SFX.Play();
                }
                else
                {
                    firstSlash = 0;
                    comboCount++;
                    combo = comboCount;
                    SFX.clip = HitSound;
                    SFX.Play();
                }
            }
            else
            {
                comboCount++;
                combo = comboCount;
                SFX.clip = HitSound;
                SFX.Play();
            }
        }
        else
        {
            transform.position = new Vector2(initialPosition.x, initialPosition.y);
        }
        if (combo == 10)
        {
            SFX.clip = PlayerUltSound;
            SFX.Play();
        }
    }
    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z= Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.WorldToScreenPoint(mouseScreenPos);
    }
    private void UpdateHealth()
    {
        for(int i = 0; i < PlayerHP.transform.childCount; i++) 
        {
            if(PlayerHealth>i)
            {
                PlayerHP.transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {

                PlayerHP.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        for (int i = 0; i < EnemyHP.transform.childCount; i++)
        {
            if (EnemyHealth > i)
            {
                EnemyHP.transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {

                EnemyHP.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
    private void Update()
    {
        Debug.Log(Player.GetComponent<Animator>().GetBool("rush")+"rush");
        Debug.Log(Player.GetComponent<Animator>().GetBool("rush end")+"rush end");
        Debug.Log(Player.GetComponent<Animator>().GetBool("slash end") + "slash end");
        Debug.Log("==============================");
        var destinationRenderer = destination.GetComponent<Renderer>();
        destinationRenderer.material.color = green;
        if(combo == 1)
        {
            playOnce = 0;
            freeze = 0;
            delayTime = 4;
            subDelayTime = 0.4f;
            redSlider.SetActive(false);
            transform.position = new Vector2(0.807f, 1.279f);
            initialPosition = transform.position;
            greenSlider.transform.position = new Vector3(-1.04f, 0.065f,+1f);
            greenSlider.transform.rotation = Quaternion.Euler(0, 0, 34);
            destination.transform.position = new Vector2(-2.93f, -1.21f);
            combo = 0;//0 mean not move in update
        }
        if(combo == 2)
        {
            transform.position = new Vector2(-3.24f, -0.54f);
            initialPosition = transform.position;
            greenSlider.transform.position = new Vector3(-1.04f, 0.065f,+1f);
            greenSlider.transform.rotation = Quaternion.Euler(0, 0, 15);
            destination.transform.position = new Vector2(1.092f, 0.638f);
            combo = 0;//0 mean not move in update
        }
        if (combo == 3)
        {
            redSlider.SetActive(true);
            transform.position = new Vector2(-3.612f, 0.9219999f);
            initialPosition = transform.position;
            greenSlider.transform.position = new Vector3(-1.412f, 1.527f,+1f);
            redSlider.transform.position = new Vector3(-0.85f, -0.82f,+1f);
            redSlider.transform.rotation = Quaternion.Euler(0, 0, 15);
            greenSlider.transform.rotation = Quaternion.Euler(0, 0, 15);
            destination.transform.position = new Vector2(0.72f, 2.1f);
            combo = 0;//0 mean not move in update
            if(firstSlash==1)
            {

                destinationRenderer.material.color = red;
                greenSlider.transform.position = new Vector2(17.61f, -0.51f);
                transform.position = new Vector3(-3.053f, -1.431f, -1.1f);
                initialPosition = transform.position;
                destination.transform.position = new Vector3(1.306f, -0.263f,-1f);
            }
        }
        if (combo == 4)
        {
            transform.position = new Vector2(-3.082f, 2.284f);
            initialPosition = transform.position;
            greenSlider.transform.position = new Vector3(-1.45f, 0.7f, +1f);
            redSlider.transform.position = new Vector3(-1.45f, 0.7f,+1f);
            redSlider.transform.rotation = Quaternion.Euler(0, 0, 45);
            greenSlider.transform.rotation = Quaternion.Euler(0, 0,-45);
            destination.transform.position = new Vector3(0.099f, -0.888f,-1f);
            combo = 0;//0 mean not move in update
            if (firstSlash == 1)
            {
                greenSlider.transform.position = new Vector2(17.61f, -0.51f);
                transform.position = new Vector3(0.13f, 2.242f,-1.1f);
                initialPosition = transform.position;
                destination.transform.position = new Vector3(-3.059f, -0.907f,-1f);
            }
        }
        if (combo == 5)
        {
            transform.position = new Vector2(0.113f, -0.878f);
            initialPosition = transform.position;
            greenSlider.transform.position = new Vector3(-1.45f, 0.7f, +1f);
            redSlider.transform.position = new Vector3(-1.45f, 0.7f, +1f);
            redSlider.transform.rotation = Quaternion.Euler(0, 0, 45);
            greenSlider.transform.rotation = Quaternion.Euler(0, 0, -45);
            destination.transform.position = new Vector3(-3.085f, 2.317f, -1f);
            combo = 0;//0 mean not move in update
            if (firstSlash == 1)
            {
                greenSlider.transform.position = new Vector2(17.61f, -0.51f);
                transform.position = new Vector3(-3.056f, -0.929f, -1.1f);
                initialPosition = transform.position;
                destination.transform.position = new Vector3(0.14f, 2.26f, -1f);
            }
        }
        if (combo == 6)
        {
            transform.position = new Vector2(-4.01f, 0.96f);
            initialPosition = transform.position;
            greenSlider.transform.position = new Vector3(-1.8f, 1.56f, +1f);
            redSlider.transform.position = new Vector3(-1.27f, -1.04f, +1f);
            redSlider.transform.rotation = Quaternion.Euler(0, 0, 15);
            greenSlider.transform.rotation = Quaternion.Euler(0, 0, 15);
            destination.transform.position = new Vector3(0.32f, 2.14f, -1f);
            combo = 0;//0 mean not move in update
            if (firstSlash == 1)
            {
                greenSlider.transform.position = new Vector2(17.61f, -0.51f);
                transform.position = new Vector3(-3.458f, -1.651f, -1.1f);
                initialPosition = transform.position;
                destination.transform.position = new Vector3(0.88f, -0.47f, -1f);
            }
        }
        if (combo == 7)
        {
            transform.position = new Vector2(-3.469f, 1.407f);
            initialPosition = transform.position;
            greenSlider.transform.position = new Vector3(-1.19f, 1.41f, +1f);
            redSlider.transform.position = new Vector3(-1.2f, -0.84f, +1f);
            redSlider.transform.rotation = Quaternion.Euler(0, 0, 0);
            greenSlider.transform.rotation = Quaternion.Euler(0, 0, 0);
            destination.transform.position = new Vector3(1.03f, 1.402f, -1f);
            combo = 0;//0 mean not move in update
            if (firstSlash == 1)
            {
                greenSlider.transform.position = new Vector2(17.61f, -0.51f);
                transform.position = new Vector3(-3.482f, -0.858f, -1.1f);
                initialPosition = transform.position;
                destination.transform.position = new Vector3(1.023f, -0.862f, -1f);
            }
        }
        if (combo == 8)
        {
            transform.position = new Vector2(-0.055f, 2.599f);
            initialPosition = transform.position;
            greenSlider.transform.position = new Vector3(-1.17f, 0.69f, +1f);
            redSlider.transform.position = new Vector3(-1.17f, 0.69f, +1f);
            redSlider.transform.rotation = Quaternion.Euler(0, 0, 15);
            greenSlider.transform.rotation = Quaternion.Euler(0, 0, 60);
            destination.transform.position = new Vector3(-2.305f, -1.274f, -1f);
            combo = 0;//0 mean not move in update
            if (firstSlash == 1)
            {
                greenSlider.transform.position = new Vector2(17.61f, -0.51f);
                transform.position = new Vector3(0.979f, 1.255f, -1.1f);
                initialPosition = transform.position;
                destination.transform.position = new Vector3(-3.371f, 0.07f, -1f);
            }
        }
        if (combo == 9)
        {
            transform.position = new Vector2(0.42f, 2.263f);
            initialPosition = transform.position;
            greenSlider.transform.position = new Vector3(-1.17f, 0.69f, +1f);
            redSlider.transform.position = new Vector3(-1.17f, 0.69f, +1f);
            redSlider.transform.rotation = Quaternion.Euler(0, 0, -45);
            greenSlider.transform.rotation = Quaternion.Euler(0, 0, 45);
            destination.transform.position = new Vector3(-2.78f, -0.948f, -1f);
            combo = 0;//0 mean not move in update
            if (firstSlash == 1)
            {
                greenSlider.transform.position = new Vector2(17.61f, -0.51f);
                transform.position = new Vector3(-2.792f, 2.278f, -1.1f);
                initialPosition = transform.position;
                destination .transform.position = new Vector3(0.392f, -0.882f, -1f);
            }
        }
        if (combo == 10) 
        {
            if (playOnce == 0)
            {
                Player.GetComponent<Animator>().SetBool("slash end", false);
                if (playerUlt.position.x<playerUltDestination.x)
                {
                    playerUlt.position += new Vector3(0.9f,0,0);
                }
                else
                {
                    playerUlt.position = playerUltDestination;
                    playOnce = 1;
                }
            }
            
            if (delayTime > 0)
            {
                delayTime -= Time.deltaTime;
                freeze = 1;
            }
            else if (delayTime <= 0)
            {
                if(playOnce == 1)
                {
                    if (playerUlt.position.x >= new Vector3(-18.89f, -0.66f, -4f).x)
                    {
                        playerUlt.position -= new Vector3(0.9f, 0, 0);
                    }
                    else
                    {
                        playerUlt.position = new Vector3(-18.89f, -0.66f, -4f);
                        if (Player.transform.position.x <= PlayerDestination.x)
                        {
                            Player.transform.position += new Vector3(0.5f, 0f, 0f);
                            Player.GetComponent<Animator>().SetBool("rush", true);
                        }
                        else
                        {
                            Player.GetComponent<Animator>().SetBool("rush", false);
                            Player.GetComponent<Animator>().SetBool("rush end", true);
                            if (subDelayTime > 0)
                            {
                                subDelayTime -= Time.deltaTime;
                                freeze = 1;
                            }
                            else if (subDelayTime <= 0)
                            {
                                subDelayTime = 0;
                                Player.GetComponent<Animator>().SetBool("rush end", false);
                                Player.GetComponent<Animator>().SetBool("slash end", true);
                                playOnce = 2;
                                
                            }
                        }
                    }
                    
                }
                if (playOnce==2)
                {
                    if (Player.transform.position.x > new Vector3(-7.18f, -1.61f, -4f).x)
                    {
                        Player.transform.position -= new Vector3(0.2f, 0, 0);
                    }
                    else
                    {
                        Player.transform.position = new Vector3(-7.18f, -1.61f, -4f);
                        combo = 11;
                    }
                }
                delayTime = 0;   
            }
        }
        if (combo == 11)
        {
            EnemyHealth--;
            UpdateHealth();
            combo = 1;
            remainingTime = 21;
            comboCount = 1;
        }
        if(freeze == 0)
        {
            timer();
        }
    }
}
