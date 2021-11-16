using UnityEngine;
using UnityEngine.UI;

public class BossHPBar : MonoBehaviour
{
    [SerializeField] private AIBase bossAI;
    [SerializeField] private Slider hpBar;


    private void Start()
    {
        hpBar.maxValue = 1.0f;
        hpBar.value    = 1.0f;
        hpBar.minValue = 0.0f;


        bossAI.OnDamagedWithHP += (maxHP, curHP) => {
            hpBar.maxValue = maxHP;
            hpBar.value    = curHP;
        };

        hpBar.gameObject.SetActive(false);

        GameManager.Instance.OnBossBattleEnter += () => {
            hpBar.gameObject.SetActive(true);
        };
    }
}