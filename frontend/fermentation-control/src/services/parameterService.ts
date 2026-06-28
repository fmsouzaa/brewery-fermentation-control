import api from './api'
import type { FermentationParameter } from '../types/FermentationParameter'

// Busca parâmetros por cerveja
export const getParameterByBeerId = (beerId: number) => api.get<FermentationParameter>(`/api/FermentationParameter/${beerId}`)

// Cria parâmetros para uma cerveja
export const createParameter = (parameter: Omit<FermentationParameter, 'id'>) => api.post('/api/FermentationParameter', parameter)