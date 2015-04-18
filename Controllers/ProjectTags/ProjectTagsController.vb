Imports System
Imports System.Linq
Imports Connect.DNN.Modules.Projects.Repositories
Imports Connect.DNN.Modules.Projects.Models.ProjectTags
Imports Connect.DNN.Modules.Projects.Models.Terms
Imports DotNetNuke.Data

Namespace Controllers.ProjectTags

 Partial Public Class ProjectTagsController

  Public Shared Function GetProjectTags(projectId As Int32) As IEnumerable(Of ProjectTag)

   Dim repo As New ProjectTagRepository
   Return repo.Find("WHERE ProjectId = @0", projectId)

  End Function

  Public Shared Sub SetProjectTags(projectId As Integer, tags As IEnumerable(Of ProjectTag))
   Dim tagIds As New List(Of String)
   Dim tc As New DotNetNuke.Entities.Content.Taxonomy.TermController
   For Each t As ProjectTag In tags
    If t.TermId < 0 Then
     Dim newTerm As String = t.Name.Trim
     newTerm = newTerm.Substring(0, 1).ToUpper() + newTerm.Substring(1)
     Dim termsExists As DotNetNuke.Entities.Content.Taxonomy.Term = tc.GetTermsByVocabulary(1).FirstOrDefault(Function(t1) t1.Name = newTerm)
     If termsExists Is Nothing Then
      Dim term As New DotNetNuke.Entities.Content.Taxonomy.Term(newTerm, "", 1)
      tagIds.Add(tc.AddTerm(term).ToString())
     Else
      tagIds.Add(termsExists.TermId.ToString())
     End If
    Else
     tagIds.Add(t.TermId.ToString())
    End If
   Next
   DataProvider.Instance().ExecuteNonQuery("Connect_Projects_SetProjectTags", projectId, String.Join(",", tagIds))
  End Sub

 End Class
End Namespace

