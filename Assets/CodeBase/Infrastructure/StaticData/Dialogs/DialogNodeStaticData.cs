using System;
using NaughtyAttributes;
using UnityEngine;

namespace CodeBase.Infrastructure.StaticData.Dialogs
{
    [Serializable]
    [CreateAssetMenu(fileName = "DialogNode", menuName = "StaticData/DialogNode", order = 0)]
    public class DialogNodeStaticData : ScriptableObject
    {
        public NextNodeData[] NextNodes = new NextNodeData[0];

        public string Name;

        [TextArea]
        public string Text;

        public Sprite icon;


        [Space(10)]
        public bool HaveCallback=false;
        [ShowIf("HaveCallback")] public int CallbackId;
    }

    [Serializable]
    public class NextNodeData
    {
        public DialogNodeStaticData NextNode;
        public string ContinueButtonLabel = "ок";
    }
}