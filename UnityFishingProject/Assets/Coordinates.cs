using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coordinates : MonoBehaviour {

    private double xPos;
    private double yPos;
    private double zPos;

    Coordinates(double x,double y ,double z) {

        this.XPos = x;
        this.yPos = y;
        this.zPos = z;

    }

    public double XPos
    {
        get
        {
            return xPos;
        }

        set
        {
            xPos = value;
        }
    }

    public double YPos
    {
        get
        {
            return yPos;
        }

        set
        {
            yPos = value;
        }
    }

    public double ZPos
    {
        get
        {
            return zPos;
        }

        set
        {
            zPos = value;
        }
    }

}
