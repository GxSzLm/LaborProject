﻿#pragma checksum "..\..\..\..\..\Modules\TestCmdWindow\Views\TestCmdWindowView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3955832A2F717AA3842B06BE810EDF4FB4C2DF4B"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using Gemini.Framework.Behaviors;
using LaborProject.Modules.TestCmdWindow.Views;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace LaborProject.Modules.TestCmdWindow.Views {
    
    
    /// <summary>
    /// TestCmdWindowView
    /// </summary>
    public partial class TestCmdWindowView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\..\..\Modules\TestCmdWindow\Views\TestCmdWindowView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel Panel1;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\..\Modules\TestCmdWindow\Views\TestCmdWindowView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button InitializeButton;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\..\Modules\TestCmdWindow\Views\TestCmdWindowView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ResetButton;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\..\Modules\TestCmdWindow\Views\TestCmdWindowView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock OutputWindow;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\..\Modules\TestCmdWindow\Views\TestCmdWindowView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TheTextBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/LaborProject;component/modules/testcmdwindow/views/testcmdwindowview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Modules\TestCmdWindow\Views\TestCmdWindowView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Panel1 = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            this.InitializeButton = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\..\..\Modules\TestCmdWindow\Views\TestCmdWindowView.xaml"
            this.InitializeButton.Click += new System.Windows.RoutedEventHandler(this.InitializeButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ResetButton = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\..\..\Modules\TestCmdWindow\Views\TestCmdWindowView.xaml"
            this.ResetButton.Click += new System.Windows.RoutedEventHandler(this.ResetButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.OutputWindow = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.TheTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 52 "..\..\..\..\..\Modules\TestCmdWindow\Views\TestCmdWindowView.xaml"
            this.TheTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TheTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

