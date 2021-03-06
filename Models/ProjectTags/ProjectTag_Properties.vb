Imports System
Imports System.Runtime.Serialization
Imports DotNetNuke.ComponentModel.DataAnnotations

Namespace Models.ProjectTags

  <TableName("vw_Connect_Projects_ProjectTags")>  <DataContract()>
  Partial Public Class ProjectTag
  Inherits ProjectTagBase

#Region " Private Members "
#End Region
	
#Region " Constructors "
  Public Sub New()
   MyBase.New()
  End Sub
#End Region

#Region " Public Properties "
  Public Property VocabularyID As Int32 = -1
  Public Property ParentTermID As Int32
  <DataMember()>
  Public Property Name As String = ""
  Public Property Description As String = ""
  Public Property Weight As Int32 = -1
  Public Property TermLeft As Int32 = -1
  Public Property TermRight As Int32 = -1
  Public Property CreatedByUserID As Int32?
  Public Property CreatedOnDate As Date
  Public Property LastModifiedByUserID As Int32?
  Public Property LastModifiedOnDate As Date
#End Region

#Region " Public Methods "
  Public Function GetProjectTagBase() As ProjectTagBase
   Dim base As New ProjectTagBase
   base.NrProjects = NrProjects
   base.ProjectId = ProjectId
   base.TermId = TermId
   Return base
  End Function
#End Region

 End Class
End Namespace


