using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthsprite;
    public void updatehealthbar(float health, float amount)
    {
        healthsprite.fillAmount = health / amount;
    }
}
