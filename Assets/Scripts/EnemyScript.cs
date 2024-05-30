using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed = 2f;
    [SerializeField] private float attackDamage = 5f;
    [SerializeField] private float attackSpeed = 1f;
    private float canAttack;
    private Transform target;

    private void FixedUpdate()
    {
        if (target != null)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }

        canAttack += Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            float damage = other.gameObject.GetComponent<Bullets>().damage;
            GetComponent<EnemyHealth>().UpdateHealth(-damage);
        }
        if (other.gameObject.tag == "Player")
        {
            AttackPlayer(other);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            AttackPlayer(other);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = null;
        }
    }

    private void AttackPlayer(Collision2D other)
    {
        if (attackSpeed <= canAttack)
        {
            other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
            canAttack = 0f;
        }
    }
}
