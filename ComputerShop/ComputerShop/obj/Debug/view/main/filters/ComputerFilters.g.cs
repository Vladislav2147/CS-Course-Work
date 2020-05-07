﻿#pragma checksum "..\..\..\..\..\view\main\filters\ComputerFilters.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B2610A0CA267261965AB1D8874D357E7E591148EA7BEB2BB84459E57D2C2D6F9"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using ComputerShop.model.converters;
using ComputerShop.model.enums;
using ComputerShop.view.main.filters;
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


namespace ComputerShop.view.main.filters {
    
    
    /// <summary>
    /// ComputerFilters
    /// </summary>
    public partial class ComputerFilters : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\..\..\..\view\main\filters\ComputerFilters.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MinCores;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\..\view\main\filters\ComputerFilters.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MaxCores;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\..\view\main\filters\ComputerFilters.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MinFrequency;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\..\view\main\filters\ComputerFilters.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MaxFrequency;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\..\view\main\filters\ComputerFilters.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MinRAM;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\..\view\main\filters\ComputerFilters.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MaxRAM;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\..\view\main\filters\ComputerFilters.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComputerType;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\..\view\main\filters\ComputerFilters.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox OS;
        
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
            System.Uri resourceLocater = new System.Uri("/ComputerShop;component/view/main/filters/computerfilters.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\view\main\filters\ComputerFilters.xaml"
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
            this.MinCores = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.MaxCores = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.MinFrequency = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.MaxFrequency = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.MinRAM = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.MaxRAM = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.ComputerType = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.OS = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

