#### ��������� ������ ####
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
	
#### ��������� ���������� ������� ####
----------
GET api/search/getById?id={id}

Body Parameters:

**id**   *int*    ����������������� ����� ���������� ������� � ��.

Response (SearchResponseDTO):

    {
        "id": 1,
        "query": "Test",
        "projectId": 1
    }
	
#### ���������� ####
----------
POST api/search/create

Body Parameters (SearchRequestDTO):
  
**query**    *string*    ������ ���������� �������.   
**projectId**    *int*    ������� ����������������� ����� ������� � ��.    

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
	
#### ���������� ####
----------
PUT api/search/update

Body Parameters (SearchRequestDTO):

**id**    *int*    ����������������� ���������� ������� � ��.
**query**    *string*    ��������� ������.   
**projectId**    *int*    ������� ����������������� ����� ������� � ��.    

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
	
#### �������� ####
----------
DELETE api/search/delete?id={id}

Body Parameters:

**id**    *int*    ����������������� ����� ���������� ������� � ��.    

Response (SearchResponseDTO): 

    {
		"id": 2,
        "query": "Training",
        "projectId": 3
	}
	