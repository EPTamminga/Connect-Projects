Imports DotNetNuke.ComponentModel.DataAnnotations
Imports System.Runtime.Serialization

Namespace Models.PTypes

  <TableName("Connect_Projects_PTypes")>
  <PrimaryKey("TypeId", AutoIncrement:=True)>
  <DataContract()>
  Partial Public Class PType
  Inherits PTypeBase

#Region " Private Members "
#End Region
	
#Region " Constructors "
  Public Sub New()
   MyBase.New()
  End Sub
#End Region

#Region " Public Methods "
  Public Function GetPTypeBase() As PTypeBase
   Dim base As New PTypeBase
   base.TypeDescription = TypeDescription
   base.TypeIcon = TypeIcon
   base.TypeId = TypeId
   Return base
  End Function
#End Region

 End Class
End Namespace

