using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public enum Orientations {StraightUp, TowardsCam, SideToCam};

    public float horizontalInput;
    public float verticalInput;

    public Vector3 initialPos;
    public Quaternion initialRot;

    public Transform [] rotationPoints;

    public Orientations currentOrientation;

    public float inputDelay;
    public float timer;

    public float turningRate;

    public Quaternion targetRot;

    private Vector3 newPosition;

    void Start()
    {
        currentOrientation = Orientations.StraightUp;
        newPosition = transform.position;
        timer = 0;
        targetRot = Quaternion.identity;
        initialPos = transform.position;
        initialRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        timer += Time.deltaTime;

        if (timer > inputDelay && (horizontalInput != 0 || verticalInput != 0))
        {
            MovePlayer();
        }

        transform.position = (transform.position * 0.5f) + (newPosition * 0.5f);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, 100000 * Time.deltaTime);


        if(Input.GetKeyDown(KeyCode.R))
        {
            resetPlayer();
        }


    }

    void MovePlayer()
    {
        Vector3 displace = new Vector3(0, 0, 0);
        Vector3 rotation = new Vector3(0, 0, 0);
        Quaternion quaternion = new Quaternion();
        if (horizontalInput > 0)
        {
            if (currentOrientation == Orientations.StraightUp)
            {
                currentOrientation = Orientations.SideToCam;
                displace = new Vector3(1.5f, -0.5f, 0);
                rotation = new Vector3(0, 0, -90);
            }
            else if (currentOrientation == Orientations.SideToCam)
            {
                currentOrientation = Orientations.StraightUp;
                displace = new Vector3(1.5f, 0.5f, 0);
                rotation = new Vector3(0, 0, -90);
            }
            else if (currentOrientation == Orientations.TowardsCam)
            {
                currentOrientation = Orientations.TowardsCam;
                displace = new Vector3(1, 0, 0);
                //rotation = new Vector3(0, 0, 90);
            }
        }
        if (horizontalInput < 0)
        {
            if (currentOrientation == Orientations.StraightUp)
            {
                currentOrientation = Orientations.SideToCam;
                displace = new Vector3(-1.5f, -0.5f, 0);
                rotation = new Vector3(0, 0, 90);

            }
            else if (currentOrientation == Orientations.SideToCam)
            {
                currentOrientation = Orientations.StraightUp;
                displace = new Vector3(-1.5f, 0.5f, 0);
                rotation = new Vector3(0, 0, 90);
            }
            else if (currentOrientation == Orientations.TowardsCam)
            {
                currentOrientation = Orientations.TowardsCam;
                displace = new Vector3(-1, 0, 0);
                //rotation = new Vector3(0, 0, 90);
            }
        }

        if (verticalInput > 0)
        {
            if (currentOrientation == Orientations.StraightUp)
            {
                currentOrientation = Orientations.TowardsCam;
                displace = new Vector3(0, -0.5f, 1.5f);
                rotation = new Vector3(90, 0, 0);

            }
            else if (currentOrientation == Orientations.TowardsCam)
            {
                currentOrientation = Orientations.StraightUp;
                displace = new Vector3(0, 0.5f, 1.5f);
                rotation = new Vector3(90, 0, 0);
            }
            else if (currentOrientation == Orientations.SideToCam)
            {
                currentOrientation = Orientations.SideToCam;
                displace = new Vector3(0, 0, 1);
                //rotation = new Vector3(90, 0, 0);
            }
        }
        if (verticalInput < 0)
        {
            if (currentOrientation == Orientations.StraightUp)
            {
                currentOrientation = Orientations.TowardsCam;
                displace = new Vector3(0, -0.5f, -1.5f);
                rotation = new Vector3(-90, 0, 0);

            }
            else if (currentOrientation == Orientations.TowardsCam)
            {
                currentOrientation = Orientations.StraightUp;
                displace = new Vector3(0, 0.5f, -1.5f);
                rotation = new Vector3(-90, 0, 0);
            }
            else if (currentOrientation == Orientations.SideToCam)
            {
                currentOrientation = Orientations.SideToCam;
                displace = new Vector3(0, 0, -1);
                //rotation = new Vector3(-90, 0, 0);
            }
        }

        timer = 0;
        newPosition = transform.position + displace;

        Vector3 angles = transform.eulerAngles;
        quaternion = Quaternion.Euler(angles + rotation);

        targetRot = quaternion;
    }

    public void resetPlayer()
    {
        transform.position = initialPos;
        transform.rotation = initialRot;
        targetRot = initialRot;
        newPosition = initialPos;
        currentOrientation = Orientations.StraightUp;
    }
}
