﻿' 游戏的方块类
' 包括：（蛇头：一个方块，蛇身：若干个方块，苹果：一个方块。)
' 每个方块是一个近似19 * 19的正方形，具体式样见【像素设计.xlsx】
Public Class Block
    Private _locatingPoint As Point  ' 定位点(在方块的中心)
    Private _bodyPoints As New ArrayList()  ' 方块体的点集合
    Private _color As Color  ' 方块颜色

    ' 蛇头：红色
    Public Shared ReadOnly Color_SnakeHead As Color = Color.Red
    ' 蛇身：天空蓝
    Public Shared ReadOnly Color_SnakeBody As Color = Color.SkyBlue
    ' 苹果：绿色
    Public Shared ReadOnly Color_Apple As Color = Color.LightGreen

    ' 构造函数
    Public Sub New(locatingPoint As Point, color As Color)
        _locatingPoint = locatingPoint
        _color = color
        CreateBody()
    End Sub

    ' 生成方块体
    Private Sub CreateBody()
        BodyPoints.Clear()  ' 清空方块体的点集合
        For locationX As Integer = LocatingPoint.X - 9 To LocatingPoint.X + 9  ' 横坐标范围
            For locationY As Integer = LocatingPoint.Y - 9 To LocatingPoint.Y + 9  ' 纵坐标范围
                If Math.Abs(locationX - LocatingPoint.X) = 9 AndAlso Math.Abs(locationY - LocatingPoint.Y) >= 7 Then  ' 不在方块内
                    Continue For
                End If
                If Math.Abs(locationX - LocatingPoint.X) = 8 AndAlso Math.Abs(locationY - LocatingPoint.Y) >= 8 Then  ' 不在方块内
                    Continue For
                End If
                If Math.Abs(locationX - LocatingPoint.X) = 7 AndAlso Math.Abs(locationY - LocatingPoint.Y) >= 9 Then  ' 不在方块内
                    Continue For
                End If

                Dim point As Point = New Point(locationX, locationY)  ' 新建像素点
                BodyPoints.Add(point)  ' 放入方块体
            Next
        Next
    End Sub

    Public Property LocatingPoint As Point
        Get
            Return _locatingPoint
        End Get
        Set(value As Point)
            _locatingPoint = value
        End Set
    End Property

    Public Property BodyPoints As ArrayList
        Get
            Return _bodyPoints
        End Get
        Set(value As ArrayList)
            _bodyPoints = value
        End Set
    End Property

    Public Property Color As Color
        Get
            Return _color
        End Get
        Set(value As Color)
            _color = value
        End Set
    End Property
End Class