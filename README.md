# Brewery Fermentation Control

Aplicação web para registro e acompanhamento de dados fermentativos, desenvolvida como desafio técnico para simular funcionalidades presentes em sistemas de gestão para cervejarias.

---

## Sobre o Projeto

Durante o processo de fermentação, cervejarias realizam o acompanhamento periódico de parâmetros como temperatura, pH e extrato. Esses registros são fundamentais para garantir a qualidade do produto e a padronização dos processos produtivos.

Esta aplicação permite o registro e acompanhamento desses parâmetros, classificando automaticamente cada registro conforme os limites configurados para cada cerveja em:

- 🟢 **Dentro do Padrão**
- 🟡 **Atenção**
- 🔴 **Fora do Padrão**

---

## 🛠️ Tecnologias

### Backend
- C# / .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- MediatR (CQRS)
- Swagger

### Frontend
- React 19 + TypeScript
- Vite
- React Router DOM
- Axios
- CSS Modules

---

## Estrutura do Repositório

```
brewery-fermentation-control/
├── backend/
│   └── FermentationControl/
│       └── FermentationControl.Api/   # API REST em C#/.NET 8
│           └── README.md              # Documentação do backend
├── frontend/
│   └── fermentation-control/          # Interface em React + TypeScript
│       └── README.md                  # Documentação do frontend
├── .gitignore
└── README.md                          # Este arquivo
```

---

## Funcionalidades Implementadas

- ✅ Cadastro de cervejas
- ✅ Cadastro de tanques
- ✅ Cadastro de parâmetros fermentativos por cerveja
- ✅ Registro de apontamentos fermentativos com classificação automática
- ✅ Dashboard com indicadores gerais
- ✅ Histórico de lotes com evolução cronológica

---

## Como executar o projeto

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js LTS](https://nodejs.org/)
- [Git](https://git-scm.com/)

### 1. Clonar o repositório

```bash
git clone https://github.com/seu-usuario/brewery-fermentation-control.git
cd brewery-fermentation-control
```

### 2. Executar o Backend

```bash
cd backend/FermentationControl/FermentationControl.Api
dotnet restore
dotnet ef database update
dotnet run
```

> API disponível em: `https://localhost:5107/swagger`

### 3. Executar o Frontend

Abra um novo terminal:

```bash
cd frontend/fermentation-control
npm install
npm run dev
```

> Interface disponível em: `http://localhost:5173`


---

## Documentação detalhada

Cada aplicação possui sua própria documentação contendo instruções específicas de configuração, arquitetura e etc.


- [Documentação do Backend](./backend/FermentationControl/README.md)
- [Documentação do Frontend](./frontend/fermentation-control/README.md)

---

## Licença

Projeto desenvolvido exclusivamente para fins de estudo e desafio técnico.
