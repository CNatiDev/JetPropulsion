using System.Collections;
using UnityEngine;
using UnityEngine.Events;
public class HitObstacle : MonoBehaviour
{
    public UnityEvent Event;
    public float explosionForce = 1000f;
    public float explosionRadius = 10f;
    bool Can_Hit = true;
    [HideInInspector] public GameObject Final;
    public void Hit()
    {   if (Can_Hit)
        {
            ScoreManager score = FindObjectOfType<ScoreManager>();
            score.Play = false;
            this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            this.GetComponent<JetPropulsion>().enabled = false;
            this.GetComponent<Rigidbody>().AddForce(Vector3.up * explosionForce, ForceMode.Impulse);
            this.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRadius, 1f, ForceMode.Impulse);
            Event.Invoke();
            Final.SetActive(true);
            GameManager gameManager = FindObjectOfType<GameManager>();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Hit();
            Can_Hit = false;
            Debug.Log("Hit" + this.name);
        }
    }

}
