#### Получение списка ####
----------
GET api/member/getAll

Body Parameters: None

Response (IEnumerable<MemberResponseDTO>):

    [
      {
        "id": 1,
        "vkId": 13243546,
        "name": "Ivan",
        "uri": "",
        "description": "",
		"ava": "",
		"membersCount": 5,
		"state": 0,
		"date": 21.02.2017
		"type": 0
      },
      {
        "id": 2,
        "vkId": 12345678,
        "name": "Vovan",
        "uri": "",
        "description": "",
		"ava": "",
		"membersCount": 10,
		"state": 0,
		"date": 22.02.2017
		"type": 0
      }
    ]
	
#### Получение участника ####
----------
GET api/member/getById?id={id}

Body Parameters:

**id**   *int*    Идентификационный номер участника в бд.

Response (MemberResponseDTO):

    {
        "id": 2,
        "vkId": 12345678,
        "name": "Vovan",
        "uri": "",
        "description": "",
		"ava": "",
		"membersCount": 10,
		"state": 0,
		"date": 22.02.2017
		"type": 0
    }
	
#### Добавление ####
----------
POST api/post/create

Body Parameters (MemberRequestDTO):
  
**vkId**    *int*    . Идентификационный номер участника в vk.   
**name**    *string*    Имя.    
**uri**    *string*    Ссылка на страницу участника.    
**description**    *string*    Описание.    
**ava**    *string*    Ссылка на главную фотографию участника.    
**membersCount**    *int*    Кол-во подписчиков.
**state**    *int*    Статус.    
**date**    *string*    Дата последней смены статуса.    
**type**    *int*    Тип участника (group/user).    

Request:

	{
        "vkId": 12345678,
        "name": "Vovan",
        "uri": "",
        "description": "",
		"ava": "",
		"membersCount": 10,
		"state": 0,
		"date": 22.02.2017
		"type": 0
	}

Response (MemberResponseDTO): 

    {
		"id": 2,
        "vkId": 12345678,
        "name": "Vovan",
        "uri": "",
        "description": "",
		"ava": "",
		"membersCount": 10,
		"state": 0,
		"date": 22.02.2017
		"type": 0
	}
	
#### Обновление ####
----------
PUT api/member/update

Body Parameters (MemberRequestDTO):

**vkId**    *int*    . Идентификационный номер участника в vk.   
**name**    *string*    Имя.    
**uri**    *string*    Ссылка на страницу участника.    
**description**    *string*    Описание.    
**ava**    *string*    Ссылка на главную фотографию участника.    
**membersCount**    *int*    Кол-во подписчиков.
**state**    *int*    Статус.    
**date**    *string*    Дата последней смены статуса.    
**type**    *int*    Тип участника (group/user).    
    
Request:

	{
        "id": 2,
        "vkId": 12345678,
        "name": "Vovan",
        "uri": "",
        "description": "",
		"ava": "",
		"membersCount": 10,
		"state": 0,
		"date": 22.02.2017
		"type": 0
    }

Response (MemberResponseDTO): 

    {
		"id": 2,
        "vkId": 12345678,
        "name": "Vovan",
        "uri": "",
        "description": "",
		"ava": "",
		"membersCount": 10,
		"state": 0,
		"date": 22.02.2017
		"type": 0
	}
	
#### Удаление ####
----------
DELETE api/member/delete?id={id}

Body Parameters:

**id**    *int*    Идентификационный номер участника в бд.    

Response (MemberResponseDTO): 

    {
		"id": 2,
        "vkId": 12345678,
        "name": "Vovan",
        "uri": "",
        "description": "",
		"ava": "",
		"membersCount": 10,
		"state": 0,
		"date": 22.02.2017
		"type": 0
	}
	
#### Поиск по фильтру ####
----------
POST api/member/getMembers

Body Parameters (GetMembersRequestDTO)

**states**    *int[]*    Список статусов.    
**projectIds**    *int[]*    Список идентификационных номеров проектов в бд.    
**count**    *int*    Кол-во записей в ответе.    

Параметры projectIds и count необязательные. Если параметр отсутствует, при фильтре он учитываться не будет.
