using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int vidaMaxima = 100;
    private int vidaActual;

    public float damageDelay = 3.0f;
    private bool invulnerable = false;

    private Rigidbody rb;

    void Start()
    {
        vidaActual = vidaMaxima;
        rb = GetComponent<Rigidbody>();
    }

    public void OnDamage(int damage)
    {
        if (invulnerable) return;

        vidaActual -= damage;
        Debug.Log("Vida atual: " + vidaActual);

        invulnerable = true;

        // Ativa modo kinematic (sem física)
        rb.isKinematic = true;

        StartCoroutine(DamageDelay());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            OnDamage(3);
        }
    }

    private IEnumerator DamageDelay()
    {
        yield return new WaitForSeconds(damageDelay);

        invulnerable = false;

        // Volta a física ao normal
        rb.isKinematic = false;
    }
}