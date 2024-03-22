using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScTakeDamage : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;

    [SerializeField] private Sprite _hurtSprite;
    [SerializeField] private Sprite _normalSprite;

    private ScHealthBar _healthBar;

    public static ScTakeDamage Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        currentHealth = maxHealth;
        ScHealthBar.Instance.SetMaxHealth();
    }

    private void Update()
    {
        if(currentHealth > maxHealth) 
        {
            currentHealth = maxHealth;
        }
        ScHealthBar.Instance.SetHealth(currentHealth); 
        ScHealthBar.Instance.healthAmount.text = currentHealth.ToString();
        Death();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ScSpikyBall SpikyBall))
        {
            currentHealth--;
            StartCoroutine(SwitchSprite(1, ScPlayerInputs.Instance.rigidbodyPlayer.gameObject));
            ScAudioManager.Instance.PlaySong("SlimeHurt");
        }
    }

    private void Death()
    {
        if (currentHealth <= 0) 
        {
            ScVictoryDefeat.Instance.Defeat();
            Destroy(gameObject);
        }
    }

    IEnumerator SwitchSprite(float seconds, GameObject player)
    {
        player.GetComponent<SpriteRenderer>().sprite = _hurtSprite;
        yield return new WaitForSeconds(seconds);
        player.GetComponent<SpriteRenderer>().sprite = _normalSprite;
    }
}
