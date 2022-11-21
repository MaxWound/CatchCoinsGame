using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public static Pool instance;
    [SerializeField]
    private GameObject sparkleFx;
    [SerializeField]
    private GameObject fx;
    [SerializeField]
    private GameObject coin;
    [SerializeField]
    private GameObject bomb;
    [SerializeField]
    private int StartCount;
    List<GameObject> bombs = new List<GameObject>();
    List<GameObject> coins = new List<GameObject>();
    List<GameObject> fires = new List<GameObject>();
    List<GameObject> sparkles = new List<GameObject>();
    [SerializeField]
    private int StartFXCount;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    private void Start()
    {
        InitPool();

    }
    private void InitPool()
    {
        for (int i = 0; i < StartCount; i++)
        {
            GameObject newCoin = Instantiate(coin, transform.position, transform.rotation);
            coins.Add(newCoin);
            newCoin.GetComponent<MeshRenderer>().enabled = false;

            newCoin.GetComponent<Rigidbody>().useGravity = false;
            
            print("инит");
        }
        for (int i = 0; i < StartCount; i++)
        {
            GameObject newBomb = Instantiate(bomb, transform.position, transform.rotation);
            bombs.Add(newBomb);
            foreach (Transform child in newBomb.transform)
            {
                if (child.GetComponent<MeshRenderer>() != null)
                {
                    MeshRenderer renderer = child.GetComponent<MeshRenderer>();
                    renderer.enabled = false;
                }
                if (child.GetComponent<ParticleSystem>() != null)
                {
                    child.GetComponent<ParticleSystem>().Clear();
                    child.GetComponent<ParticleSystem>().Stop();
                }
            }
            newBomb.GetComponent<Rigidbody>().useGravity = false;
            print("инит");
        }
        for (int i = 0; i < StartFXCount; i++)
        {
            GameObject newFx = Instantiate(fx, transform.position, transform.rotation);
            
            fires.Add(newFx);
            
            print("инит");
        }
        for (int i = 0; i < StartFXCount; i++)
        {
            GameObject newFx = Instantiate(sparkleFx, transform.position, transform.rotation);

            sparkles.Add(newFx);

            print("инит");
        }
    }
    public void StartSpawnFire(Vector3 pos)
    {
        StartCoroutine(SpawnFire(pos));
    }
    public void StartSpawnSparkles(Vector3 pos)
    {
        StartCoroutine(SpawnSparkles(pos));
    }
    public IEnumerator SpawnFire(Vector3 pos)
    {
        fires[0].transform.position = pos;
        fires[0].GetComponent<ParticleSystem>().Play();
        fires[0].GetComponent<AudioSource>().time = 0f;
        fires[0].GetComponent<AudioSource>().Play();
        GameObject fireToReturn = fires[0];
        fires.Remove(fires[0]);
        yield return new WaitForSeconds(1.2f);
        fireToReturn.GetComponent<ParticleSystem>().Stop();
        fires[0].GetComponent<AudioSource>().Stop();
        fires[0].GetComponent<AudioSource>().time = 0f;

        fireToReturn.transform.position = transform.position;
        fires.Add(fireToReturn);

    }
    public IEnumerator SpawnSparkles(Vector3 pos)
    {
        sparkles[0].transform.position = pos;
        sparkles[0].GetComponent<ParticleSystem>().Play();
        sparkles[0].GetComponent<AudioSource>().time = 0f;
        sparkles[0].GetComponent<AudioSource>().Play();
        GameObject sparklesToReturn = sparkles[0];
        sparkles.Remove(sparkles[0]);
        yield return new WaitForSeconds(1.2f);
        sparklesToReturn.GetComponent<ParticleSystem>().Stop();
        sparkles[0].GetComponent<AudioSource>().Stop();

        sparklesToReturn.transform.position = transform.position;
        sparkles.Add(sparklesToReturn);

    }
    public void SpawnFromPool(Transform parent, Vector3 pos)
    {
        int randomInt = Random.Range(1, 5);
        if (randomInt > 1)
        {
            coins[0].GetComponent<MeshRenderer>().enabled = true;
            coins[0].transform.position = pos;
            coins[0].GetComponent<Rigidbody>().velocity = Vector3.zero;
            coins[0].GetComponent<Rigidbody>().useGravity = true;
            coins[0].GetComponent<Rigidbody>().AddTorque(new Vector3(0f, 1000f, 0f));
            coins[0].transform.parent = parent;
            coins.Remove(coins[0]);
        }
        else
        {
            //bombs[0].GetComponent<MeshRenderer>().enabled = true;
            foreach (Transform child in bombs[0].transform)
            {
                if (child.GetComponent<MeshRenderer>() != null)
                {
                    MeshRenderer renderer = child.GetComponent<MeshRenderer>();
                    renderer.enabled = true;
                }
                if (child.GetComponent<ParticleSystem>() != null)
                {

                    child.GetComponent<ParticleSystem>().Play();
                }
            }
                bombs[0].transform.position = pos;
            bombs[0].GetComponent<Rigidbody>().velocity = Vector3.zero;
            bombs[0].GetComponent<Rigidbody>().useGravity = true;
            bombs[0].GetComponent<Rigidbody>().AddTorque(new Vector3(0f, 1000f, 0f));
            bombs[0].transform.parent = parent;
            bombs.Remove(bombs[0]);
        }


    }
    public void ReturnCoinToPool(GameObject obj)
    {
        obj.transform.position = transform.position;
        obj.GetComponent<MeshRenderer>().enabled = false;
        obj.GetComponent<Rigidbody>().useGravity = false;
        obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
        coins.Add(obj);
        print(coins.Count);
    }
    public void ReturnBombToPool(GameObject obj)
    {
        obj.transform.position = transform.position;
        foreach (Transform child in obj.transform)
        {
            if (child.GetComponent<MeshRenderer>() != null)
            {
                MeshRenderer renderer = child.GetComponent<MeshRenderer>();
                renderer.enabled = false;
            }
            if (child.GetComponent<ParticleSystem>() != null)
            {
                child.GetComponent<ParticleSystem>().Clear();
                child.GetComponent<ParticleSystem>().Stop();
            }
        }
        obj.GetComponent<Rigidbody>().useGravity = false;
        obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
        bombs.Add(obj);
    }
}
