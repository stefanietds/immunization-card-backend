# Backend - Sistema de Cartão de Vacinação

## Descrição
Backend desenvolvido em **.NET 9** para gerenciar pacientes, vacinas e cartões de vacinação.  
Fornece APIs REST consumidas pelo frontend em React, utilizando boas práticas de arquitetura.

### Tecnologias e Pacotes
- **.NET 9**
- **C#**
- **Entity Framework Core 8** (SQLite)
- **FluentValidation 11** para validação de DTOs
- **MediatR 14** para organização de Commands e Queries
- **AutoMapper 12** para mapeamento entre Models e DTOs
- **Swashbuckle (Swagger) 10** para documentação de API

## Como rodar
- `dotnet restore`
- `dotnet ef database update`
- `dotnet build`
- `dotnet run`

## Arquitetura
src/
├── Application # Lógica de aplicação, casos de uso, interfaces de serviços
├── Domain # Entidades de negócio, regras de negócio puras, agregados
├── Infrastructure # Implementações de acesso a dados, integração com APIs externas, persistência
└── Presentation # Camada de apresentação: Controllers

## Endpoints Principais

### Pessoas
- `GET /api/patient` - Lista todas os pacientes
- `POST /api/patient` - Cria um novo paciente
- `DELETE /api/patient/{id}` - Deleta um paciente

### Vacinas
- `GET /api/vaccine` - Lista todas as vacinas
- `POST /api/vaccine` - Cria uma nova vacina
  
### Cartões de Vacinação
- `GET /api/immunizationcard` - Lista todas os pacientes que tem cartão de vacinação
- `GET /api/immunizationcard/patient/{patientId}` - Retorna o cartão de uma pessoa
- `POST /api/immunizationcard` - Cria um cartão
- `DELETE /api/immunizationcard/{id}` - Deleta uma dose do cartão
