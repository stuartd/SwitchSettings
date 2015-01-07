using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using EnvDTE;
using EnvDTE80;
using Microsoft.Win32;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;

namespace Mosaic.SwitchSettings
{
    /// <summary>
    /// This is the class that implements the package exposed by this assembly.
    ///
    /// The minimum requirement for a class to be considered a valid package for Visual Studio
    /// is to implement the IVsPackage interface and register itself with the shell.
    /// This package uses the helper classes defined inside the Managed Package Framework (MPF)
    /// to do it: it derives from the Package class that provides the implementation of the 
    /// IVsPackage interface and uses the registration attributes defined in the framework to 
    /// register itself and its components with the shell.
    /// </summary>
    // This attribute tells the PkgDef creation utility (CreatePkgDef.exe) that this class is
    // a package.
    [PackageRegistration(UseManagedResourcesOnly = true)]
    // This attribute is used to register the information needed to show this package
    // in the Help/About dialog of Visual Studio.
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    // This attribute is needed to let the shell know that this package exposes some menus.
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(GuidList.guidSwitchSettingsPkgString)]
    public sealed class SwitchSettingsPackage : Package
    {
        protected override void Initialize()
        {
            // Add our command handlers for menu (commands must exist in the .vsct file)
            OleMenuCommandService mcs = GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if ( null != mcs )
            {
                // Create the command for the menu item.
                CommandID menuCommandID = new CommandID(GuidList.guidSwitchSettingsCmdSet, (int)PkgCmdIDList.cmdSingle);
                MenuCommand menuItem = new MenuCommand(SingleMenuItemCallback, menuCommandID );
                mcs.AddCommand( menuItem );

                menuCommandID = new CommandID(GuidList.guidSwitchSettingsCmdSet, (int)PkgCmdIDList.cmdDual);
                menuItem = new MenuCommand(DualMenuItemCallback, menuCommandID);
                mcs.AddCommand(menuItem);
            }
        }
       

        private void SingleMenuItemCallback(object sender, EventArgs e)
        {
            DTE2 dte = (DTE2)GetService(typeof(DTE));
            dte.ExecuteCommand("Tools.ImportandExportSettings",
                                              @"/import:""C:\settings\single.vssettings""");
        }

      
        private void DualMenuItemCallback(object sender, EventArgs e)
        {
            DTE2 dte = (DTE2)GetService(typeof(DTE));
            dte.ExecuteCommand("Tools.ImportandExportSettings",
                                              @"/import:""C:\settings\dual.vssettings""");
        }

    }
}
