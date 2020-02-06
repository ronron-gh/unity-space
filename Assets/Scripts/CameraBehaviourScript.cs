
#define GYRO_ENABLE
//#define GYRO_LOG


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class CameraBehaviourScript : MonoBehaviour {

#if GYRO_ENABLE
    private float gyro_y_offset;
    private float gyro_y_init;
#endif

    private Quaternion camRot;

    public UnityEngine.UI.Text label_gyroRotX;
    public UnityEngine.UI.Text label_gyroRotY;
    public UnityEngine.UI.Text label_gyroRotZ;

    public Slider slider_pitch;
    public Slider slider_yaw;
    public Slider slider_zoom;

#if GYRO_ENABLE
#if GYRO_LOG
    //ファイル出力
    StreamWriter file_gyro_y;
    int start_time, now_time, duration;
    string filepath;
#endif
#endif

    // Use this for initialization
    void Start () {
#if GYRO_ENABLE
        Input.gyro.enabled = true;
        gyro_y_offset = 0f;
        gyro_y_init = Input.gyro.attitude.eulerAngles.y;
#endif

#if GYRO_ENABLE
#if GYRO_LOG
        filepath = Application.persistentDataPath + "/gyro_y.txt";
        Debug.Log(filepath);
        //file_gyro_y = new StreamWriter(@"gyro_y.txt");
        file_gyro_y = new StreamWriter(filepath);
        start_time = getTime();
#endif
#endif

    }

    // Update is called once per frame
    void Update () {

#if GYRO_ENABLE
        gyro_y_offset = slider_yaw.value;
        camRot = Input.gyro.attitude;
        camRot = Quaternion.Euler(90, gyro_y_offset - gyro_y_init, 0)
                    * (new Quaternion(-camRot.x, -camRot.y, camRot.z, camRot.w));

        label_gyroRotX.text = "gyro x : " + camRot.eulerAngles.x.ToString();
        label_gyroRotY.text = "gyro y : " + camRot.eulerAngles.y.ToString();
        label_gyroRotZ.text = "gyro z : " + camRot.eulerAngles.z.ToString();
#else
        camRot = Quaternion.Euler(slider_pitch.value, slider_yaw.value, 0f);
#endif

        GetComponent<Transform>().localRotation = camRot;


#if GYRO_ENABLE
#if GYRO_LOG
        now_time = getTime();
        duration = now_time - start_time;
        file_gyro_y.WriteLine("{0},{1}", duration, camRot.eulerAngles.y.ToString());
#endif
#endif

        GetComponent<Camera>().fieldOfView = slider_zoom.value;

    }

    private void OnApplicationPause(bool pause)
    {
        //一時停止
        if (pause)
        {
#if GYRO_ENABLE
#if GYRO_LOG
            file_gyro_y.Dispose();
#endif
#endif
        }
        //再開
        else
        {

        }
    }

    private void OnApplicationQuit()
    {
#if GYRO_ENABLE
#if GYRO_LOG
        file_gyro_y.Dispose();
#endif
#endif
    }

    int getTime()
    {
        int ms;
        ms = DateTime.Now.Hour * 60 * 60 * 1000 + DateTime.Now.Minute * 60 * 1000 +
                DateTime.Now.Second * 1000 + DateTime.Now.Millisecond;
        return ms;
    }
}

