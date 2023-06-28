using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slider : MonoBehaviour
{
    Slider barSlider;
    // Start is called before the first frame update
    void Start()
    {
        barSlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        barSlider.value = GameManager.Instance.getPower();
    }
}
