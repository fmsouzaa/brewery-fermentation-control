import api from './api'
import type { Tank } from '../types/Tank'

// Busca todos os tanques
export const getAllTanks = () => api.get<Tank[]>('/api/Tank')

// Cria um novo tanque
export const createTank = (tank: Omit<Tank, 'id'>) => api.post('/api/Tank', tank)