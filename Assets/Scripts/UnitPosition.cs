using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPosition : MonoBehaviour
{
    public bool active;
    public string pos;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(this.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        MoveUnit();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tile"))
        {

            Debug.Log(this.gameObject.name + " : " + other.gameObject.name);
        }
    }

    private void MoveUnit()
    {
        if (active)
        {
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, 0.5f, speed * Time.deltaTime), transform.position.z);
            StartCoroutine(MoveDown());
        }
    }

    IEnumerator MoveDown()
    {
        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(Move());
        transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, 0.15f, speed * Time.deltaTime), transform.position.z);
    }
    IEnumerator Move()
    {
        Vector3 posB = GameObject.Find(pos).transform.position;
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, posB.x, speed * Time.deltaTime), transform.position.y, Mathf.Lerp(transform.position.z, posB.z, speed * Time.deltaTime));
        active = false;
        yield return new WaitForSeconds(1f);
    }
}
