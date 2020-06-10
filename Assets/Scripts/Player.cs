using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public class PlayerStats {
        public float Health = 100f;
    }

    public Light pointLight;

    public Slider healthBar;

    public Text healthText;

    public PlayerStats playerStats = new PlayerStats();

    public PlayerMovement MyMovement;

    public Animator anim;

    public GameObject blood;

    public bool canBeDamaged = true;

    public SpriteRenderer playerSprite;

    void Start() 
    {
        playerSprite = GetComponent<SpriteRenderer>();
    }

    void Update() 
    {
        healthBar.value = playerStats.Health;
        healthText.text = playerStats.Health + " / 100";
    }

    void DamagePlayer (int damage) 
    {
        playerStats.Health -= damage;
        if (playerStats.Health <= 0) {
                Instantiate(blood, transform.position, Quaternion.identity);
                MyMovement.alive = false;
                anim.SetBool("Dead", true);
                canBeDamaged = false;
                StartCoroutine(GameOver());
        } else {
            StartCoroutine(PlayerFlash());
        }
    }

    void OnCollisionEnter2D(Collision2D col) 
    {
        if (col.gameObject.CompareTag("Enemy") && canBeDamaged)
            {
                Vector2 difference = transform.position - col.transform.position;
                transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y);
                DamagePlayer(10);
            }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {

        if (other.gameObject.CompareTag("Pollo"))
            {
                playerStats.Health = Mathf.Min(100f, playerStats.Health + 20f);
                other.gameObject.SetActive(false);
            }  
            
        if (other.gameObject.CompareTag("Pocion"))
            {
                StartCoroutine(ExpandLight());
                other.gameObject.SetActive(false);
            } 
    }

    IEnumerator ExpandLight() 
    {
        pointLight.range = pointLight.range * 3f;
        yield return new WaitForSeconds(5);
        pointLight.range = pointLight.range / 3f;
    }

    IEnumerator GameOver() 
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("GameOver");
    }

    IEnumerator PlayerFlash() 
    {
        canBeDamaged = false;
        playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
        yield return new WaitForSeconds(0.2f);
        playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
        yield return new WaitForSeconds(0.2f);
        playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
        yield return new WaitForSeconds(0.2f);
        playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
        yield return new WaitForSeconds(0.2f);
        playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
        yield return new WaitForSeconds(0.2f);
        playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
        canBeDamaged = true;
    }
    


}
