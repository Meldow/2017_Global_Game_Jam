using Player;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public AttackEnemy attackEnemy;

    void OnTriggerEnter(Collider other) {
        var enemy = other.GetComponent<Enemy.Enemy>();
        if (enemy != null) {
            enemy.ReceiveDamage(attackEnemy);
        }
    }

}
