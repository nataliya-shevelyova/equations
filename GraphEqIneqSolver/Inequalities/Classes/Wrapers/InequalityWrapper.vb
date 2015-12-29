Imports GraphEqIneqSolver.Extenders
Imports GraphEqIneqSolver.Data
Imports GraphEqIneqSolver.Inequalities.Interfaces
Imports GraphEqIneqSolver.Functions.Interfaces
Imports GraphEqIneqSolver.Utilities.Interfaces
Imports System.Collections.ObjectModel
Imports GraphEqIneqSolver.Equations.Interfaces

Namespace Inequalities.Classes.Wrapers

	Public MustInherit Class InequalityWrapper
		Implements IInequality

		Protected ReadOnly A As Double
		Protected ReadOnly B As Double
		Protected ReadOnly C As Double
		Protected ReadOnly D As Double

		Protected ReadOnly Equation As IEquation

		Sub New(ByVal equation As IEquation, Optional ByVal a As Double = Double.NaN, Optional ByVal b As Double = Double.NaN, Optional ByVal c As Double = Double.NaN, Optional ByVal d As Double = Double.NaN)
			Me.Equation = equation
			Me.A = a
			Me.B = b
			Me.C = c
			Me.D = d
		End Sub

        Public MustOverride ReadOnly Property InequalityType() As InequalityType Implements IInequality.InequalityType

        Public MustOverride ReadOnly Property AllRangeSolutions(ByVal xRange As XRange) As ReadOnlyCollection(Of XRange) Implements IInequality.AllRangeSolutions

        Public ReadOnly Property LeftPart() As IFunction Implements IExpression.LeftPart
            Get
                Return Equation.LeftPart
            End Get
        End Property

        Public ReadOnly Property RightPart() As IFunction Implements IExpression.RightPart
            Get
                Return Equation.RightPart
            End Get
        End Property

        Public ReadOnly Property PrimaryRoots() As ReadOnlyCollection(Of Double) Implements IExpression.PrimaryRoots
            Get
                Return Equation.PrimaryRoots
            End Get
        End Property

        Public ReadOnly Property XViewPoints() As ReadOnlyCollection(Of Double) Implements IExpression.XViewPoints
            Get
                Return Equation.XViewPoints
            End Get
        End Property

        Public ReadOnly Property YViewPoints() As ReadOnlyCollection(Of Double) Implements IExpression.YViewPoints
            Get
                Return Equation.YViewPoints
            End Get
        End Property

        Public Overridable ReadOnly Property TextSolutions() As ReadOnlyCollection(Of String) Implements IExpression.TextSolutions
            Get
                Dim solutions = AllRangeSolutions(New XRange(Double.NegativeInfinity, Double.PositiveInfinity))
                If Not solutions.Any() Then Return SolutionAbsent()
                Dim res = New List(Of String)
                For i = 0 To solutions.Count - 1
                    Dim range = solutions(i)
                    While i < solutions.Count - 1 AndAlso _
                     (InequalityType = InequalityType.LessOrEqual Or InequalityType = InequalityType.GreaterOrEqual) AndAlso _
                     range.Max.IsEqualTo(solutions(i + 1).Min)
                        range = New XRange(range.Min, solutions(i + 1).Max)
                        i = i + 1
                    End While
                    res.Add(RangeSolution(LeftBound, range.Min, range.Max, RightBound)(0))
                Next
                Return res.Distinct.ToList.AsReadOnly
            End Get
        End Property

		Protected ReadOnly Property LeftBound() As Char
			Get
				If InequalityType = InequalityType.Greater Or InequalityType = InequalityType.Less Then
					Return "("
				End If
				Return "["
			End Get
		End Property

		Protected ReadOnly Property RightBound() As Char
			Get
				If InequalityType = InequalityType.Greater Or InequalityType = InequalityType.Less Then
					Return ")"
				End If
				Return "]"
			End Get
		End Property

	End Class
End Namespace