using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Start is called before the first frame update

    public List<EnemyFollow> enemies = new List<EnemyFollow>();
    public float delaybeforestart = 2f;
    public void StartEnemyWave()
    {
        StartCoroutine(DelayedStart());
    }
    IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(delaybeforestart);

        foreach(EnemyFollow enemy in enemies)
        {
            enemy.canmove = true;
        }
    }
}
