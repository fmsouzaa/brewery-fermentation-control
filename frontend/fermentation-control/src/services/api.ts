import axios from 'axios'

// Configuração base do axios com a URL do backend
const api = axios.create({
  baseURL: 'http://localhost:5107'
})

export default api