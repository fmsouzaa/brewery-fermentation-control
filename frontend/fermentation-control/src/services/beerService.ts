import api from './api'
import type { Beer } from '../types/Beer'

// Busca todas as cervejas
export const getAllBeers = () => api.get<Beer[]>('/api/Beer')

// Cria uma nova cerveja
export const createBeer = (beer: Omit<Beer, 'id'>) => api.post('/api/Beer', beer)