using UnityEditor;
using UnityEngine;

namespace Arkanoid.Utility
{
    /// <summary>
    /// Auto Editor Refresh (reload assembly and assets).<br/>
    /// Resets on Editor relaunch.
    /// </summary>
    public class EditorAutoRefresh
    {
        private const string kMenuItemName = "Tools/Auto Refresh";
        private const string kRefreshMsg   = "<color=green>Editor Auto Refresh is ENABLED</color>";
        private const string kNoRefreshMsg = "<color=orange>Editor Auto Refresh is DISABLED</color>";
        private static bool _isEditorLocked; // resets to false when assembly is reloaded
        
        [MenuItem(kMenuItemName)]
        private static void AutoRefreshToggle()
        {
            if (_isEditorLocked)
            {
                _isEditorLocked = false;
                EditorApplication.UnlockReloadAssemblies();
                Debug.Log(kRefreshMsg);
            }
            else
            {
                _isEditorLocked = true;
                EditorApplication.LockReloadAssemblies();
                Debug.Log(kNoRefreshMsg);
            }
        }

        [MenuItem(kMenuItemName, true)]
        private static bool AutoRefreshToggleValidation()
        {
            Menu.SetChecked(kMenuItemName, !_isEditorLocked);
            return true;
        }
    }
}