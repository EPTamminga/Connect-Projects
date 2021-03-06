Imports System
Imports Connect.DNN.Modules.Projects.Controllers.ProjectTags
Imports Connect.DNN.Modules.Projects.Controllers.PTypes
Imports Connect.DNN.Modules.Projects.Controllers.Urls
Imports Connect.DNN.Modules.Projects.Repositories
Imports Connect.DNN.Modules.Projects.Models.Projects

Namespace Controllers.Projects

 Partial Public Class ProjectsController

  Public Shared Function GetProjects(moduleId As Integer) As IEnumerable(Of Project)

   Dim repo As New ProjectRepository
   Return repo.Get(moduleId)

  End Function

  Public Shared Function GetProject(moduleId As Integer, projectId As Int32) As Project

   Dim res As Project
   Dim repo As New ProjectRepository
   res = repo.GetById(projectId, moduleId)
   res.Urls = UrlsController.GetUrls(projectId)
   res.ProjectTypes = PTypesController.GetSelectionList(projectId)
   res.ProjectTags = ProjectTagsController.GetProjectTags(projectId)
   Return res

  End Function

  Public Shared Function AddProject(ByRef project As ProjectBase, createdByUser As Integer) As Integer

   project.CreatedByUserID = createdByUser
   project.CreatedOnDate = Now
   project.LastModifiedByUserID = createdByUser
   project.LastModifiedOnDate = Now
   Dim repo As New ProjectBaseRepository
   repo.Insert(project)
   Return project.ProjectId

  End Function

  Public Shared Sub UpdateProject(project As ProjectBase, updatedByUser As Integer)

   project.LastModifiedByUserID = updatedByUser
   project.LastModifiedOnDate = Now
   Dim repo As New ProjectBaseRepository
   repo.Update(project)

  End Sub

  Public Shared Sub DeleteProject(project As ProjectBase)

   Dim repo As New ProjectBaseRepository
   repo.Delete(project)

  End Sub

 End Class
End Namespace

