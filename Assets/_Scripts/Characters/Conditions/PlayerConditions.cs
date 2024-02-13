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


    public float noHungerHealthDecay;

    public UnityEvent onTakeDamage;
    public UnityEvent onDeath; // �÷��̾� ��� �� �߻��� �̺�Ʈ
    public UnityEvent onStaminaDepleted; // ���¹̳� �� �� �߻��� �̺�Ʈ

   

    void Start()
    {   
       
        health.curValue = health.startValue;
        hunger.curValue = hunger.startValue;
        playerSO.Stamina.curValue = playerSO.Stamina.startValue;
    }

    // Update is called once per frame
    void Update()
    {
        hunger.Subtract(hunger.decayRate * Time.deltaTime);
        playerSO.Stamina.Add(playerSO.Stamina.regenRate * Time.deltaTime);

        if (hunger.curValue == 0.0f)
            health.Subtract(noHungerHealthDecay * Time.deltaTime);

        if (health.curValue == 0.0f && onDeath != null)
        {
            onDeath.Invoke(); // ��� �̺�Ʈ �߻�
        }


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
        // ���¹̳ʰ� ������� ������ ���� ���¹̳ʸ� ��� ����ϰ� false�� ��ȯ
        if (playerSO.Stamina.curValue < amount)
        {
            if (playerSO.Stamina.curValue > 0)
            {
                playerSO.Stamina.Subtract(playerSO.Stamina.curValue); // ���� ���¹̳� ���
                if (onStaminaDepleted != null)
                {
                    onStaminaDepleted.Invoke(); // ���¹̳� �� �̺�Ʈ �߻�
                }
            }
            return false;
        }

        // ���¹̳ʸ� ���ҽ�Ű�� true�� ��ȯ
        playerSO.Stamina.Subtract(amount);
        return true;
    }

    public void Die()
    {
        Debug.Log("�÷��̾ �׾���.");
        if (onDeath != null)
        {
            onDeath.Invoke(); // ��� �̺�Ʈ �߻�
        }
    }


    public void TakeDamage(int damage)
    {
        health.Subtract(damage);
        Debug.Log($"�÷��̾ {damage} ��ŭ�� �������� �޾ҽ��ϴ�.");
        if (onTakeDamage != null)
        {
            onTakeDamage.Invoke(); // ���� �Ծ��� ���� �̺�Ʈ �߻�
        }
    }

    public bool CanRun()
    {
        return playerSO.Stamina.curValue >= minStaminaToRun;
    }
}
