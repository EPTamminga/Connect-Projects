Imports System
Imports Connect.DNN.Modules.Projects.Repositories
Imports Connect.DNN.Modules.Projects.Models.ProjectTypes
Imports DotNetNuke.Data

Namespace Controllers.ProjectTypes

 Partial Public Class ProjectTypesController

  Public Shared Function GetProjectTypes(projectId As Int32) As IEnumerable(Of ProjectType)

   Dim repo As New ProjectTypeRepository
   Return repo.Find("WHERE ProjectId=@0", projectId)

  End Function

  Public Shared Sub SetProjectTypes(projectId As Integer, typeIds As List(Of Integer))
   DataProvider.Instance().ExecuteNonQuery("Connect_Projects_SetProjectTypes", projectId, String.Join(",", typeIds))
  End Sub

  Public Shared Function GetProjectType(projectId As Int32, typeId As Int32) As ProjectType

   Dim repo As New ProjectTypeRepository
   Return repo.GetById(projectId, typeId)

  End Function

  Public Shared Sub AddProjectType(projecttype As ProjectTypeBase)

   Dim repo As New ProjectTypeBaseRepository
   repo.Insert(projecttype)

  End Sub

  Public Shared Sub UpdateProjectType(projecttype As ProjectTypeBase)

   Dim repo As New ProjectTypeBaseRepository
   repo.Update(projecttype)

  End Sub

  Public Shared Sub DeleteProjectType(projecttype As ProjectTypeBase)

   Dim repo As New ProjectTypeBaseRepository
   repo.Delete(projecttype)

  End Sub

 End Class
End Namespace

