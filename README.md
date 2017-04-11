VkHunter - приложение, для мониторинга пиратского контента в социальной сети vk.com.
======================================================================
Для запуска приложения необходим .NET 4.6 и установленный сервер MySQL.
Перед запуском необходимо в файле App.config, сделать необходимые настройки:

1. Настроить соединение с бд. Для этого в свойстве `<connectionStrings>`, установить значения параметров

    `server=[server_name]`    
    `user id=[user_name]`    
    `password=[password]`    
    `database=[db_name]`    

2. В свойстве `<appSettings>`, установить параметры для ключей

    `key="baseUrl" value="[host]"` адрес хоста, в котором будет работать приложение: value="http://localhost:9000/"            
    `key="timeUpdate" value="[HH:mm]"` время ежедневного обновления данных, формат короткого времени: value="11:22"            
    `key="timeout" value="[int]"` таймаут между запросами в мс: value="333"                      
    `key="adminUser" value="[user_name]"` логин администратора: value="test@market.com"                    
    `key="adminPassword" value="[password]"` пароль администратора: value="password"                  

    `key="vk_appId" value="[appId]"` идентификатор приложения в vk.       
    `key="vk_email" value="[email]"` логин в vk.       
    `key="vk_password" value="[password]"` пароль в vk.       

3. В свойстве `<system.net>`  настроить SMTP для почтовика, через который будет отправляться электронная почта с уведомлениями.
По умолчанию настроен локальный прием писем, уведомления будут приходить в директорию G:\Temp\Email\. При желании путь к директории можно изменить, путь должен быть абсолютным и реально существовать.
Если необходима отправка писем на удаленный почтовый сервер, нужно закомментировать `<system.net>` для локальной версии и раскомментировать для удаленной.

    В свойстве `<network>` указать параметры:

    `port=[port]` порт сервера, для gmail: port="587"                     
    `host=[smtp_host]` хост smtp сервера, для gmail: host="smtp.gmail.com"                      
    `userName=[user_name]` имя пользователя аккаунта сервера: userName="test@gmail.com"                    
    `password=[password]` пароль аккаунта: password="password"                         

При первом запуске приложения будет создана база данных.
По умолчанию будет создан аккаунт с логином [user_name] и паролем [password], указанные в конфигурационном файле.
Логин должен совпадать с реальным email, на этот email будут отправляться уведомления о критических ошибках и ходе выполнения задач.

Отправка параметров выполняется в формате JSON. В заголовке запроса ключ ContentType должен иметь значение 'application/json'.
Для доступа к api необходим авторизационный токен (кроме api/account/login).
Токен отправляется в заголовке с ключом Authorization, в параметре ключа указывается тип токена и через пробел сам токен ("bearer " + token).

При неудачной авторизации будет возвращен ответ

    {
      "Message": "Authorization has been denied for this request."
    }

Пример запроса с авторизацией на C#:

    var authToken = "54w6rtfdhwfw5";
    var requestModel = new VendorRequestDTO
    {
    	MarketId = 1042232,
    	Regions = new int[] { 213 },
    	Name = "Market",
        Schedule = "1001000"
    };
    
    var client = new HttpClient();
    client.BaseAddress = new Uri("http://localhost:9000/");
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", authToken);
    
    var response = await client.PostAsJsonAsync("api/vendor/create", requestModel);
    var responseModel = await response.Content.ReadAsAsync<Vendor>();

Раз в сутки, по времени, установленном в конфигурационном файле (в значении ключа timeUpdate), будет запущена фоновая задача обновления данных из vk.

## Схема БД

![vk2.png](https://bitbucket.org/repo/ArznkB/images/4237096613-vk2.png)

### API

### [Account](https://github.com/Rammun/Vk-hunter/blob/master/Documents/Account.md)
### [Project](https://github.com/Rammun/Vk-hunter/blob/master/Documents/Project.md)
### [Search](https://github.com/Rammun/Vk-hunter/blob/master/Documents/Search.md)
### [Member](https://github.com/Rammun/Vk-hunter/blob/master/Documents/Member.md)
### [Post](https://github.com/Rammun/Vk-hunter/blob/master/Documents/Post.md)
### [History](https://github.com/Rammun/Vk-hunter/blob/master/Documents/History.md)
