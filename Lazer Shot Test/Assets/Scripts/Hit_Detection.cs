using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hit_Detection : MonoBehaviour
{
    public TextMeshPro Text;
    int numhits = 0;

    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.tag == "Target")
        {
            numhits++;
            Text.text = "Hits: " + numhits.ToString();
            Destroy(collision.gameObject);
        }
    }

}
