#### Получение списка ####
----------
GET api/post/getAll

Body Parameters: None

Response (IEnumerable<PostResponseDTO>):

    [
      {
        "id": 1,
        "text": "test",
        "description": null,
        "photoUri": ["",""],
        "memberId": 1
      },
      {
        "id": 2,
        "text": "test",
        "description": null,
        "photoUri": ["",""],
        "memberId": 2
      }
    ]
	
#### Получение поста ####
----------
GET api/post/getById?id={id}

Body Parameters:

**id**   *int*    Идентификационный номер поста в бд.

Response (PostResponseDTO):

    {
        "id": 1,
        "text": "test",
        "description": null,
        "photoUri": ["",""],
        "memberId": 1
    }
	
#### Добавление ####
----------
POST api/post/create

Body Parameters (PostRequestDTO):
  
**text**    *string*    Тело поста.   
**description**    *string*    Описание.    
**photoUri**    *[string]*    Список ссылок на фото.    
**memberId**    *int*    Внешний идентификатор участника в бд.    

Request:

	{
	    "text": "test",
        "description": "abc",
        "photoUri": ["",""],
        "memberId": 1
	}

Response (PostResponseDTO): 

    {
		"id": 1,
        "text": "test",
        "description": "abc",
        "photoUri": ["",""],
        "memberId": 1
	}
	
#### Обновление ####
----------
PUT api/post/update

Body Parameters (PostRequestDTO):

**id**    *int*    Идентификационный поста в бд.
**text**    *string*    Тело поста.   
**description**    *string*    Описание.    
**photoUri**    *[string]*    Список ссылок на фото.    
**memberId**    *int*    Внешний идентификатор участника в бд.

Request:

	{
        "id": 1,
        "text": "test",
        "description": "abc",
        "photoUri": ["",""],
        "memberId": 1
    }

Response (PostResponseDTO): 

    {
		"id": 1,
        "text": "test",
        "description": "abc",
        "photoUri": ["",""],
        "memberId": 1
	}
	
#### Удаление ####
----------
DELETE api/post/delete?id={id}

Body Parameters:

**id**    *int*    Идентификационный номер поста в бд.    

Response (PostResponseDTO): 

    {
		"id": 1,
        "text": "test",
        "description": "abc",
        "photoUri": ["",""],
        "memberId": 1
	}
	