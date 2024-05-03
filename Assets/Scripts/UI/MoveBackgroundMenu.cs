using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveBackgroundMenu : MonoBehaviour
{
    [SerializeField] Image BackgroundFar1;
    [SerializeField] Image BackgroundFar2;
    [SerializeField] Image BackgroundMed1;
    [SerializeField] Image BackgroundMed2;
    [SerializeField] Image BackgroundClose1;
    [SerializeField] Image BackgroundClose2;

    [SerializeField] float FarMoveSpeed = 0.5f;
    [SerializeField] float MedMoveSpeed = 1f;
    [SerializeField] float CloseMoveSpeed = 1.5f;

    private Vector3 Starting1 = new Vector3 (0, 0, 0);
    private Vector3 Starting2 = new Vector3 (1920, 0, 0);

    private void Update()
    {
        //Move the far by a little bit
        if(BackgroundFar2.gameObject.transform.localPosition.x <= 0)
        {
            BackgroundFar1.gameObject.transform.localPosition = Starting1;
            BackgroundFar2.gameObject.transform.localPosition = Starting2;
            //Debug.Log($"Background Far Pos 1: {BackgroundFar1.gameObject.transform.localPosition}, 2:{BackgroundFar2.gameObject.transform.localPosition}");
        }
        else
        {
            BackgroundFar1.gameObject.transform.localPosition -= new Vector3(FarMoveSpeed, 0, 0);
            BackgroundFar2.gameObject.transform.localPosition -= new Vector3(FarMoveSpeed, 0, 0);
        }
        //Move the medium by a little bit more
        if(BackgroundMed2.gameObject.transform.localPosition.x <= 0)
        {
            BackgroundMed1.gameObject.transform.localPosition = Starting1;
            BackgroundMed2.gameObject.transform.localPosition = Starting2;
            //Debug.Log($"Background Far Pos 1: {BackgroundMed1.gameObject.transform.localPosition}, 2:{BackgroundMed2.gameObject.transform.localPosition}");
        }
        else
        {
            BackgroundMed1.gameObject.transform.localPosition -= new Vector3(MedMoveSpeed, 0, 0);
            BackgroundMed2.gameObject.transform.localPosition -= new Vector3(MedMoveSpeed, 0, 0);
        }
        //Move the Close by a lot more
        if(BackgroundClose2.transform.localPosition.x <= 0)
        {
            //return to normal
            BackgroundClose1.gameObject.transform.localPosition = Starting1;
            BackgroundClose2.gameObject.transform.localPosition = Starting2;
            //Debug.Log($"Background Far Pos 1: {BackgroundFar1.gameObject.transform.localPosition}, 2:{BackgroundFar2.gameObject.transform.localPosition}");
        }
        else
        {
            BackgroundClose1.gameObject.transform.localPosition -= new Vector3(CloseMoveSpeed, 0, 0);
            BackgroundClose2.gameObject.transform.localPosition -= new Vector3(CloseMoveSpeed, 0, 0);
        }
    }
}
