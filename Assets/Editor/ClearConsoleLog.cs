using System.Reflection;
using UnityEditor;

namespace OOOne.Tools.Editor
{
    public static class ClearConsoleLog
    {
        [MenuItem("Tools/ClearLog %&c")]
        static void ClearLog()
        {
            Assembly assembly = Assembly.GetAssembly(typeof(SceneView));
            System.Type type   = assembly.GetType("UnityEditor.LogEntries");
            MethodInfo  method = type.GetMethod("Clear");
            method.Invoke(new object() , null);
        }
    }
}