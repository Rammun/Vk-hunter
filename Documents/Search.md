#### Получение списка ####
----------
GET api/search/getAll

Body Parameters: None

Response (IEnumerable<SearchResponseDTO>):

    [
      {
        "id": 1,
        "query": "Test",
        "projectId": 1
      },
      {
        "id": 2,
        "query": "Train",
        "projectId": 1
      }
    ]
	
#### Получение поискового запроса ####
----------
GET api/search/getById?id={id}

Body Parameters:

**id**   *int*    Идентификационный номер поискового запроса в бд.

Response (SearchResponseDTO):

    {
        "id": 1,
        "query": "Test",
        "projectId": 1
    }
	
#### Добавление ####
----------
POST api/search/create

Body Parameters (SearchRequestDTO):
  
**query**    *string*    Строка поискового запроса.   
**projectId**    *int*    Внешний идентификационный номер проекта в бд.    

Request:

	{
	    "query": "Train",
	    "projectId": 1
	}

Response (SearchResponseDTO): 

    {
		"id": 2,
        "query": "Train",
        "projectId": 1
	}
	
#### Обновление ####
----------
PUT api/search/update

Body Parameters (SearchRequestDTO):

**id**    *int*    Идентификационный поискового запроса в бд.
**query**    *string*    Поисковый запрос.   
**projectId**    *int*    Внешний идентификационный номер проекта в бд.    

Request:

	{
        "id": 2,
        "query": "Training",
        "projectId": 3
    }

Response (SearchResponseDTO): 

    {
		"id": 2,
        "query": "Training",
        "projectId": 3
	}
	
#### Удаление ####
----------
DELETE api/search/delete?id={id}

Body Parameters:

**id**    *int*    Идентификационный номер поискового запроса в бд.    

Response (SearchResponseDTO): 

    {
		"id": 2,
        "query": "Training",
        "projectId": 3
	}
	