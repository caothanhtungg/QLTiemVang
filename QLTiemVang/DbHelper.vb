Imports System.Configuration
Imports System.Data.SqlClient

Module DbHelper
    Private ReadOnly connStr As String = ConfigurationManager.ConnectionStrings("connStr").ConnectionString

    Public Function GetTable(sql As String, Optional prms As List(Of SqlParameter) = Nothing) As DataTable
        Dim dt As New DataTable()
        Using conn As New SqlConnection(connStr)
            Using cmd As New SqlCommand(sql, conn)
                If prms IsNot Nothing Then cmd.Parameters.AddRange(prms.ToArray())
                Using da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    Public Function ExecNonQuery(sql As String, Optional prms As List(Of SqlParameter) = Nothing) As Integer
        Using conn As New SqlConnection(connStr)
            conn.Open()
            Using cmd As New SqlCommand(sql, conn)
                If prms IsNot Nothing Then cmd.Parameters.AddRange(prms.ToArray())
                Return cmd.ExecuteNonQuery()
            End Using
        End Using
    End Function

    Public Function ExecScalar(Of T)(sql As String, Optional prms As List(Of SqlParameter) = Nothing) As T
        Using conn As New SqlConnection(connStr)
            conn.Open()
            Using cmd As New SqlCommand(sql, conn)
                If prms IsNot Nothing Then cmd.Parameters.AddRange(prms.ToArray())
                Dim o = cmd.ExecuteScalar()
                If o Is Nothing OrElse o Is DBNull.Value Then Return Nothing
                Return CType(o, T)
            End Using
        End Using
    End Function
End Module
