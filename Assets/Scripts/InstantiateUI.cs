using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class InstantiateUI : MonoBehaviour
{
    public Canvas canvas;
    public GameObject panel;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        prefab = Instantiate(prefab, panel.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
