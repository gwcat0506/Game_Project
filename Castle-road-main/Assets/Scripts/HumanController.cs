using System.Collections;
using Player;
using UnityEngine;
using Random = UnityEngine.Random;

public class HumanController : MonoBehaviour
{
    private float _speed;

    private void Start()
    {
        _speed = Random.Range(0.6f, 1f);

        if (transform.position.x > 0 && transform.position.x < 14)
        {
            StartCoroutine(GoLeft());
        }
        else
        {
            StartCoroutine(GoRight());
        }
    }

    private IEnumerator GoRight()
    {
        while (transform.position.x <= 10)
        {
            transform.position += Vector3.right * (Time.deltaTime * _speed);
            yield return null;
        }
        Destroy(gameObject);
    }

    private IEnumerator GoLeft()
    {
        while (transform.position.x >= -10)
        {
            transform.position += Vector3.left * (Time.deltaTime * _speed);
            yield return null;
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("collide");
            /*_animator.SetTrigger(Attack);
            StartCoroutine(AttackPlayer(0.4f, other.gameObject));*/
            Vector3 scale = other.gameObject.transform.localScale;
            other.gameObject.transform.localScale = new Vector3(scale.x, scale.y * 0.1f, scale.z);
            Destroy(other.gameObject);
        }
    }
    
    /*private IEnumerator AttackPlayer(float delayTime, GameObject player)
    {
        yield return new WaitForSeconds(delayTime);
        _audioManager.Play("Punch"); 
        Destroy(player);
    }*/
}
