#### ��������� ������ ####
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
	
#### ��������� ��������� ####
----------
GET api/member/getById?id={id}

Body Parameters:

**id**   *int*    ����������������� ����� ��������� � ��.

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
	
#### ���������� ####
----------
POST api/post/create

Body Parameters (MemberRequestDTO):
  
**vkId**    *int*    . ����������������� ����� ��������� � vk.   
**name**    *string*    ���.    
**uri**    *string*    ������ �� �������� ���������.    
**description**    *string*    ��������.    
**ava**    *string*    ������ �� ������� ���������� ���������.    
**membersCount**    *int*    ���-�� �����������.
**state**    *int*    ������.    
**date**    *string*    ���� ��������� ����� �������.    
**type**    *int*    ��� ��������� (group/user).    

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
	
#### ���������� ####
----------
PUT api/member/update

Body Parameters (MemberRequestDTO):

**vkId**    *int*    . ����������������� ����� ��������� � vk.   
**name**    *string*    ���.    
**uri**    *string*    ������ �� �������� ���������.    
**description**    *string*    ��������.    
**ava**    *string*    ������ �� ������� ���������� ���������.    
**membersCount**    *int*    ���-�� �����������.
**state**    *int*    ������.    
**date**    *string*    ���� ��������� ����� �������.    
**type**    *int*    ��� ��������� (group/user).    
    
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
	
#### �������� ####
----------
DELETE api/member/delete?id={id}

Body Parameters:

**id**    *int*    ����������������� ����� ��������� � ��.    

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
	
#### ����� �� ������� ####
----------
POST api/member/getMembers

Body Parameters (GetMembersRequestDTO)

**states**    *int[]*    ������ ��������.    
**projectIds**    *int[]*    ������ ����������������� ������� �������� � ��.    
**count**    *int*    ���-�� ������� � ������.    

��������� projectIds � count ��������������. ���� �������� �����������, ��� ������� �� ����������� �� �����.
