Imports Connect.DNN.Modules.Projects.Repositories
Imports Connect.DNN.Modules.Projects.Models.Terms

Namespace Controllers.Terms

 Partial Public Class TermsController

  Public Shared Function SearchTerms(searchString As String) As IEnumerable(Of Term)

   searchString = String.Format("%{0}%", searchString)
   Dim repo As New TermRepository
   Return repo.Find("WHERE Name LIKE @0", searchString)

  End Function

 End Class
End Namespace

