using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    private MeshRenderer renderer;
    private Material originalmaterial;
    public Material DissolveMaterial;
    public float dissolveDuration = 2f;

    public HealthBar healthBar;
    public GameObject healthBarPrefab;
    private float maxhealth;
    public enum enemytype { Easy, Medium, Hard }
    public enemytype DifficultyLevel;

    void Start()
    {
        switch (DifficultyLevel)
        {
            case enemytype.Easy:
                maxhealth = 50f;
                break;
            case enemytype.Medium:
                maxhealth = 80f;
                break;
            case enemytype.Hard:
                maxhealth = 130f;
                break;
        }

        health = maxhealth;

        GameObject hb = Instantiate(healthBarPrefab);
        healthBar = hb.GetComponentInChildren<HealthBar>();
        FollowHealthBar follow = hb.AddComponent<FollowHealthBar>();
        follow.target = this.transform;
        follow.offset = new Vector3(0, 2f, 0);
        healthBar.updatehealthbar(health, maxhealth);

        renderer = GetComponent<MeshRenderer>();
        originalmaterial = renderer.material;
    }

    public void takedamage(float amount)
    {
        health -= amount;
        healthBar.updatehealthbar(health, maxhealth);

        if (health <= 0f)
        {
            Die();
        }
    }
    void Die()
    {
        if (healthBar != null)
            Destroy(healthBar.gameObject);

        StartCoroutine(DissolveDeath());
    }

    private System.Collections.IEnumerator DissolveDeath()
    {
        renderer.material = DissolveMaterial;

        float dissolveValue = 0f;
        while (dissolveValue < 1f)
        {
            dissolveValue += Time.deltaTime / dissolveDuration;
            renderer.material.SetFloat("_DissolveAmount", dissolveValue);
            yield return null;
        }

        Destroy(gameObject);
    }
}
