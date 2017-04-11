#### ��������� ������ ####
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
	
#### ��������� ������� ####
----------
GET api/history/getById?id={id}

Body Parameters:

**id**   *int*    ����������������� ����� ������� � ��.

Response (HistoryResponseDTO):

    {
		"id": 1,
		"vkId": "123456",
		"type": 0,
		"state": 0,
		"date": "01.01.2000",
		"memberId": 1
	}
	
#### ���������� ####
----------
POST api/history/create

Body Parameters (HistoryRequestDTO):
  
**vkId**    *long*    ����������������� ����� ������������ � vk.   
**type**    *int*    ��� ��������� (0 - ������, 1 - ������������).    
**state**    *int*    ������ ���������.    
**date**    *string*    ���� ��������� �������.    
**memberId**    *int*    ������� ����������������� ��� ��������� � ��.    

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
	
#### ���������� ####
----------
PUT api/history/update

Body Parameters (HistoryRequestDTO):

**id**    *int*    ����������������� ����� ������� � ��.
**vkId**    *long*    ����������������� ����� ������������ � vk.    
**type**    *int*    ��� ��������� (0 - ������, 1 - ������������).    
**state**    *int*    ������ ���������.    
**date**    *string*    ���� ��������� �������.    
**memberId**    *int*    ������� ����������������� ��� ��������� � ��.    

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
	
#### �������� ####
----------
DELETE api/history/delete?id={id}

Body Parameters:

**id**    *int*    ����������������� ����� ������� � ��.    

Response (HistoryResponseDTO): 

    {
		"id": 1,
		"vkId": "123456",
		"type": 0,
		"state": 0,
		"date": "01.01.2000",
		"memberId": 1
	}
	