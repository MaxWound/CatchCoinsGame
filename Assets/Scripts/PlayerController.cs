using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private int lifePoints;

    private bool isAlive = true;
    [SerializeField]
    private float leftBound;
    [SerializeField]
    private float rightBound;

    private float mouseStart;
    private float mouseDelta;
    private float mouseCurrent => Input.mousePosition.x;
    private Vector3 direction;
    private Rigidbody rb;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private AudioSource coinAudioSource;
    [SerializeField]
    private ParticleSystem houseFireFx;
    private void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            if (Input.GetMouseButtonDown(0))
            {

                mouseStart = Input.mousePosition.x;
            }
            if (Input.GetMouseButton(0))
            {
                mouseDelta = mouseCurrent - mouseStart;
                mouseStart = Input.mousePosition.x;
                direction = mouseDelta > 0 ? Vector3.right * mouseDelta : Vector3.left * Mathf.Abs(mouseDelta);
                if ((transform.position + direction * Time.smoothDeltaTime).x < rightBound && (transform.position + direction * Time.smoothDeltaTime).x > leftBound)
                {

                    transform.position += direction * Time.smoothDeltaTime;
                }


            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Coins")
        {
            if (isAlive)
            {
                GameManager.instance.OperateScore(1);
                coinAudioSource.time = 0f;
                coinAudioSource.Play();
                animator.ResetTrigger("Bump");
                animator.SetTrigger("Bump");

                Pool.instance.ReturnCoinToPool(other.gameObject);
            }
            else
            {
                Pool.instance.StartSpawnSparkles(other.transform.position);
                Pool.instance.ReturnCoinToPool(other.gameObject);
            }

        }

        if (other.tag == "Bomb")
        {

            Pool.instance.StartSpawnFire(other.transform.position);
            Pool.instance.ReturnBombToPool(other.gameObject);
            if (isAlive)
            {
                lifePoints--;
                if (lifePoints <= 0)
                {
                    isAlive = false;
                    GameUI.instance.ShowDie();
                    houseFireFx.Play();
                }
            }
        }

    }
}
