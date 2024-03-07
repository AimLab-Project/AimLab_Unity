using System.Collections;
using System.Collections.Generic;
public interface IFPSObject 
{
    //오브젝트 정보 전달을 위한 인터페이스 
    public int CheckTime(); //return. 생성 후 삭제전 시간.
    public float GetDistancePlayer(); // 유저와 오브젝트 간 거리. 


}
