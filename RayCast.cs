using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//UI관련 사용하기 위해서
public class RayCast : MonoBehaviour
{
    public Image reticle;//UI있어야함
    float timeElapsed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        raycasting();
    }
    void raycasting()
    {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward * 1000);
        if(Physics.Raycast(transform.position,forward,out hit))
        {
            //버튼 게이지 채욱리
            //지금까지 지내온 시간
            timeElapsed = Time.deltaTime + timeElapsed;//한프레임당 걸린 시간(변동가능) + timeElapsed 
            reticle.fillAmount = timeElapsed / 3;//reticle에 있는 fill amount 값을 3으로 나누기, 3초 세면 3 나눠서 1 될 수 있게, 3초 기다리기 
            if (timeElapsed >= 3)
            {
                timeElapsed = 3;
                hit.transform.GetComponent<Button>().onClick.Invoke();//raycast로 부딪힌 오브젝트의 온 클릭 기능 실행해라
            }
            
            Debug.Log("hit");
        }
        //여기까지만 하면 button 밖에 있으면 게이지가 멈춤
        //버튼 밖에서 게이지 줄이기
        else
        {
            timeElapsed = timeElapsed - Time.deltaTime;
            reticle.fillAmount = timeElapsed / 3;
            if (timeElapsed <= 0) timeElapsed = 0;
        }
        Debug.DrawRay(transform.position, forward, Color.red);
    }
}
