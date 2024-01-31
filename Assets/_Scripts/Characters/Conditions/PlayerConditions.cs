using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public interface IDamagable
{
    void TakePhysicalDamage(int damageAmount);
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
    public Image warningImage; // �� ���ǿ� ���� ��� �̹���

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
    public Condition stamina;

    public float noHungerHealthDecay;
    public UnityEvent onTakeDamage;

    private Animator animator; // Animator ������Ʈ�� ������ ����

    private Coroutine healthBlinkCoroutine;
    private Coroutine hungerBlinkCoroutine;
    private Coroutine staminaBlinkCoroutine;

    void Start()
    {
        health.curValue = health.startValue;
        hunger.curValue = hunger.startValue;
        stamina.curValue = stamina.startValue;
        animator = GetComponent<Animator>(); // Animator ������Ʈ ����

        health.warningImage.gameObject.SetActive(false);
        hunger.warningImage.gameObject.SetActive(false);
        stamina.warningImage.gameObject.SetActive(false);
    }

    void Update()
    {
        // ������� 0�̸� ü�� ����
        if (hunger.curValue == 0.0f)
        {
            Debug.Log("�����");
            health.Subtract(noHungerHealthDecay * Time.deltaTime);
        }

        // ü���� 0�̸� ����
        if (health.curValue == 0.0f)
        {
            Die();
        }

        // �޸��� ������ �� ���׹̳� ����
        if (animator.GetBool("Run") && stamina.curValue > 0)
        {
            stamina.Subtract(4 * Time.deltaTime);
        }

        // ���� ������ �� ���׹̳� ����
        if (animator.GetBool("@Attack") && stamina.curValue >= 10)
        {
            stamina.Subtract(10); // ���� �� ���׹̳� 10 ����
            animator.SetBool("@Attack", false); // ���� ���� �ʱ�ȭ
        }

        // ��� �̹��� ������Ʈ
        CheckWarning(health);
        CheckWarning(hunger);
        CheckWarning(stamina);
    }

    void CheckWarning(Condition condition)
    {
        if (condition.GetPercentage() < 0.2f)
        {
            if (condition.warningImage.gameObject.activeInHierarchy == false)
            {
                condition.warningImage.gameObject.SetActive(true);
                switch (condition)
                {
                    case var _ when condition == health:
                        healthBlinkCoroutine = StartCoroutine(BlinkImage(condition.warningImage, 2.0f));
                        break;
                    case var _ when condition == hunger:
                        hungerBlinkCoroutine = StartCoroutine(BlinkImage(condition.warningImage, 2.0f));
                        break;
                    case var _ when condition == stamina:
                        staminaBlinkCoroutine = StartCoroutine(BlinkImage(condition.warningImage, 2.0f));
                        break;
                }
            }
        }
        else
        {
            condition.warningImage.gameObject.SetActive(false);
            if (condition == health && healthBlinkCoroutine != null)
            {
                StopCoroutine(healthBlinkCoroutine);
            }
            else if (condition == hunger && hungerBlinkCoroutine != null)
            {
                StopCoroutine(hungerBlinkCoroutine);
            }
            else if (condition == stamina && staminaBlinkCoroutine != null)
            {
                StopCoroutine(staminaBlinkCoroutine);
            }
        }
    }


    IEnumerator BlinkImage(Image image, float interval)
    {
        while (image.gameObject.activeSelf)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0); // ����
            yield return new WaitForSeconds(interval);
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1); // ������
            yield return new WaitForSeconds(interval);
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
        if (stamina.curValue - amount < 0)
        {
            return false;
        }
        stamina.Subtract(amount);
        return true;
    }

    public void Die()
    {
        Debug.Log("�÷��̾ �׾���.");
        // ������ ���õ� �߰� ������ ���⿡ �� �� �ֽ��ϴ�.
    }

    public void TakePhysicalDamage(int damageAmount)
    {
        health.Subtract(damageAmount);
        onTakeDamage?.Invoke();
    }
}
