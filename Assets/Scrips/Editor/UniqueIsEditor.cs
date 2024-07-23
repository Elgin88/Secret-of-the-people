using System;
using UnityEditor;
using UnityEngine;

namespace Scripts.Editor
{
    [CustomEditor(typeof(UniqueId))]

    public class UniqueIsEditor : UnityEditor.Editor
    {
        private void OnEnable()
        {
            var uniqueID = (UniqueId)target;

            if (string.IsNullOrEmpty(uniqueID.Id))
            {
                Generate(uniqueID);
            }
        }

        private void Generate(UniqueId uniqueId)
        {
            uniqueId.Id = Guid.NewGuid().ToString();

            if (!Application.isPlaying)
            {
                EditorUtility.SetDirty(uniqueId);

            }
        }
    }

    internal class UniqueId : MonoBehaviour
    {
        internal string Id;
    }
}