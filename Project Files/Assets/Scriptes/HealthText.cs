using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthText : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int NumOfLives = 3;
    Text text ;
    void Start()
    {
        text = GetComponent<Text>();
        SetText(NumOfLives);
    }
    
    public void SetText(int Num)
    {
        text.text = "X" + Num.ToString();
    }

    public int GetNumOfLives()
    {
        return NumOfLives;
    }
    public string GetText()
    {
        return text.text;
    }
    
    public void SetTNumOfLives(int Num)
    {
        NumOfLives = Num;
        SetText( Num);
    }

    // Update is called once per frame
     void Update()
    {
        
        
    }
}
