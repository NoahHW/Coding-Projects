
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic.ApplicationServices
Imports MySql.Data.MySqlClient

Public Class DbManager
    Private Property connectionString = "server=localhost;user id=root;password=;database=vb_finalblockproject"
    Private Property connect As MySqlConnection

    'constructor
    Public Sub New()
        Try
            Me.connect = New MySqlConnection(connectionString)
            Me.connect.Open()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Connection Failed")
        End Try
    End Sub
    ''' <summary>
    ''' test the connection
    ''' </summary>
    Public Sub TestConnection()
        If Me.connect.State = ConnectionState.Open Then
            MsgBox("I am openn")
        Else
            MsgBox("Not open yet!")
        End If
    End Sub



    'This Function is to get all the information from a single index 
    Public Function GetSingleAdmin(id As Integer) As employee



        Dim query As String = "SELECT * FROM employee WHERE id = " & id
        Dim user As New employee

        Try
            Dim cmd As New MySqlCommand(query, Me.connect)
            Dim reader As MySqlDataReader = cmd.ExecuteReader

            If reader.Read Then
                user.id = reader.GetInt16(0)
                user.employeenumber = reader.GetString(1)
                user.Password = reader.GetString(2)
            End If
            reader.Close()
        Catch ex As Exception

        End Try

        Return user
    End Function


    'This sub is to edit the admin by id
    Public Sub EditAdmin(Admin As employee)
        Dim cmd As New MySqlCommand

        Try
            cmd.Connection = Me.connect
            cmd.CommandText = " UPDATE employee SET password = @password WHERE id = @id "
            cmd.Parameters.AddWithValue("@password", Admin.password)
            cmd.Parameters.AddWithValue("@id", Admin.id)

            Dim rowAffected = cmd.ExecuteNonQuery
            MsgBox("Password Updated succesfully")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Connectionn Faild")
        End Try
    End Sub

    'This function takes the users username and gives what index it's at in the database
    Public Function UsertoId(employeenumber As String) As employee


        Dim query As String = "SELECT * FROM employee WHERE "
        query += "Employeenumber = '" & employeenumber & "'"
        Dim user As New employee

        Try
            Dim cmd As New MySqlCommand(query, Me.connect)
            Dim reader As MySqlDataReader = cmd.ExecuteReader

            If reader.Read Then
                user.id = reader.GetInt16(0)
            End If
            reader.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Connectionn Failed")
        End Try

        Return user
    End Function


    'This sub is to create an employee 

    Public Sub CreateEmployee(worker As employee)
        Dim cmd As New MySqlCommand

        Try
            cmd.Connection = Me.connect
            cmd.CommandText = "INSERT INTO employee VALUES(default, @Firstname, @Lastname, @Dob, @Address, @City, @Province, @PostalCode, @CellPhone, @Employeenumber, @Password, @Sin, @Salary, @DateStarted, @Degree, @Level,default)"
            cmd.Parameters.AddWithValue("@Firstname", worker.firstname)
            cmd.Parameters.AddWithValue("@Lastname", worker.lastname)
            cmd.Parameters.AddWithValue("@Dob", worker.dob)
            cmd.Parameters.AddWithValue("@Address", worker.address)
            cmd.Parameters.AddWithValue("@City", worker.city)
            cmd.Parameters.AddWithValue("@Province", worker.province)
            cmd.Parameters.AddWithValue("@PostalCode", worker.postalcode)
            cmd.Parameters.AddWithValue("@CellPhone", worker.cellphone)
            cmd.Parameters.AddWithValue("@Employeenumber", worker.employeenumber)
            cmd.Parameters.AddWithValue("@Password", worker.password)
            cmd.Parameters.AddWithValue("@Sin", worker.sin)
            cmd.Parameters.AddWithValue("@Salary", worker.salary)
            cmd.Parameters.AddWithValue("@DateStarted", worker.datestarted)
            cmd.Parameters.AddWithValue("@Degree", worker.degree)
            cmd.Parameters.AddWithValue("@Level", worker.level)

            Dim rowAffected = cmd.ExecuteNonQuery
            MsgBox("Employee succesfully created")

        Catch ex As Exception
            MsgBox("Employee Number already exists leave the page and return so that the employee number can change", MsgBoxStyle.Critical, "Error")
        End Try

    End Sub


    'This Function is to get all the information from a single index 
    Public Function GetSingleEmployee(id As Integer) As employee



        Dim query As String = "SELECT * FROM employee WHERE id = " & id
        Dim employee As New employee

        Try
            Dim cmd As New MySqlCommand(query, Me.connect)
            Dim reader As MySqlDataReader = cmd.ExecuteReader

            If reader.Read Then
                employee.id = reader.GetInt16(0)
                employee.firstname = reader.GetString(1)
                employee.lastname = reader.GetString(2)
                employee.dob = reader.GetString(3)
                employee.address = reader.GetString(4)
                employee.city = reader.GetString(5)
                employee.province = reader.GetString(6)
                employee.postalcode = reader.GetString(7)
                employee.cellphone = reader.GetString(8)
                employee.employeenumber = reader.GetString(9)
                employee.password = reader.GetString(10)
                employee.sin = reader.GetString(11)
                employee.salary = reader.GetString(12)
                employee.datestarted = reader.GetString(13)
                employee.degree = reader.GetString(14)
                employee.level = reader.GetString(15)
                employee.Status = reader.GetString(16)
            End If
            reader.Close()
        Catch ex As Exception

        End Try

        Return employee
    End Function

    'This sub is used to delete the employee by entering there id

    Public Sub DeleteEmployee(id As Integer)
        Dim cmd As New MySqlCommand
        Try
            cmd.Connection = Me.connect
            cmd.CommandText = "UPDATE employee SET status = 0 WHERE id = " & id

            Dim rowAffected = cmd.ExecuteNonQuery
            MsgBox("Employee Successfully deactivated")

        Catch ex As Exception
            MsgBox("Index doesn't exist" & vbCrLf & "The number of the id must be in the table right next to it", MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    'This sub is to edit the employee 
    Public Sub Editemployee(employee As employee)
        Dim cmd As New MySqlCommand

        Try
            cmd.Connection = Me.connect
            cmd.CommandText = "UPDATE employee SET Firstname = @firstname, Lastname = @lastname, Dob = @dob, Address = @address, City = @city, Province = @province, Postalcode = @postalcode, CellPhone = @cellphone, Sin = @sin, Salary = @salary, Datestarted = @datestarted, Degree = @degree,Level = @level WHERE id = @id"
            cmd.Parameters.AddWithValue("@firstname", employee.firstname)
            cmd.Parameters.AddWithValue("@lastname", employee.lastname)
            cmd.Parameters.AddWithValue("@dob", employee.dob)
            cmd.Parameters.AddWithValue("@address", employee.address)
            cmd.Parameters.AddWithValue("@city", employee.city)
            cmd.Parameters.AddWithValue("@province", employee.province)
            cmd.Parameters.AddWithValue("@postalcode", employee.postalcode)
            cmd.Parameters.AddWithValue("@cellPhone", employee.cellphone)
            cmd.Parameters.AddWithValue("@sin", employee.sin)
            cmd.Parameters.AddWithValue("@salary", employee.salary)
            cmd.Parameters.AddWithValue("@datestarted", employee.datestarted)
            cmd.Parameters.AddWithValue("@degree", employee.degree)
            cmd.Parameters.AddWithValue("@level", employee.level)
            cmd.Parameters.AddWithValue("@id", employee.id)




            Dim rowAffected = cmd.ExecuteNonQuery
            MsgBox("Employee Updated succesfully")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Connectionn Faild")
        End Try
    End Sub


    'This sub is to create an video 

    Public Sub CreateVideo(movie As movie)
        Dim cmd As New MySqlCommand

        Try
            cmd.Connection = Me.connect
            cmd.CommandText = "INSERT INTO videos VALUES(@video_id, @photo, @title, @year, @country, @language, @length, @resume, @genre, @actors, @director, default)"
            cmd.Parameters.AddWithValue("@video_id", movie.videoid)
            cmd.Parameters.AddWithValue("@photo", movie.photo)
            cmd.Parameters.AddWithValue("@Title", movie.title)
            cmd.Parameters.AddWithValue("@year", movie.year)
            cmd.Parameters.AddWithValue("@country", movie.country)
            cmd.Parameters.AddWithValue("@language", movie.language)
            cmd.Parameters.AddWithValue("@length", movie.length)
            cmd.Parameters.AddWithValue("@resume", movie.resumes)
            cmd.Parameters.AddWithValue("@genre", movie.genre)
            cmd.Parameters.AddWithValue("@actors", movie.Actors)
            cmd.Parameters.AddWithValue("@director", movie.director)

            Dim rowAffected = cmd.ExecuteNonQuery
            MsgBox("Movie succesfully created")

        Catch ex As Exception
            MsgBox("Video Number already exists leave the page and return so that the video number can change", MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    'This loads the url from the link you input
    Public Sub LoadImageFromUrl(ByRef url As String, ByVal pb As PictureBox)
        Try
            Dim request As Net.HttpWebRequest = DirectCast(Net.HttpWebRequest.Create(url), Net.HttpWebRequest)
            Dim response As Net.HttpWebResponse = DirectCast(request.GetResponse, Net.HttpWebResponse)
            Dim img As Image = Image.FromStream(response.GetResponseStream())
            response.Close()
            pb.SizeMode = PictureBoxSizeMode.StretchImage
            pb.Image = img
        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            MsgBox("Image from the link doesn't exist", MsgBoxStyle.Critical)
        End Try
    End Sub

    'This sub is used to delete the video by entering there videoid

    Public Sub DeleteVideo(video_id As Integer)
        Dim cmd As New MySqlCommand
        Try
            cmd.Connection = Me.connect
            cmd.CommandText = "UPDATE videos SET status = 0 WHERE video_id = " & video_id

            Dim rowAffected = cmd.ExecuteNonQuery
            MsgBox("Video Successfully deactivated")

        Catch ex As Exception
            MsgBox("Index doesn't exist" & vbCrLf & "The number of the id must be in the table right next to it", MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    'This function is used to get the a single video by videoid
    Public Function GetSingleVideo(video_id As Integer) As movie



        Dim query As String = "SELECT * FROM videos WHERE video_id = " & video_id
        Dim movie As New movie

        Try
            Dim cmd As New MySqlCommand(query, Me.connect)
            Dim reader As MySqlDataReader = cmd.ExecuteReader

            If reader.Read Then
                movie.videoid = reader.GetString(0)
                movie.photo = reader.GetString(1)
                movie.title = reader.GetString(2)
                movie.year = reader.GetString(3)
                movie.country = reader.GetString(4)
                movie.language = reader.GetString(5)
                movie.length = reader.GetString(6)
                movie.resumes = reader.GetString(7)
                movie.genre = reader.GetString(8)
                movie.Actors = reader.GetString(9)
                movie.director = reader.GetString(10)
                movie.status = reader.GetString(11)
            End If
            reader.Close()
        Catch ex As Exception

        End Try

        Return movie
    End Function
    'This sub is used to ediy the video 
    Public Sub Editvideo(movie As movie)
        Dim cmd As New MySqlCommand

        Try
            cmd.Connection = Me.connect
            cmd.CommandText = "UPDATE videos SET photo = @photo, title = @title, year = @year, country = @country, language = @language, length = @length, resume = @resume, genre = @genre, actors = @actors, director = @director WHERE video_id = @video_id"
            cmd.Parameters.AddWithValue("@photo", movie.photo)
            cmd.Parameters.AddWithValue("@title", movie.title)
            cmd.Parameters.AddWithValue("@year", movie.year)
            cmd.Parameters.AddWithValue("@country", movie.country)
            cmd.Parameters.AddWithValue("@language", movie.language)
            cmd.Parameters.AddWithValue("@length", movie.length)
            cmd.Parameters.AddWithValue("@resume", movie.resumes)
            cmd.Parameters.AddWithValue("@genre", movie.genre)
            cmd.Parameters.AddWithValue("@actors", movie.Actors)
            cmd.Parameters.AddWithValue("@director", movie.director)
            cmd.Parameters.AddWithValue("@video_id", movie.videoid)



            Dim rowAffected = cmd.ExecuteNonQuery
            MsgBox("Video Updated succesfully")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Connectionn Faild")
        End Try
    End Sub
    'This sub is to create an video 

    Public Sub CreateClient(person As client)
        Dim cmd As New MySqlCommand

        Try
            cmd.Connection = Me.connect
            cmd.CommandText = "INSERT INTO clients VALUES(default, @client_number, @fname, @lname, @email, @phone, @dob, @address, @city, @province, @postal_code, default, @type_of_card, @card_number, @month_expires, @year_expires, default)"
            cmd.Parameters.AddWithValue("@client_number", person.clientnumber)
            cmd.Parameters.AddWithValue("@fname", person.firstname)
            cmd.Parameters.AddWithValue("@lname", person.lastname)
            cmd.Parameters.AddWithValue("@email", person.email)
            cmd.Parameters.AddWithValue("@phone", person.cellphone)
            cmd.Parameters.AddWithValue("@dob", person.dob)
            cmd.Parameters.AddWithValue("@address", person.address)
            cmd.Parameters.AddWithValue("@city", person.city)
            cmd.Parameters.AddWithValue("@province", person.province)
            cmd.Parameters.AddWithValue("@postal_code", person.postalcode)
            cmd.Parameters.AddWithValue("@type_of_card", person.typecard)
            cmd.Parameters.AddWithValue("@card_number", person.cardnumber)
            cmd.Parameters.AddWithValue("@month_expires", person.monthexpire)
            cmd.Parameters.AddWithValue("@year_expires", person.yearexpire)


            Dim rowAffected = cmd.ExecuteNonQuery
            MsgBox("Client succesfully created")

        Catch ex As Exception
            MsgBox("Client Number already exists leave the page and return so that the client number can change", MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    'This sub is used to delete the client by entering there clientid
    Public Sub DeleteClient(client_id As Integer)
        Dim cmd As New MySqlCommand
        Try
            cmd.Connection = Me.connect
            cmd.CommandText = "UPDATE clients SET status = 0 WHERE client_id = " & client_id

            Dim rowAffected = cmd.ExecuteNonQuery
            MsgBox("Client Successfully deactivated")

        Catch ex As Exception
            MsgBox("Index doesn't exist" & vbCrLf & "The number of the id must be in the table right next to it", MsgBoxStyle.Critical, "Error")
        End Try


    End Sub
    'This function is used to get a single client by entering there clientnumber
    Public Function GetSingleClient(client_id As Integer) As client



        Dim query As String = "SELECT * FROM clients WHERE client_id = " & client_id
        Dim client As New client

        Try
            Dim cmd As New MySqlCommand(query, Me.connect)
            Dim reader As MySqlDataReader = cmd.ExecuteReader

            If reader.Read Then
                client.clientid = reader.GetInt16(0)
                client.clientnumber = reader.GetString(1)
                client.firstname = reader.GetString(2)
                client.lastname = reader.GetString(3)
                client.email = reader.GetString(4)
                client.cellphone = reader.GetString(5)
                client.dob = reader.GetString(6)
                client.address = reader.GetString(7)
                client.city = reader.GetString(8)
                client.province = reader.GetString(9)
                client.postalcode = reader.GetString(10)
                client.Status = reader.GetString(11)
                client.typecard = reader.GetString(12)
                client.cardnumber = reader.GetString(13)
                client.monthexpire = reader.GetString(14)
                client.yearexpire = reader.GetString(15)
                client.videorented = reader.GetString(16)
            End If
            reader.Close()
        Catch ex As Exception

        End Try

        Return client
    End Function
    'This function is used to get a single client by entering there clientnumber
    Public Function GetSingleClients(client_number As Integer) As client



        Dim query As String = "SELECT * FROM clients WHERE client_number = " & client_number
        Dim client As New client

        Try
            Dim cmd As New MySqlCommand(query, Me.connect)
            Dim reader As MySqlDataReader = cmd.ExecuteReader

            If reader.Read Then
                client.clientid = reader.GetInt16(0)
                client.clientnumber = reader.GetString(1)
                client.firstname = reader.GetString(2)
                client.lastname = reader.GetString(3)
                client.email = reader.GetString(4)
                client.cellphone = reader.GetString(5)
                client.dob = reader.GetString(6)
                client.address = reader.GetString(7)
                client.city = reader.GetString(8)
                client.province = reader.GetString(9)
                client.postalcode = reader.GetString(10)
                client.Status = reader.GetString(11)
                client.typecard = reader.GetString(12)
                client.cardnumber = reader.GetString(13)
                client.monthexpire = reader.GetString(14)
                client.yearexpire = reader.GetString(15)
                client.videorented = reader.GetString(16)
            End If
            reader.Close()
        Catch ex As Exception

        End Try

        Return client
    End Function
    'This sub is to edit the employee 
    Public Sub Editclient(client As client)
        Dim cmd As New MySqlCommand

        Try
            cmd.Connection = Me.connect
            cmd.CommandText = "UPDATE clients SET fname = @fname, lname = @lname, email = @email, phone = @phone, dob = @dob, address = @address, city = @city, province = @province, postal_code = @postal_code, type_of_card = @type_of_card, card_number = @card_number, month_expires = @month_expires, year_expires = @year_expires WHERE client_id = @client_id"
            cmd.Parameters.AddWithValue("@fname", client.firstname)
            cmd.Parameters.AddWithValue("@lname", client.lastname)
            cmd.Parameters.AddWithValue("@email", client.email)
            cmd.Parameters.AddWithValue("@phone", client.cellphone)
            cmd.Parameters.AddWithValue("@dob", client.dob)
            cmd.Parameters.AddWithValue("@address", client.address)
            cmd.Parameters.AddWithValue("@city", client.city)
            cmd.Parameters.AddWithValue("@province", client.province)
            cmd.Parameters.AddWithValue("@postal_code", client.postalcode)
            cmd.Parameters.AddWithValue("@type_of_card", client.typecard)
            cmd.Parameters.AddWithValue("@card_number", client.cardnumber)
            cmd.Parameters.AddWithValue("@month_expires", client.monthexpire)
            cmd.Parameters.AddWithValue("@year_expires", client.yearexpire)
            cmd.Parameters.AddWithValue("@client_id", client.clientid)




            Dim rowAffected = cmd.ExecuteNonQuery
            MsgBox("Client Updated succesfully")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Connectionn Faild")
        End Try
    End Sub

    'This sub is to rent the movie 
    Public Sub rent_movie(client As client)
        Dim cmd As New MySqlCommand

        Try
            cmd.Connection = Me.connect
            cmd.CommandText = "UPDATE clients SET videos_rented = @videos_rented, status = @status WHERE client_number = @client_number"
            cmd.Parameters.AddWithValue("@videos_rented", client.videorented)
            cmd.Parameters.AddWithValue("@status", client.Status)
            cmd.Parameters.AddWithValue("@client_number", client.clientnumber)




            Dim rowAffected = cmd.ExecuteNonQuery
            MsgBox("Video was rented succesfully")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Connectionn Faild")
        End Try
    End Sub
    Public Sub rentvideo(movie As movie)
        Dim cmd As New MySqlCommand

        Try
            cmd.Connection = Me.connect
            cmd.CommandText = "UPDATE videos SET status = @status WHERE video_id = @video_id"
            cmd.Parameters.AddWithValue("@status", movie.status)
            cmd.Parameters.AddWithValue("@video_id", movie.videoid)



            Dim rowAffected = cmd.ExecuteNonQuery


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Connectionn Faild")
        End Try
    End Sub

    'This sub is to return the movie 
    Public Sub return_movie(client As client)
        Dim cmd As New MySqlCommand

        Try
            cmd.Connection = Me.connect
            cmd.CommandText = "UPDATE clients SET videos_rented = @videos_rented, status = @status WHERE client_number = @client_number"
            cmd.Parameters.AddWithValue("@videos_rented", client.videorented)
            cmd.Parameters.AddWithValue("@status", client.Status)
            cmd.Parameters.AddWithValue("@client_number", client.clientnumber)




            Dim rowAffected = cmd.ExecuteNonQuery
            MsgBox("Video was returned succesfully")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Connectionn Faild")
        End Try
    End Sub
    Public Sub returnvideo(movie As movie)
        Dim cmd As New MySqlCommand

        Try
            cmd.Connection = Me.connect
            cmd.CommandText = "UPDATE videos SET status = @status WHERE video_id = @video_id"
            cmd.Parameters.AddWithValue("@status", movie.status)
            cmd.Parameters.AddWithValue("@video_id", movie.videoid)



            Dim rowAffected = cmd.ExecuteNonQuery


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Connectionn Faild")
        End Try
    End Sub

End Class