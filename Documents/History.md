#### Получение списка ####
----------
GET api/history/getAll

Body Parameters: None

Response (IEnumerable<History>):

    [
      {
		"id": 1,
		"vkId": "123456",
		"type": 0,
		"state": 0,
		"date": "01.01.2000",
		"memberId": 1
	  }
	]
	
#### Получение истории ####
----------
GET api/history/getById?id={id}

Body Parameters:

**id**   *int*    Идентификационный номер истории в бд.

Response (HistoryResponseDTO):

    {
		"id": 1,
		"vkId": "123456",
		"type": 0,
		"state": 0,
		"date": "01.01.2000",
		"memberId": 1
	}
	
#### Добавление ####
----------
POST api/history/create

Body Parameters (HistoryRequestDTO):
  
**vkId**    *long*    Идентификационный номер пользователя в vk.   
**type**    *int*    Тип участника (0 - группа, 1 - пользователь).    
**state**    *int*    Статус участника.    
**date**    *string*    Дата получения статуса.    
**memberId**    *int*    Внешний идентификационный код участника в бд.    

Request:

	{
		"vkId": "123456",
		"type": 0,
		"state": 0,
		"date": "01.01.2000",
		"memberId": 1
	}

Response (HistoryResponseDTO): 

    {
		"id": 1,
		"vkId": "123456",
		"type": 0,
		"state": 0,
		"date": "01.01.2000",
		"memberId": 1
	}
	
#### Обновление ####
----------
PUT api/history/update

Body Parameters (HistoryRequestDTO):

**id**    *int*    Идентификационный номер истории в бд.
**vkId**    *long*    Идентификационный номер пользователя в vk.    
**type**    *int*    Тип участника (0 - группа, 1 - пользователь).    
**state**    *int*    Статус участника.    
**date**    *string*    Дата получения статуса.    
**memberId**    *int*    Внешний идентификационный код участника в бд.    

Request:

	{
        "id": 1,
		"vkId": "123456",
		"type": 0,
		"state": 0,
		"date": "01.01.2000",
		"memberId": 1
    }

Response (HistoryResponseDTO): 

    {
		"id": 1,
		"vkId": "123456",
		"type": 0,
		"state": 0,
		"date": "01.01.2000",
		"memberId": 1
	}
	
#### Удаление ####
----------
DELETE api/history/delete?id={id}

Body Parameters:

**id**    *int*    Идентификационный номер истории в бд.    

Response (HistoryResponseDTO): 

    {
		"id": 1,
		"vkId": "123456",
		"type": 0,
		"state": 0,
		"date": "01.01.2000",
		"memberId": 1
	}
	