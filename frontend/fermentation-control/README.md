# Fermentation Control — Frontend

Interface web para controle e acompanhamento de dados fermentativos de cervejarias, desenvolvida em React + TypeScript.

## Tecnologias Utilizadas

- **React 19** com **TypeScript**
- **Vite** — bundler moderno para desenvolvimento rápido
- **React Router DOM** — navegação entre páginas
- **Axios** — requisições HTTP para a API
- **CSS Modules** — estilização isolada por componente

## Pré-requisitos

- [Node.js](https://nodejs.org) versão 18 ou superior
- Backend do projeto rodando em `http://localhost:5107`

## Como Executar

**1. Entre na pasta do frontend:**
```bash
cd frontend/fermentation-control
```

**2. Instale as dependências:**
```bash
npm install
```

**3. Inicie o servidor de desenvolvimento:**
```bash
npm run dev
```

**4. Acesse no navegador:**
```
http://localhost:5173
```

> ⚠️ O backend precisa estar rodando antes de iniciar o frontend para que os dados sejam carregados corretamente.

## Estrutura de Pastas

```
src/
├── assets/          # Imagens e logos
├── components/
│   ├── Layout/      # Sidebar e estrutura base das páginas
│   └── ui/
│       └── Alert/   # Componente de mensagens de sucesso e erro
├── pages/
│   ├── Dashboard/           # Tela inicial com indicadores
│   ├── Beers/               # Cadastro de cervejas
│   ├── Tanks/               # Cadastro de tanques
│   ├── FermentationParameter/  # Cadastro de parâmetros
│   ├── FermentationRecord/  # Registro de fermentação
│   └── BatchHistory/        # Histórico de lotes
├── services/        # Funções de chamada à API
│   ├── api.ts               # Configuração base do Axios
│   ├── beerService.ts
│   ├── tankService.ts
│   ├── parameterService.ts
│   ├── fermentationService.ts
│   └── dashboardService.ts
├── types/           # Interfaces TypeScript
│   ├── Beer.ts
│   ├── Tank.ts
│   ├── FermentationParameter.ts
│   ├── FermentationRecord.ts
│   ├── FermentationRecordDetail.ts
│   └── Dashboard.ts
├── utils/           # Funções utilitárias
│   ├── categoryUtils.ts     # Conversão do enum de classificação
│   └── textFormatterUtils.ts # Formatação de textos
└── styles/
    └── global.css   # Variáveis globais de cor e fonte
```

## Funcionalidades

### Dashboard
Tela inicial com 4 indicadores:
- Total de registros fermentativos
- Registros dentro do padrão
- Registros que requerem atenção
- Registros fora do padrão

### Cadastro de Cervejas
Permite cadastrar cervejas com nome e estilo, e listar todas as cervejas cadastradas.

### Cadastro de Tanques
Permite cadastrar tanques com nome e capacidade em litros, e listar todos os tanques cadastrados.

### Parâmetros de Fermentação
Permite cadastrar os parâmetros aceitáveis por cerveja:
- Temperatura mínima, máxima e tolerância
- pH mínimo, máximo e tolerância
- Extrato mínimo, máximo e tolerância

### Registro de Fermentação
Permite registrar apontamentos fermentativos com:
- Data e hora
- Cerveja e tanque
- Número do lote
- Temperatura, pH e extrato
- Observações

A classificação é realizada automaticamente pelo backend com base nos parâmetros da cerveja selecionada.

### Histórico de Lotes
Permite buscar todos os registros de um lote pelo número, exibindo a evolução dos parâmetros ao longo do tempo com a classificação de cada registro.

## Critérios de Classificação

A classificação é realizada pelo backend e retornada ao frontend como um enum numérico:

| Valor | Classificação    | Critério |
|-------|-----------------|----------|
| 0     | Dentro do Padrão | Todos os parâmetros dentro dos limites mínimo e máximo |
| 1     | Atenção          | Algum parâmetro dentro da tolerância mas fora do ideal |
| 2     | Fora do Padrão   | Algum parâmetro fora dos limites incluindo tolerância |

## Variáveis de Ambiente

A URL base da API está configurada em `src/services/api.ts`. Caso o backend rode em uma porta diferente, altere o valor de `baseURL`:

```typescript
const api = axios.create({
  baseURL: 'http://localhost:5107'
})
```

## Layout Responsivo

A aplicação é responsiva e suporta:
- **Desktop** — sidebar fixa lateral
- **Tablet** — grid adaptado para 2 colunas
- **Mobile** — menu hamburguer com sidebar deslizante
