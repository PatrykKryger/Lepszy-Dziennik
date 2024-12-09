﻿#pragma checksum "..\..\TeacherWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6CFE04FE3044C5EDED9689C96029A7AD273AB648CDBAA1B0CA4F78EB54D31A16"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using Dziennik;
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


namespace Dziennik {
    
    
    /// <summary>
    /// TeacherWindow
    /// </summary>
    public partial class TeacherWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\TeacherWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox StudentsListBox;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\TeacherWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock SelectedStudentName;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\TeacherWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock SelectedStudentPoints;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\TeacherWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NewPointsTextBox;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\TeacherWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox SubjectsComboBox;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\TeacherWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NewGradeTextBox;
        
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
            System.Uri resourceLocater = new System.Uri("/Dziennik;component/teacherwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\TeacherWindow.xaml"
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
            this.StudentsListBox = ((System.Windows.Controls.ListBox)(target));
            
            #line 13 "..\..\TeacherWindow.xaml"
            this.StudentsListBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.StudentsListBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.SelectedStudentName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.SelectedStudentPoints = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.NewPointsTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            
            #line 32 "..\..\TeacherWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.UpdatePoints_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.SubjectsComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.NewGradeTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            
            #line 45 "..\..\TeacherWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddGrade_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

