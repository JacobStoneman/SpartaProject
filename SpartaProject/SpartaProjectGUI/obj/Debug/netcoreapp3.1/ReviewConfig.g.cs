﻿#pragma checksum "..\..\..\ReviewConfig.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D481131637ED21F6238E35B9F9CED519000433FC"
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
    /// ReviewConfig
    /// </summary>
    public partial class ReviewConfig : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\ReviewConfig.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlock_rating;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\ReviewConfig.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlock_comment;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\ReviewConfig.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBox_rating_value;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\ReviewConfig.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBox_comment_value;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\ReviewConfig.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_add;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\ReviewConfig.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_update;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\ReviewConfig.xaml"
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
            System.Uri resourceLocater = new System.Uri("/SpartaProjectGUI;component/reviewconfig.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ReviewConfig.xaml"
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
            this.textBlock_rating = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.textBlock_comment = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.textBox_rating_value = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.textBox_comment_value = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.button_add = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\ReviewConfig.xaml"
            this.button_add.Click += new System.Windows.RoutedEventHandler(this.button_add_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.button_update = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\ReviewConfig.xaml"
            this.button_update.Click += new System.Windows.RoutedEventHandler(this.button_update_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.button_delete = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\ReviewConfig.xaml"
            this.button_delete.Click += new System.Windows.RoutedEventHandler(this.button_delete_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

