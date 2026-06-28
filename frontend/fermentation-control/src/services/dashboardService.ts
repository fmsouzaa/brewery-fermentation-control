import api from './api'
import type { DashboardData  } from '../types/Dashboard.ts'

// Busca os dados do dashboard
export const getDashboard = () => api.get<DashboardData >('/api/Dashboard')