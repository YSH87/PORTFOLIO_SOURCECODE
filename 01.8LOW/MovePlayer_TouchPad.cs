using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class TouchMovePlayer : MonoBehaviour
{
    public Transform player;
    public float speed;

    void Update()
    {
        var v = CrossPlatformInputManager.GetAxis("Vertical");
        var h = CrossPlatformInputManager.GetAxis("Horizontal");
        Vector3 movement = new Vector3(h,0f,v).normalized;
        player.transform.Translate(movement * speed * Time.deltaTime, Space.World);
        player.transform.LookAt(player.transform.position+movement); // (내 위치 + 내가 상대적으로 더 이동할곳)을 바라보기
    }

    
}