using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public static class StringExtensions {
    public static long ConvertedInteger(this string source) {
        return Convert.ToInt64(source, 10);
    }
}