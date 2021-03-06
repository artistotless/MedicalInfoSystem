#pragma checksum "..\..\..\frames\WarehousesAddPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8F42D5CF7945723C3172470C8A9A2F18CBDEFAD8"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using MedicalTrader;
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


namespace MedicalTrader {
    
    
    /// <summary>
    /// WarehousesAddPage
    /// </summary>
    public partial class WarehousesAddPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\frames\WarehousesAddPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button openExcel;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\frames\WarehousesAddPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox name;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\frames\WarehousesAddPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox region;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\frames\WarehousesAddPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox address;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\frames\WarehousesAddPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox employeeList;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\frames\WarehousesAddPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem employeeListItems;
        
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
            System.Uri resourceLocater = new System.Uri("/MedicalTrader;component/frames/warehousesaddpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\frames\WarehousesAddPage.xaml"
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
            this.openExcel = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\frames\WarehousesAddPage.xaml"
            this.openExcel.Click += new System.Windows.RoutedEventHandler(this.SaveWarehouse);
            
            #line default
            #line hidden
            return;
            case 2:
            this.name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.region = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.address = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.employeeList = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.employeeListItems = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

