# API docs
## Version: v1

### /api/books/{id}

#### GET
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| id | path |  | Yes | integer |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

#### PATCH
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| id | path |  | Yes | integer |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/books

#### POST
##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

#### GET
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| categoriesOfBooks | query |  | No | [ string ] |
| regexString | query |  | No | string |
| longitude | query |  | No | double |
| latitude | query |  | No | double |
| radius | query |  | No | double |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/transactions/{id}

#### GET
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| id | path |  | Yes | integer |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

#### PATCH
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| id | path |  | Yes | integer |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/transactions

#### POST
##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

#### GET
##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/users/{id}

#### GET
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| id | path |  | Yes | integer |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/users/login

#### POST
##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### Models

#### CategoryOfBook

| Name | Type | Description | Required |
| ---- | ---- | ----------- | -------- |
| CategoryOfBook | string |  |  |

#### User

| Name | Type | Description | Required |
| ---- | ---- | ----------- | -------- |
| id | integer |  | No |
| name | string |  | Yes |

#### BookReadDto

| Name | Type | Description | Required |
| ---- | ---- | ----------- | -------- |
| id | integer |  | No |
| title | string |  | No |
| author | string |  | No |
| isbn | string |  | No |
| isAvaible | boolean |  | No |
| description | string |  | No |
| category | string | _Enum:_ `"Fantasy"`, `"Horror"`, `"Romans"`, `"Wojenna"`, `"Obyczajowa"`, `"Historyczna"` | No |
| imgUrl | string |  | No |
| latitude | double |  | No |
| longitude | double |  | No |
| addedDate | dateTime |  | No |
| owner | object |  | No |

#### BookChangeDto

| Name | Type | Description | Required |
| ---- | ---- | ----------- | -------- |
| title | string |  | No |
| author | string |  | No |
| isbn | string |  | No |
| isAvaible | boolean |  | No |
| description | string |  | No |
| category | string | _Enum:_ `"Fantasy"`, `"Horror"`, `"Romans"`, `"Wojenna"`, `"Obyczajowa"`, `"Historyczna"` | No |
| imgUrl | string |  | No |
| latitude | double |  | No |
| longitude | double |  | No |

#### BookAddDto

| Name | Type | Description | Required |
| ---- | ---- | ----------- | -------- |
| title | string |  | Yes |
| author | string |  | Yes |
| isbn | string |  | Yes |
| description | string |  | Yes |
| category | string | _Enum:_ `"Fantasy"`, `"Horror"`, `"Romans"`, `"Wojenna"`, `"Obyczajowa"`, `"Historyczna"` | Yes |
| imgUrl | string |  | Yes |
| latitude | double |  | Yes |
| longitude | double |  | Yes |

#### TransactionStatus

| Name | Type | Description | Required |
| ---- | ---- | ----------- | -------- |
| TransactionStatus | string |  |  |

#### TransactionReadDto

| Name | Type | Description | Required |
| ---- | ---- | ----------- | -------- |
| id | integer |  | No |
| roomId | string |  | No |
| customer | object |  | No |
| book | object |  | No |
| status | string | _Enum:_ `"Pending"`, `"Accepted"`, `"Declined"`, `"Rented"`, `"Finished"` | No |
| dateTimeStart | dateTime |  | No |
| dateTimeEnd | dateTime |  | No |

#### TransactionChangeDto

| Name | Type | Description | Required |
| ---- | ---- | ----------- | -------- |
| status | string | _Enum:_ `"Pending"`, `"Accepted"`, `"Declined"`, `"Rented"`, `"Finished"` | No |

#### TransactionAddDto

| Name | Type | Description | Required |
| ---- | ---- | ----------- | -------- |
| bookId | integer |  | Yes |
| daysOfRentalTime | integer |  | Yes |

#### Book

| Name | Type | Description | Required |
| ---- | ---- | ----------- | -------- |
| id | integer |  | No |
| title | string |  | Yes |
| author | string |  | Yes |
| isbn | string |  | Yes |
| isAvaible | boolean |  | Yes |
| description | string |  | Yes |
| category | string | _Enum:_ `"Fantasy"`, `"Horror"`, `"Romans"`, `"Wojenna"`, `"Obyczajowa"`, `"Historyczna"` | Yes |
| imgUrl | string |  | Yes |
| addedDate | dateTime |  | Yes |
| latitude | double |  | Yes |
| longitude | double |  | Yes |
| userId | integer |  | Yes |

#### UserReadDto

| Name | Type | Description | Required |
| ---- | ---- | ----------- | -------- |
| id | integer |  | No |
| name | string |  | No |
| books | [ object ] |  | No |

#### UserAddDto

| Name | Type | Description | Required |
| ---- | ---- | ----------- | -------- |
| loginId | string |  | No |
| name | string |  | No |
