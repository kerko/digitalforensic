Module Module1
    Dim lsFilesFound As New List(Of String)
    Sub Main()
        Try
            Dim strSearchDir As String = ""
            Dim strSavePath As String = ""
            Console.WriteLine("In welchem Verzeichnis soll gesucht werden?")
            strSearchDir = Console.ReadLine()
            Console.WriteLine("Beginne mit der Suche")
            DirctorySearch(strSearchDir)
            Console.WriteLine("Suche beendet")

            Console.WriteLine("Es wurden " & lsFilesFound.Count & " Dateien gefunden")
            Console.WriteLine("in 5 Sek. gehts weiter")

            Threading.Thread.Sleep(5000)

            If lsFilesFound.Count > 0 Then

                For Each Str As String In lsFilesFound
                    Console.WriteLine(Str)
                Next
            End If


            Console.WriteLine("Geben Sie die Datei zum Speichern der Resultate an")
            strSavePath = Console.ReadLine()
            storeResult(strSavePath)
            Console.WriteLine("Finish :-)")

            Console.ReadLine()

        Catch ex As Exception
            Console.WriteLine(ex.ToString)
            Console.ReadLine()
        End Try
    End Sub
    Sub storeResult(ByVal strPath As String)
        Try
            Dim strWriter As New IO.StreamWriter(strPath)
            If lsFilesFound.Count > 0 Then

                For Each Str As String In lsFilesFound
                    strWriter.WriteLine(Str)
                Next
                strWriter.Close()
            End If
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub
    Sub DirctorySearch(ByVal sDir As String)
        Dim d As String
        Dim f As String

        Try
            For Each d In IO.Directory.GetDirectories(sDir)
                Console.WriteLine(d)

                Try
                    For Each f In IO.Directory.GetFiles(d)
                        Try
                            Dim fi As New IO.FileInfo(f)
                            If (fi.Length Mod 1024.0) = 0 And fi.Length >= 299098 Then
                                lsFilesFound.Add(f)
                            End If
                        Catch
                        End Try
                    Next
                    DirctorySearch(d)
                Catch ex As Exception
                End Try
            Next
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub
End Module
