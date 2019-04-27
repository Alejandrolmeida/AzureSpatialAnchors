using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int curHealth = 100;

    public GameObject ObjectToDestroy;

    public void AddjustCurrentHealth(int adj)
    {
        curHealth += adj;

        if (curHealth < 0)
            curHealth = 0;

        if (curHealth > maxHealth)
            curHealth = maxHealth;

        if (curHealth <= 0)
            if (ObjectToDestroy != null)
                Destroy(ObjectToDestroy);
    }
   
}