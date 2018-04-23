Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Text

Namespace SelectedValues

    Public NotInheritable Class DataHelper

        Private Sub New()
        End Sub

        Public Shared Function GetData(ByVal count As Integer) As BindingList(Of Record)
            Dim records As New BindingList(Of Record)()
            For i As Integer = 0 To count - 1
                records.Add(New Record() With { _
                    .ID = i, _
                    .ParentID = i Mod 10, _
                    .Text = String.Format("Text {0}", i), _
                    .Dt = Date.Today.AddDays(i), _
                    .Value = If(i Mod 2 = 0, i * 0.13D, i * 0.012D), _
                    .State = i Mod 2 = 0, _
                    .Info = String.Format("Line{0}", i) _
                })
            Next i
            Return records
        End Function
    End Class

    Public Class Record
        Implements INotifyPropertyChanged

        Public Sub New()
        End Sub

        Private id_Renamed As Integer
        Public Property ID() As Integer
            Get
                Return id_Renamed
            End Get
            Set(ByVal value As Integer)
                If id_Renamed <> value Then
                    id_Renamed = value
                    OnPropertyChanged()
                End If
            End Set
        End Property

        Private parentID_Renamed As Integer
        Public Property ParentID() As Integer
            Get
                Return parentID_Renamed
            End Get
            Set(ByVal value As Integer)
                If parentID_Renamed <> value Then
                    parentID_Renamed = value
                    OnPropertyChanged()
                End If
            End Set
        End Property

        Private text_Renamed As String
        Public Property Text() As String
            Get
                Return text_Renamed
            End Get
            Set(ByVal value As String)
                If text_Renamed <> value Then
                    text_Renamed = value
                    OnPropertyChanged()
                End If
            End Set
        End Property

        Private info_Renamed As String
        Public Property Info() As String
            Get
                Return info_Renamed
            End Get
            Set(ByVal value As String)
                If info_Renamed <> value Then
                    info_Renamed = value
                    OnPropertyChanged()
                End If
            End Set
        End Property
        Private val? As Decimal
        Public Property Value() As Decimal?
            Get
                Return val
            End Get
            Set(ByVal value? As Decimal)
                If Not val.Equals(value) Then
                    val = value
                    OnPropertyChanged()
                End If
            End Set
        End Property

        Private dt_Renamed As Date
        Public Property Dt() As Date
            Get
                Return dt_Renamed
            End Get
            Set(ByVal value As Date)
                If dt_Renamed <> value Then
                    dt_Renamed = value
                    OnPropertyChanged()
                End If
            End Set
        End Property

        Private state_Renamed As Boolean
        Public Property State() As Boolean
            Get
                Return state_Renamed
            End Get
            Set(ByVal value As Boolean)
                If state_Renamed <> value Then
                    state_Renamed = value
                    OnPropertyChanged()
                End If
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return String.Format("ID = {0}, Text = {1}", ID, Text)
        End Function

        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
        Protected Sub OnPropertyChanged(<CallerMemberName> Optional propertyName As String = "")
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
        End Sub
    End Class
End Namespace
