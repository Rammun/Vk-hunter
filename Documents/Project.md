#### Получение списка ####
----------
GET api/project/getAll

Body Parameters: None

Response (IEnumerable<Project>):

    [
      {
		"id": 1,
		"name": "Test",
		"externalId": 54321,
		"searches": [
		  {
			"id": 1,
			"query": "Test",
			"projectId": 1
		  }
		]
	  },
	  {
		"id": 2,
		"name": "Test2",
		"externalId": 54321,
		"searches": []
	  }
	]
	
#### Получение проекта ####
----------
GET api/project/getById?id={id}

Body Parameters:

**id**   *int*    Идентификационный номер проекта в бд.

Response (ProjectResponseDTO):

    {
		"id": 1,
		"name": "Test",
		"externalId": 54321,
		"searches": []
	}
	
#### Добавление ####
----------
POST api/project/create

Body Parameters (ProjectRequestDTO):
  
**name**    *string*    Название проекта.   
**externalId**    *int*    Внешний идентификационный номер.    

Request:

	{
	    "name": "Test",
		"externalId": 54321
	}

Response (ProjectResponseDTO): 

    {
		"id": 1,
		"name": "Test",
		"externalId": 54321,
		"searches": [
		  {
			"id": 1,
			"query": "Test",
			"projectId": 1
		  }
		]
	}
	
#### Обновление ####
----------
PUT api/project/update

Body Parameters (ProjectRequestDTO):

**id**    *int*    Идентификационный номер проекта в бд.
**name**    *string*    Название проекта.   
**externalId**    *int*    Внешний идентификационный номер.    

Request:

	{
        "id": 2,
        "externalId": 987654321,
        "name": "Songs!"
    }

Response (ProjectResponseDTO): 

    {
		"id": 2,
        "externalId": 987654321,
        "name": "Songs!",
		"searches": []
	}
	
#### Удаление ####
----------
DELETE api/project/delete?id={id}

Body Parameters:

**id**    *int*    Идентификационный номер проекта в бд.    

Response (ProjectResponseDTO): 

    {
		"id": 2,
        "externalId": 987654321,
        "name": "Songs!",
		"searches": []
	}
	