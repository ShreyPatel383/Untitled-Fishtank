using UnityEngine;
using System;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;

public class TransparentWindow : MonoBehaviour
{
    //All Dllimport functions are using Windows API to turn background transparent.
    [DllImport("user32.dll")]
    public static extern int MessageBox(IntPtr head, string text, string caption, uint type);

    [DllImport("user32.dll")]

    private static extern IntPtr GetActiveWindow();
    private struct Margins { 
        public int LeftWidth;
        public int RightWidth;
        public int TopWidth;
        public int BottomWidth;
    }

    [DllImport("Dwmapi.dll")]
    private static extern uint DwmExtendFrameIntoClientArea(IntPtr head, ref Margins margins);


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Value of -1 gives transparent glass effect on windows application.
        IntPtr head = GetActiveWindow();
        Margins margins = new Margins { LeftWidth = -1 };
        DwmExtendFrameIntoClientArea(head, ref margins);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
