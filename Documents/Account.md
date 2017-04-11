#### Регистрация пользователя ####
----------
POST api/account/register

Body Parameters (RegisterRequestDTO):

**UserName**   *string*    Логин. Должен иметь формат email.   
**Password**   *string*   Пароль. Минимум 6 символов.   

Request:

    {
    	"UserName": "admin@admin.com",
    	"Password": "qwerty"
    }

Response:

    {
      "Succeeded": true,
      "Errors": []
    }

#### Получение токена ####
-----
POST api/account/login

Body Parameters (LoginRequestDTO):

**UserName**   *string*    Логин. Должен иметь формат email.   
**Password**   *string*   Пароль. Минимум 6 символов.   

Request:

    {
    	"UserName": "admin@admin.com",
    	"Password": "qwerty"
    }

Response:

    {
		"token": "AQAAANCMnd8BFdERjHoAwE_Cl"
	}
	
#### Получение токена (вариант 2)####
-----
POST api/account/token

ContentType:  x-www-form-urlencoded

Body Parameters:

**grant_type**   *string*    Значение параметра всегда "password".   
**username**    *string*    Логин. Должен иметь формат email.   
**password**   *string*   Пароль. Минимум 6 символов.   

Response:

    {
		"access_token": "AQAAANCMnd8BFdERjHoAwE_Cl-sBAAAAx",
		"token_type": "bearer",
		"expires_in": 86399,
		"userName": "admin@admin.com",
		".issued": "Thu, 05 Jan 2017 17:19:48 GMT",
		".expires": "Fri, 06 Jan 2017 17:19:48 GMT"
	}

Пример запроса на C#:

	var client = new HttpClient("http://localhost:9000/")
	
	var requestParams = new Dictionary<string, string>
    {
        { "grant_type", "password" },
        { "username", UserName },
        { "password", Password }
    };

    var content = new FormUrlEncodedContent(requestParams);
    var response = await client.PostAsync(@"api/token", content);
    var responseData = await response.Content.ReadAsAsync<Dictionary<string, string>>();
    var authToken = responseData["access_token"];
	
	
По умолчанию время жизни токена 24 часа, прописано жетско в коде в файле Startup.cs.