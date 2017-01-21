using Player;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public AttackEnemy attackEnemy;

    void OnTriggerEnter(Collider other) {
        var enemy = other.GetComponent<Enemy.Enemy>();
        if (enemy != null) {
            Debug.Log("found enemy :: " + enemy.name);
            enemy.ReceiveDamage(attackEnemy);
        }
    }

}
