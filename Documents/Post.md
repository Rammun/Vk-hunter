#### ��������� ������ ####
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
	
#### ��������� ����� ####
----------
GET api/post/getById?id={id}

Body Parameters:

**id**   *int*    ����������������� ����� ����� � ��.

Response (PostResponseDTO):

    {
        "id": 1,
        "text": "test",
        "description": null,
        "photoUri": ["",""],
        "memberId": 1
    }
	
#### ���������� ####
----------
POST api/post/create

Body Parameters (PostRequestDTO):
  
**text**    *string*    ���� �����.   
**description**    *string*    ��������.    
**photoUri**    *[string]*    ������ ������ �� ����.    
**memberId**    *int*    ������� ������������� ��������� � ��.    

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
	
#### ���������� ####
----------
PUT api/post/update

Body Parameters (PostRequestDTO):

**id**    *int*    ����������������� ����� � ��.
**text**    *string*    ���� �����.   
**description**    *string*    ��������.    
**photoUri**    *[string]*    ������ ������ �� ����.    
**memberId**    *int*    ������� ������������� ��������� � ��.

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
	
#### �������� ####
----------
DELETE api/post/delete?id={id}

Body Parameters:

**id**    *int*    ����������������� ����� ����� � ��.    

Response (PostResponseDTO): 

    {
		"id": 1,
        "text": "test",
        "description": "abc",
        "photoUri": ["",""],
        "memberId": 1
	}
	