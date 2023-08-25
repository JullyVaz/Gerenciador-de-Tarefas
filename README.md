# Gerenciador-de-Tarefas

Cadastra uma lista de tarefas que permitirá organizar melhor a sua rotina.

Essa lista de tarefas possui um CRUD, ou seja, permiti obter, criar, salvar e deletar os registros.

Essa aplicação é do tipo MVC

A classe principal é a classe Tarefa


**Endpoints**


| Verbo  | Endpoint                | Parâmetro | Body          |
|--------|-------------------------|-----------|---------------|
| POST   | /Tarefa - Cadastrar     | N/A       | Schema Tarefa |
| GET    |/Tarefa/ObterPorData     | data      | N/A           |
| GET    | /Tarefa/ObterPorStatus  | status    | N/A           |
| GET    | /Tarefa/ObterTodos      | N/A       | N/A           |
| GET    |  /Tarefa/{id}           | id        | N/A           |
| DELETE | /Tarefa/{id}            | id        | N/A           |
| PUT    | /Tarefa/{id} -Altera    | id        | Schema Tarefa |

Esse é o schema (model) de Tarefa, utilizado para passar para os métodos que exigirem

```json
{
  "id": 0,
  "titulo": "string",
  "descricao": "string",
  "data": "2023-06-08T01:31:07.056Z",
  "status": "Pendente"
}


