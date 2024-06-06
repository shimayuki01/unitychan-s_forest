using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldObjectGenerater : MonoBehaviour
{
    [SerializeField] Button contactButton;
    
    public GameObject stone1;
    public string itemId;
    public GameObject stone2;
    public GameObject stone3;
    GameObject stone4;

    // Start is called before the first frame update
    void Start()
    {
        GenerateFieldObject(stone1, itemId);
        GenerateFieldObject(stone2, itemId);
        GenerateFieldObject(stone3, itemId);
    }
    void GenerateFieldObject(GameObject fieldObject, string itemId)//, Vector3 position, Vector3 rotation)
    {
        //Quaternion quaternion = Quaternion.Euler(rotation);
        fieldObject.AddComponent<FieldObject>();
        fieldObject.GetComponent<FieldObject>().contactButton = contactButton;
        fieldObject.GetComponent<FieldObject>().itemId = itemId;
        
        //GameObject a  = Instantiate(fieldObject, position, quaternion);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
