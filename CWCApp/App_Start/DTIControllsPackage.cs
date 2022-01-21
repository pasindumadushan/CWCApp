using System;

[assembly: WebActivatorEx.PreApplicationStartMethod(
    typeof(CWCApp.App_Start.DTIControllsPackage), "PreStart")]

namespace CWCApp.App_Start {
    public static class DTIControllsPackage {
        public static void PreStart() {
            DTIControls.Share.initializePathProvider();
        }
    }
}