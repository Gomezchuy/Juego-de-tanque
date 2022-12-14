using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHealth : MonoBehaviour {

    public int damage =0;
    public int hp = 100;
    public int Max_hp = 100;
    public GameObject tanExplosion;
    public AudioClip tankExplosionAudio;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    int Add_Health()
    {
        hp += 5;
        Invoke("Reduce_Health",0.1f);
        return hp;
    }
    float Reduce_Health()
    {
        if (hp >= Max_hp)
        {
            hp = Max_hp;
        }
        return hp;
    }
    int Add_Damage()
    {
        damage += 5;
        Invoke("Reduce_Damage", 10);
        return damage;
    }
    float Reduce_Damage()
    {
        damage -= 5;
        return damage;
    }

    void TakeDamage()
    {
        if (hp <= 0) return;
        //hp -= Random.Range(8,15) + damage;
        damage = Add_Damage();
        hp = hp - (3 + damage);
        if (hp <= 0)
        {
            AudioSource.PlayClipAtPoint(tankExplosionAudio, transform.position);
            GameObject.Instantiate(tanExplosion, transform.position + Vector3.up, transform.rotation);
            GameObject.Destroy(this.gameObject);
        }

    }
}
