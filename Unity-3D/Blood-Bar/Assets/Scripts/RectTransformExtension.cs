using UnityEngine;
//可以用来修改RectTransform的Left、Right、Bottom、Top的扩展方法
public static class RectTransformExtension
{
	//RectTransform新增4个方法：
    public static void Left(this RectTransform rTrans, int value)
    {
        rTrans.offsetMin = new Vector2(value, rTrans.offsetMin.y);
    }

    public static void Right(this RectTransform rTrans, int value)
    {
        rTrans.offsetMax = new Vector2(-value, rTrans.offsetMax.y);
    }

    public static void Bottom(this RectTransform rTrans, int value)
    {
        rTrans.offsetMin = new Vector2(rTrans.offsetMin.x, value);
    }

    public static void Top(this RectTransform rTrans, int value)
    {
        rTrans.offsetMax = new Vector2(rTrans.offsetMax.x, -value);
    }
}