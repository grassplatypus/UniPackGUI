' --------------------------------------------------------------------
'   Vertical Tab Control
' --------------------------------------------------------------------
' Tab control with tabs arranged vertically on the left or right side.
'
' Code by Franz Alex Gaisie-Essilfie based on answer by Rob P.
'
' http://stackoverflow.com/a/7501638/117870
' --------------------------------------------------------------------


Option Strict On
Option Explicit On

Imports System.ComponentModel
Imports System.Linq

Namespace Global.System.Windows.Forms

    Public Class VerticalTabControl
        Inherits System.Windows.Forms.TabControl

        ''' <summary>Specifies the alignment of the tabs on a <see cref="VerticalTabControl"/>.</summary>
        Public Enum TabAlignment
            ''' <summary>Aligns tabs on the left side.</summary>
            Left
            ''' <summary>Aligns tabs on the right side.</summary>
            Right
        End Enum


        Private customItemSize As Boolean

        ''' <summary>Initializes a new instance of the <see cref="VerticalTabControl"/> class.</summary>
        Public Sub New()
            MyBase.New()

            ' set the properties on MyBase
            MyBase.SizeMode = TabSizeMode.Fixed
            MyBase.Alignment = Forms.TabAlignment.Left
            MyBase.DrawMode = TabDrawMode.OwnerDrawFixed

            ' set the properties on Me
            Me.Alignment = TabAlignment.Left
            customItemSize = False
        End Sub

        ''' <summary>
        ''' Gets or sets the area of the control (for example, along the left) where the tabs are aligned.
        ''' </summary>
        ''' <returns>One of the <see cref="T:System.Windows.Forms.VerticalTabControl.TabAlignment" /> values. The default is Left.</returns>
        '''   <PermissionSet>
        '''   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        '''   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        '''   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
        '''   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        '''   </PermissionSet>
        <DefaultValue(GetType(VerticalTabControl.TabAlignment), "Left")>
        <Description("Determines whether the tabs appear on the left or right side of the Control.")>
        Public Shadows Property Alignment As TabAlignment
            Get
                Return If(MyBase.Alignment = Forms.TabAlignment.Left, TabAlignment.Left, TabAlignment.Right)
            End Get
            Set(value As TabAlignment)
                If (value <> Me.Alignment) Then
                    If value = TabAlignment.Left Then
                        MyBase.Alignment = Forms.TabAlignment.Left
                    Else
                        MyBase.Alignment = Forms.TabAlignment.Right
                    End If

                    Me.RecreateHandle()
                End If
            End Set
        End Property

        ''' <summary>Gets or sets the images to display on the control's tabs.</summary>
        ''' <returns>An <see cref="T:System.Windows.Forms.ImageList" /> that specifies the images to display on the tabs.</returns>
        '''   <PermissionSet>
        '''   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        '''   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        '''   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
        '''   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        '''   </PermissionSet>
        <Description("The ImageList object from which this tab takes its images.")>
        Public Shadows Property ImageList As ImageList
            Get
                Return MyBase.ImageList
            End Get
            Set(value As ImageList)
                If value IsNot MyBase.ImageList Then
                    If MyBase.ImageList IsNot Nothing Then
                        RemoveHandler MyBase.ImageList.RecreateHandle, AddressOf RecreatingImageListHandle
                    End If

                    MyBase.ImageList = value

                    If value IsNot Nothing Then
                        AddHandler MyBase.ImageList.RecreateHandle, AddressOf RecreatingImageListHandle
                    End If

                    If Not customItemSize Then Me.ResetItemSize()
                End If
            End Set
        End Property

        ''' <summary>Gets or sets the size of the control's tabs.</summary>
        ''' <returns>A <see cref="T:System.Drawing.Size" /> that represents the size of the tabs.</returns>
        '''   <PermissionSet>
        '''   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        '''   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        '''   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
        '''   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        '''   </PermissionSet>
        <AmbientValue(GetType(Size), "0, 0")>
        Public Shadows Property ItemSize As Size
            Get
                ' return the flipped item size
                Return MyBase.ItemSize.FlipWH()
            End Get
            Set(value As Size)
                ' ensure the width/height is never less than 0
                If ((value.Width < 0) OrElse (value.Height < 0)) Then
                    Throw New ArgumentOutOfRangeException(
                        "ItemSize", "The width and/or height of the ItemSize cannot be less than 0.")
                End If

                ' set the flag if user has changed the item size
                value = value.FlipWH()
                customItemSize = (customItemSize) OrElse (value <> MyBase.ItemSize)

                MyBase.ItemSize = value
            End Set
        End Property

#Region "ItemSize ambient value methods."
        ''' <summary>Resets the <see cref="ItemSize"/> property.</summary>
        <EditorBrowsable(EditorBrowsableState.Never)>
        Public Sub ResetItemSize()
            MyBase.ItemSize = Me.GetDefaultItemSize().FlipWH()
            customItemSize = False
        End Sub

        ''' <summary>
        ''' Determines whether the <see cref="ItemSize"/> property should be serialized.
        ''' </summary>
        ''' <remarks>
        ''' This method indicates to designers whether the property value is different from the 
        ''' ambient value, in which case the designer should persist the value.
        ''' </remarks>
        Private Function ShouldSerializeItemSize() As Boolean
            Return customItemSize
        End Function
#End Region

#Region "Hidden inherited properties"
        <Browsable(False), Bindable(False), EditorBrowsable(EditorBrowsableState.Never)>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        <Obsolete("Not intended to be used in this class.", True)>
        Public Shadows Property DrawMode As TabDrawMode

        <Browsable(False), Bindable(False), EditorBrowsable(EditorBrowsableState.Never)>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        <Obsolete("Not intended to be used in this class.", True)>
        Public Shadows Property Multiline As Boolean

        <Browsable(False), Bindable(False), EditorBrowsable(EditorBrowsableState.Never)>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        <Obsolete("Not intended to be used in this class.", True)>
        Public Shadows Property SizeMode As TabSizeMode
#End Region

        ''' <summary>
        ''' Raises the <see cref="E:System.Windows.Forms.TabControl.DrawItem" /> event.
        ''' </summary>
        ''' <param name="e">
        ''' A <see cref="T:System.Windows.Forms.DrawItemEventArgs" /> that contains the event data.
        ''' </param>
        Protected Overrides Sub OnDrawItem(e As DrawItemEventArgs)
            MyBase.OnDrawItem(e)

            Dim g = e.Graphics
            Dim tab = Me.TabPages(e.Index)

            ' draw the white background for selected tabs
            If Me.SelectedIndex = e.Index Then
                g.FillRectangle(New SolidBrush(e.ForeColor), Me.GetTabRect(e.Index))
            End If


            ' draw the tab image if there is any to be drawn
            If TabHasValidImage(e.Index) Then
                Dim imageIndex = Me.ImageList.Images.IndexOfKey(tab.ImageKey)
                imageIndex = If(imageIndex <> -1, imageIndex, tab.ImageIndex)

                Me.ImageList.Draw(g, Me.GetTabImageRect(e.Index).Location, imageIndex)
            End If

            ' draw the text
            g.DrawString(tab.Text, Me.Font, SystemBrushes.ControlText, Me.GetTabTextRect(e.Index))
        End Sub

        ''' <summary>
        ''' This member overrides <see cref="M:System.Windows.Forms.Control.OnHandleCreated(System.EventArgs)" />.
        ''' </summary>
        ''' <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        Protected Overrides Sub OnHandleCreated(e As EventArgs)
            MyBase.OnHandleCreated(e)

            ' set the tab size
            Me.ResetItemSize()
        End Sub

        ''' <summary>Gets the size of the tab.</summary>
        Protected Overridable Function GetDefaultItemSize() As Size
            If Me.TabCount = 0 Then Return MyBase.ItemSize


            ' tab height will be the height of text with ascending and descending bar
            Dim height = TextRenderer.MeasureText("bp", Me.Font).Height
            Dim width = Me.TabPages.OfType(Of TabPage).Max(
                                    Function(t) TextRenderer.MeasureText(t.Text, Me.Font).Width + (Padding.X \ 2))


            ' adjust height & width for cases where there is an image list
            If Me.AnyTabHasValidImage() Then
                height = Math.Max(height, Me.ImageList.ImageSize.Height)
                width += Me.ImageList.ImageSize.Width + Me.Padding.X
            End If


            ' add the padding and return the result
            ' width can't be more than 128
            Return New Size(Math.Min(128, width + (2 * Padding.X)), height + (2 * Padding.Y))
        End Function

        ''' <summary>
        ''' Gets the rectangle which holds the location where the specified tab's image is drawn.
        ''' </summary>
        ''' <param name="index">The index of the tab whose image rectangle is to be calculated.</param>
        Protected Overridable Function GetTabImageRect(index As Integer) As Rectangle
            Dim rect = Me.GetTabRect(index)
            Dim imgSz = Me.ImageList.ImageSize

            rect.Inflate(-Me.Padding.X, -Me.Padding.Y)  ' remove the padding

            If Me.Alignment = TabAlignment.Left Then
                Return New Rectangle(rect.Location, imgSz)
            Else
                Return New Rectangle(New Point(rect.Right - imgSz.Width, rect.Top), imgSz)
            End If
        End Function

        ''' <summary>
        ''' Gets the rectangle which holds the location where the specified tab's text is drawn.
        ''' </summary>
        ''' <param name="index">The index of the tab whose text rectangle is to be calculated.</param>
        Protected Overridable Function GetTabTextRect(index As Integer) As Rectangle
            Dim textHeight = TextRenderer.MeasureText(Me.TabPages(index).Text, Me.Font).Height

            Dim rect = Me.GetTabRect(index)

            rect.Inflate(-Me.Padding.X, -Me.Padding.Y) ' remove the padding

            If AnyTabHasValidImage() Then
                Dim horizAdjustment = Me.ImageList.ImageSize.Width + Me.Padding.X

                rect.Width -= horizAdjustment ' reduce by image width + padding.X

                If Me.Alignment = TabAlignment.Left Then
                    rect.Offset(horizAdjustment, 0)
                End If
            End If

            Return rect
        End Function

        ''' <summary>Determines if any tab has a valid image.</summary>
        ''' <returns><c>true</c> if any tabPage has a valid image.</returns>
        Private Function AnyTabHasValidImage() As Boolean
            For i = 0 To Me.TabCount - 1
                If Me.TabHasValidImage(i) Then
                    Return True
                End If
            Next

            Return False
        End Function

        ''' <summary>Determines whether the tabPage with the specified index has valid image.</summary>
        ''' <param name="index">The index of the tabPage.</param>
        ''' <returns><c>true</c> if the tabPage has a valid image; otherwise false.</returns>
        Private Function TabHasValidImage(index As Integer) As Boolean
            Dim tab = Me.TabPages(index)

            Return (Me.ImageList IsNot Nothing AndAlso Not Me.ImageList.Images.Empty) AndAlso
                   (tab.ImageIndex.IsInRange(0, Me.ImageList.Images.Count - 1) OrElse
                    Me.ImageList.Images.Keys.Contains(tab.ImageKey))
        End Function

        Private Sub RecreatingImageListHandle(sender As Object, e As EventArgs)
            If Not customItemSize Then Me.ResetItemSize()
        End Sub

    End Class

    ''' <summary>
    ''' Extension methods for the <see name="System.Windows.Forms.VerticalTabControl"/> control.
    ''' </summary>
    Friend Module VerticalTabControlExtensions
        ''' <summary>Determines whether the specified value is in the specified range.</summary>
        ''' <typeparam name="T">The type of the items to be compared</typeparam>
        ''' <param name="value">The value to be evaluated.</param>
        ''' <param name="min">The minimum bounds (inclusive) of the range.</param>
        ''' <param name="max">The maximum bounds (inclusive) of the range.</param>
        ''' <returns>
        ''' <c>true</c> if <paramref name="value"/> is lies within the range specified 
        ''' <paramref name="min"/> and <paramref name="max"/> (boundaries inclusive).
        ''' </returns>
        <Runtime.CompilerServices.Extension()>
        <DebuggerStepThrough()>
        Public Function IsInRange(Of T As IComparable(Of T))(value As T, min As T, max As T) As Boolean
            Return value.CompareTo(min) >= 0 AndAlso value.CompareTo(max) <= 0
        End Function

        ''' <summary>Flips the width and height of the specified System.Drawing.Size variable.</summary>
        ''' <param name="sz">The size variable whose width and height are to be flipped.</param>
        <Runtime.CompilerServices.Extension()>
        <DebuggerStepThrough()>
        Public Function FlipWH(sz As Size) As Size
            Return New Size(sz.Height, sz.Width)
        End Function
    End Module
End Namespace