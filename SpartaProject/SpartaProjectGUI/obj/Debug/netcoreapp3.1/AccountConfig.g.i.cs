﻿#pragma checksum "..\..\..\AccountConfig.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3FBF7885F01FD0461AAF29BDE385113C0EEA09A7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SpartaProjectGUI;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace SpartaProjectGUI {
    
    
    /// <summary>
    /// AccountConfig
    /// </summary>
    public partial class AccountConfig : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\AccountConfig.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlock_userID;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\AccountConfig.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlock_name;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\AccountConfig.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlock_accountType;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\AccountConfig.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlock_userID_value;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\AccountConfig.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBox_name_value;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\AccountConfig.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton radioButton_customer;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\AccountConfig.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton radioButton_seller;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\AccountConfig.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_add;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\AccountConfig.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_update;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\AccountConfig.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_delete;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SpartaProjectGUI;component/accountconfig.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\AccountConfig.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.textBlock_userID = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.textBlock_name = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.textBlock_accountType = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.textBlock_userID_value = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.textBox_name_value = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.radioButton_customer = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 7:
            this.radioButton_seller = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 8:
            this.button_add = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\AccountConfig.xaml"
            this.button_add.Click += new System.Windows.RoutedEventHandler(this.button_add_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.button_update = ((System.Windows.Controls.Button)(target));
            return;
            case 10:
            this.button_delete = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

