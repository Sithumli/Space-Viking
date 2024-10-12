using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    private Transform player;
    private Vector3 tempPos;
    [SerializeField]
    private float minx, maxx;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!player)
            return;
        tempPos = transform.position;
        tempPos.x = player.position.x;
        tempPos.x = Mathf.Clamp(player.position.x, minx, maxx);
        transform.position = tempPos;
    }
}
