﻿#pragma checksum "..\..\..\DataSearch.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B14381C3FD46CDB1D9C30B6EFD39651976F18460"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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
using connectFour;


namespace connectFour {
    
    
    /// <summary>
    /// DataSearch
    /// </summary>
    public partial class DataSearch : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\DataSearch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid mainGrid;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\DataSearch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ColumnDefinition dataCol;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\DataSearch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RowDefinition dataRow;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\DataSearch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox searchOption;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\DataSearch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox users;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\DataSearch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock playersData;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\DataSearch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button searchBtn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/connectFour;component/datasearch.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\DataSearch.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.mainGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.dataCol = ((System.Windows.Controls.ColumnDefinition)(target));
            return;
            case 3:
            this.dataRow = ((System.Windows.Controls.RowDefinition)(target));
            return;
            case 4:
            this.searchOption = ((System.Windows.Controls.ComboBox)(target));
            
            #line 29 "..\..\..\DataSearch.xaml"
            this.searchOption.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.searchOption_SelectionChangedAsync);
            
            #line default
            #line hidden
            return;
            case 5:
            this.users = ((System.Windows.Controls.ListBox)(target));
            return;
            case 6:
            this.playersData = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.searchBtn = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\..\DataSearch.xaml"
            this.searchBtn.Click += new System.Windows.RoutedEventHandler(this.DataSearch_ClickedAsync);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

