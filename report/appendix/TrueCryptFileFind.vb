Module Module1
    Dim lsFilesFound As New List(Of String)
    Sub Main()
        Try
            Dim strSearchDir As String = ""
            Dim strSavePath As String = ""
            Dim strProgramParma As String = ""
            Console.WriteLine("*******************************************")
            Console.WriteLine("*Prameter:")
            Console.WriteLine("*1 - Startet die Suche nach TC Container")
            Console.WriteLine("*2 - Startet die Suche nach KeyFiles")

            strProgramParma = Console.ReadLine(0)

            Console.WriteLine("In welchem Verzeichnis soll gesucht werden?")
            strSearchDir = Console.ReadLine()
            Console.WriteLine("Beginne mit der Suche")

            Select Case strProgramParma
                Case "1"
                    DirctorySearch(strSearchDir)
                Case "2"
                    KeyFileSearch(strSearchDir)
            End Select

            Console.WriteLine("Suche beendet")

            Console.WriteLine("Es wurden " & lsFilesFound.Count &_
            & " Dateien gefunden")
            Console.WriteLine("in 5 Sek. gehts weiter")

            Threading.Thread.Sleep(5000)

            If lsFilesFound.Count > 0 Then

                For Each Str As String In lsFilesFound
                    Console.WriteLine(Str)
                Next

                Console.WriteLine("Geben Sie die Datei zum " &_
                " Speichern der Resultate an")
                strSavePath = Console.ReadLine()
                storeResult(strSavePath)
                Console.WriteLine("Finish :-)")

            End If

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
    Sub KeyFileSearch(ByVal sDir As String)
        Dim d As String
        Dim f As String

        Try
            For Each d In IO.Directory.GetDirectories(sDir)
                Console.WriteLine(d)

                Try
                    For Each f In IO.Directory.GetFiles(d)
                        Try
                            Dim fi As New IO.FileInfo(f)
                            If fi.Length = 64 Then
                                lsFilesFound.Add(f)
                            End If
                        Catch
                        End Try
                    Next
                    KeyFileSearch(d)
                Catch ex As Exception
                End Try
            Next
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
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
                            If (fi.Length Mod 1024.0) = 0 &_
                            And fi.Length >= 299098 Then
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
