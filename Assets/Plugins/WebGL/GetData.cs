using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class GetData : MonoBehaviour
{
    [DllImport("__Internal")]
    public static extern void GetGameData(string player, string score);
}
