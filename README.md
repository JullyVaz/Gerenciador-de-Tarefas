# Gerenciador-de-Tarefas

Cadastrar uma lista de tarefas que permitirá organizar melhor a sua rotina.

Essa lista de tarefas precisa ter um CRUD, ou seja, deverá permitir a você obter os registros, criar, salvar e deletar esses registros.

A sua aplicação deverá ser do tipo Web API ou MVC

A classe principal é a classe de tarefa



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
  "data": "2022-06-08T01:31:07.056Z",
  "status": "Pendente"
}

Projeto em desenvolvimento!
