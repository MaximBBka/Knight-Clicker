using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BaseMobs : MonoBehaviour
{
    [SerializeField] private CheckPlayer checkPlayer;
    [SerializeField] private GameObject empty;
    private WaitForSeconds wait;
    [SerializeField] private int health;
    [SerializeField] private int healthMax;
    [SerializeField] private int reward;
    [SerializeField] private TextMeshProUGUI healthBar;

    private void Start()
    {
        health = healthMax;
    }
    public void TakeDamage()
    {
        health -= MainUI.Instance.GetTotalStrong();
        healthBar.SetText(health.ToString());
        if (health <= 0)
        {
            empty.SetActive(false);
            StartCoroutine(Timer());
            Rewarded();
        }
    }
    public IEnumerator Timer()
    {
        wait ??= new WaitForSeconds(2); // ѕроверка wait на null и присваивание ей 2 секунд
        yield return wait;
        RespawnMob();
    }
    public void RespawnMob()
    {
        empty.SetActive(true);
        health = healthMax;
        healthBar.SetText(health.ToString());
    }
    public void Rewarded()
    {
        MainUI.Instance.AddTotalStrongReward(reward);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = checkPlayer.color;
        Gizmos.DrawWireSphere(transform.position, checkPlayer.radius);
    }

    private void Update()
    {
        if (checkPlayer.Check(transform) && Input.GetMouseButtonDown(0))
        {
            if (health > 0)
            {
                TakeDamage();
            }
        }
    }
}