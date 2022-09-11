using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private bool isOpen = false;
    [SerializeField]
    private bool isEnemy;
    [SerializeField]
    public void OnTriggerEnter(Collider collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.tag == (isEnemy ? "Enemy" : "Player"))
            {
                Debug.Log(isEnemy);
                var coroutine = MoveDoor(new Vector3(this.transform.GetChild(0).position.x, 7f, this.transform.GetChild(0).position.z));
                StartCoroutine(coroutine);
            }
        }
    }
    public void OnTriggerExit(Collider collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.tag == (isEnemy ? "Enemy" : "Player"))
            {
                var coroutine = CloseDoor();
                StartCoroutine(coroutine);
            }
        }
    }
    public IEnumerator MoveDoor(Vector3 destination)
    {
        float elapsedTime = 0;
        float waitTime = 1f;
        while (elapsedTime < waitTime)
        {
            this.transform.GetChild(0).position = Vector3.Lerp(this.transform.GetChild(0).position, destination, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;
            Debug.Log("lol");
            yield return null;
        }
        this.transform.GetChild(0).position = destination;
        isOpen = !isOpen;
        yield return null;
    }

    public IEnumerator CloseDoor()
    {
        yield return new WaitUntil(() => isOpen == true);
        var coroutine = MoveDoor(new Vector3(this.transform.GetChild(0).position.x, 2f, this.transform.GetChild(0).position.z));
        StartCoroutine(coroutine);
    }
}
