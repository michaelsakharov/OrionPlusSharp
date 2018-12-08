namespace Engine
{
    namespace My
    {
        [global::System.Runtime.CompilerServices.CompilerGenerated()]
        [global::System.CodeDom.Compiler.GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.1.0.0")]
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal sealed partial class MySettings : global::System.Configuration.ApplicationSettingsBase
        {
            private static MySettings defaultInstance = (MySettings)global::System.Configuration.ApplicationSettingsBase.Synchronized(new MySettings());

            
            public static MySettings Default
            {
                get
                {

                    
                    return defaultInstance;
                }
            }
        }
    }

    namespace My
    {
        [global::Microsoft.VisualBasic.HideModuleName()]
        [global::System.Diagnostics.DebuggerNonUserCode()]
        [global::System.Runtime.CompilerServices.CompilerGenerated()]
        internal static class MySettingsProperty
        {
            [global::System.ComponentModel.Design.HelpKeyword("My.Settings")]
            internal static global::Engine.My.MySettings Settings
            {
                get
                {
                    return global::Engine.My.MySettings.Default;
                }
            }
        }
    }
}
