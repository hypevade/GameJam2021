using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{
    [SerializeField]
    private Vector3 nextPos;
    [SerializeField]
    private GameObject _roadPrefab;
    [SerializeField]
    private int _deleteTime;
    private float timer;
    [SerializeField]
    private float startPause = 5f;
    [SerializeField]
    private float frequency = 3f;

    void Start()
    {
        timer = startPause;
        for (int i = 0; i < 3; i++)
        {
            var temp = Instantiate(_roadPrefab, nextPos, Quaternion.identity);
            nextPos = temp.transform.GetChild(0).position;
        }
    }

    void FixedUpdate()
    {
        if (timer <= 0f)
        {
            timer = frequency;
            GenerateNext();
        }
        timer -= Time.deltaTime;
    }

    void GenerateNext()
    {
        var temp = Instantiate(_roadPrefab, nextPos, Quaternion.identity);
        nextPos = temp.transform.GetChild(0).position;
        StartCoroutine(Delete(temp));
    }

    IEnumerator Delete(GameObject temp)
    {
        yield return new WaitForSeconds(_deleteTime);
        Destroy(temp);
    }
}
