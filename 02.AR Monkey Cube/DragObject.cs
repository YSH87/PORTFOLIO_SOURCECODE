using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragObject : MonoBehaviour, IDragHandler
{
    public float rotateSpeed = 0.3f;
    //마우스 드레그 정보를 가져와서 변화값에 맞게 오브젝트를 돌려야한다.

    
    public void OnDrag(PointerEventData data)
    {
        transform.Rotate(new Vector3(-data.delta.y * rotateSpeed, -data.delta.x * rotateSpeed, 0), Space.World);
    }
    
}
