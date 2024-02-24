using UnityEngine;
using UnityEngine.Events;

public interface IDamagable
{
    void TakeDamage(int damageAmount);
}

[System.Serializable]
public class Condition
{
    [HideInInspector]
    public float curValue;
    public float maxValue;
    public float startValue;
    public float regenRate;
    public float decayRate;

    public void Add(float amount)
    {
        curValue = Mathf.Min(curValue + amount, maxValue);
    }

    public void Subtract(float amount)
    {
        curValue = Mathf.Max(curValue - amount, 0.0f);
    }

    public float GetPercentage()
    {
        return curValue / maxValue;
    }


}

public class PlayerConditions : MonoBehaviour, IDamagable
{
    public Condition health;
    public Condition hunger;
    public PlayerSO playerSO;
    public float minStaminaToRun = 10f;
    public AudioClip deathClip;

    public float noHungerHealthDecay;

    public UnityEvent onTakeDamage;
    public UnityEvent onDeath; // 플레이어 사망 시 발생할 이벤트
    public UnityEvent onStaminaDepleted; // 스태미너 고갈 시 발생할 이벤트

    private bool isDead = false;

    void Start()
    {
        gameManager.I.playerConditions = this;
        health.curValue = health.startValue;
        hunger.curValue = hunger.startValue;
        playerSO.Stamina.curValue = playerSO.Stamina.startValue;
    }


void Update()
{
    hunger.Subtract(hunger.decayRate * Time.deltaTime);
    playerSO.Stamina.Add(playerSO.Stamina.regenRate * Time.deltaTime);

    if (hunger.curValue <= 0.0f)
        health.Subtract(noHungerHealthDecay * Time.deltaTime);

    if (health.curValue <= 0.0f)
        Die(); // 체력이 0 이하일 때 Die 메서드 호출
}

    public void Heal(float amount)
    {
        health.Add(amount);
    }

    public void Eat(float amount)
    {
        hunger.Add(amount);
    }

    public bool UseStamina(float amount)
    {
        // 스태미너가 충분하지 않으면 남은 스태미너를 모두 사용하고 false를 반환
        if (playerSO.Stamina.curValue < amount)
        {
            if (playerSO.Stamina.curValue > 0)
            {
                playerSO.Stamina.Subtract(playerSO.Stamina.curValue); // 남은 스태미너 사용
                if (onStaminaDepleted != null)
                {
                    onStaminaDepleted.Invoke(); // 스태미너 고갈 이벤트 발생
                }
            }
            return false;
        }

        // 스태미너를 감소시키고 true를 반환
        playerSO.Stamina.Subtract(amount);
        return true;
    }
    public void TakeDamage(int damage)
    {
        Debug.Log($"TakeDamage 호출됨. 받은 대미지: {damage}");
        health.Subtract(damage);
        onTakeDamage.Invoke(); // 피해 입었을 때의 이벤트 발생

        if (health.curValue <= 0.0f)
            Die(); // 체력이 0 이하일 때 Die 메서드 호출
    }
    public void Die()
    {
        if (!isDead) // isDead를 클래스 멤버 변수로 추가하여 중복 사망 처리 방지
        {
            Debug.Log("플레이어가 죽었다.");
            isDead = true;
            AudioSource.PlayClipAtPoint(deathClip, transform.position);
            onDeath.Invoke(); // 사망 이벤트 발생

        }
    }




    public bool CanRun()
    {
        return playerSO.Stamina.curValue >= minStaminaToRun;
    }
}
