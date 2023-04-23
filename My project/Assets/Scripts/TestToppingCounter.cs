using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TestToppingCounter : MonoBehaviour
{
    public static int counter = 0;
    public TextMeshProUGUI olives;

    
    // Start is called before the first frame update
    void Start()
    {
        olives = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        olives.text = "Olives: " + counter;
        
    }
}
