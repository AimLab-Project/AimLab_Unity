
using UnityEngine;
using UnityEngine.UI;

public class CursurDot : MonoBehaviour, ICursur
{
    [SerializeField]
    RectTransform thisLine;

    [SerializeField]
    RectTransform outLine;

    [SerializeField]
    RectTransform innerLine;

    [SerializeField]
    float MinValue;

    [SerializeField]
    float MaxValue;

    public void EnableCursur(bool isEnable)
    {
        this.gameObject.SetActive(isEnable);
    }

    public void SetLengthInner(float degree)
    {
        thisLine.sizeDelta += new Vector2 (degree , 0);
    }

    public void SetThinknessInner(float degree)
    {
        thisLine.sizeDelta += new Vector2(0, degree);
    }

    public void SetOpacityInner(float degree)
    {
        Image dotImg = innerLine.GetComponent<Image>();
        Color temp = dotImg.color;
        temp.a += degree;
        if (temp.a <= 0.01f)
            temp.a = 0.01f;
        dotImg.color = temp;
    }

    public void EnableOut(bool isEnable)
    {
        outLine.gameObject.SetActive(isEnable);
    }

    public void SetOpacityOut(float degree)
    {
        if (degree < 0)
            return;
        Image dotImg = outLine.GetComponent<Image>();
        Color temp = dotImg.color;
        temp.a = degree;
        dotImg.color = temp;
    }

    public void SetThinknessOut(float degree)
    {
        outLine.sizeDelta += new Vector2(degree, degree);
    }

    public float GetMinValue()
    {
        return MinValue;
    }

    public float GetMaxValue()
    {
        return MaxValue;
    }
   
}

