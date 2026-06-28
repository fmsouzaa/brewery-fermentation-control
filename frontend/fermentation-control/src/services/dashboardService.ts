import api from './api'
import type { Dashboard } from '../types/Dashboard.ts'

// Busca os dados do dashboard
export const getDashboard = () => api.get<Dashboard>('/api/Dashboard')