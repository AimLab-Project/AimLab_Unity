using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICursur
{
    public void EnableCursur(bool isEnable);
   
    public void SetOpacityInner(float degree);

    public void SetThinknessInner(float degree);
    public void SetLengthInner(float degree);

    public void EnableOut(bool isEnable);
    public void SetOpacityOut(float degree);

    public void SetThinknessOut(float degree);
}
