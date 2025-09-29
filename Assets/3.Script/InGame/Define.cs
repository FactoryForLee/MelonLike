using UnityEngine;

namespace InGameDefine
{
    public enum EBallColor
    {
        Red,
        RedOrange,
        Orange,
        YellowOrange,
        Yellow,
        YellowGreen,
        Green,
        Teal,
        Blue,
        Indigo,
        Violet,
        Magenta,
        Count
    }

    public interface IAddSub
    {
        void Reduce(int value);
        void Add(int value);
    }

    public interface IPoolObject
    {
        void OnAppear();
        void OnDisappear();
    }
}
