using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class craft : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Player player;

    void Start()
    {
        Debug.Log("BagSummary"+player.getBagSummary());


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
